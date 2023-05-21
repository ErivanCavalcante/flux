using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Flux.Consolidado.Domain.Entity.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Filtro
    {
        [Description("Dia")]
        DIA,

        [Description("Mês")]
        MES,

        [Description("Ano")]
        ANO,
    }
}
