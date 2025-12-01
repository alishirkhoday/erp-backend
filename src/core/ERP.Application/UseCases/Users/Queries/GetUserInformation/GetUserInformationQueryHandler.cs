using ERP.Domain.Repositories.Users;

namespace ERP.Application.UseCases.Users.Queries.GetUserInformation
{
    public class GetUserInformationQueryHandler(IUserRepository userRepository, IUserProfileRepository userProfileImageRepository)
        : IRequestHandler<GetUserInformationQuery, Result<GetUserInformationResponseDto, Error>>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserProfileRepository _userProfileImageRepository = userProfileImageRepository;

        public async Task<Result<GetUserInformationResponseDto, Error>> Handle(GetUserInformationQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (user is null)
            {
                return Result.Failure<GetUserInformationResponseDto, Error>(Errors.User.UserNotFound());
            }
            var result = new GetUserInformationResponseDto
            {
                Username = user.Username.Value,
                ImageUrlOrPath = await _userProfileImageRepository.GetImageByUserIdAsync(user.Id.ToString(), cancellationToken)
            };
            return Result.Success<GetUserInformationResponseDto, Error>(result);
        }
    }
}
