namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class SaleOrderItem : BaseEntity
    {
        public SaleOrder SaleOrder { get; private set; } = default!;
        public Item Item { get; private set; } = default!;
        public decimal Quantity { get; private set; }

        private SaleOrderItem()
        {
        }

        public SaleOrderItem(SaleOrder saleOrder, Item item, decimal quantity)
        {
            ArgumentNullException.ThrowIfNull(saleOrder, nameof(saleOrder));
            ArgumentNullException.ThrowIfNull(item, nameof(item));
            SaleOrder = saleOrder;
            Item = item;
            Quantity = quantity;
        }
    }
}
