namespace ERP.Application.UseCases.Users.Commands.SendVerificationCode
{
    public record SendVerificationCodeResultDto(string username, string? mobilePhoneNumberWithRegionCode, string? email);
}
