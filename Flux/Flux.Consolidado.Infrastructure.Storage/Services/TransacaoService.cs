using Flux.Consolidado.Domain.Application.Services;
using Flux.Consolidado.Infrastructure.Storage.Configs;
using Microsoft.EntityFrameworkCore.Storage;

namespace Flux.Consolidado.Infrastructure.Storage.Services
{
    internal class TransacaoService : ITransacaoService
    {
        private readonly ConsolidadoContext _consolidadoContext;
        IDbContextTransaction? _contextCurrentTransaction = null;

        public TransacaoService(ConsolidadoContext consolidadoContext)
        {
            _consolidadoContext = consolidadoContext;
        }

        public void Iniciar()
        {
            _contextCurrentTransaction = _consolidadoContext.Database.BeginTransaction();
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
