namespace SeLie.Infrastructure.Base.Entity
{
    public class EntityDeletableLevelBase : EntityLevelBase, IDeletable
    {
        public virtual bool Deletable { get; set; } = true;

        public virtual bool Deleted { get; set; } = false;
    }
}