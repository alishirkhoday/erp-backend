using ERP.Application.Common.Interfaces.DbContext;
using ERP.Application.Common.Security;
using ERP.Application.UseCases.UsersManagement.Authentication.SendVerificationCode;
using ERP.Domain.Entities.Users;
using ERP.Domain.Repositories.Users;
using System.Text;

namespace ERP.Application.UseCases.UsersManagement.Authentication.SignUp
{
    public sealed class SignUpCommandHandler(IMainDbContext context, IUserRepository userRepository, IMediator mediator)
        : IRequestHandler<SignUpCommand, Result<SignUpResultDto, Error>>
    {
        private readonly IMainDbContext _context = context;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMediator _mediator = mediator;

        public async Task<Result<SignUpResultDto, Error>> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var isExitsUsername = await _userRepository.CheckUserExistsByUsernameAsync(request.Username, cancellationToken);
            if (isExitsUsername)
            {
                return Result.Failure<SignUpResultDto, Error>(Errors.User.UsernameIsUsed(request.Username));
            }
            var newUser = new User(request.Username, request.Password.HashPassword());
            await _userRepository.CreateAsync(newUser, cancellationToken);
            int resultSaveChanges;
            if (!string.IsNullOrEmpty(request.MobilePhoneNumberRegionCode) && !string.IsNullOrEmpty(request.MobilePhoneNumber))
            {
                var mobilePhoneNumberWithRegionCode = new StringBuilder(request.MobilePhoneNumberRegionCode).Append(request.MobilePhoneNumber).ToString();
                var isExitsMobilePhoneNumber = await _userRepository.CheckUserExistsByMobilePhoneNumberAsync(mobilePhoneNumberWithRegionCode, cancellationToken);
                if (isExitsMobilePhoneNumber)
                {
                    return Result.Failure<SignUpResultDto, Error>(Errors.User.MobilePhoneNumberIsUsed(mobilePhoneNumberWithRegionCode));
                }
                newUser.SetMobilePhoneNumber(request.MobilePhoneNumberRegionCode, request.MobilePhoneNumber);
                resultSaveChanges = await _context.SaveChanges(cancellationToken);
                if (resultSaveChanges <= 0)
                {
                    return Result.Failure<SignUpResultDto, Error>(Errors.General.NotSavedChanges());
                }
                var sendVerificationCodeCommand = new SendVerificationCodeCommand()
                {
                    UserId = newUser.Id.ToString(),
                    MobilePhoneNumberWithRegionCode = newUser.NormalizedMobilePhoneNumber
                };
                var result = await _mediator.Send(sendVerificationCodeCommand, cancellationToken);
                if (!result.IsSuccess)
                {
                    return Result.Failure<SignUpResultDto, Error>(Errors.User.ErrorForSendVerificationCode());
                }
            }
            else if (!string.IsNullOrEmpty(request.Email))
            {
                var isExitsEmail = await _userRepository.CheckUserExistsByEmailAsync(request.Email, cancellationToken);
                if (isExitsEmail)
                {
                    return Result.Failure<SignUpResultDto, Error>(Errors.User.EmailIsUsed(request.Email));
                }
                newUser.SetEmail(request.Email);
                resultSaveChanges = await _context.SaveChanges(cancellationToken);
                if (resultSaveChanges <= 0)
                {
                    return Result.Failure<SignUpResultDto, Error>(Errors.General.NotSavedChanges());
                }
                var sendVerificationCodeCommand = new SendVerificationCodeCommand()
                {
                    UserId = newUser.Id.ToString(),
                    Email = newUser.NormalizedEmail
                };
                var result = await _mediator.Send(sendVerificationCodeCommand, cancellationToken);
                if (!result.IsSuccess)
                {
                    return Result.Failure<SignUpResultDto, Error>(Errors.User.ErrorForSendVerificationCode());
                }
            }
            else
            {
                return Result.Failure<SignUpResultDto, Error>(Errors.User.YouMustChooseOneOfTheRegistrationMethods());
            }
            return Result.Success<SignUpResultDto, Error>(new SignUpResultDto(newUser.NormalizedUsername, newUser.NormalizedMobilePhoneNumber, newUser.NormalizedEmail));
        }
    }
}
