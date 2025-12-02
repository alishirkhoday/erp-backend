using ERP.Application.UseCases.Users.Models;

namespace ERP.Application.Common.Interfaces.Verification
{
    public interface IOTPCodeService
    {
        Task<Tuple<string?, bool>> GenerateAsync(string userId, OTPCodeChannel channel, CancellationToken cancellationToken = default);
        Task<OTPCode?> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
        Task<bool> VerifyAsync(string userId, string inputCode, CancellationToken cancellationToken = default);
        Task<int?> GetUserCodesCountAsync(string userId, CancellationToken cancellationToken = default);
    }
}
