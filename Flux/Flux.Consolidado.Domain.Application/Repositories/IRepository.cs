using Flux.Consolidado.Domain.Entity.Entities.Base;

namespace Flux.Consolidado.Domain.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
