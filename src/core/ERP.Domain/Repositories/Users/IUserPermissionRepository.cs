using ERP.Domain.Entities.Users;
using System.Linq.Expressions;

namespace ERP.Domain.Repositories.Users
{
    public interface IUserPermissionRepository : IRepository<UserPermission>
    {
        Task<List<T>> GetPermissionsByUserAsync<T>(User user, Expression<Func<UserPermission, T>> expression, CancellationToken cancellationToken = default);
    }
}
