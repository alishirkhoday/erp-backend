using ERP.Domain.Entities.Modules.HumanResourcesManagement;
using ERP.Domain.Repositories.Modules.HumanResourcesManagement;

namespace ERP.Infrastructure.MainDatabase.Repositories.Modules.HumanResourcesManagement
{
    public class HumanRepository(IMainDbContext context) : Repository<Human>(context), IHumanRepository
    {
        public async Task<bool> IsExistenceByNatioanlIdAsync(string natioanlId, CancellationToken cancellationToken = default)
        {
            var result = await _entity.AnyAsync(h => h.NationalId.Value == natioanlId, cancellationToken);
            return result;
        }

        public async Task<bool> IsExistenceByPassportIdAsync(string passportId, CancellationToken cancellationToken = default)
        {
            var result = await _entity.AnyAsync(h => h.PassportId.Value == passportId, cancellationToken);
            return result;
        }
    }
}
