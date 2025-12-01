using ERP.Application.UseCases.Users.DTOs;

namespace ERP.Application.UseCases.Users.Commands.VerificationCode
{
    public sealed record VerificationCodeCommand : VerificationCodeDto, IRequest<Result<string, Error>>
    {
    }
}
