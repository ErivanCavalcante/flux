using Flux.Consolidado.Domain.Entity.Enums;
using MediatR;

namespace Flux.Consolidado.Domain.Application.Features.Consolidado.Commands.Criar
{
    public record CriarConsolidadoRequest(TipoMovimentacao tipoMovimentacao, float valor) : IRequest<bool>;
}
