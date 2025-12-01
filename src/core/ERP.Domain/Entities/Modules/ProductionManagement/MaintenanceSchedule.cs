namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class MaintenanceSchedule : BaseEntity
    {
        public Machine Machine { get; private set; } = default!;
        public DateTimeOffset ScheduledDate { get; private set; }
        public string MaintenanceType { get; private set; } = default!; // Preventive / Corrective
        public string Description { get; private set; } = default!;
        public bool IsCompleted { get; private set; } = false;

        public MaintenanceSchedule(Machine machine, DateTimeOffset scheduledDate, string type, string description)
        {
            Machine = machine;
            ScheduledDate = scheduledDate;
            MaintenanceType = type;
            Description = description;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }
    }
}
