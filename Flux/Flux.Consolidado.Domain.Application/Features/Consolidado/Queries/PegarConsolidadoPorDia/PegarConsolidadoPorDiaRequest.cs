using MediatR;

namespace Flux.Consolidado.Domain.Application.Features.Consolidado.Queries.PegarConsolidadoPorDia
{
    public record PegarConsolidadoPorDiaRequest(DateTime? data) : IRequest<IEnumerable<PegarConsolidadoPorDiaResponse>>;
}
