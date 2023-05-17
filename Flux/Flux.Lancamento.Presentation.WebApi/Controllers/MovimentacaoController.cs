using Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Criar;
using Flux.Lancamento.Domain.Application.Features.Movimentacao.Queries.ListarTudo;
using Flux.Lancamento.Presentation.WebApi.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Flux.Lancamento.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : MainController
    {
        public MovimentacaoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> PegarTodos()
        {
            return await Execute<ListarTudoMovimentacaoRequest, IEnumerable<ListarTudoMovimentacaoResponse>>(new ListarTudoMovimentacaoRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarMovimentacaoRequest request)
        {
            return await Execute(request);
        }
    }
}
