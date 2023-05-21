using Flux.Lancamento.Domain.Application.Services;
using MediatR;
using Flux.Lancamento.Domain.Application.Repositories;

namespace Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Atualizar
{
    public class AtualizarMovimentacaoCommand : IRequestHandler<AtualizarMovimentacaoRequest>
    {
        private readonly ITransacaoService _transacaoService;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public AtualizarMovimentacaoCommand(ITransacaoService transacaoService, IMovimentacaoRepository movimentacaoRepository)
        {
            _transacaoService = transacaoService;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task Handle(AtualizarMovimentacaoRequest request, CancellationToken cancellationToken)
        {
            _transacaoService.Iniciar();

            try
            {
                var movimentacao = await _movimentacaoRepository.GetByIdAsync(request.id)
                    ?? throw new Exception("Movimentação não encontrada.");

                movimentacao.Descricao = request.descricao;

                await _movimentacaoRepository.UpdateAsync(movimentacao);

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
