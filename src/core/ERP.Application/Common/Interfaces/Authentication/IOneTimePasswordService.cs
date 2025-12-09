using ERP.Domain.Entities.Users;

namespace ERP.Application.Common.Interfaces.Authentication
{
    public interface IOneTimePasswordService
    {
        Task<Tuple<string?, bool>> GenerateAsync(string mobilePhoneNumberOrEmail, OneTimePasswordChannel channel, CancellationToken cancellationToken = default);
        Task<OneTimePassword?> GetByMobilePhoneNumberOrEmailAsync(string mobilePhoneNumberOrEmail, CancellationToken cancellationToken = default);
        Task<bool> VerifyAsync(string mobilePhoneNumberOrEmail, string inputCode, CancellationToken cancellationToken = default);
        Task<int?> GetUserOTPCountAsync(string mobilePhoneNumberOrEmail, CancellationToken cancellationToken = default);
    }
}
