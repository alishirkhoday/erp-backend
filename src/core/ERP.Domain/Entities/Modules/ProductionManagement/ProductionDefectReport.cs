namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class ProductionDefectReport : BaseEntity
    {
        public ProductionTask Task { get; private set; } = default!;
        public string DefectType { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public int Quantity { get; private set; }
        public DateTimeOffset ReportedAt { get; private set; } = DateTimeOffset.UtcNow;

        public ProductionDefectReport(ProductionTask task, string defectType, string description, int quantity)
        {
            Task = task;
            DefectType = defectType;
            Description = description;
            Quantity = quantity;
        }
    }
}
