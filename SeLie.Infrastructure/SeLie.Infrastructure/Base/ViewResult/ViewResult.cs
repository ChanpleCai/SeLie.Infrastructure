namespace SeLie.Infrastructure.Base
{
    public class ViewResult : IViewResult<string>
    {
        public ViewResult(bool success)
        {
            Success = success;
            Message = success ? Constant.Success : Constant.Failed;
        }

        public ViewResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public string Result { get; set; } = "";
    }

    public class ViewResult<TResult> : IViewResult<TResult>
    {
        public ViewResult(bool success, TResult result)
        {
            Success = success;
            Message = success ? Constant.Success : Constant.Failed;
            Result = result;
        }

        public ViewResult(bool success, string message, TResult result)
        {
            Success = success;
            Message = message;
            Result = result;
        }

        public ViewResult(bool success)
        {
            Success = success;
            Message = success ? Constant.Success : Constant.Failed;
            Result = default;
        }

        public ViewResult(bool success, string message)
        {
            Success = success;
            Message = message;
            Result = default;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public TResult Result { get; set; }
    }
}