using Flux.Lancamento.Domain.Application.Services;
using MovimentacaoEntity = Flux.Lancamento.Domain.Entity.Entities.Movimentacao;
using MediatR;
using Flux.Lancamento.Domain.Entity.Enums;
using Flux.Lancamento.Domain.Application.Repositories.Consolidado;
using Flux.Lancamento.Domain.Application.Repositories;
using Flux.Lancamento.Domain.Application.Features.Shared.Responses.Consolidado;

namespace Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Deletar
{
    public class DeletarMovimentacaoCommand : IRequestHandler<DeletarMovimentacaoRequest>
    {
        private readonly ITransacaoService _transacaoService;
        private readonly IConsolidadoRepository _consolidadoRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public DeletarMovimentacaoCommand(ITransacaoService transacaoService, IConsolidadoRepository consolidadoRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _transacaoService = transacaoService;
            _consolidadoRepository = consolidadoRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task Handle(DeletarMovimentacaoRequest request, CancellationToken cancellationToken)
        {
            _transacaoService.Iniciar();

            try
            {
                var movimentacao = await _movimentacaoRepository.GetByIdAsync(request.id)
                    ?? throw new Exception("Movimentação não encontrada.");

                // Cria o consolidado com o inverso da movimentacao
                var result = await _consolidadoRepository.CriarConsolidado(new CriarConsolidadoDto
                {
                    TipoMovimentacao = movimentacao.TipoMovimentacao == TipoMovimentacao.RECEITA ? 
                        TipoMovimentacao.DESPESA.ToString() : TipoMovimentacao.RECEITA.ToString(),
                    Valor = movimentacao.Valor,
                });

                if (!result.IsSuccessStatusCode) throw new Exception("Erro ao salvar o consolidado.");

                await _movimentacaoRepository.DeleteAsync(movimentacao.Id);

                _transacaoService.Comitar();
            }
            catch (Exception ex)
            {
                _transacaoService.Reverter();
                throw;
            }
        }
    }
}
