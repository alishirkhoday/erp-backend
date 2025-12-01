namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class Item : BaseEntity
    {
        public Guid GroupId { get; private set; }
        public ItemGroup Group { get; private set; } = default!;
        public ItemType Type { get; private set; }
        public string? StockKeepingUnit { get; private set; }
        public string? Name { get; private set; }
        public string? BarCode { get; private set; }
        public string? QRCode { get; private set; }
        public string? Description { get; private set; }
        public bool IsActive { get; private set; }

        private readonly List<ItemSpecification> _specifications = [];
        public IReadOnlyList<ItemSpecification> Specifications => _specifications.AsReadOnly();

        private Item()
        {
        }

        public Item(ItemGroup group, ItemType type)
        {
            ArgumentNullException.ThrowIfNull(group, nameof(group));
            Group = group;
            GroupId = group.Id;
            Type = type;
        }

        public void Update(string sku, string name, string? barCode = null, string? qrCode = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(sku, nameof(sku));
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            StockKeepingUnit = sku.Trim();
            Name = name.Trim();
            BarCode = barCode?.Trim();
            QRCode = qrCode?.Trim();
        }

        public void SetActive() => IsActive = true;
        public void SetDeactive() => IsActive = false;
        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();

        public void AddSpecification(ItemSpecification specification)
        {
            ArgumentNullException.ThrowIfNull(specification, nameof(specification));
            _specifications.Add(specification);
        }

        public void RemoveSpecification(ItemSpecification specification)
        {
            ArgumentNullException.ThrowIfNull(specification, nameof(specification));
            _specifications.Remove(specification);
        }

        public void RemoveAllSpecifications()
        {
            _specifications.Clear();
        }
    }
}
