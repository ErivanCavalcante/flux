using MediatR;

namespace Flux.Consolidado.Domain.Application.Features.Consolidado.Queries.PegarConsolidadoPorAno
{
    public record PegarConsolidadoPorAnoRequest(DateTime? data) : IRequest<IEnumerable<PegarConsolidadoPorAnoResponse>>;
}
