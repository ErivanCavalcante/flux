using Flux.Lancamento.Domain.Application.Repositories;
using Flux.Lancamento.Domain.Entity.Entities.Base;
using Flux.Lancamento.Infrastructure.Storage.Configs;
using Microsoft.EntityFrameworkCore;

namespace Flux.Lancamento.Infrastructure.Storage.Repositories.Base
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly MovimentacaoContext _context;
        protected readonly DbSet<T> _dbEntity;

        public Repository(MovimentacaoContext context)
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
