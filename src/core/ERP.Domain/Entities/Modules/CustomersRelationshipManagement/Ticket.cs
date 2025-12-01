namespace ERP.Domain.Entities.Modules.CustomersRelationshipManagement
{
    public class Ticket : BaseEntity
    {
        public Customer Customer { get; private set; } = default!;
        public TicketSubject Subject { get; private set; } = default!;
        public TicketStatus Status { get; private set; }
        public DateTimeOffset? ClosedAt { get; private set; }

        private readonly List<TicketMessage> _messages = [];
        public IReadOnlyList<TicketMessage> Messages => _messages;

        private Ticket()
        {
        }

        public Ticket(Customer customer, TicketSubject subject)
        {
            ArgumentNullException.ThrowIfNull(customer, nameof(customer));
            ArgumentNullException.ThrowIfNull(subject, nameof(subject));
            Customer = customer;
            Subject = subject;
            Status = TicketStatus.Open;
        }

        public void ChangeStatus(TicketStatus status) => Status = status;
        public void AddMessage(TicketMessage message) => _messages.Add(message);
    }
}
