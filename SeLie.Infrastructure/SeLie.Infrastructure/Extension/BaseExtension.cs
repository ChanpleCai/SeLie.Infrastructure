﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SeLie.Infrastructure
{
    public static partial class Extension
    {
        #region Object

        public static void CheckNotNull<TObject>(this TObject obj)
        {
#pragma warning disable IDE0041 // Use 'is null' check
            if (ReferenceEquals(obj, null))
#pragma warning restore IDE0041 // Use 'is null' check
                throw new ArgumentNullException(nameof(obj),
                    $"Please make sure argument {typeof(TObject)} is not null");
        }

        #endregion

        #region Enum

        public static TEnum AddFlag<TEnum>(this TEnum e, TEnum flag) where TEnum : Enum =>
            (TEnum) Enum.ToObject(typeof(TEnum), Convert.ToInt32(e) | Convert.ToInt32(flag));


        public static TEnum RemoveFlag<TEnum>(this TEnum e, TEnum flag) where TEnum : Enum =>
            (TEnum) Enum.ToObject(typeof(TEnum), Convert.ToInt32(e) & ~Convert.ToInt32(flag));

        public static bool IsNotSingleFlag<TEnum>(this TEnum e) where TEnum : Enum
        {
            int a = Convert.ToInt32(e);
            return a == 0 || (a & (a - 1)) != 0;
        }

        public static IEnumerable<TEnum> GetFlags<TEnum>(this TEnum e) where TEnum : Enum
        {
            foreach (TEnum t in Enum.GetValues(typeof(TEnum)))
                if (e.HasFlag(t))
                    yield return t;
        }

        public static void CheckSingleFlag<TEnum>(this TEnum e) where TEnum : Enum
        {
            if (e.IsNotSingleFlag())
                throw new ArgumentException($"You can only add single {typeof(TEnum)} value at a time.", nameof(e));
        }

        #endregion

        #region SafeTrim

        public static string SafeTrim(this string str) => string.IsNullOrWhiteSpace(str) ? "" : str.Trim();

        public static TObject SafeTrim<TObject>(this TObject obj) where TObject : class
        {
            foreach (var val in obj.GetType().GetProperties().Where(_ => _.PropertyType == typeof(string)))
                val.SetValue(obj, (val.GetValue(obj) as string).SafeTrim());

            return obj;
        }

        public static TObject DeciamlTrim<TObject>(this TObject obj)
        {
            foreach (var val in obj.GetType().GetProperties().Where(_ => _.PropertyType == typeof(decimal)))
                val.SetValue(obj, Convert.ToDecimal(val.GetValue(obj)).Normalize());

            return obj;
        }


        // https://stackoverflow.com/questions/4298719/parse-decimal-and-filter-extra-0-on-the-right
        public static decimal Normalize(this decimal value) => value / 1.0000_0000_0000_0000_0000_0000_0000m;

        #endregion
    }
}