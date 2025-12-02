using ERP.Application.Common.Interfaces.Authentication;
using ERP.Application.Common.Interfaces.DbContext;
using ERP.Application.Common.Security;
using ERP.Domain.Entities.Users;
using ERP.Domain.Repositories.Users;

namespace ERP.Application.UseCases.Users.Commands.SignIn
{
    public sealed class SignInCommandHandler(IMainDbContext context, IUserRepository userRepository, IUserSessionRepository userSessionRepository, ITokenService tokenService)
        : IRequestHandler<SignInCommand, Result<string, Error>>
    {
        private readonly IMainDbContext _context = context;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserSessionRepository _userSessionRepository = userSessionRepository;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<Result<string, Error>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
            if (user is null)
            {
                return Result.Failure<string, Error>(Errors.User.UserNotFound());
            }
            if (user.Status == UserStatus.Inactive)
            {
                return Result.Failure<string, Error>(Errors.User.UserIsNotActive());
            }
            if (user.Status == UserStatus.Ban)
            {
                return Result.Failure<string, Error>(Errors.User.UserIsBan());
            }
            if (user.LockoutEnabled && user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.UtcNow)
            {
                return Result.Failure<string, Error>(Errors.User.UserAccountIsLocked(DateTimeOffset.UtcNow.ToHourMinuteDifference(user.LockoutEnd.Value)));
            }
            if (PasswordHashService.VerifyPassword(user.Password.Value, request.Password))
            {
                user.HandleAccessFailed();
                //_resultSaveChanges = await _context.SaveChanges(cancellationToken);
                //if (_resultSaveChanges <= 0)
                //{
                //    return Result.Failure<string, Error>(Errors.General.NotSavedChanges());
                //}
                return Result.Failure<string, Error>(Errors.User.PasswordIsWrong());
            }
            var tokenExpireDate = DateTimeOffset.UtcNow.AddHours(12);
            var token = _tokenService.GenerateJsonWebToken(user, tokenExpireDate);
            if (token is null)
            {
                return Result.Failure<string, Error>(Errors.General.AnErrorHasOccurred());
            }
            var session = new UserSession(user, token.HashSha256(), tokenExpireDate, request.InternetProtocol, request.DeviceName, request.OperatingSystem);
            await _userSessionRepository.CreateAsync(session, cancellationToken);
            user.ResetLockout();
            var resultSaveChanges = await _context.SaveChanges(cancellationToken);
            if (resultSaveChanges <= 0)
            {
                return Result.Failure<string, Error>(Errors.General.NotSavedChanges());
            }
            return Result.Success<string, Error>(token);
        }
    }
}
