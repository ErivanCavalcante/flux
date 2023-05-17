using Flux.Lancamento.Domain.Entity.Enums;
using MediatR;

namespace Flux.Lancamento.Domain.Application.Features.Movimentacao.Queries.ListarTudo
{
    public class ListarTudoMovimentacaoResponse
    {
        public Guid Id { get; set; }
        public string TipoMovimentacao { get; set; } = string.Empty;
        public float Valor { get; set; }
        public float UltimoSaldo { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data { get; set; }
    }
}
