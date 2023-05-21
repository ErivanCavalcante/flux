using Flux.Consolidado.Domain.Application.Repositories;
using MediatR;

namespace Flux.Consolidado.Domain.Application.Features.Consolidado.Queries.PegarConsolidadoPorAno
{
    public class PegarConsolidadoPorAnoQuery : IRequestHandler<PegarConsolidadoPorAnoRequest, IEnumerable<PegarConsolidadoPorAnoResponse>>
    {
        private readonly IConsolidadoRepository _consolidadoRepository;

        public PegarConsolidadoPorAnoQuery(IConsolidadoRepository consolidadoRepository)
        {
            _consolidadoRepository = consolidadoRepository;
        }

        public async Task<IEnumerable<PegarConsolidadoPorAnoResponse>> Handle(PegarConsolidadoPorAnoRequest request, CancellationToken cancellationToken)
        {
            var ano = request.data?.Year ?? DateTime.Now.Year;

            var consolidados = await _consolidadoRepository.PegaPorAno(ano);

            // Pega o ultimo consolidado de cada mes
            var result = new List<(int mes, PegarConsolidadoPorAnoResponse response)>();
            var mesesInseridos = new List<int>();

            foreach ( var data in consolidados )
            {
                var ultimoConsolidado = data.OrderByDescending(x => x.DataCriacao)
                    .First();

                result.Add((ultimoConsolidado.DataCriacao.Month, new PegarConsolidadoPorAnoResponse
                {
                    Name = ConverteMes(ultimoConsolidado.DataCriacao.Month),
                    Value = ultimoConsolidado?.Saldo ?? 0,
                }));

                mesesInseridos.Add(ultimoConsolidado!.DataCriacao.Month);
            }

            AdicionarMesEnexistente(result, mesesInseridos);

            return result
                .OrderBy(x => x.mes)
                .Select(x => x.response);
        }

        string ConverteMes(int mes)
        {
            if (mes < 0 || mes > 11) throw new Exception("O ano é inválido");

            var meses = new Dictionary<int, string>
            {
                { 0, "Jan" },
                { 1, "Fev" },
                { 2, "Mar" },
                { 3, "Abr" },
                { 4, "Mai" },
                { 5, "Jun" },
                { 6, "Jul" },
                { 7, "Ago" },
                { 8, "Set" },
                { 9, "Out" },
                { 10, "Nov" },
                { 11, "Dez" },
            };

            return meses[mes];
        }

        void AdicionarMesEnexistente(List<(int mes, PegarConsolidadoPorAnoResponse response)> result, List<int> mesesInseridos)
        {
            var mesesTotais = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            var mesesInesistentes = mesesTotais.Where(x => !mesesInseridos.Contains(x));

            foreach (var mes in mesesInesistentes)
            {
                result.Add((mes, new PegarConsolidadoPorAnoResponse
                {
                    Name = ConverteMes(mes),
                    Value = 0,
                }));
            }
        }
    }
}
