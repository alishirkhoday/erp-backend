using ERP.Application.Common.Interfaces.Authentication;
using ERP.Domain.Entities.Users;

namespace ERP.Application.UseCases.UsersManagement.Authentication.SendVerificationCode
{
    public sealed class SendVerificationCodeCommandHandler(IOneTimePasswordService otpCodeService)
        : IRequestHandler<SendVerificationCodeCommand, Result<string, Error>>
    {
        private readonly IOneTimePasswordService _otpCodeService = otpCodeService;

        public async Task<Result<string, Error>> Handle(SendVerificationCodeCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.MobilePhoneNumberWithRegionCode))
            {
                var otpCode = await _otpCodeService.GenerateAsync(request.MobilePhoneNumberWithRegionCode, OneTimePasswordChannel.SMS, cancellationToken);
                if (!otpCode.Item2)
                {
                    return Result.Failure<string, Error>(Errors.User.TheNumberOfRequestsForVerificationCodeHasBeenReached());
                }
                //to do : send verification code by mobile phone number
            }
            else if (!string.IsNullOrEmpty(request.Email))
            {
                var otpCode = await _otpCodeService.GenerateAsync(request.Email, OneTimePasswordChannel.Email, cancellationToken);
                if (!otpCode.Item2)
                {
                    return Result.Failure<string, Error>(Errors.User.TheNumberOfRequestsForVerificationCodeHasBeenReached());
                }
                //to do : send verification code by email
            }
            else
            {
                return Result.Failure<string, Error>(Errors.User.YouMustChooseOneOfTheMethods());
            }
            return Result.Success<string, Error>("Verification Code Sent");
        }
    }
}
