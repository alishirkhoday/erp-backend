namespace ERP.Application.UseCases.UsersManagement.Authentication.Verify
{
    public sealed record VerifyCommand : VerifyDto, IRequest<Result<string, Error>>
    {
    }
}
