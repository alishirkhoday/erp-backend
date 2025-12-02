using ERP.Application.Common.Interfaces.Verification;
using ERP.Application.UseCases.Users.Models;
using ERP.Domain.Repositories.Users;

namespace ERP.Application.UseCases.Users.Commands.SendVerificationCode
{
    public sealed class SendVerificationCodeCommandHandler(IUserRepository userRepository, IOTPCodeService otpCodeService)
        : IRequestHandler<SendVerificationCodeCommand, Result<SendVerificationCodeResultDto, Error>>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IOTPCodeService _otpCodeService = otpCodeService;

        public async Task<Result<SendVerificationCodeResultDto, Error>> Handle(SendVerificationCodeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
            if (user is null)
            {
                return Result.Failure<SendVerificationCodeResultDto, Error>(Errors.User.UserNotFound());
            }
            if (!string.IsNullOrEmpty(request.MobilePhoneNumberWithRegionCode))
            {
                if (user.NormalizedMobilePhoneNumber != request.MobilePhoneNumberWithRegionCode)
                {
                    return Result.Failure<SendVerificationCodeResultDto, Error>(Errors.User.ThisMobilePhoneNumberDoesNotMatch());
                }
                var otpCode = await _otpCodeService.GenerateAsync(user.Id.ToString(), OTPCodeChannel.SMS, cancellationToken);
                if (!otpCode.Item2)
                {
                    return Result.Failure<SendVerificationCodeResultDto, Error>(Errors.User.TheNumberOfRequestsForVerificationCodeHasBeenReached());
                }
                //to do : send verification code by mobile phone number
            }
            else if (!string.IsNullOrEmpty(request.Email))
            {
                if (user.NormalizedEmail != request.Email.ToLower().Trim())
                {
                    return Result.Failure<SendVerificationCodeResultDto, Error>(Errors.User.ThisEmailDoesNotMatch());
                }
                var otpCode = await _otpCodeService.GenerateAsync(user.Id.ToString(), OTPCodeChannel.Email, cancellationToken);
                if (!otpCode.Item2)
                {
                    return Result.Failure<SendVerificationCodeResultDto, Error>(Errors.User.TheNumberOfRequestsForVerificationCodeHasBeenReached());
                }
                //to do : send verification code by email
            }
            else
            {
                return Result.Failure<SendVerificationCodeResultDto, Error>(Errors.User.YouMustChooseOneOfTheMethods());
            }
            return Result.Success<SendVerificationCodeResultDto, Error>(new SendVerificationCodeResultDto(user.NormalizedUsername, user.NormalizedMobilePhoneNumber, user.NormalizedEmail));
        }
    }
}
