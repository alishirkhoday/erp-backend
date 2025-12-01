namespace ERP.Domain.Entities.Modules.CustomersRelationshipManagement
{
    public class Invoice : BaseEntity
    {
        public Customer Customer { get; private set; } = default!;
        public string Number { get; private set; } = default!;
        public InvoiceType Type { get; private set; }
        public DateTimeOffset RegistrationDateTime { get; private set; }
        public decimal TotalAmount => Items.Sum(i => i.Amount);
        public decimal TotalDiscounts => Items.Sum(i => i.Discount);
        public decimal AmountPayable => Items.Sum(i => i.AmountPayable);

        private readonly List<InvoiceItem> _items = [];
        public IReadOnlyList<InvoiceItem> Items => _items;

        private Invoice()
        {
        }

        public Invoice(Customer customer, string number, InvoiceType type)
        {
            ArgumentNullException.ThrowIfNull(customer, nameof(customer));
            ArgumentException.ThrowIfNullOrEmpty(number, nameof(number));
            Customer = customer;
            Number = number;
            RegistrationDateTime = DateTimeOffset.UtcNow;
            Type = type;
        }

        public void SetItems(List<InvoiceItem> items)
        {
            if (items.Count > 0)
            {
                items.ForEach(c => _items.Add(new InvoiceItem(this, c.Item, c.ItemUnitPrice, c.Quantity, c.Discount)));
            }
        }
    }
}
