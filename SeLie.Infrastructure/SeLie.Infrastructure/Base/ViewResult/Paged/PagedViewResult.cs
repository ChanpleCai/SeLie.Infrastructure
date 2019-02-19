using System.Collections.Generic;
using System.Linq;

namespace SeLie.Infrastructure.Base
{
    public class PagedViewResult<TResult, TPagedInputDto> : IViewResult<List<TResult>>
        where TPagedInputDto : PagedInputDto
    {
        public PagedViewResult()
        {
        }

        public PagedViewResult(IQueryable<TResult> input, TPagedInputDto pagedInputDto)
        {
            Pagination = new PaginationDto
            {
                CurrentPage = pagedInputDto.CurrentPage,
                PageSize = pagedInputDto.PageSize,
                Total = input.Count()
            };

            Result = input.Skip((pagedInputDto.CurrentPage - 1) * pagedInputDto.PageSize).Take(pagedInputDto.PageSize)
                .ToList();
        }

        public PaginationDto Pagination { get; set; }

        public List<TResult> Result { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; }
    }
}