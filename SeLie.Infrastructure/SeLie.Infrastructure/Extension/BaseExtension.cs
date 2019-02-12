using System;
using System.Collections.Generic;

namespace SeLie.Infrastructure
{
    public static partial class Extension
    {
        #region Object

        public static void CheckNotNull<T>(this T e)
        {
#pragma warning disable IDE0041 // Use 'is null' check
            if (ReferenceEquals(e, null))
#pragma warning restore IDE0041 // Use 'is null' check
                throw new ArgumentNullException(nameof(e), $"Please make sure argument {typeof(T)} is not null");
        }

        #endregion

        #region Enum

        public static T AddFlag<T>(this T e, T flag) where T : Enum =>
            (T)Enum.ToObject(typeof(T), Convert.ToInt32(e) | Convert.ToInt32(flag));


        public static T RemoveFlag<T>(this T e, T flag) where T : Enum =>
            (T)Enum.ToObject(typeof(T), Convert.ToInt32(e) & ~Convert.ToInt32(flag));


        public static bool IsNotSingleFlag<T>(this T e) where T : Enum
        {
            int a = Convert.ToInt32(e);
            return a == 0 || (a & (a - 1)) != 0;
        }


        public static IEnumerable<T> GetFlags<T>(this T e) where T : Enum
        {
            foreach (T t in Enum.GetValues(typeof(T)))
                if (e.HasFlag(t))
                    yield return t;
        }


        public static void CheckSingleFlag<T>(this T e) where T : Enum
        {
            if (e.IsNotSingleFlag())
                throw new ArgumentException($"You can only add single {typeof(T)} value at a time.", nameof(e));
        }

        #endregion
    }
}
