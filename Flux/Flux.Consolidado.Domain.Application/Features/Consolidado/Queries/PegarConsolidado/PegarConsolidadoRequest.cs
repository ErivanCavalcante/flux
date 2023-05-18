using Flux.Consolidado.Domain.Entity.Enums;
using MediatR;

namespace Flux.Consolidado.Domain.Application.Features.Consolidado.Queries.PegarConsolidado
{
    public record PegarConsolidadoRequest(Filtro filtro, DateTime data) : IRequest<PegarConsolidadoResponse>;
}
