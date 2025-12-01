using ERP.Application.UseCases.Users.DTOs;

namespace ERP.Application.UseCases.Users.Commands.SignIn
{
    public sealed record SignInCommand : SignInDto, IRequest<Result<string, Error>>
    {
        public string InternetProtocol { get; init; } = default!;
        public string? DeviceName { get; init; }
        public string? OperatingSystem { get; init; }
    }
}
