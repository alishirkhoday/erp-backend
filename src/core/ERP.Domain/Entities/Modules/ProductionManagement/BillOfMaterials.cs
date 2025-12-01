using ERP.Domain.Entities.Modules.InventoryManagement;

namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class BillOfMaterials : BaseEntity
    {
        public Item Item { get; private set; } = default!;
        public string Description { get; private set; } = default!;

        private readonly List<BillOfMaterialItem> _components = [];
        public IReadOnlyList<BillOfMaterialItem> Components => _components;

        public BillOfMaterials(Item item)
        {
            Item = item;
        }

        public void AddComponent(BillOfMaterialItem item)
        {
            _components.Add(item);
        }
    }
}
