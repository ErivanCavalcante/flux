using Flux.Lancamento.Domain.Application.Services;
using MovimentacaoEntity = Flux.Lancamento.Domain.Entity.Entities.Movimentacao;
using MediatR;
using Flux.Lancamento.Domain.Entity.Enums;
using Flux.Lancamento.Domain.Application.Repositories.Consolidado;
using Flux.Lancamento.Domain.Application.Repositories;
using Flux.Lancamento.Domain.Application.Features.Shared.Responses.Consolidado;

namespace Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Criar
{
    public class CriarMovimentacaoCommand : IRequestHandler<CriarMovimentacaoRequest>
    {
        private readonly ITransacaoService _transacaoService;
        private readonly IConsolidadoRepository _consolidadoRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public CriarMovimentacaoCommand(ITransacaoService transacaoService, IConsolidadoRepository consolidadoRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _transacaoService = transacaoService;
            _consolidadoRepository = consolidadoRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task Handle(CriarMovimentacaoRequest request, CancellationToken cancellationToken)
        {
            _transacaoService.Iniciar();

            try
            {
                // Pega o ultimo saldo
                var consolidado = await _consolidadoRepository.PegaUltimo();

                var movimentacao = new MovimentacaoEntity();

                if (request.tipo == TipoMovimentacao.RECEITA)
                {
                    movimentacao.AdicionarReceita(request.descricao, request.valor, consolidado.Valor);
                }
                else
                {
                    movimentacao.AdicionarDespesa(request.descricao, request.valor, consolidado.Valor);
                }

                await _movimentacaoRepository.CreateAsync(movimentacao);

                await _consolidadoRepository.CriarConsolidado(new CriarConsolidadoDto
                {
                    TipoMovimentacao = movimentacao.TipoMovimentacao.ToString(),
                    Valor = movimentacao.Valor,
                });

                _transacaoService.Comitar();

                // Ajusta o sistema para quando dar erro no servico de consolidar reverter td
            }
            catch (Exception ex)
            {
                _transacaoService.Reverter();
                throw;
            }
        }
    }
}
