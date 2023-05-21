using Flux.Lancamento.Domain.Entity.Entities.Base;
using Flux.Lancamento.Domain.Entity.Enums;

namespace Flux.Lancamento.Domain.Entity.Entities
{
    public class Movimentacao : BaseEntity
    {
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public float Valor { get; set; }
        public string Descricao { get; set; } = string.Empty;

        public void AdicionarReceita(string descricao, float valor)
        {
            TipoMovimentacao = TipoMovimentacao.RECEITA;
            Descricao = descricao;
            Valor = valor;  
        }

        public void AdicionarDespesa(string descricao, float valor)
        {
            TipoMovimentacao = TipoMovimentacao.DESPESA;
            Descricao = descricao;
            Valor = valor;
        }
    }
}
