using ERP.Application.Common.Interfaces.DbContext;
using ERP.Domain.Entities.Users;
using ERP.Domain.Repositories.Users;
using System.Linq.Expressions;

namespace ERP.Infrastructure.MainDatabase.Repositories.Users
{
    public class UserPermissionRepository(IMainDbContext context) : Repository<UserPermission>(context), IUserPermissionRepository
    {
        public async Task<List<T>> GetPermissionsByUserAsync<T>(User user, Expression<Func<UserPermission, T>> expression, CancellationToken cancellationToken = default)
        {
            var result = await _entity.AsQueryable().AsNoTracking()
                .Where(up => up.User.Id == user.Id)
                .Select(expression)
                .ToListAsync(cancellationToken);
            return result;
        }
    }
}
