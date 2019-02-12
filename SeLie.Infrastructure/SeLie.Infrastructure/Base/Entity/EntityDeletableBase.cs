namespace SeLie.Infrastructure.Base
{
    public class EntityDeletableBase : EntityBase, IDeletable
    {
        public virtual bool Deletable { get; set; } = true;

        public virtual bool Deleted { get; set; } = false;
    }
}