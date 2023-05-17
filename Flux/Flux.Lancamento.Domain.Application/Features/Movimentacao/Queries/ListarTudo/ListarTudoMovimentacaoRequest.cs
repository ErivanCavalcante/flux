using MediatR;

namespace Flux.Lancamento.Domain.Application.Features.Movimentacao.Queries.ListarTudo
{
    public record ListarTudoMovimentacaoRequest() : IRequest<IEnumerable<ListarTudoMovimentacaoResponse>>;
}
