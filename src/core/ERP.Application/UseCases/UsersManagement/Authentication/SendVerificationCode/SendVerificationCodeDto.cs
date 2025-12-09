namespace ERP.Application.UseCases.UsersManagement.Authentication.SendVerificationCode
{
    public record SendVerificationCodeDto
    {
        public string UserId { get; init; } = default!;
        public string? MobilePhoneNumberWithRegionCode { get; init; }
        public string? Email { get; init; }
    }
}
