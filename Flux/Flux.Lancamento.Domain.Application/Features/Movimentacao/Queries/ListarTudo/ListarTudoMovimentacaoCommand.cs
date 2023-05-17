using MediatR;
using Flux.Lancamento.Domain.Application.Repositories.Consolidado;
using Flux.Lancamento.Domain.Application.Repositories;

namespace Flux.Lancamento.Domain.Application.Features.Movimentacao.Queries.ListarTudo
{
    public class ListarTudoMovimentacaoCommand : IRequestHandler<ListarTudoMovimentacaoRequest, IEnumerable<ListarTudoMovimentacaoResponse>>
    {
        private readonly IConsolidadoRepository _consolidadoRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public ListarTudoMovimentacaoCommand(IConsolidadoRepository consolidadoRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _consolidadoRepository = consolidadoRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<IEnumerable<ListarTudoMovimentacaoResponse>> Handle(ListarTudoMovimentacaoRequest request, CancellationToken cancellationToken)
        {
            // Lista de forma decrescente
            var movimentacoes = await _movimentacaoRepository.PegarTodas();

            return movimentacoes;
        }
    }
}
