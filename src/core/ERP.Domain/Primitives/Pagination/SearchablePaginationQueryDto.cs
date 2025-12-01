namespace ERP.Domain.Primitives.Pagination
{
    public record SearchablePaginationQueryDto : IPaginationQuery
    {
        public string? SearchValue { get; set; }

        private int _pageSize;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value < 1 || value > 50 ? 10 : value;
            }
        }

        private int _pageNumber;
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value < 1 ? 1 : value;
            }
        }
    }
}
