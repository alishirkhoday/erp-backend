namespace ERP.Domain.Entities.Modules.PricingManagement
{
    public class PriceList : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public DateOnly EffectiveDate { get; private set; }
        public string Currency { get; private set; } = "IRR";
        public bool IsActive { get; private set; }

        private readonly List<PriceListItem> _items = [];
        public IReadOnlyList<PriceListItem> Items => _items;
    }
}
