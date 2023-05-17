using Flux.Lancamento.Domain.Application.Services;
using Flux.Lancamento.Infrastructure.Storage.Configs;
using Microsoft.EntityFrameworkCore.Storage;

namespace Flux.Lancamento.Infrastructure.Storage.Services
{
    internal class TransacaoService : ITransacaoService
    {
        private readonly MovimentacaoContext _movimentacaoContext;
        IDbContextTransaction? _contextCurrentTransaction = null;

        public TransacaoService(MovimentacaoContext movimentacaoContext)
        {
            _movimentacaoContext = movimentacaoContext;
        }

        public void Iniciar()
        {
            _contextCurrentTransaction = _movimentacaoContext.Database.BeginTransaction();
        }

        public void Comitar()
        {
            _contextCurrentTransaction!.Commit();
        }

        public void Reverter()
        {
            _contextCurrentTransaction!.Rollback();
        }

        public void Dispose()
        {
            _contextCurrentTransaction?.Dispose();
            _contextCurrentTransaction = null;
        }
    }
}
