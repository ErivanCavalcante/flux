using Flux.Consolidado.Domain.Entity.Entities.Base;

namespace Flux.Consolidado.Domain.Entity.Entities
{
    public class Consolidado : BaseEntity
    {
        public float Saldo { get; set; }

        public Consolidado()
        {
            Id = Guid.Empty;
            Saldo = 0.0f;
        }
    }
}
