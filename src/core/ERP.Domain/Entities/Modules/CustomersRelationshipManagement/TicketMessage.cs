namespace ERP.Domain.Entities.Modules.CustomersRelationshipManagement
{
    public class TicketMessage : BaseEntity
    {
        public Ticket Ticket { get; private set; } = default!;
        public string CreatorId { get; private set; } = default!;
        public TicketMessageCreatorType CreatorType { get; private set; } = default!;
        public string Message { get; private set; } = default!;
        public string? ReplayMessageId { get; private set; }

        private TicketMessage()
        {
        }

        public TicketMessage(Ticket ticket, string message, string? replayMessageId = null)
        {
            ArgumentNullException.ThrowIfNull(ticket, nameof(ticket));
            ArgumentException.ThrowIfNullOrEmpty(message, nameof(message));
            Ticket = ticket;
            Message = message;
            ReplayMessageId = replayMessageId;
        }
    }
}
