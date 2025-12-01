namespace ERP.Domain.Entities.Modules.InventoryManagement.NewFolder
{
    public class ItemBatch : BaseEntity
    {
        //public Item Item { get; private set; } = default!;
        public string BatchNumber { get; private set; } = default!;
        public DateOnly ProductionDate { get; private set; }
        public DateOnly? ExpirationDate { get; private set; }
        public decimal InitialQuantity { get; private set; }
        public decimal RemainingQuantity { get; private set; }

        public ItemBatch()
        {
        }

        public ItemBatch(Item item, string batchNumber, DateOnly productionDate, decimal initialQty, DateOnly? expiration = null)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));
            //Item = item;
            BatchNumber = batchNumber;
            ProductionDate = productionDate;
            ExpirationDate = expiration;
            InitialQuantity = initialQty;
            RemainingQuantity = initialQty;
        }

        public void Consume(decimal qty)
        {
            if (qty > RemainingQuantity)
                throw new InvalidOperationException("Not enough quantity in batch.");
            RemainingQuantity -= qty;
        }
    }
}
