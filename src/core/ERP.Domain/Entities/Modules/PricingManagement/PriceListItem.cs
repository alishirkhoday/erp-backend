namespace ERP.Domain.Entities.Modules.PricingManagement
{
    public class PriceListItem : BaseEntity
    {
        public Guid ItemId { get; private set; }
        public decimal BasePrice { get; private set; }
        public decimal? DiscountPercent { get; private set; }
        public decimal? TaxPercent { get; private set; }
        public decimal FinalPrice => BasePrice - (DiscountPercent ?? 0) * BasePrice / 100 + (TaxPercent ?? 0) * BasePrice / 100;
    }
}
