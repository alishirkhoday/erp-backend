using ERP.Application.Common.Interfaces.DbContext;
using ERP.Domain.Entities.Users;
using ERP.Domain.Entities.Users.Normalization;
using ERP.Domain.Repositories.Users;

namespace ERP.Infrastructure.MainDatabase.Repositories.Users
{
    public class UserRepository(IMainDbContext context) : Repository<User>(context), IUserRepository
    {
        public async Task<bool> CheckUserExistsByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            var result = await _entity.AnyAsync(u => u.NormalizedUsername == username.ToNormalization(), cancellationToken);
            return result;
        }

        public async Task<bool> CheckUserExistsByMobilePhoneNumberAsync(string mobilePhoneNumberWithRegionCode, CancellationToken cancellationToken = default)
        {
            var result = await _entity.AnyAsync(u => u.NormalizedMobilePhoneNumber == mobilePhoneNumberWithRegionCode, cancellationToken);
            return result;
        }

        public async Task<bool> CheckUserExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var result = await _entity.AnyAsync(u => u.NormalizedEmail == email.ToNormalization(), cancellationToken);
            return result;
        }

        public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            var result = await _entity.FirstOrDefaultAsync(u => u.NormalizedUsername == username.ToNormalization(), cancellationToken);
            return result;
        }

        public async Task<User?> GetByMobilePhoneNumberAsync(string mobilePhoneNumberWithRegionCode, CancellationToken cancellationToken = default)
        {
            var result = await _entity.FirstOrDefaultAsync(u => u.NormalizedMobilePhoneNumber == mobilePhoneNumberWithRegionCode, cancellationToken);
            return result;
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var result = await _entity.FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToNormalization(), cancellationToken);
            return result;
        }
    }
}
