namespace ERP.Domain.Entities.Modules.ProductManagement
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
        public Guid? ParentId { get; private set; }
        public Category? Parent { get; private set; }

        private readonly List<Category> _children = [];
        public IReadOnlyList<Category> Children => _children;

        private Category()
        {
        }

        public Category(string name, Category? parent = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
            if (parent is not null)
            {
                Parent = parent;
                ParentId = parent.Id;
            }
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
