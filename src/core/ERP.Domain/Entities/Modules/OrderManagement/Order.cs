using ERP.Domain.Entities.Modules.CustomersRelationshipManagement;
using ERP.Domain.Entities.Modules.OrderManagement.ValueObjects;

namespace ERP.Domain.Entities.Modules.OrderManagement
{
    public class Order : BaseEntity
    {
        public Customer Customer { get; private set; } = default!;
        public string Code { get; private set; } = default!;
        public DateTimeOffset RegistrationDateTime { get; private set; }
        public DateTimeOffset TimeLeftToPayment { get; private set; }
        public OrderStatus Status { get; private set; }
        public ShipToAddress ShipToAddress { get; private set; } = default!;
        public decimal OrderSendCostAmount { get; private set; } = default!;
        public decimal TotalAmount => Items.Sum(i => i.Amount);
        public decimal TotalDiscounts => Items.Sum(i => i.Discount);
        public decimal AmountPayable => Items.Sum(i => i.AmountPayable);

        private readonly List<OrderItem> _items = [];
        public IReadOnlyList<OrderItem> Items => _items;

        private readonly List<Payment> _payments = [];
        public IReadOnlyList<Payment> Payments => _payments;

        private readonly List<OrderShipmentStatusHistory> _shipmentStatusHistories = [];
        public IReadOnlyList<OrderShipmentStatusHistory> ShipmentStatusHistories => _shipmentStatusHistories;

        private Order()
        {
        }

        public Order(Customer customer, string code)
        {
            ArgumentNullException.ThrowIfNull(customer, nameof(customer));
            ArgumentException.ThrowIfNullOrEmpty(code, nameof(code));
            Customer = customer;
            Code = code;
            RegistrationDateTime = DateTimeOffset.UtcNow;
            Status = OrderStatus.Pending;
        }

        public void SetTimeLeftToPayment(int timeLeftToPayment)
        {
            TimeLeftToPayment = RegistrationDateTime.AddMinutes(timeLeftToPayment);
        }

        public void SetItems(List<OrderItem> items)
        {
            if (items.Count > 0)
            {
                items.ForEach(c => _items.Add(new OrderItem(this, c.Item, c.ItemUnitPrice, c.Quantity, c.Discount)));
            }
        }

        public void AddAddress(ShipToAddress shipToAddress) => ShipToAddress = shipToAddress;
        public void AddPayment(Payment payment) => _payments.Add(payment);
        public void AddShipmentStatusHistory(OrderShipmentStatusHistory shipmentStatusHistory) => _shipmentStatusHistories.Add(shipmentStatusHistory);
    }
}
