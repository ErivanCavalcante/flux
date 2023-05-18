using Flux.Consolidado.Domain.Application.Repositories;
using Flux.Consolidado.Domain.Application.Services;
using ConsolidadoEntity = Flux.Consolidado.Domain.Entity.Entities.Consolidado;
using MediatR;
using Flux.Consolidado.Domain.Entity.Enums;

namespace Flux.Consolidado.Domain.Application.Features.Consolidado.Commands.Criar
{
    public class CriarConsolidadoCommand : IRequestHandler<CriarConsolidadoRequest, bool>
    {
        private readonly ITransacaoService _transacaoService;
        private readonly IConsolidadoRepository _consolidadoRepository;

        public CriarConsolidadoCommand(ITransacaoService transacaoService, IConsolidadoRepository consolidadoRepository)
        {
            _transacaoService = transacaoService;
            _consolidadoRepository = consolidadoRepository;
        }

        public async Task<bool> Handle(CriarConsolidadoRequest request, CancellationToken cancellationToken)
        {
            _transacaoService.Iniciar();

            try
            {
                var ultimoConsolidado = await _consolidadoRepository.PegarUltimo()
                    ?? new ConsolidadoEntity();

                var consolidado = new ConsolidadoEntity
                {
                    Saldo = CalculaSaldo(request.tipoMovimentacao, ultimoConsolidado.Saldo, request.valor),
                };

                await _consolidadoRepository.CreateAsync(consolidado);

                _transacaoService.Comitar();
            }
            catch (Exception ex)
            {
                _transacaoService.Reverter();
                throw;
            }

            return true;
        }

        float CalculaSaldo(TipoMovimentacao movimentacao, float ultimoSaldo, float valor)
        {
            return (movimentacao == TipoMovimentacao.RECEITA) ? ultimoSaldo + valor : ultimoSaldo - valor;
        }
    }
}
