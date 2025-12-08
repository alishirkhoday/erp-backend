namespace ERP.Application.UseCases.UsersManagement.Authentication.SendVerificationCode
{
    public record SendVerificationCodeResultDto(string username, string? mobilePhoneNumberWithRegionCode, string? email);
}
