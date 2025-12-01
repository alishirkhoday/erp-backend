using ERP.Application.UseCases.Users.DTOs;

namespace ERP.Application.UseCases.Users.Commands.SendVerificationCode
{
    public sealed record SendVerificationCodeCommand : SendVerificationCodeDto, IRequest<Result<SendVerificationCodeResultDto, Error>>
    {
    }
}
