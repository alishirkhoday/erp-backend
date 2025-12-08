namespace ERP.Application.UseCases.UsersManagement.Authentication.SignIn
{
    public sealed record SignInCommand : SignInDto, IRequest<Result<string, Error>>
    {
        public string InternetProtocol { get; init; } = default!;
        public string? DeviceName { get; init; }
        public string? OperatingSystem { get; init; }
    }
}
