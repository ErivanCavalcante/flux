using MediatR;

namespace Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Deletar
{
    public record DeletarMovimentacaoRequest(Guid id) : IRequest;
}
