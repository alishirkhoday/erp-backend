namespace ERP.Domain.Entities.Modules.InventoryManagement
{
    public class UnitOfMeasureConversion : BaseEntity
    {
        public Guid FromUnit { get; private set; } = default!;
        public Guid ToUnit { get; private set; } = default!;
        public decimal Factor { get; private set; }
        public string? Description { get; private set; }

        private UnitOfMeasureConversion()
        {
        }

        public UnitOfMeasureConversion(Guid fromUnit, Guid toUnit, decimal factor)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(factor, nameof(factor));
            FromUnit = fromUnit;
            ToUnit = toUnit;
            Factor = factor;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
