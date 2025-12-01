namespace ERP.Application.UseCases.Users.DTOs
{
    public record VerificationCodeDto
    {
        public string Username { get; init; } = default!;
        public string? MobilePhoneNumberWithRegionCode { get; init; }
        public string? Email { get; init; }
        public string Code { get; init; } = default!;
    }
}
