using ERP.Domain.Entities.Modules.InventoryManagement;

namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class ProductionBatch : BaseEntity
    {
        public string BatchCode { get; private set; } = default!;
        public Item Item { get; private set; } = default!;
        public int Quantity { get; private set; }
        public DateTimeOffset StartDate { get; private set; }
        public DateTimeOffset? EndDate { get; private set; }
        public string? Notes { get; private set; }

        public ProductionBatch(string batchCode, Item item, int quantity, DateTimeOffset startDate, string? notes = null)
        {
            BatchCode = batchCode;
            Item = item;
            Quantity = quantity;
            StartDate = startDate;
            Notes = notes;
        }

        public void EndBatch(DateTimeOffset endDate)
        {
            EndDate = endDate;
        }
    }
}
