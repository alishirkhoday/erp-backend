namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class ItemInventory : BaseEntity
    {
        public Guid ItemId { get; private set; }
        public Item Item { get; private set; } = default!;
        public decimal MinimumQuantity { get; private set; }
        public decimal OnHandQuantity { get; private set; }
        public decimal ReservedQuantity { get; private set; }
        public decimal AvailableQuantity => OnHandQuantity - ReservedQuantity;
        public DateTimeOffset LastUpdatedOnHandQuantity { get; private set; }
        public DateTimeOffset LastUpdatedReservedQuantity { get; private set; }

        private ItemInventory()
        {
        }

        public ItemInventory(Item item, decimal minimumQuantity)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(minimumQuantity, nameof(minimumQuantity));
            Item = item;
            ItemId = item.Id;
            MinimumQuantity = minimumQuantity;
        }

        public void Increase(decimal quantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity, nameof(quantity));
            OnHandQuantity += quantity;
            LastUpdatedOnHandQuantity = DateTimeOffset.UtcNow;
        }

        public void Decrease(decimal quantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity, nameof(quantity));
            if (quantity > OnHandQuantity)
                throw new ArgumentException("Insufficient inventory.", nameof(quantity));

            OnHandQuantity -= quantity;
            LastUpdatedOnHandQuantity = DateTimeOffset.UtcNow;
        }

        public void Reserve(decimal quantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity, nameof(quantity));
            if (quantity > AvailableQuantity)
                throw new ArgumentException("Insufficient available inventory for reservation.", nameof(quantity));

            ReservedQuantity += quantity;
            LastUpdatedReservedQuantity = DateTimeOffset.UtcNow;
        }

        public void ReleaseReserved(decimal quantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity, nameof(quantity));
            if (quantity > ReservedQuantity)
                throw new ArgumentException("Release quantity exceeds reserved quantity.", nameof(quantity));

            ReservedQuantity -= quantity;
            LastUpdatedReservedQuantity = DateTimeOffset.UtcNow;
        }

        public void AdjustQuantity(decimal newQuantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(newQuantity, nameof(newQuantity));
            OnHandQuantity = newQuantity;
            LastUpdatedOnHandQuantity = DateTimeOffset.UtcNow;
        }
    }
}
