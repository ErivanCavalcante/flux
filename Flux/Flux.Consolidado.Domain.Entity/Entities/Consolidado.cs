using Flux.Consolidado.Domain.Entity.Entities.Base;

namespace Flux.Consolidado.Domain.Entity.Entities
{
    public class Consolidado : BaseEntity
    {
        public float Valor { get; set; }
        public float ValorMes { get; set; }
        public float ValorAno { get; set; }
    }
}
