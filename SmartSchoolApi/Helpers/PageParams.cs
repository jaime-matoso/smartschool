namespace SmartschoolApi.Helpers
{
    public class PageParams
    {
        public int MaxPageSize { get; set; } = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

    }
}
