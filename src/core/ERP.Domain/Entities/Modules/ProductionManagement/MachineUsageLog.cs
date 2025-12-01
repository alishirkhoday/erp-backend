namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class MachineUsageLog : BaseEntity
    {
        public Machine Machine { get; private set; } = default!;
        public ProductionTask Task { get; private set; } = default!;
        public DateTimeOffset StartTime { get; private set; }
        public DateTimeOffset? EndTime { get; private set; }
        public string? Notes { get; private set; }

        public MachineUsageLog(Machine machine, ProductionTask task, DateTimeOffset startTime, string? notes = null)
        {
            Machine = machine;
            Task = task;
            StartTime = startTime;
            Notes = notes;
        }

        public void End(DateTimeOffset endTime)
        {
            EndTime = endTime;
        }
    }
}
