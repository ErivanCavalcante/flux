using Flux.Consolidado.Domain.Application.Repositories;
using ConsolidadoEntity = Flux.Consolidado.Domain.Entity.Entities.Consolidado;
using MediatR;

namespace Flux.Consolidado.Domain.Application.Features.Consolidado.Queries.PegarConsolidado
{
    public class PegarConsolidadoQuery : IRequestHandler<PegarConsolidadoRequest, PegarConsolidadoResponse>
    {
        private readonly IConsolidadoRepository _consolidadoRepository;

        public PegarConsolidadoQuery(IConsolidadoRepository consolidadoRepository)
        {
            _consolidadoRepository = consolidadoRepository;
        }

        public async Task<PegarConsolidadoResponse> Handle(PegarConsolidadoRequest request, CancellationToken cancellationToken)
        {
            var ultimoConsolidado = await _consolidadoRepository.PegarUltimo()
                    ?? new ConsolidadoEntity();

            var saldoFiltro = await _consolidadoRepository.ContarSaldoFiltro(request.filtro, request.data);

            return new PegarConsolidadoResponse
            {
                SaldoTotal = ultimoConsolidado.Saldo,
                SaldoFiltro = saldoFiltro,
            };
        }
    }
}
