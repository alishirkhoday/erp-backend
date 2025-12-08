namespace ERP.Application.UseCases.UsersManagement.Authentication.SendVerificationCode
{
    public record SendVerificationCodeDto
    {
        public string Username { get; init; } = default!;
        public string? MobilePhoneNumberWithRegionCode { get; init; }
        public string? Email { get; init; }
    }
}
