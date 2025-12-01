namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class QualityControlCheck : BaseEntity
    {
        public ProductionTask Task { get; private set; } = default!;
        public DateTimeOffset CheckedAt { get; private set; } = DateTimeOffset.UtcNow;
        public string InspectorName { get; private set; } = default!;
        public bool Passed { get; private set; }
        public string? Notes { get; private set; }

        public QualityControlCheck(ProductionTask task, string inspectorName, bool passed, string? notes = null)
        {
            Task = task;
            InspectorName = inspectorName;
            Passed = passed;
            Notes = notes;
        }
    }
}
