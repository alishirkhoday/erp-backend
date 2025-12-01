namespace ERP.Application.UseCases.Users.Commands.SignUp
{
    public record SignUpResultDto(string username, string? mobilePhoneNumberWithRegionCode, string? email);
}
