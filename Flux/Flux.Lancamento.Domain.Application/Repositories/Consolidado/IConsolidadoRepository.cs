using Flux.Lancamento.Domain.Application.Features.Shared.Responses.Consolidado;
using Refit;

namespace Flux.Lancamento.Domain.Application.Repositories.Consolidado
{
    public interface IConsolidadoRepository
    {
        [Get("/consolidado/ultimo")]
        Task<ApiResponse<UltimoConsolidadoDto>> PegaUltimo();

        [Post("/consolidado")]
        Task<ApiResponse<bool>> CriarConsolidado(CriarConsolidadoDto consolidado);
    }
}
