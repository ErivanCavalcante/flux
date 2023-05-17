using Flux.Lancamento.Domain.Application.Features.Movimentacao.Queries.ListarTudo;
using Flux.Lancamento.Domain.Entity.Entities;

namespace Flux.Lancamento.Domain.Application.Repositories
{
    public interface IMovimentacaoRepository : IRepository<Movimentacao>
    {
        Task<List<ListarTudoMovimentacaoResponse>> PegarTodas();
    }
}
