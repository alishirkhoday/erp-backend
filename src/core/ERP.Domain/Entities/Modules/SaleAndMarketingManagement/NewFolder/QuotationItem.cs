using ERP.Domain.Entities.Modules.InventoryManagement;

namespace ERP.Domain.Entities.Modules.SaleAndMarketingManagement.NewFolder
{
    public class QuotationItem : BaseEntity
    {
        public Quotation Quotation { get; private set; } = default!;
        public Item Item { get; private set; } = default!;
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal DiscountPercent { get; private set; }

        public QuotationItem(Quotation quotation, Item item, int quantity, decimal unitPrice, decimal discount)
        {
            Quotation = quotation;
            Item = item;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
        }

        public decimal Total => Quantity * UnitPrice * (1 - DiscountPercent / 100);
    }
}
