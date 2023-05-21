using MediatR;

namespace Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Atualizar
{
    public record AtualizarMovimentacaoRequest(Guid id, string descricao) : IRequest;
}
