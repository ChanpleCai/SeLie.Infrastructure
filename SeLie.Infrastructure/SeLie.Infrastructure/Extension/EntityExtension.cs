using System;
using System.Collections.Generic;
using System.Linq;
using SeLie.Infrastructure.Base;

namespace SeLie.Infrastructure
{
    public static partial class Extension
    {
        #region EntityBase

        #region Info

        public static bool IsVersion<T>(this T t, int value) where T : EntityBase => t.Version.Equals(value);

        public static T SetVersion<T>(this T t, int value) where T : EntityBase
        {
            if (value <= 0) return t;

            t.Version = value;

            return t;
        }

        public static T UpdateVersion<T>(this T t) where T : EntityBase
        {
            ++t.Version;

            return t;
        }

        public static int GetVersion<T>(this T t) where T : EntityBase => t.Version;

        public static bool IsModifiedUser<T>(this T t, string name) where T : EntityBase =>
            t.ModifiedUser.ToLower().Equals(name.Trim().ToLower());

        public static T SetModifiedUser<T>(this T t, string name) where T : EntityBase
        {
            t.ModifiedUser = name + string.Empty;

            return t;
        }

        public static string GetModifiedUser<T>(this T t) where T : EntityBase => t.ModifiedUser;

        public static T SetModeifiedTime<T>(this T t, DateTime time) where T : EntityBase
        {
            t.ModifiedTime = time;

            return t;
        }

        public static T UpdateModifiedTime<T>(this T t) where T : EntityBase
        {
            t.ModifiedTime = DateTime.Now;

            return t;
        }

        public static DateTime GetModifiedTime<T>(this T t) where T : EntityBase => t.ModifiedTime;

        public static T SetInfo<T>(this T t, string name) where T : EntityBase =>
            t.SetModifiedUser(name).UpdateModifiedTime().UpdateVersion();

        #endregion


        #region Enabled

        public static List<T> GetEnabled<T>(this IEnumerable<T> t) where T : EntityBase =>
            t.Where(_ => _.Enabled).ToList();

        public static bool IsEnabled<T>(this T t) where T : EntityBase => t.Enabled;

        public static T Enable<T>(this T t) where T : EntityBase
        {
            t.Enabled = true;

            return t;
        }

        public static T Disable<T>(this T t) where T : EntityBase
        {
            t.Enabled = false;

            return t;
        }

        public static T ReverseEnabled<T>(this T t) where T : EntityBase
        {
            t.Enabled = !t.Enabled;

            return t;
        }

        #endregion

        #region Order

        public static int GetOrder<T>(this T t) where T : EntityBase => t.Order;

        public static T SetOrder<T>(this T t, int value) where T : EntityBase
        {
            t.Order = value;

            return t;
        }

        public static bool IsOrder<T>(this T t, int value) where T : EntityBase => t.Order.Equals(value);

        public static List<T> OrderbyOrder<T>(this IEnumerable<T> t) where T : EntityBase =>
            t.OrderBy(_ => _.Order).ToList();

        #endregion


        #endregion

        #region IDeletable

        public static bool IsDeleted<T>(this T t) where T : IDeletable => t.Deleted;

        public static bool IsDeletable<T>(this T t) where T : IDeletable => t.Deletable;


        public static List<T> GetEnabledAndNotDeleted<T>(this IEnumerable<T> t) where T : EntityBase, IDeletable =>
            t.Where(_ => _.Enabled && !_.Deleted).ToList();


        public static List<T> GetNotDeleted<T>(this IEnumerable<T> t) where T : IDeletable =>
            t.Where(_ => !_.Deleted).ToList();

        public static List<T> TryDelete<T>(this IEnumerable<T> e) where T : IDeletable =>
            e.Select(_ => _.TryDelete()).ToList();


        public static T TryDelete<T>(this T t) where T : IDeletable
        {
            if (t.Deletable) t.Deleted = true;

            return t;
        }

        public static T Delete<T>(this T t) where T : IDeletable
        {
            t.Deleted = true;

            return t;
        }

        public static T UnDelete<T>(this T t) where T : IDeletable
        {
            t.Deleted = false;

            return t;
        }

        public static T Deletable<T>(this T t) where T : IDeletable
        {
            t.Deletable = true;

            return t;
        }

        public static T UnDeletable<T>(this T t) where T : IDeletable
        {
            t.Deletable = false;

            return t;
        }

        public static T ReverseDeleted<T>(this T t) where T : IDeletable
        {
            t.Deleted = !t.Deleted;

            return t;
        }

        public static T ReverseDeletable<T>(this T t) where T : IDeletable
        {
            t.Deletable = !t.Deletable;

            return t;
        }


        #endregion
    }
}
