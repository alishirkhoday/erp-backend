namespace ERP.Domain.Entities.Modules.SaleAndMarketingManagement.NewFolder
{
    public class SalesCampaign : BaseEntity
    {
        public string Title { get; private set; } = default!;
        public string? Description { get; private set; }
        public DateTimeOffset StartDate { get; private set; }
        public DateTimeOffset EndDate { get; private set; }
        public CampaignStatus Status { get; private set; }

        private readonly List<CampaignTargetCustomer> _targets = [];
        public IReadOnlyList<CampaignTargetCustomer> Targets => _targets;

        public SalesCampaign(string title, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));
            if (endDate >= startDate)
                throw new ArgumentException("EndDate must be after StartDate");

            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Status = CampaignStatus.Planned;
        }

        public void AddTarget(CampaignTargetCustomer customer)
        {
            _targets.Add(customer);
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
