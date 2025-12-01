namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class Department : BaseEntity
    {
        public string Code { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public bool IsSystematic { get; private set; }
        public string? Description { get; private set; }
        public Guid? ParentId { get; private set; }
        public Department? Parent { get; private set; }

        private readonly List<Department> _children = [];
        public IReadOnlyList<Department> Children => _children;

        private readonly List<Position> _positions = [];
        public IReadOnlyList<Position> Positions => _positions;

        private Department()
        {
        }

        public Department(string code, string name, Department? parent = null, bool isSystematic = false)
        {
            ArgumentException.ThrowIfNullOrEmpty(code, nameof(code));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Code = code;
            Name = name;
            if (parent is not null)
            {
                Parent = parent;
                ParentId = parent.Id;
            }
            IsSystematic = isSystematic;
        }

        public void Update(string code, string name, Department? parent = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(code, nameof(code));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Code = code;
            Name = name;
            if (parent is not null)
            {
                Parent = parent;
                ParentId = parent.Id;
            }
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();

        public void AddPosition(Position position) => _positions.Add(position);
    }
}
