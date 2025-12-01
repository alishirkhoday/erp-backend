using ERP.Domain.Entities.Modules.FinanceManagement;

namespace ERP.Domain.Repositories.Modules.FinanceManagement
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<bool> IsExistenceByNameAsync(string name, CancellationToken cancellationToken);
        Task<int> GetCountAccountsByAccountTypeAndAccountGroupAsync(AccountType type, AccountGroup group, CancellationToken cancellationToken);
        Task<int> GetCountChildAccountsByAccountIdAsync(Guid parentId, CancellationToken cancellationToken);
    }
}
