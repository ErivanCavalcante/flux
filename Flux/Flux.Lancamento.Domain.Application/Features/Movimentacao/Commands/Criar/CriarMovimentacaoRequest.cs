using Flux.Lancamento.Domain.Entity.Enums;
using MediatR;

namespace Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Criar
{
    public record CriarMovimentacaoRequest(TipoMovimentacao tipo, string descricao, float valor) : IRequest<bool>;
}
