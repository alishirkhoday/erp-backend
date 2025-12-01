namespace ERP.Domain.Entities.Modules.SaleAndMarketingManagement
{
    public class LeadInteraction : BaseEntity
    {
        public Lead Lead { get; private set; } = default!;
        public string Subject { get; private set; } = default!;
        public LeadInteractionType Type { get; private set; }
        public string Note { get; private set; } = default!;
        public string Description { get; private set; } = default!;

        private LeadInteraction()
        {
        }

        public LeadInteraction(Lead customer, string subject, LeadInteractionType type, string note, string description)
        {
            ArgumentNullException.ThrowIfNull(customer, nameof(customer));
            ArgumentException.ThrowIfNullOrEmpty(subject, nameof(subject));
            ArgumentException.ThrowIfNullOrEmpty(note, nameof(note));
            ArgumentException.ThrowIfNullOrEmpty(description, nameof(description));
            Lead = customer;
            Subject = subject;
            Type = type;
            Note = note;
            Description = description;
        }
    }
}
