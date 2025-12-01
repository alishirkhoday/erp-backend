using ERP.Domain.Entities.Modules.InventoryManagement;

namespace ERP.Domain.Entities.Modules.OrderManagement
{
    public class OrderItem : BaseEntity
    {
        public Order Order { get; private set; } = default!;
        public Item Item { get; private set; } = default!;
        public decimal ItemUnitPrice { get; private set; }
        public double Quantity { get; private set; }
        public decimal Amount => ItemUnitPrice * (decimal)Quantity;
        public decimal Discount { get; private set; }
        public decimal AmountPayable => Amount - Discount;

        private OrderItem()
        {
        }

        public OrderItem(Order order, Item item, decimal itemUnitPrice, double quantity, decimal discount)
        {
            ArgumentNullException.ThrowIfNull(order, nameof(order));
            ArgumentNullException.ThrowIfNull(item, nameof(item));
            Order = order;
            Item = item;
            ItemUnitPrice = itemUnitPrice;
            Quantity = quantity;
            Discount = discount;
        }
    }
}
