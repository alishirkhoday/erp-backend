using ERP.Domain.Entities.Modules.HumanResourcesManagement;

namespace ERP.Domain.Repositories.Modules.HumanResourcesManagement
{
    public interface IHumanRepository : IRepository<Human>
    {
        Task<bool> IsExistenceByNatioanlIdAsync(string natioanlId, CancellationToken cancellationToken = default);
        Task<bool> IsExistenceByPassportIdAsync(string passportId, CancellationToken cancellationToken = default);
    }
}
