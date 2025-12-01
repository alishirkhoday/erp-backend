using ERP.Domain.Entities.Modules.OrderManagement.ValueObjects;

namespace ERP.Domain.Entities.Modules.OrderManagement
{
    public class Payment : BaseEntity
    {
        public Order Order { get; private set; } = default!;
        public PaymentStatus Status { get; private set; }
        public PaymentMethod Method { get; private set; }
        public DateTimeOffset? PaymentDateTime { get; private set; }
        public decimal? AmountPaid { get; private set; }
        public PaymentGatewayInformation PaymentGatewayInformation { get; private set; } = default!;

        private Payment()
        {
        }

        public Payment(Order order, PaymentMethod method, decimal amountPaid)
        {
            ArgumentNullException.ThrowIfNull(order, nameof(order));
            Order = order;
            Method = method;
            AmountPaid = amountPaid;
            Status = PaymentStatus.Pending;
        }

        public void SetPaymentGatewayInformation(PaymentGatewayInformation paymentGatewayInformation) => PaymentGatewayInformation = paymentGatewayInformation;
    }
}
