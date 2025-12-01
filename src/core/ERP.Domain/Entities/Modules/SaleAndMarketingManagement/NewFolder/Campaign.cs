namespace ERP.Domain.Entities.Modules.SaleAndMarketingManagement.NewFolder
{
    public class Campaign : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public string Channel { get; private set; } = default!;
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public decimal Budget { get; private set; }
        public CampaignStatus Status { get; private set; }

        private readonly List<Lead> _leads = [];
        public IReadOnlyList<Lead> Leads => _leads;

        public Campaign(string name, string channel, DateOnly startDate, DateOnly endDate, decimal budget)
        {
            Name = name;
            Channel = channel;
            StartDate = startDate;
            EndDate = endDate;
            Budget = budget;
            Status = CampaignStatus.Planned;
        }

        public void AddLead(Lead lead) => _leads.Add(lead);
    }
}
