namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class Machine : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public string Model { get; private set; } = default!;
        public string SerialNumber { get; private set; } = default!;
        public string Location { get; private set; } = default!;
        public string? Description { get; private set; }

        public Machine(string name, string model, string serialNumber, string location, string? description = null)
        {
            Name = name;
            Model = model;
            SerialNumber = serialNumber;
            Location = location;
            Description = description;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
