using ERP.Domain.Entities.Modules.CustomersRelationshipManagement;

namespace ERP.Domain.Entities.Modules.SaleAndMarketingManagement.NewFolder
{
    public class Quotation : BaseEntity
    {
        public Customer Customer { get; private set; } = default!;
        public DateTimeOffset IssueDate { get; private set; }
        public DateTimeOffset? ExpiryDate { get; private set; }
        public QuotationStatus Status { get; private set; }

        private readonly List<QuotationItem> _items = [];
        public IReadOnlyList<QuotationItem> Items => _items;

        public Quotation(Customer customer, DateTimeOffset issueDate, DateTimeOffset? expiryDate = null)
        {
            Customer = customer;
            IssueDate = issueDate;
            ExpiryDate = expiryDate;
        }

        public void AddItem(QuotationItem item) => _items.Add(item);
    }
}
