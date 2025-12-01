namespace ERP.Domain.Entities.Modules.OrderManagement.ValueObjects
{
    public class PaymentGatewayInformation : ValueObject
    {
        public string? Name { get; }
        public string? Domain { get; }
        public string? TrackingCode { get; }

        private PaymentGatewayInformation()
        {
        }

        public PaymentGatewayInformation(string name, string domain, string trackingCode)
        {
            Name = name;
            Domain = domain;
            TrackingCode = trackingCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Domain;
            yield return Name;
            yield return TrackingCode;
        }
    }
}
