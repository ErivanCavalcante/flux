using Flux.Consolidado.Domain.Application.Repositories;
using Flux.Consolidado.Domain.Entity.Entities.Base;
using Flux.Consolidado.Infrastructure.Storage.Configs;
using Microsoft.EntityFrameworkCore;

namespace Flux.Consolidado.Infrastructure.Storage.Repositories.Base
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ConsolidadoContext _context;
        protected readonly DbSet<T> _dbEntity;

        public Repository(ConsolidadoContext context)
        {
            _context = context;
            _dbEntity = context.Set<T>();
        }

        public Task<T?> GetByIdAsync(Guid id) => _dbEntity.AsNoTracking().FirstOrDefaultAsync(prop => prop.Id.Equals(id));

        public async Task CreateAsync(T entity)
        {
            entity.Id = entity.Id.Equals(Guid.Empty) ? Guid.NewGuid() : entity.Id;
            entity.DataCriacao = DateTime.Now;
            entity.Ativo = true;
            _dbEntity.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            T? entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbEntity.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            var entry = _context.Entry(entity);

            entry.State = EntityState.Modified;

            entity.DataAlteracao = DateTime.Now;

            entry.Property(x => x.DataCriacao).IsModified = false;
            entry.Property(x => x.Ativo).IsModified = false;

            await _context.SaveChangesAsync();

            entry.State = EntityState.Detached;
        }
    }
}
