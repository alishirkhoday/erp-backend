using ERP.Application.UseCases.Users.Commands.VerificationCode;
using ERP.Application.UseCases.Users.DTOs;

namespace ERP.WebApi.Controllers.Users
{
    [ApiController]
    [Route("api/v{version:apiVersion}/User/[controller]")]
    [ApiVersion(Helpers.ApiVersion)]
    [ApiExplorerSettings(GroupName = Helpers.UserSwaggerGroup)]
    public class VerificationCodeController : BaseController<string>
    {
        private readonly IValidator<VerificationCodeCommand> _validator;

        public VerificationCodeController(IMediator mediator, Serilog.ILogger logger, IValidator<VerificationCodeCommand> validator) : base(mediator, logger)
        {
            _validator = validator;
        }

        /// <summary>
        /// Verification code user
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Sample request:
        ///     body:
        ///     {
        ///         "username" : "string",
        ///         "mobilePhoneNumberWithRegionCode" : "string"
        ///         "email" : "string",
        ///         "verificationCode" : "string"
        ///     }
        ///     Sample response:
        ///     Username
        /// </remarks>
        /// <returns></returns>
        [HttpPost(Name = "VerificationCode")]
        public async Task<IActionResult> Index([FromBody] VerificationCodeDto dto)
        {
            var command = new VerificationCodeCommand()
            {
                Username = dto.Username,
                MobilePhoneNumberWithRegionCode = dto.MobilePhoneNumberWithRegionCode,
                Email = dto.Email,
                Code = dto.Code
            };
            _logger.Information("Verification code user : Username => {@Username} , MobilePhoneNumberWithRegionCode => {@MobilePhoneNumberWithRegionCode} , Email => {@Email} , VerificationCode => {@VerificationCode}",
                command.Username, command.MobilePhoneNumberWithRegionCode, command.Email, command.Code);
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                _logger.Error("Errors for verification code user : {@Errors}", validationResult.Errors);
                return BadRequest(validationResult.Errors);
            }
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                _logger.Information("Verification code user is success : Username => {@Value}", result.Value);
                return FromResult(result);
            }
            _logger.Error("Error for verification code user : {@Error}", result.Error);
            return BadRequest(result.Error.Message);
        }
    }
}
