namespace ERP.Application.UseCases.Users.DTOs
{
    public record SignInDto
    {
        public string Username { get; init; } = default!;
        public string Password { get; init; } = default!;
    }
}
