using Microsoft.EntityFrameworkCore;

namespace SmartschoolApi.Helpers
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 0;
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PageList(List<T> items, int currentPage, int pageSize, int totalItems)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(Count / (double)pageSize);
            this.AddRange(items);
        }

        public static PageList<T> CreateAsync(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();

            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
