using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Flux.Consolidado.Infrastructure.Storage.Configs
{
    internal class ConsolidadoContext : DbContext
    {
        public ConsolidadoContext(DbContextOptions<ConsolidadoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
