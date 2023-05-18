using Flux.Consolidado.Domain.Entity.Enums;
using ConsolidadoEntity = Flux.Consolidado.Domain.Entity.Entities.Consolidado;

namespace Flux.Consolidado.Domain.Application.Repositories
{
    public interface IConsolidadoRepository : IRepository<ConsolidadoEntity>
    {
        Task<float> ContarSaldoFiltro(Filtro filtro, DateTime data);
        Task<ConsolidadoEntity?> PegarUltimo();
    }
}
