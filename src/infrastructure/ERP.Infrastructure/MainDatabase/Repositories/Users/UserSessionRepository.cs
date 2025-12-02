using ERP.Application.Common.Interfaces.DbContext;
using ERP.Domain.Entities.Users;
using ERP.Domain.Repositories.Users;

namespace ERP.Infrastructure.MainDatabase.Repositories.Users
{
    public class UserSessionRepository(IMainDbContext context) : Repository<UserSession>(context), IUserSessionRepository
    {
        public async Task<UserSession?> GetByUserAndTokenAsync(User user, string token, CancellationToken cancellationToken = default)
        {
            var result = await _entity.AsQueryable().AsNoTracking()
                .Where(ut => ut.User.Id == user.Id && ut.Token == token)
                .FirstOrDefaultAsync(cancellationToken);
            return result;
        }
    }
}
