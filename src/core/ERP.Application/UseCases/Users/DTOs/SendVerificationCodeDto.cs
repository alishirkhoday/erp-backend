namespace ERP.Application.UseCases.Users.DTOs
{
    public record SendVerificationCodeDto
    {
        public string Username { get; init; } = default!;
        public string? MobilePhoneNumberWithRegionCode { get; init; }
        public string? Email { get; init; }
    }
}
