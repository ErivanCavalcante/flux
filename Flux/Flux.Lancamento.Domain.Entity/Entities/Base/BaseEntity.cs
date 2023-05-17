namespace Flux.Lancamento.Domain.Entity.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; } = null;
        public DateTime? DataInativacao { get; set; } = null;
    }
}
