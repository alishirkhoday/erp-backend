namespace ERP.Domain.Primitives.Pagination
{
    public class PaginatedItems<T> where T : class
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public long TotalCount { get; private set; }
        public IEnumerable<T> Items { get; private set; }

        public PaginatedItems(int pageNumber, int pageSize, long totalCount, IEnumerable<T> items)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            Items = items;
        }
    }
}
