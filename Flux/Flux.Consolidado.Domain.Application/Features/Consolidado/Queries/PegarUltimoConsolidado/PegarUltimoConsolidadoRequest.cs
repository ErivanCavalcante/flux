using MediatR;

namespace Flux.Consolidado.Domain.Application.Features.Consolidado.Queries.PegarUltimoConsolidado
{
    public record PegarUltimoConsolidadoRequest() : IRequest<PegarUltimoConsolidadoResponse>;
}
