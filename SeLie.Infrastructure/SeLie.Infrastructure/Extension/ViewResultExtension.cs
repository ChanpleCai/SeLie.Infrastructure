using System;
using SeLie.Infrastructure.Base;

namespace SeLie.Infrastructure
{
    public static partial class Extension
    {
        public static ViewResult Success() => new ViewResult(true);

        public static ViewResult Success(string message) => new ViewResult(true, message);

        public static ViewResult<TResult> Success<TResult>(this TResult view) => new ViewResult<TResult>(true, view);

        public static ViewResult<TResult> Success<TResult>(this TResult view, string message) =>
            new ViewResult<TResult>(true, message, view);

        public static ViewResult Failed() => new ViewResult(false);

        public static ViewResult Failed(string error) => new ViewResult(false, error);

        public static ViewResult Failed(Exception e) => new ViewResult(false, e.Message);

        public static ViewResult<TResult> Failed<TResult>() => new ViewResult<TResult>(false);

        public static ViewResult<TResult> Failed<TResult>(string error) => new ViewResult<TResult>(false, error);

        public static ViewResult<TResult> Failed<TResult>(Exception e) => new ViewResult<TResult>(false, e.Message);

        public static PagedViewResult<TResult, TPagedInputDto> Success<TResult, TPagedInputDto>(
            this PagedViewResult<TResult, TPagedInputDto> result)
            where TPagedInputDto : PagedInputDto =>
            result;

        public static PagedViewResult<TResult, TPagedIntputDto> Success<TResult, TPagedIntputDto>(
            this PagedViewResult<TResult, TPagedIntputDto> result, string message)
            where TPagedIntputDto : PagedInputDto
        {
            result.Message = message;

            return result;
        }

        public static PagedViewResult<TResult, TPagedInputDto> Failed<TResult, TPagedInputDto>()
            where TPagedInputDto : PagedInputDto =>
            new PagedViewResult<TResult, TPagedInputDto>
            {
                Success = false
            };

        public static PagedViewResult<TResult, TPagedInputDto> Failed<TResult, TPagedInputDto>(string message)
            where TPagedInputDto : PagedInputDto =>
            new PagedViewResult<TResult, TPagedInputDto>
            {
                Success = false,
                Message = message
            };

        public static PagedViewResult<TResult, TPagedInputDto> Failed<TResult, TPagedInputDto>(Exception e)
            where TPagedInputDto : PagedInputDto =>
            new PagedViewResult<TResult, TPagedInputDto>
            {
                Success = false,
                Message = e.Message
            };
    }
}