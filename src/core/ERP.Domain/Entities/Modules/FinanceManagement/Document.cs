namespace ERP.Domain.Entities.Modules.FinanceManagement
{
    public class Document : BaseEntity
    {
        public FinancialYear FinancialYear { get; private set; } = default!;
        public string Title { get; private set; } = default!;
        public DateTimeOffset FinancialEventDateTime { get; private set; }
        public string Description { get; private set; } = default!;
        public DocumentType Type { get; private set; }
        public DocumentStatus Status { get; private set; }
        public bool IsAutomatic { get; private set; }

        private readonly List<DocumentItem> _items = [];
        public IReadOnlyList<DocumentItem> Items => _items;

        private Document()
        {
        }

        public Document(FinancialYear financialYear, string title, DateTimeOffset financialEventDateTime, string description, DocumentType type, bool isAutomatic = false)
        {
            ArgumentNullException.ThrowIfNull(financialYear, nameof(financialYear));
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            ArgumentException.ThrowIfNullOrEmpty(description, nameof(description));
            FinancialYear = financialYear;
            Title = title;
            FinancialEventDateTime = financialEventDateTime;
            Description = description;
            Type = type;
            Status = DocumentStatus.Draft;
            IsAutomatic = isAutomatic;
        }

        public void Update(string title, DateTimeOffset financialEventDateTime, string description, DocumentType type)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            ArgumentException.ThrowIfNullOrEmpty(description, nameof(description));
            Title = title;
            FinancialEventDateTime = financialEventDateTime;
            Description = description;
            Type = type;
        }

        public void ChangeStatus(DocumentStatus status) => Status = status;
        public void AddItem(DocumentItem item) => _items.Add(item);

        public bool IsBalanced()
        {
            var debitTotal = _items.Sum(l => l.Debtor);
            var creditTotal = _items.Sum(l => l.Creditor);
            return debitTotal == creditTotal;
        }
    }
}
