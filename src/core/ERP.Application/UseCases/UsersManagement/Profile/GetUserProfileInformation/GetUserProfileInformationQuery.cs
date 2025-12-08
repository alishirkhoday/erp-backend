namespace ERP.Application.UseCases.UsersManagement.Profile.GetUserProfileInformation
{
    public record GetUserProfileInformationQuery : IRequest<Result<GetUserProfileInformationResponseDto, Error>>
    {
        public string UserId { get; init; } = default!;
    }
}
