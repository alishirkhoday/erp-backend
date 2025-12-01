namespace ERP.Domain.Entities.Modules.SaleAndMarketingManagement
{
    public class LeadOpportunity : BaseEntity
    {
        public Lead Lead { get; private set; } = default!;
        public string Title { get; private set; } = default!;
        public decimal EstimatedValue { get; private set; }
        public LeadOpportunityStatus Status { get; private set; }
        public DateTimeOffset ExpectedCloseDate { get; private set; }

        private LeadOpportunity()
        {
        }

        public LeadOpportunity(Lead lead, string title, decimal estimatedValue, DateTimeOffset expectedCloseDate)
        {
            ArgumentNullException.ThrowIfNull(lead, nameof(lead));
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            Lead = lead;
            Title = title;
            EstimatedValue = estimatedValue;
            ExpectedCloseDate = expectedCloseDate;
            Status = LeadOpportunityStatus.Prospect;
        }

        public void ChangeStatus(LeadOpportunityStatus status) => Status = status;
    }
}
