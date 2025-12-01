namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class ItemAttributeValue : BaseEntity
    {
        public Guid AttributeId { get; private set; }
        public ItemAttribute Attribute { get; private set; } = default!;
        public string Value { get; private set; } = default!;
        public string? Description { get; private set; }

        private readonly List<ItemSpecification> _specifications = [];
        public IReadOnlyList<ItemSpecification> Specifications => _specifications.AsReadOnly();

        private ItemAttributeValue()
        {
        }

        public ItemAttributeValue(ItemAttribute attribute, string value)
        {
            ArgumentNullException.ThrowIfNull(attribute, nameof(attribute));
            ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));

            Attribute = attribute;
            AttributeId = attribute.Id;
            Value = value.Trim();
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
