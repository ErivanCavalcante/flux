namespace Flux.Lancamento.Domain.Application.Features.Shared.Responses.Consolidado
{
    public class CriarConsolidadoDto
    {
        public string TipoMovimentacao { get; set; } = string.Empty;
        public float Valor { get; set; }
    }
}
