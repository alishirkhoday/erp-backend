namespace ERP.Application.UseCases.UsersManagement.Authentication.SendVerificationCode
{
    public sealed record SendVerificationCodeCommand : SendVerificationCodeDto, IRequest<Result<SendVerificationCodeResultDto, Error>>
    {
    }
}
