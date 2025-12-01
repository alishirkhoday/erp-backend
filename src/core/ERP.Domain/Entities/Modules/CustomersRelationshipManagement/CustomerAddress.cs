namespace ERP.Domain.Entities.Modules.CustomersRelationshipManagement
{
    public class CustomerAddress : BaseEntity
    {
        public Customer Customer { get; private set; } = default!;
        public string? Title { get; private set; }
        public string? Latitude { get; private set; }
        public string? Longitude { get; private set; }
        public string Country { get; private set; } = default!;
        public string Province { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string Region { get; private set; } = default!;
        public string Street { get; private set; } = default!;
        public string PostalCode { get; private set; } = default!;
        public string Plaque { get; private set; } = default!;

        private CustomerAddress()
        {
        }

        public CustomerAddress(Customer customer, string country, string province, string city, string region, string street, string plaque, string postalCode)
        {
            ArgumentNullException.ThrowIfNull(customer, nameof(customer));
            ArgumentException.ThrowIfNullOrEmpty(country, nameof(country));
            ArgumentException.ThrowIfNullOrEmpty(province, nameof(province));
            ArgumentException.ThrowIfNullOrEmpty(city, nameof(city));
            ArgumentException.ThrowIfNullOrEmpty(region, nameof(region));
            ArgumentException.ThrowIfNullOrEmpty(street, nameof(street));
            ArgumentException.ThrowIfNullOrEmpty(plaque, nameof(plaque));
            ArgumentException.ThrowIfNullOrEmpty(postalCode, nameof(postalCode));
            Customer = customer;
            Country = country;
            Province = province;
            City = city;
            Region = region;
            Street = street;
            Plaque = plaque;
            PostalCode = postalCode;
        }

        public void SetTitle(string title)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            Title = title;
        }

        public void SetGeographicCoordinates(string latitude, string longitude)
        {
            ArgumentException.ThrowIfNullOrEmpty(latitude, nameof(latitude));
            ArgumentException.ThrowIfNullOrEmpty(longitude, nameof(longitude));
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
