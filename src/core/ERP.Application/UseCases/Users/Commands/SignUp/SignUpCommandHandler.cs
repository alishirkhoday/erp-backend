using ERP.Domain.Entities.Users;
using ERP.Domain.Repositories.Users;
using System.Text;

namespace ERP.Application.UseCases.Users.Commands.SignUp
{
    public sealed class SignUpCommandHandler(IMainDbContext context, IUserRepository userRepository)
        : BaseCommandHandler(context), IRequestHandler<SignUpCommand, Result<SignUpResultDto, Error>>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Result<SignUpResultDto, Error>> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var isExitsUsername = await _userRepository.CheckUserExistsByUsernameAsync(request.Username, cancellationToken);
            if (isExitsUsername)
            {
                return Result.Failure<SignUpResultDto, Error>(Errors.User.UsernameIsUsed(request.Username));
            }
            var newUser = new User(request.Username, request.Password.Hash());
            await _userRepository.CreateAsync(newUser, cancellationToken);
            if (!string.IsNullOrEmpty(request.MobilePhoneNumberRegionCode) && !string.IsNullOrEmpty(request.MobilePhoneNumber))
            {
                var mobilePhoneNumber = new StringBuilder(request.MobilePhoneNumberRegionCode).Append(request.MobilePhoneNumber).ToString();
                var isExitsMobilePhoneNumber = await _userRepository.CheckUserExistsByMobilePhoneNumberAsync(mobilePhoneNumber, cancellationToken);
                if (isExitsMobilePhoneNumber)
                {
                    return Result.Failure<SignUpResultDto, Error>(Errors.User.MobilePhoneNumberIsUsed(mobilePhoneNumber));
                }
                newUser.SetMobilePhoneNumber(request.MobilePhoneNumberRegionCode, request.MobilePhoneNumber);
            }
            else if (!string.IsNullOrEmpty(request.Email))
            {
                var isExitsEmail = await _userRepository.CheckUserExistsByEmailAsync(request.Email, cancellationToken);
                if (isExitsEmail)
                {
                    return Result.Failure<SignUpResultDto, Error>(Errors.User.EmailIsUsed(request.Email));
                }
                newUser.SetEmail(request.Email);
            }
            else
            {
                return Result.Failure<SignUpResultDto, Error>(Errors.User.YouMustChooseOneOfTheRegistrationMethods());
            }
            var resultSaveChanges = await _context.SaveChanges(cancellationToken);
            if (resultSaveChanges <= 0)
            {
                return Result.Failure<SignUpResultDto, Error>(Errors.General.NotSavedChanges());
            }
            return Result.Success<SignUpResultDto, Error>(new SignUpResultDto(newUser.NormalizedUsername, newUser.NormalizedMobilePhoneNumber, newUser.NormalizedEmail));
        }
    }
}
