using Flux.Consolidado.Domain.Application.Features.Consolidado.Commands.Criar;
using Microsoft.Extensions.DependencyInjection;

namespace Flux.Consolidado.Domain.Application
{
    public static class ConfigurarExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarConsolidadoCommand).Assembly));

            return services;
        }
    }
}
