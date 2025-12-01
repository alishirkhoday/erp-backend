using CSharpFunctionalExtensions;
using ERP.Application.Common;

namespace ERP.WebApi.Controllers
{
    public class BaseController<T>(IMediator mediator, Serilog.ILogger logger) : ControllerBase where T : class
    {
        protected readonly IMediator _mediator = mediator;
        protected readonly Serilog.ILogger _logger = logger;

        protected IActionResult Ok(T result)
        {
            return base.Ok(Envelope<T>.Ok(result));
        }

        protected IActionResult FromResult(IResult<T, Error> result)
        {
            if (result.IsSuccess)
                return Ok(result.Value);

            if (result.Error == Errors.General.NotFound())
                return NotFound(Envelope<T>.Error(result.Error));

            return BadRequest(Envelope<T>.Error(result.Error));
        }
    }
}
