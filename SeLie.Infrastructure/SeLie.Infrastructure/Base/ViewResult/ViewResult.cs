namespace SeLie.Infrastructure.Base
{
    public class ViewResult : IViewResult<string>
    {
        private const string Succ = "Success!";

        private const string Fail = "Failed!";

        public ViewResult(bool success)
        {
            Success = success;
            Message = success ? Succ : Fail;
        }

        public ViewResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public string Result { get; set; } = string.Empty;
    }

    public class ViewResult<T> : IViewResult<T>
    {

        private const string Succ = "Success!";

        private const string Fail = "Failed!";

        public ViewResult(bool success, T result)
        {
            Success = success;
            Message = success ? Succ : Fail;
            Result = result;
        }

        public ViewResult(bool success, string message, T result)
        {
            Success = success;
            Message = message;
            Result = result;
        }

        public ViewResult(bool success)
        {
            Success = success;
            Message = success ? Succ : Fail;
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

        public T Result { get; set; }
    }

}
