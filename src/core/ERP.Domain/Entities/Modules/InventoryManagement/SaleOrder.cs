namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class SaleOrder : BaseEntity
    {
        public string Number { get; private set; } = default!;
        public DateTimeOffset OrderDateTime { get; private set; }
        public SaleOrderStatus Status { get; private set; }

        public string? Description { get; private set; }
        public string? Note { get; private set; }

        private readonly List<SaleOrderItem> _items = [];
        public IReadOnlyList<SaleOrderItem> Items => _items;

        private SaleOrder()
        {
        }

        public SaleOrder(string number)
        {
            Number = number;
            OrderDateTime = DateTimeOffset.UtcNow;
            Status = SaleOrderStatus.Draft;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();

        public void AddItem(SaleOrderItem item) => _items.Add(item);
    }
}
