namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class ProductionSchedule : BaseEntity
    {
        public ProductionOrder Order { get; private set; } = default!;
        public WorkStation WorkStation { get; private set; } = default!;
        public DateTimeOffset ScheduledStart { get; private set; }
        public DateTimeOffset ScheduledEnd { get; private set; }

        public ProductionSchedule(ProductionOrder order, WorkStation workStation, DateTimeOffset scheduledStart, DateTimeOffset scheduledEnd)
        {
            Order = order;
            WorkStation = workStation;
            ScheduledStart = scheduledStart;
            ScheduledEnd = scheduledEnd;
        }
    }
}
