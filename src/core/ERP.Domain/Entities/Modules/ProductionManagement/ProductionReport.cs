namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class ProductionReport : BaseEntity
    {
        public ProductionOrder Order { get; private set; } = default!;
        public int ActualQuantityProduced { get; private set; }
        public int ScrapQuantity { get; private set; }
        public string? Notes { get; private set; }

        public ProductionReport(ProductionOrder order, int actualQuantityProduced, int scrapQuantity, string? notes)
        {
            Order = order;
            ActualQuantityProduced = actualQuantityProduced;
            ScrapQuantity = scrapQuantity;
            Notes = notes;
        }
    }
}
