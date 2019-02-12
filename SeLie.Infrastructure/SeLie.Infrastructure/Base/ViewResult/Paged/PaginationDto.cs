namespace SeLie.Infrastructure.Base
{
    public class PaginationDto
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int Total { get; set; }
    }
}