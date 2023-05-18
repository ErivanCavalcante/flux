using Flux.Consolidado.Domain.Application.Repositories;
using ConsolidadoEntity = Flux.Consolidado.Domain.Entity.Entities.Consolidado;
using MediatR;

namespace Flux.Consolidado.Domain.Application.Features.Consolidado.Queries.PegarUltimoConsolidado
{
    public class PegarUltimoConsolidadoQuery : IRequestHandler<PegarUltimoConsolidadoRequest, PegarUltimoConsolidadoResponse>
    {
        private readonly IConsolidadoRepository _consolidadoRepository;

        public PegarUltimoConsolidadoQuery(IConsolidadoRepository consolidadoRepository)
        {
            _consolidadoRepository = consolidadoRepository;
        }

        public async Task<PegarUltimoConsolidadoResponse> Handle(PegarUltimoConsolidadoRequest request, CancellationToken cancellationToken)
        {
            var ultimoConsolidado = await _consolidadoRepository.PegarUltimo()
                    ?? new ConsolidadoEntity();

            return new PegarUltimoConsolidadoResponse
            {
                Valor = ultimoConsolidado.Saldo,
            };
        }
    }
}
