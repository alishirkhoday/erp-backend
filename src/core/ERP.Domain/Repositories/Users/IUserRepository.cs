using ERP.Domain.Entities.Users;

namespace ERP.Domain.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
        Task<User?> GetByMobilePhoneNumberAsync(string mobilePhoneNumberWithRegionCode, CancellationToken cancellationToken = default);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> CheckUserExistsByUsernameAsync(string username, CancellationToken cancellationToken = default);
        Task<bool> CheckUserExistsByMobilePhoneNumberAsync(string mobilePhoneNumberWithRegionCode, CancellationToken cancellationToken = default);
        Task<bool> CheckUserExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
