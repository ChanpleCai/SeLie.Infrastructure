﻿using System;

namespace SeLie.Infrastructure.Base
{
    public class EntityLevelBase : EntityBase, ILevel
    {
        public virtual int Level { get; set; } = 1;

        public virtual Guid ParentId { get; set; } = Guid.Empty;
    }
}