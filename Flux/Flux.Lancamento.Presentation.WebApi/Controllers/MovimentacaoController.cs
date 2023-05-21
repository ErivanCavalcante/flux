using Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Atualizar;
using Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Criar;
using Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Deletar;
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

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarMovimentacaoRequest request)
        {
            return await Execute(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            return await Execute(new DeletarMovimentacaoRequest(id));
        }
    }
}
