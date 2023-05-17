using System.ComponentModel;

namespace Flux.Lancamento.Domain.Entity.Enums
{
    public enum TipoMovimentacao
    {
        [Description("Receita")]
        RECEITA,

        [Description("Receita")]
        DESPESA,
    }
}
