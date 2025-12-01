using ERP.Domain.Entities.Modules.InventoryManagement;

namespace ERP.Domain.Entities.Modules.CustomersRelationshipManagement
{
    public class InvoiceItem : BaseEntity
    {
        public Invoice Invoice { get; private set; } = default!;
        public Item Item { get; private set; } = default!;
        public decimal ItemUnitPrice { get; private set; }
        public double Quantity { get; private set; }
        public decimal Amount => ItemUnitPrice * (decimal)Quantity;
        public decimal Discount { get; private set; }
        public decimal AmountPayable => Amount - Discount;

        private InvoiceItem()
        {
        }

        public InvoiceItem(Invoice invoice, Item item, decimal itemUnitPrice, double quantity, decimal discount)
        {
            ArgumentNullException.ThrowIfNull(invoice, nameof(invoice));
            ArgumentNullException.ThrowIfNull(item, nameof(item));
            Invoice = invoice;
            Item = item;
            ItemUnitPrice = itemUnitPrice;
            Quantity = quantity;
            Discount = discount;
        }
    }
}
