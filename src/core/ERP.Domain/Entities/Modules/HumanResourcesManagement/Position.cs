namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class Position : BaseEntity
    {
        public Department Department { get; private set; } = default!;
        public string Title { get; private set; } = default!;
        public bool IsSystematic { get; private set; }
        public string? Description { get; private set; }

        private Position()
        {
        }

        public Position(Department department, string title, bool isSystematic = false)
        {
            ArgumentNullException.ThrowIfNull(department, nameof(department));
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            Department = department;
            Title = title;
            IsSystematic = isSystematic;
        }

        public void Update(string title)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            Title = title;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
