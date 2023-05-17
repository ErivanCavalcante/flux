using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Flux.Lancamento.Infrastructure.Storage.Configs
{
    internal class MovimentacaoContext : DbContext
    {
        public MovimentacaoContext(DbContextOptions<MovimentacaoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
