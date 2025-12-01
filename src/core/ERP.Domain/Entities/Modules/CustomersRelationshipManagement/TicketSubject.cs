namespace ERP.Domain.Entities.Modules.CustomersRelationshipManagement
{
    public class TicketSubject : BaseEntity
    {
        public string Title { get; private set; } = default!;

        private TicketSubject()
        {
        }

        public TicketSubject(string title)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            Title = title;
        }

        public void Update(string title)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            Title = title;
        }
    }
}
