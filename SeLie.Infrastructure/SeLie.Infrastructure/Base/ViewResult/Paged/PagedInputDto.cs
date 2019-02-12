namespace SeLie.Infrastructure.Base
{
    public class PagedInputDto
    {
        public int PageSize { get; set; } = Constant.DefaultPageSize;

        public int CurrentPage { get; set; } = 1;
    }
}