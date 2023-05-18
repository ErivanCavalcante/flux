using Flux.Consolidado.Domain.Application.Repositories;
using Flux.Consolidado.Domain.Application.Services;
using Flux.Consolidado.Infrastructure.Storage.Configs;
using Flux.Consolidado.Infrastructure.Storage.Services;
using Flux.Lancamento.Domain.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Consolidado.Infrastructure.Storage
{
    public static class ConfigurarExtension
    {
        public static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConsolidadoContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("Sqlite")!;
                options.UseSqlite(connectionString, x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "public"));
                options.EnableSensitiveDataLogging(false);
            });

            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<IConsolidadoRepository, ConsolidadoRepository>();

            return services;
        }
    }
}
