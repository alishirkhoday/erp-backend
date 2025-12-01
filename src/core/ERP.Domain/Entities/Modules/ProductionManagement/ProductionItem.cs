namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class ProductionItem : BaseEntity
    {
        public Guid ProductionOrderId { get; set; }
        public string ProductName { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
