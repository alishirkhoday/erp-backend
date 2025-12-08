using ERP.Application.UseCases.UsersManagement.Authentication.Verify;

namespace ERP.WebApi.Controllers.UsersManagement.Authentication
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Auth/[controller]")]
    [ApiVersion(Helpers.ApiVersion)]
    [ApiExplorerSettings(GroupName = Helpers.AuthenticationSwaggerGroup)]
    public class VerifyController : BaseController<string>
    {
        private readonly IValidator<VerifyCommand> _validator;

        public VerifyController(IMediator mediator, Serilog.ILogger logger, IValidator<VerifyCommand> validator) : base(mediator, logger)
        {
            _validator = validator;
        }

        /// <summary>
        /// Verify user
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Sample request:
        ///     body:
        ///     {
        ///         "username" : "string",
        ///         "mobilePhoneNumberWithRegionCode" : "string"
        ///         "email" : "string",
        ///         "code" : "string"
        ///     }
        ///     Sample response:
        ///     Username
        /// </remarks>
        /// <returns></returns>
        [HttpPost(Name = "Verify")]
        public async Task<IActionResult> Index([FromBody] VerifyDto dto)
        {
            var command = new VerifyCommand()
            {
                Username = dto.Username,
                MobilePhoneNumberWithRegionCode = dto.MobilePhoneNumberWithRegionCode,
                Email = dto.Email,
                Code = dto.Code
            };
            _logger.Information("Verify user : Username => {@Username} , MobilePhoneNumberWithRegionCode => {@MobilePhoneNumberWithRegionCode} , Email => {@Email} , Code => {@Code}",
                command.Username, command.MobilePhoneNumberWithRegionCode, command.Email, command.Code);
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                _logger.Error("Errors for verify user : {@Errors}", validationResult.Errors);
                return BadRequest(validationResult.Errors);
            }
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                _logger.Information("Verify user is success : Username => {@Value}", result.Value);
                return FromResult(result);
            }
            _logger.Error("Error for verify user : {@Error}", result.Error);
            return BadRequest(result.Error.Message);
        }
    }
}
