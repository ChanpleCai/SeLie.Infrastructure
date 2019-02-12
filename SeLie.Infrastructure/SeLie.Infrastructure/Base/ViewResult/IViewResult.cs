namespace SeLie.Infrastructure.Base
{
    public interface IViewResult
    {
        bool Success { get; set; }

        string Message { get; set; }
    }

    public interface IViewResult<TClass> : IViewResult
    {
        TClass Result { get; set; }
    }
}
