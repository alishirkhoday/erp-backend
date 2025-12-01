using ERP.Application.UseCases.Modules.HumanResourcesManagement.Commands.CreateNewHuman;
using ERP.Application.UseCases.Modules.HumanResourcesManagement.DTOs;

namespace ERP.WebApi.Controllers.Modules.HumanResourcesManagement
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Human/[controller]")]
    [ApiVersion(Helpers.ApiVersion)]
    [ApiExplorerSettings(GroupName = Helpers.AccountSwaggerGroup)]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "CreateNewHuman")]
    public class CreateNewHumanController : BaseController<string>
    {
        private readonly IValidator<CreateNewHumanCommand> _validator;

        public CreateNewHumanController(IMediator mediator, Serilog.ILogger logger, IValidator<CreateNewHumanCommand> validator) : base(mediator, logger)
        {
            _validator = validator;
        }

        /// <summary>
        /// Add new Human
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Sample request:
        ///     body:
        ///     {
        ///         "userId" : "string",
        ///         "nationalId" : "string",
        ///         "name" : "string",
        ///         "family" : "string",
        ///         "gender" : "enum",
        ///         "birthDate" : "date",
        ///         "maritalStatus" : "bool",
        ///         "passportId" : "string",
        ///     }
        ///     Sample response:
        ///     Full name
        /// </remarks>
        /// <returns></returns>
        [HttpPost(Name = "CreateNewHuman")]
        public async Task<IActionResult> Index([FromBody] AddEditHumanDto dto)
        {
            var command = new CreateNewHumanCommand
            {
                UserId = dto.UserId,
                NationalId = dto.NationalId,
                Name = dto.Name,
                Family = dto.Family,
                Gender = dto.Gender,
                BirthDate = dto.BirthDate,
                MaritalStatus = dto.MaritalStatus,
                PassportId = dto.PassportId
            };
            _logger.Information("Add new human : UserId => {@UserId} , NationalId => {@NationalId} , Name => {@Name} , Family => {@Family} , Gender => {@Gender} , BirthDate => {@BirthDate} , MaritalStatus => {@MaritalStatus} , PassportId => {@PassportId}",
               command.UserId, command.NationalId, command.Name, command.Family, command.Gender, command.BirthDate, command.MaritalStatus, command.PassportId);
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                _logger.Error("Errors for add new human : {@Errors}", validationResult.Errors);
                return BadRequest(validationResult.Errors);
            }
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                _logger.Information("Saved new human : Full name => {@Value}", result.Value);
                return FromResult(result);
            }
            _logger.Error("Error for add new human : {@Error}", result.Error);
            return BadRequest(result.Error.Message);
        }
    }
}
