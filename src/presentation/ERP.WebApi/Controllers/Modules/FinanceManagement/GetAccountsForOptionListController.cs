using ERP.Application.Common.ResponseModels;
using ERP.Application.UseCases.Modules.FinanceManagement.Queries.GetAccountsForOptionList;

namespace ERP.WebApi.Controllers.Modules.FinanceManagement
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Account/[controller]")]
    [ApiVersion(Helpers.ApiVersion)]
    [ApiExplorerSettings(GroupName = Helpers.AccountSwaggerGroup)]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "GetAccountsForOptionList")]
    public class GetAccountsForOptionListController : BaseController<IReadOnlyList<GetResponseForOptionListDto>>
    {
        public GetAccountsForOptionListController(IMediator mediator, Serilog.ILogger logger) : base(mediator, logger)
        {
        }

        [HttpGet(Name = "GetAccountsForOptionList")]
        public async Task<IActionResult> Index([FromQuery] string? search)
        {
            var query = new GetAccountsForOptionListQuery { Search = search };
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                return FromResult(result);
            }
            _logger.Error("Error for GetAccountsForOptionList : {@Error}", result.Error);
            return BadRequest(result.Error.Message);
        }
    }
}
