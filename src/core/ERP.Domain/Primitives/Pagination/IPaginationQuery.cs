namespace ERP.Domain.Primitives.Pagination
{
    public interface IPaginationQuery
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
