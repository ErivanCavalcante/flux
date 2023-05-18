using Flux.Consolidado.Domain.Application.Features.Consolidado.Commands.Criar;
using Flux.Consolidado.Domain.Application.Features.Consolidado.Queries.PegarConsolidado;
using Flux.Consolidado.Domain.Application.Features.Consolidado.Queries.PegarUltimoConsolidado;
using Flux.Consolidado.Presentation.WebApi.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Flux.Consolidado.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsolidadoController : MainController
    {
        public ConsolidadoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("ultimo")]
        public async Task<IActionResult> PegarUltimo()
        {
            return await Execute<PegarUltimoConsolidadoRequest, PegarUltimoConsolidadoResponse>(new PegarUltimoConsolidadoRequest());
        }

        [HttpGet]
        public async Task<IActionResult> PegarPorFiltro([FromQuery] PegarConsolidadoRequest request)
        {
            return await Execute<PegarConsolidadoRequest, PegarConsolidadoResponse>(request);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarConsolidadoRequest request)
        {
            return await Execute<CriarConsolidadoRequest, bool>(request);
        }
    }
}
