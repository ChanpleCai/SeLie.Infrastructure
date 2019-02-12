using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using SeLie.Infrastructure.Base;

namespace SeLie.Infrastructure
{
    public static partial class Extension
    {
        #region EntityBase

        #region Info

        public static bool IsVersion<TEntity>(this TEntity entity, int value) where TEntity : EntityBase => entity.Version.Equals(value);

        public static TEntity SetVersion<TEntity>(this TEntity entity, int value) where TEntity : EntityBase
        {
            if (value <= 0) return entity;

            entity.Version = value;

            return entity;
        }

        public static TEntity UpdateVersion<TEntity>(this TEntity entity) where TEntity : EntityBase
        {
            ++entity.Version;

            return entity;
        }

        public static int GetVersion<TEntity>(this TEntity entity) where TEntity : EntityBase => entity.Version;

        public static bool IsModifiedUser<TEntity>(this TEntity entity, string name) where TEntity : EntityBase =>
            entity.ModifiedUser.ToLower().Equals(name.Trim().ToLower());

        public static TEntity SetModifiedUser<TEntity>(this TEntity entity, string name) where TEntity : EntityBase
        {
            entity.ModifiedUser = name + string.Empty;

            return entity;
        }

        public static string GetModifiedUser<TEntity>(this TEntity entity) where TEntity : EntityBase => entity.ModifiedUser;

        public static TEntity SetModeifiedTime<TEntity>(this TEntity entity, DateTime time) where TEntity : EntityBase
        {
            entity.ModifiedTime = time;

            return entity;
        }

        public static TEntity UpdateModifiedTime<TEntity>(this TEntity entity) where TEntity : EntityBase
        {
            entity.ModifiedTime = DateTime.Now;

            return entity;
        }

        public static DateTime GetModifiedTime<TEntity>(this TEntity entity) where TEntity : EntityBase => entity.ModifiedTime;

        public static TEntity SetInfo<TEntity>(this TEntity entity, string name) where TEntity : EntityBase =>
            entity.SetModifiedUser(name).UpdateModifiedTime().UpdateVersion();

        #endregion


        #region Enabled

        public static List<TEntity> GetEnabled<TEntity>(this IEnumerable<TEntity> entity) where TEntity : EntityBase =>
            entity.Where(_ => _.Enabled).ToList();

        public static bool IsEnabled<TEntity>(this TEntity entity) where TEntity : EntityBase => entity.Enabled;

        public static TEntity Enable<TEntity>(this TEntity entity) where TEntity : EntityBase
        {
            entity.Enabled = true;

            return entity;
        }

        public static TEntity Disable<TEntity>(this TEntity entity) where TEntity : EntityBase
        {
            entity.Enabled = false;

            return entity;
        }

        public static TEntity ReverseEnabled<TEntity>(this TEntity entity) where TEntity : EntityBase
        {
            entity.Enabled = !entity.Enabled;

            return entity;
        }

        #endregion

        #region Order

        public static int GetOrder<TEntity>(this TEntity entity) where TEntity : EntityBase => entity.Order;

        public static TEntity SetOrder<TEntity>(this TEntity entity, int value) where TEntity : EntityBase
        {
            entity.Order = value;

            return entity;
        }

        public static bool IsOrder<TEntity>(this TEntity entity, int value) where TEntity : EntityBase => entity.Order.Equals(value);

        public static List<TEntity> OrderbyOrder<TEntity>(this IEnumerable<TEntity> entity) where TEntity : EntityBase =>
            entity.OrderBy(_ => _.Order).ToList();

        #endregion


        #endregion

        #region IDeletable

        public static bool IsDeleted<TEntity>(this TEntity entity) where TEntity : IDeletable => entity.Deleted;

        public static bool IsDeletable<TEntity>(this TEntity entity) where TEntity : IDeletable => entity.Deletable;


        public static List<TEntity> GetEnabledAndNotDeleted<TEntity>(this IEnumerable<TEntity> entity) where TEntity : EntityBase, IDeletable =>
            entity.Where(_ => _.Enabled && !_.Deleted).ToList();


        public static List<TEntity> GetNotDeleted<TEntity>(this IEnumerable<TEntity> entity) where TEntity : IDeletable =>
            entity.Where(_ => !_.Deleted).ToList();

        public static List<TEntity> TryDelete<TEntity>(this IEnumerable<TEntity> entity) where TEntity : IDeletable =>
            entity.Select(_ => _.TryDelete()).ToList();


        public static TEntity TryDelete<TEntity>(this TEntity entity) where TEntity : IDeletable
        {
            if (entity.Deletable) entity.Deleted = true;

            return entity;
        }

        public static TEntity Delete<TEntity>(this TEntity entity) where TEntity : IDeletable
        {
            entity.Deleted = true;

            return entity;
        }

        public static TEntity UnDelete<TEntity>(this TEntity entity) where TEntity : IDeletable
        {
            entity.Deleted = false;

            return entity;
        }

        public static TEntity Deletable<TEntity>(this TEntity entity) where TEntity : IDeletable
        {
            entity.Deletable = true;

            return entity;
        }

        public static TEntity UnDeletable<TEntity>(this TEntity entity) where TEntity : IDeletable
        {
            entity.Deletable = false;

            return entity;
        }

        public static TEntity ReverseDeleted<TEntity>(this TEntity entity) where TEntity : IDeletable
        {
            entity.Deleted = !entity.Deleted;

            return entity;
        }

        public static TEntity ReverseDeletable<TEntity>(this TEntity entity) where TEntity : IDeletable
        {
            entity.Deletable = !entity.Deletable;

            return entity;
        }


        #endregion

        #region ILevel

        public static int SetLevel<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> e, TPrimaryKey parentId)
            where TEntity : EntityLevelBase, IEntity<TPrimaryKey>
            => e.FirstOrDefault(_ => _.Id.Equals(parentId))?.Level + 1 ?? 1;

        #endregion
    }
}
