using ERP.Domain.Entities.Modules.CustomersRelationshipManagement;

namespace ERP.Domain.Entities.Modules.SaleAndMarketingManagement.NewFolder
{
    public class Opportunity : BaseEntity
    {
        public string Title { get; private set; } = default!;
        public decimal EstimatedValue { get; private set; }
        public DateOnly ExpectedCloseDate { get; private set; }
        public OpportunityStage Stage { get; private set; }
        public Customer? Customer { get; private set; }
        public Lead? SourceLead { get; private set; }

        public Opportunity(string title, decimal estimatedValue, DateOnly expectedCloseDate, Lead? sourceLead = null, Customer? customer = null)
        {
            Title = title;
            EstimatedValue = estimatedValue;
            ExpectedCloseDate = expectedCloseDate;
            Stage = OpportunityStage.InitialContact;
            SourceLead = sourceLead;
            Customer = customer;
        }

        public void AdvanceStage(OpportunityStage stage) => Stage = stage;
    }
}
