using Flux.Lancamento.Domain.Application.Features.Shared.Responses.Consolidado;
using Refit;

namespace Flux.Lancamento.Domain.Application.Repositories.Consolidado
{
    public interface IConsolidadoRepository
    {
        [Get("/consolidado/ultimo")]
        Task<UltimoConsolidadoDto> PegaUltimo();

        [Post("/consolidado")]
        Task CriarConsolidado(CriarConsolidadoDto consolidado);
    }
}
