namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class WorkStation : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public string Location { get; private set; } = default!;
        public string? Description { get; private set; }

        public WorkStation(string name, string location, string? description = null)
        {
            Name = name;
            Location = location;
            Description = description;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
