using ERP.Application.UseCases.UsersManagement.Authentication.SignIn;

namespace ERP.WebApi.Controllers.UsersManagement.Authentication
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Auth/[controller]")]
    [ApiVersion(Helpers.ApiVersion)]
    [ApiExplorerSettings(GroupName = Helpers.AuthenticationSwaggerGroup)]
    public class SignInController : BaseController<string>
    {
        private readonly IValidator<SignInCommand> _validator;

        public SignInController(IMediator mediator, Serilog.ILogger logger, IValidator<SignInCommand> validator) : base(mediator, logger)
        {
            _validator = validator;
        }

        /// <summary>
        /// Sign in user
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Sample request:
        ///     body:
        ///     {
        ///         "username" : "string",
        ///         "password" : "string"
        ///     }
        ///     Sample response:
        ///     Token
        /// </remarks>
        /// <returns></returns>
        [HttpPost(Name = "SignIn")]
        public async Task<IActionResult> Index([FromBody] SignInDto dto)
        {
            var command = new SignInCommand()
            {
                Username = dto.Username,
                Password = dto.Password,
                InternetProtocol = Request.Headers.Host.ToString(),
                DeviceName = Request.Headers["sec-ch-ua"].ToString(),
                OperatingSystem = Request.Headers["sec-ch-ua-platform"].ToString()
            };
            _logger.Information("Sign in user : Username => {@Username} , Password => {@Password} , InternetProtocol => {@InternetProtocol} , DeviceName => {@DeviceName} , OperatingSystem => {@OperatingSystem}",
                command.Username, command.Password, command.InternetProtocol, command.DeviceName, command.OperatingSystem);
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                _logger.Error("Errors for sign in user : {@Errors}", validationResult.Errors);
                return BadRequest(validationResult.Errors);
            }
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                _logger.Information("Sign in user is success : Token => {@Value}", result.Value);
                return FromResult(result);
            }
            _logger.Error("Error for sign in user : {@Error}", result.Error);
            return BadRequest(result.Error.Message);
        }
    }
}
