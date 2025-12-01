namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class UnitOfMeasure : BaseEntity
    {
        public string Code { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }

        private readonly List<ItemUnitOfMeasure> _itemGroups = [];
        public IReadOnlyList<ItemUnitOfMeasure> ItemGroups => _itemGroups.AsReadOnly();

        private UnitOfMeasure()
        {
        }

        public UnitOfMeasure(string code, string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(code, nameof(code));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Code = code;
            Name = name;
        }

        public void Update(string code, string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(code, nameof(code));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Code = code;
            Name = name;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
