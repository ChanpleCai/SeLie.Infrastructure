namespace SeLie.Infrastructure.Base
{
    public interface IDeletable
    {
        bool Deletable { get; set; }

        bool Deleted { get; set; }
    }
}
