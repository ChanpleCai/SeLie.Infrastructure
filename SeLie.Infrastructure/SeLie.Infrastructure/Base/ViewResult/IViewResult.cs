namespace SeLie.Infrastructure.Base
{
    public interface IViewResult
    {
        bool Success { get; set; }

        string Message { get; set; }
    }

    public interface IViewResult<TResult> : IViewResult
    {
        TResult Result { get; set; }
    }
}
