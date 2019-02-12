using System;
using System.Collections.Generic;

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
                throw new ArgumentNullException(nameof(obj), $"Please make sure argument {typeof(TObject)} is not null");
        }

        #endregion

        #region Enum

        public static TEnum AddFlag<TEnum>(this TEnum e, TEnum flag) where TEnum : Enum =>
            (TEnum)Enum.ToObject(typeof(TEnum), Convert.ToInt32(e) | Convert.ToInt32(flag));


        public static TEnum RemoveFlag<TEnum>(this TEnum e, TEnum flag) where TEnum : Enum =>
            (TEnum)Enum.ToObject(typeof(TEnum), Convert.ToInt32(e) & ~Convert.ToInt32(flag));


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
    }
}
