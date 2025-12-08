namespace ERP.Application.UseCases.UsersManagement.Authentication.SignUp
{
    public sealed record SignUpCommand : SignUpDto, IRequest<Result<SignUpResultDto, Error>>
    {
    }
}
