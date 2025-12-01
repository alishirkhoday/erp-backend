using ERP.Application.UseCases.Modules.FinanceManagement.Commands.CreateNewAccount;
using ERP.Application.UseCases.Modules.FinanceManagement.DTOs;

namespace ERP.WebApi.Controllers.Modules.FinanceManagement
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Account/[controller]")]
    [ApiVersion(Helpers.ApiVersion)]
    [ApiExplorerSettings(GroupName = Helpers.AccountSwaggerGroup)]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "CreateNewAccount")]
    public class CreateNewAccountController : BaseController<string>
    {
        private readonly IValidator<CreateNewAccountCommand> _validator;

        public CreateNewAccountController(IMediator mediator, Serilog.ILogger logger, IValidator<CreateNewAccountCommand> validator) : base(mediator, logger)
        {
            _validator = validator;
        }

        /// <summary>
        /// Add new Account
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        /// Sample request:
        ///     body:
        ///     {
        ///         "name" : "string",
        ///         "type" : "enum",
        ///         "group" : "enum",
        ///         "balance" : "enum",
        ///         "financialStatement" : "enum",
        ///         "isFinal" : "bool",
        ///         "parentAccountId" : "string",
        ///     }
        ///     Sample response:
        ///     Account Code
        /// </remarks>
        /// <returns></returns>
        [HttpPost(Name = "CreateNewAccount")]
        public async Task<IActionResult> Index([FromBody] AddEditAccountDto dto)
        {
            var command = new CreateNewAccountCommand
            {
                Name = dto.Name,
                Type = dto.Type,
                Group = dto.Group,
                Balance = dto.Balance,
                FinancialStatement = dto.FinancialStatement,
                IsFinal = dto.IsFinal,
                ParentAccountId = dto.ParentAccountId
            };
            _logger.Information("Add new account : Name => {@Name} , Type => {@Type} , Group => {@Group} , Balance => {@Balance} , FinancialStatement => {@FinancialStatement} , IsFinal => {@IsFinal} , ParentAccountId => {@ParentAccountId}",
                command.Name, command.Type, command.Group, command.Balance, command.FinancialStatement, command.IsFinal, command.ParentAccountId);
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                _logger.Error("Errors for add new account : {@Errors}", validationResult.Errors);
                return BadRequest(validationResult.Errors);
            }
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                _logger.Information("Saved new account : Account Code => {@Value}", result.Value);
                return FromResult(result);
            }
            _logger.Error("Error for add new account : {@Error}", result.Error);
            return BadRequest(result.Error.Message);
        }
    }
}
