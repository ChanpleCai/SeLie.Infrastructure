using System;
using Abp.Domain.Entities;

namespace SeLie.Infrastructure.Base
{
    public class EntityBase : Entity<Guid>
    {
        public virtual string Name { get; set; } = "";

        public virtual bool Enabled { get; set; } = true;

        public virtual DateTime ModifiedTime { get; set; } = DateTime.Now;

        public virtual string ModifiedUser { get; set; } = "";

        public virtual int Version { get; set; } = 1;

        public virtual int Order { get; set; } = 1;
    }
}