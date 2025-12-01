using ERP.Domain.Entities.Modules.OrderManagement;
using ERP.Domain.Entities.Users;

namespace ERP.Domain.Entities.Modules.CustomersRelationshipManagement
{
    public class Customer : BaseEntity
    {
        public Guid UserId { get; private set; } = default!;
        public User User { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public string? Family { get; private set; }
        public CustomerType Type { get; private set; }

        private readonly List<CustomerAddress> _addresses = [];
        public IReadOnlyList<CustomerAddress> Addresses => _addresses;

        private readonly List<Order> _orders = [];
        public IReadOnlyList<Order> Orders => _orders;

        private readonly List<Invoice> _invoices = [];
        public IReadOnlyList<Invoice> Invoices => _invoices;

        private readonly List<Ticket> _tickets = [];
        public IReadOnlyList<Ticket> Tickets => _tickets;

        //Note : SubCustomer

        private Customer()
        {
        }

        /// <summary>
        /// If the customer is the individual, use this sample.
        /// </summary>
        public Customer(User user, string name, string family)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            ArgumentException.ThrowIfNullOrEmpty(family, nameof(family));
            User = user;
            UserId = user.Id;
            Name = name;
            Family = family;
            Type = CustomerType.Individual;
        }

        /// <summary>
        /// If the customer is the organization, use this sample.
        /// </summary>
        public Customer(User user, string fullName)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));
            ArgumentException.ThrowIfNullOrEmpty(fullName, nameof(fullName));
            User = user;
            UserId = user.Id;
            Name = fullName;
            Type = CustomerType.Organization;
        }

        /// <summary>
        /// If the customer is the individual, use this sample.
        /// </summary>
        public void Update(string name, string family)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            ArgumentException.ThrowIfNullOrEmpty(family, nameof(family));
            Name = name;
            Family = family;
        }

        /// <summary>
        /// If the customer is the organization, use this sample.
        /// </summary>
        public void Update(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
        }

        public void AddAddress(CustomerAddress address) => _addresses.Add(address);
        public void AddOrder(Order order) => _orders.Add(order);
        public void AddInvoice(Invoice invoice) => _invoices.Add(invoice);
        public void AddTicket(Ticket ticket) => _tickets.Add(ticket);
    }
}
