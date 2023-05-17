using Flux.Lancamento.Domain.Application.Repositories;
using Flux.Lancamento.Domain.Application.Services;
using Flux.Lancamento.Infrastructure.Storage.Configs;
using Flux.Lancamento.Infrastructure.Storage.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Lancamento.Infrastructure.Storage
{
    public static class ConfigurarExtension
    {
        public static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovimentacaoContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("Sqlite")!;
                options.UseSqlite(connectionString, x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "public"));
                options.EnableSensitiveDataLogging(false);
            });

            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();

            return services;
        }
    }
}
