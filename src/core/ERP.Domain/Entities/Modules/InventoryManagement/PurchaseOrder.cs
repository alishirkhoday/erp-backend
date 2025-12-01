namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class PurchaseOrder : BaseEntity
    {
        public string Number { get; private set; } = default!;
        public DateTimeOffset OrderDateTime { get; private set; }
        public PurchaseOrderStatus Status { get; private set; }

        public string? Description { get; private set; }
        public string? Note { get; private set; }

        private readonly List<PurchaseOrderItem> _items = [];
        public IReadOnlyList<PurchaseOrderItem> Items => _items;

        private PurchaseOrder()
        {
        }

        public PurchaseOrder(string number)
        {
            Number = number;
            OrderDateTime = DateTimeOffset.UtcNow;
            Status = PurchaseOrderStatus.Draft;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();

        public void AddItem(PurchaseOrderItem item) => _items.Add(item);
    }
}
