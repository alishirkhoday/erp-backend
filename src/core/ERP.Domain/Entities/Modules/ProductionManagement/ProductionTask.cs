namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class ProductionTask : BaseEntity
    {
        public ProductionOrder Order { get; private set; } = default!;
        public string Title { get; private set; } = default!;
        public WorkStation WorkStation { get; private set; } = default!;
        public DateTimeOffset? StartTime { get; private set; }
        public DateTimeOffset? EndTime { get; private set; }
        public ProductionTaskStatus Status { get; private set; } = ProductionTaskStatus.Pending;

        public ProductionTask(ProductionOrder order, string title, WorkStation workStation)
        {
            Order = order;
            Title = title;
            WorkStation = workStation;
        }

        public void Start()
        {
            Status = ProductionTaskStatus.InProgress;
            StartTime = DateTimeOffset.UtcNow;
        }

        public void Complete()
        {
            Status = ProductionTaskStatus.Completed;
            EndTime = DateTimeOffset.UtcNow;
        }
    }
}
