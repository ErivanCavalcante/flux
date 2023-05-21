using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Flux.Lancamento.Domain.Entity.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoMovimentacao
    {
        [Description("Receita")]
        RECEITA,

        [Description("Receita")]
        DESPESA,
    }
}
