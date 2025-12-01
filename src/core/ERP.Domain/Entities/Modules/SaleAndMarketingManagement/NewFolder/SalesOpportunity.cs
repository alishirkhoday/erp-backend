using ERP.Domain.Entities.Modules.CustomersRelationshipManagement;

namespace ERP.Domain.Entities.Modules.SaleAndMarketingManagement.NewFolder
{
    public class SalesOpportunity : BaseEntity
    {
        public string Title { get; private set; } = default!;
        public Customer? Customer { get; private set; }
        public Lead? Lead { get; private set; }
        public OpportunityStage Stage { get; private set; }
        public decimal EstimatedValue { get; private set; }
        public DateTimeOffset? ExpectedCloseDate { get; private set; }

        public SalesOpportunity(string title, decimal estimatedValue, OpportunityStage stage, Lead? lead = null, Customer? customer = null)
        {
            Title = title;
            EstimatedValue = estimatedValue;
            Stage = stage;
            Lead = lead;
            Customer = customer;
        }

        public void UpdateStage(OpportunityStage stage)
        {
            Stage = stage;
        }
    }
}
