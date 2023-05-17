using Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Criar;
using Flux.Lancamento.Domain.Application.Repositories.Consolidado;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Flux.Lancamento.Domain.Application
{
    public static class ConfigurarExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddRefitClient<IConsolidadoRepository>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("http://localhost:5002/");
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarMovimentacaoRequest).Assembly));

            return services;
        }
    }
}
