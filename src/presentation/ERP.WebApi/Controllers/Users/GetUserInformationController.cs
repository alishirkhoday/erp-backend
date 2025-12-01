using ERP.Application.UseCases.Users.Queries.GetUserInformation;
using ERP.WebApi.Services;

namespace ERP.WebApi.Controllers.Users
{
    [ApiController]
    [Route("api/v{version:apiVersion}/User/[controller]")]
    [ApiVersion(Helpers.ApiVersion)]
    [ApiExplorerSettings(GroupName = Helpers.UserSwaggerGroup)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GetUserInformationController : BaseController<GetUserInformationResponseDto>
    {
        public GetUserInformationController(IMediator mediator, Serilog.ILogger logger) : base(mediator, logger)
        {
        }

        [HttpGet(Name = "GetUserInformation")]
        public async Task<IActionResult> Index()
        {
            var query = new GetUserInformationQuery
            {
                UserId = User.GetUserID()
            };
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                return FromResult(result);
            }
            return BadRequest(result.Error.Message);
        }
    }
}
