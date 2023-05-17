using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Flux.Lancamento.Presentation.WebApi.Controllers.Base
{
    public class MainController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public MainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> Execute<P, R>(P request)
            where P : IRequest<R>
        {
            var result = await _mediator.Send(request);

            return new OkObjectResult(new
            {
                success = true,
                data = result
            });
        }

        protected async Task<IActionResult> Execute<P>(P request)
            where P : IRequest
        {
            await _mediator.Send(request);

            return new OkObjectResult(new
            {
                success = true,
                data = new object(),
            });
        }
    }
}
