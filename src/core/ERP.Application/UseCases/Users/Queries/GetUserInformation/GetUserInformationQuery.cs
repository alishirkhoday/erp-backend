namespace ERP.Application.UseCases.Users.Queries.GetUserInformation
{
    public record GetUserInformationQuery : IRequest<Result<GetUserInformationResponseDto, Error>>
    {
        public string UserId { get; init; } = default!;
    }
}
