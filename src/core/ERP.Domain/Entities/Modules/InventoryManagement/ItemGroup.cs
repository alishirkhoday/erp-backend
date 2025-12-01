namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class ItemGroup : BaseEntity
    {
        public string Code { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public bool IsActive { get; private set; }
        public string? Description { get; private set; }

        private readonly List<ItemAttribute> _attributes = [];
        public IReadOnlyList<ItemAttribute> Attributes => _attributes.AsReadOnly();

        private readonly List<Item> _items = [];
        public IReadOnlyList<Item> Items => _items.AsReadOnly();

        private readonly List<ItemUnitOfMeasure> _unitOfMeasures = [];
        public IReadOnlyList<ItemUnitOfMeasure> UnitOfMeasures => _unitOfMeasures.AsReadOnly();

        private ItemGroup()
        {
        }

        public ItemGroup(string code, string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(code, nameof(code));
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Code = code.Trim();
            Name = name.Trim();
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();

        public void AddAttribute(ItemAttribute attribute)
        {
            ArgumentNullException.ThrowIfNull(attribute, nameof(attribute));
            _attributes.Add(attribute);
        }

        public void RemoveAttribute(ItemAttribute attribute)
        {
            ArgumentNullException.ThrowIfNull(attribute, nameof(attribute));
            _attributes.Remove(attribute);
        }
    }
}
