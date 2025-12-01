using ERP.Application.UseCases.Users.DTOs;

namespace ERP.Application.UseCases.Users.Commands.SignUp
{
    public sealed record SignUpCommand : SignUpDto, IRequest<Result<SignUpResultDto, Error>>
    {
    }
}
