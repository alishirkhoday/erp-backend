using ERP.Domain.Entities.Modules.FinanceManagement;
using ERP.Domain.Repositories.Modules.FinanceManagement;

namespace ERP.Infrastructure.MainDatabase.Repositories.Modules.FinanceManagement
{
    public class AccountRepository(IMainDbContext context) : Repository<Account>(context), IAccountRepository
    {
        public async Task<bool> IsExistenceByNameAsync(string name, CancellationToken cancellationToken)
        {
            var result = await _entity.AnyAsync(e => e.Name == name.Trim(), cancellationToken);
            return result;
        }

        public async Task<int> GetCountAccountsByAccountTypeAndAccountGroupAsync(AccountType type, AccountGroup group, CancellationToken cancellationToken)
        {
            var result = await _entity.Where(a => a.Type == type && a.Group == group).CountAsync(cancellationToken);
            return result;
        }

        public async Task<int> GetCountChildAccountsByAccountIdAsync(Guid parentId, CancellationToken cancellationToken)
        {
            var result = await _entity.Where(a => a.ParentId == parentId).CountAsync(cancellationToken);
            return result;
        }
    }
}
