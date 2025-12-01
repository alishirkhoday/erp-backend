using ERP.Domain.Entities.Modules.InventoryManagement;

namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class BillOfMaterialItem : BaseEntity
    {
        public BillOfMaterials BillOfMaterials { get; private set; } = default!;
        public Item Component { get; private set; } = default!;
        public decimal Quantity { get; private set; }
        public string Unit { get; private set; } = default!;

        public BillOfMaterialItem(BillOfMaterials bom, Item component, decimal quantity, string unit)
        {
            BillOfMaterials = bom;
            Component = component;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
