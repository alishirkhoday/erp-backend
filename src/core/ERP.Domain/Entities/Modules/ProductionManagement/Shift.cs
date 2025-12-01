namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class Shift : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public string? Description { get; private set; }

        public Shift(string name, TimeSpan startTime, TimeSpan endTime, string? description = null)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Description = description;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
