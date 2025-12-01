namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class PurchaseOrderItem : BaseEntity
    {
        public PurchaseOrder PurchaseOrder { get; private set; } = default!;
        public Item Item { get; private set; } = default!;
        public decimal Quantity { get; private set; }

        private PurchaseOrderItem()
        {
        }

        public PurchaseOrderItem(PurchaseOrder purchaseOrder, Item item, decimal quantity, string? note = null)
        {
            ArgumentNullException.ThrowIfNull(purchaseOrder, nameof(purchaseOrder));
            ArgumentNullException.ThrowIfNull(item, nameof(item));
            PurchaseOrder = purchaseOrder;
            Item = item;
            Quantity = quantity;
        }
    }
}
