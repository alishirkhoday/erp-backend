using ERP.Domain.Entities.Users;

namespace ERP.Domain.Repositories.Users
{
    public interface IUserSessionRepository : IRepository<UserSession>
    {
        Task<UserSession?> GetByUserAndTokenAsync(User user, string token, CancellationToken cancellationToken = default);
    }
}
