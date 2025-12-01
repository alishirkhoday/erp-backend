using ERP.Domain.Entities.Modules.InventoryManagement;

namespace ERP.Domain.Entities.Modules.WarehouseManagement
{
    public class WarehouseTransactionItem : BaseEntity
    {
        public Guid TransactionId { get; private set; }
        public WarehouseTransaction Transaction { get; private set; } = default!;
        public Guid ItemId { get; private set; }
        public Item Item { get; private set; } = default!;
        public decimal Quantity { get; private set; }

        private WarehouseTransactionItem()
        {
        }

        public WarehouseTransactionItem(WarehouseTransaction transaction, Item item, decimal quantity)
        {
            ArgumentNullException.ThrowIfNull(transaction, nameof(transaction));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity, nameof(quantity));
            Transaction = transaction;
            TransactionId = transaction.Id;
            Item = item;
            ItemId = item.Id;
            Quantity = quantity;
        }
    }
}
