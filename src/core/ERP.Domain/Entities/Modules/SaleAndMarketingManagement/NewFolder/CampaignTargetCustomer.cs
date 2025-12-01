using ERP.Domain.Entities.Modules.CustomersRelationshipManagement;

namespace ERP.Domain.Entities.Modules.SaleAndMarketingManagement.NewFolder
{
    public class CampaignTargetCustomer : BaseEntity
    {
        public SalesCampaign Campaign { get; private set; } = default!;
        public Customer Customer { get; private set; } = default!;
    }
}
