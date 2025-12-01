using ERP.Domain.Entities.Users;

namespace ERP.Domain.Repositories.Users
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        Task<string?> GetImageByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    }
}
