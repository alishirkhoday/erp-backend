using ERP.Application.Common.Interfaces.DbContext;
using ERP.Application.Common.Interfaces.Verification;
using ERP.Domain.Repositories.Users;

namespace ERP.Application.UseCases.Users.Commands.VerificationCode
{
    public sealed class VerificationCodeCommandHandler(IMainDbContext context, IUserRepository userRepository, IOTPCodeService otpCodeService)
        : IRequestHandler<VerificationCodeCommand, Result<string, Error>>
    {
        private readonly IMainDbContext _context = context;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IOTPCodeService _otpCodeService = otpCodeService;

        public async Task<Result<string, Error>> Handle(VerificationCodeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
            if (user is null)
            {
                return Result.Failure<string, Error>(Errors.User.UserNotFound());
            }
            var ver = await _otpCodeService.VerifyAsync(user.Id.ToString(), request.Code, cancellationToken);
            var otpCode = await _otpCodeService.GetByUserIdAsync(user.Id.ToString(), cancellationToken);
            if (otpCode is null)
            {
                return Result.Failure<string, Error>(Errors.User.VerificationCodeIsNotValid());
            }
            if (otpCode.Code != request.Code)
            {
                return Result.Failure<string, Error>(Errors.User.VerificationCodeIsNotValid());
            }
            if (!string.IsNullOrEmpty(request.MobilePhoneNumberWithRegionCode))
            {
                if (user.NormalizedMobilePhoneNumber != request.MobilePhoneNumberWithRegionCode)
                {
                    return Result.Failure<string, Error>(Errors.User.ThisMobilePhoneNumberDoesNotMatch());
                }
                user.ConfirmMobilePhoneNumber();
            }
            else if (!string.IsNullOrEmpty(request.Email))
            {
                if (user.NormalizedEmail != request.Email.ToLower().Trim())
                {
                    return Result.Failure<string, Error>(Errors.User.ThisEmailDoesNotMatch());
                }
                user.ConfirmEmail();
            }
            else
            {
                return Result.Failure<string, Error>(Errors.User.YouMustChooseOneOfTheMethods());
            }
            user.Active();
            var resultSaveChanges = await _context.SaveChanges(cancellationToken);
            if (resultSaveChanges <= 0)
            {
                return Result.Failure<string, Error>(Errors.General.NotSavedChanges());
            }
            return Result.Success<string, Error>(user.NormalizedUsername);
        }
    }
}
