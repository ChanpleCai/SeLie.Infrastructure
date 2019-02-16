using System;

namespace SeLie.Infrastructure.Base
{
    public interface ILevel
    {
        int Level { get; set; }

        Guid ParentId { get; set; }
    }
}
