namespace ERP.Domain.Entities.Modules.OrderManagement.ValueObjects
{
    public class ShipToAddress : ValueObject
    {
        public string? Latitude { get; private set; }
        public string? Longitude { get; private set; }
        public string Country { get; } = default!;
        public string Province { get; } = default!;
        public string City { get; } = default!;
        public string Region { get; } = default!;
        public string Street { get; } = default!;
        public string Plaque { get; } = default!;
        public string PostalCode { get; } = default!;
        public string ReceiverFullName { get; } = default!;
        public string ReceiverMobileNumber { get; } = default!;

        private ShipToAddress()
        {
        }

        public ShipToAddress(string country, string province, string city, string region, string street, string plaque, string postalCode, string receiverFullName, string receiverMobileNumber)
        {
            ArgumentException.ThrowIfNullOrEmpty(country, nameof(country));
            ArgumentException.ThrowIfNullOrEmpty(province, nameof(province));
            ArgumentException.ThrowIfNullOrEmpty(city, nameof(city));
            ArgumentException.ThrowIfNullOrEmpty(region, nameof(region));
            ArgumentException.ThrowIfNullOrEmpty(street, nameof(street));
            ArgumentException.ThrowIfNullOrEmpty(plaque, nameof(plaque));
            ArgumentException.ThrowIfNullOrEmpty(postalCode, nameof(postalCode));
            ArgumentException.ThrowIfNullOrEmpty(receiverFullName, nameof(receiverFullName));
            ArgumentException.ThrowIfNullOrEmpty(receiverMobileNumber, nameof(receiverMobileNumber));
            Country = country;
            Province = province;
            City = city;
            Region = region;
            Street = street;
            Plaque = plaque;
            PostalCode = postalCode;
            ReceiverFullName = receiverFullName;
            ReceiverMobileNumber = receiverMobileNumber;
        }

        public void SetGeographicCoordinates(string latitude, string longitude)
        {
            ArgumentException.ThrowIfNullOrEmpty(latitude, nameof(latitude));
            ArgumentException.ThrowIfNullOrEmpty(longitude, nameof(longitude));
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
            yield return Country;
            yield return Province;
            yield return City;
            yield return Region;
            yield return Street;
            yield return Plaque;
            yield return PostalCode;
            yield return ReceiverFullName;
            yield return ReceiverMobileNumber;
        }
    }
}
