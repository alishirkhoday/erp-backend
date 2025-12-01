namespace ERP.Domain.Entities.Modules.SaleAndMarketingManagement
{
    public class Lead : BaseEntity
    {
        public string FullName { get; private set; } = default!;
        public LeadSource Source { get; private set; }
        public string MobilePhoneNumberWithRegionCode { get; private set; } = default!;
        public string? Email { get; private set; }
        public LeadStatus Status { get; private set; }

        private readonly List<LeadNote> _notes = [];
        public IReadOnlyList<LeadNote> Notes => _notes;

        private readonly List<LeadInteraction> _interactions = [];
        public IReadOnlyList<LeadInteraction> Interactions => _interactions;

        private readonly List<LeadOpportunity> _opportunities = [];
        public IReadOnlyList<LeadOpportunity> Opportunities => _opportunities;

        private Lead()
        {
        }

        public Lead(string fullName, LeadSource source, string mobilePhoneNumberWithRegionCode, string? email = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(fullName, nameof(fullName));
            ArgumentException.ThrowIfNullOrEmpty(mobilePhoneNumberWithRegionCode, nameof(mobilePhoneNumberWithRegionCode));
            FullName = fullName;
            Source = source;
            MobilePhoneNumberWithRegionCode = mobilePhoneNumberWithRegionCode;
            Email = email;
            Status = LeadStatus.New;
        }

        public void ChangeStatus(LeadStatus status) => Status = status;
        public void AddInteraction(LeadInteraction interaction) => _interactions.Add(interaction);
        public void AddOpportunity(LeadOpportunity opportunity) => _opportunities.Add(opportunity);
    }
}
