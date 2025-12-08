using ERP.Domain.Entities.Users;

namespace ERP.Application.Common.Interfaces.Authentication
{
    public interface IOneTimePasswordService
    {
        Task<Tuple<string?, bool>> GenerateAsync(string userId, OneTimePasswordChannel channel, CancellationToken cancellationToken = default);
        Task<OneTimePassword?> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
        Task<bool> VerifyAsync(string userId, string inputCode, CancellationToken cancellationToken = default);
        Task<int?> GetUserOTPCountAsync(string userId, CancellationToken cancellationToken = default);
    }
}
