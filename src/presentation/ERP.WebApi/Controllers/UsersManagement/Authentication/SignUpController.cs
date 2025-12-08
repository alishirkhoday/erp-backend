using ERP.Application.UseCases.UsersManagement.Authentication.SignUp;

namespace ERP.WebApi.Controllers.UsersManagement.Authentication
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Auth/[controller]")]
    [ApiVersion(Helpers.ApiVersion)]
    [ApiExplorerSettings(GroupName = Helpers.AuthenticationSwaggerGroup)]
    public class SignUpController : BaseController<SignUpResultDto>
    {
        private readonly IValidator<SignUpCommand> _validator;

        public SignUpController(IMediator mediator, Serilog.ILogger logger, IValidator<SignUpCommand> validator) : base(mediator, logger)
        {
            _validator = validator;
        }

        /// <summary>
        /// Sign up user
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Sample request:
        ///     body:
        ///     {
        ///         "username" : "string",
        ///         "password" : "string",
        ///         "mobilePhoneNumberRegionCode" : "string"
        ///         "mobilePhoneNumber" : "string"
        ///         "email" : "string"
        ///     }
        /// Sample response:
        ///     {
        ///         Username,
        ///         MobilePhoneNumberWithRegionCode
        ///         Email
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost(Name = "SignUp")]
        public async Task<IActionResult> Index([FromBody] SignUpDto dto)
        {
            var command = new SignUpCommand()
            {
                Username = dto.Username,
                Password = dto.Password,
                MobilePhoneNumberRegionCode = dto.MobilePhoneNumberRegionCode,
                MobilePhoneNumber = dto.MobilePhoneNumber,
                Email = dto.Email
            };
            _logger.Information("Sign up user : Username => {@Username} , Password => {@Password} , MobilePhoneNumberRegionCode => {@MobilePhoneNumberRegionCode} , MobilePhoneNumber => {@MobilePhoneNumber} , Email => {@Email}",
                command.Username, command.Password, command.MobilePhoneNumberRegionCode, command.MobilePhoneNumber, command.Email);
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                _logger.Error("Errors for sign up user : {@Errors}", validationResult.Errors);
                return BadRequest(validationResult.Errors);
            }
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                _logger.Information("Sign up user is success : Username => {@username} , MobilePhoneNumberWithRegionCode => {@mobilePhoneNumberWithRegionCode} , Email => {@email}",
                    result.Value.username, result.Value.mobilePhoneNumberWithRegionCode, result.Value.email);
                return FromResult(result);
            }
            _logger.Error("Error for sign up user : {@Error}", result.Error);
            return BadRequest(result.Error.Message);
        }
    }
}
