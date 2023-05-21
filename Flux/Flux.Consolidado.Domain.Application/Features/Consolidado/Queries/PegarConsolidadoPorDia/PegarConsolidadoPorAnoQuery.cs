using Flux.Consolidado.Domain.Application.Repositories;
using MediatR;

namespace Flux.Consolidado.Domain.Application.Features.Consolidado.Queries.PegarConsolidadoPorDia
{
    public class PegarConsolidadoPorDiaQuery : IRequestHandler<PegarConsolidadoPorDiaRequest, IEnumerable<PegarConsolidadoPorDiaResponse>>
    {
        private readonly IConsolidadoRepository _consolidadoRepository;

        public PegarConsolidadoPorDiaQuery(IConsolidadoRepository consolidadoRepository)
        {
            _consolidadoRepository = consolidadoRepository;
        }

        public async Task<IEnumerable<PegarConsolidadoPorDiaResponse>> Handle(PegarConsolidadoPorDiaRequest request, CancellationToken cancellationToken)
        {
            var dia = request.data ?? DateTime.Now;

            var consolidados = await _consolidadoRepository.PegaPorDia(dia);

            return consolidados.Select(x => new PegarConsolidadoPorDiaResponse
            {
                Name = x.DataCriacao.ToString("HH:mm:ss"),
                Value = x.Saldo,
            });
        }
    }
}
