namespace ERP.Application.UseCases.UsersManagement.Authentication.Verify
{
    public record VerifyDto
    {
        public string Username { get; init; } = default!;
        public string? MobilePhoneNumberWithRegionCode { get; init; }
        public string? Email { get; init; }
        public string Code { get; init; } = default!;
    }
}
