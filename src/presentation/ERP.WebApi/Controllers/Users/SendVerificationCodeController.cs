using ERP.Application.UseCases.Users.Commands.SendVerificationCode;
using ERP.Application.UseCases.Users.DTOs;

namespace ERP.WebApi.Controllers.Users
{
    [ApiController]
    [Route("api/v{version:apiVersion}/User/[controller]")]
    [ApiVersion(Helpers.ApiVersion)]
    [ApiExplorerSettings(GroupName = Helpers.UserSwaggerGroup)]
    public class SendVerificationCodeController : BaseController<SendVerificationCodeResultDto>
    {
        private readonly IValidator<SendVerificationCodeCommand> _validator;

        public SendVerificationCodeController(IMediator mediator, Serilog.ILogger logger, IValidator<SendVerificationCodeCommand> validator) : base(mediator, logger)
        {
            _validator = validator;
        }

        /// <summary>
        /// Send verification code
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Sample request:
        ///     body:
        ///     {
        ///         "username" : "string",
        ///         "mobilePhoneNumberWithRegionCode" : "string"
        ///         "email" : "string"
        ///     }
        ///     Sample response:
        ///     {
        ///         Username,
        ///         MobilePhoneNumberWithRegionCode
        ///         Email
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost(Name = "SendVerificationCode")]
        public async Task<IActionResult> Index([FromBody] SendVerificationCodeDto dto)
        {
            var command = new SendVerificationCodeCommand()
            {
                Username = dto.Username,
                MobilePhoneNumberWithRegionCode = dto.MobilePhoneNumberWithRegionCode,
                Email = dto.Email
            };
            _logger.Information("Send verification code user : Username => {@Username} , MobilePhoneNumberWithRegionCode => {@MobilePhoneNumberWithRegionCode} , Email => {@Email}",
               command.Username, command.MobilePhoneNumberWithRegionCode, command.Email);
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                _logger.Error("Errors for send verification code user : {@Errors}", validationResult.Errors);
                return BadRequest(validationResult.Errors);
            }
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                _logger.Information("Send verification code user is success : Username => {@username} , MobilePhoneNumberWithRegionCode => {@mobilePhoneNumberWithRegionCode} , Email => {@email}",
                    result.Value.username, result.Value.mobilePhoneNumberWithRegionCode, result.Value.email);
                return FromResult(result);
            }
            _logger.Error("Error for send verification code user : {@Error}", result.Error);
            return BadRequest(result.Error.Message);
        }
    }
}
