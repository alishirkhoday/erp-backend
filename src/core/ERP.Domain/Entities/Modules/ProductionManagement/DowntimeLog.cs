namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class DowntimeLog : BaseEntity
    {
        public Machine Machine { get; private set; } = default!;
        public DateTimeOffset StartTime { get; private set; }
        public DateTimeOffset? EndTime { get; private set; }
        public string Reason { get; private set; } = default!;

        public DowntimeLog(Machine machine, DateTimeOffset startTime, string reason)
        {
            Machine = machine;
            StartTime = startTime;
            Reason = reason;
        }

        public void End(DateTimeOffset endTime)
        {
            EndTime = endTime;
        }
    }
}
