namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class ItemAttribute : BaseEntity
    {
        public Guid GroupId { get; private set; }
        public ItemGroup Group { get; private set; } = default!;
        public string Title { get; private set; } = default!;
        public bool IsBoolean { get; private set; }
        public string? Description { get; private set; }

        private readonly List<ItemAttributeValue> _values = [];
        public IReadOnlyList<ItemAttributeValue> Values => _values.AsReadOnly();

        private readonly List<ItemSpecification> _specifications = [];
        public IReadOnlyList<ItemSpecification> Specifications => _specifications.AsReadOnly();

        private ItemAttribute()
        {
        }

        public ItemAttribute(ItemGroup group, string title, bool isBoolean)
        {
            ArgumentNullException.ThrowIfNull(group, nameof(group));
            ArgumentException.ThrowIfNullOrWhiteSpace(title, nameof(title));
            Group = group;
            GroupId = group.Id;
            Title = title.Trim();
            IsBoolean = isBoolean;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();

        public void AddValue(ItemAttributeValue value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _values.Add(value);
        }

        public void RemoveValue(ItemAttributeValue value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _values.Remove(value);
        }
    }
}
