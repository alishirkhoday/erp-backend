namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class ItemUnitOfMeasure : BaseEntity
    {
        public Guid ItemGroupId { get; private set; }
        public ItemGroup ItemGroup { get; private set; } = default!;
        public Guid UnitOfMeasureId { get; private set; }
        public UnitOfMeasure UnitOfMeasure { get; private set; } = default!;

        private ItemUnitOfMeasure()
        {
        }

        public ItemUnitOfMeasure(ItemGroup itemGroup, UnitOfMeasure unitOfMeasure)
        {
            ArgumentNullException.ThrowIfNull(itemGroup, nameof(itemGroup));
            ArgumentNullException.ThrowIfNull(unitOfMeasure, nameof(unitOfMeasure));

            ItemGroup = itemGroup;
            ItemGroupId = itemGroup.Id;
            UnitOfMeasure = unitOfMeasure;
            UnitOfMeasureId = unitOfMeasure.Id;
        }
    }
}
