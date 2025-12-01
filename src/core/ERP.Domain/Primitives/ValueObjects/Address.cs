namespace ERP.Domain.Primitives.ValueObjects
{
    public class Address : ValueObject
    {
        public string? Latitude { get; private set; }
        public string? Longitude { get; private set; }
        public string Country { get; private set; } = default!;
        public string Province { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string Region { get; private set; } = default!;
        public string Street { get; private set; } = default!;
        public string Plaque { get; private set; } = default!;
        public string PostalCode { get; private set; } = default!;

        private Address()
        {
        }

        public Address(string country, string province, string city, string region, string street, string plaque, string postalCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(country, nameof(country));
            ArgumentException.ThrowIfNullOrEmpty(province, nameof(province));
            ArgumentException.ThrowIfNullOrEmpty(city, nameof(city));
            ArgumentException.ThrowIfNullOrEmpty(region, nameof(region));
            ArgumentException.ThrowIfNullOrEmpty(street, nameof(street));
            ArgumentException.ThrowIfNullOrEmpty(plaque, nameof(plaque));
            ArgumentException.ThrowIfNullOrEmpty(postalCode, nameof(postalCode));
            Country = country;
            Province = province;
            City = city;
            Region = region;
            Street = street;
            Plaque = plaque;
            PostalCode = postalCode;
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
        }
    }
}
