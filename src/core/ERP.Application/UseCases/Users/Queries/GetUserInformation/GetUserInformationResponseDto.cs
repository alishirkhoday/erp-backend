namespace ERP.Application.UseCases.Users.Queries.GetUserInformation
{
    public record GetUserInformationResponseDto
    {
        public string Username { get; init; } = default!;
        public string? ImageUrlOrPath { get; init; }
    }
}
