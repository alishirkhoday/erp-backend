namespace ERP.Domain.Entities.Modules.OrderManagement
{
    public class OrderShipmentStatusHistory : BaseEntity
    {
        public Order Order { get; private set; } = default!;
        public OrderShipmentStatus Status { get; private set; }
        public DateTimeOffset ChangedDateTime { get; private set; }

        private OrderShipmentStatusHistory()
        {
        }

        public OrderShipmentStatusHistory(Order order, OrderShipmentStatus status)
        {
            ArgumentNullException.ThrowIfNull(order, nameof(order));
            Order = order;
            Status = status;
            ChangedDateTime = DateTimeOffset.UtcNow;
        }
    }
}
