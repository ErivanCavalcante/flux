using Flux.Lancamento.Domain.Application.Features.Movimentacao.Queries.ListarTudo;
using Flux.Lancamento.Domain.Entity.Entities;
using Flux.Lancamento.Infrastructure.Storage.Configs;
using Flux.Lancamento.Infrastructure.Storage.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Flux.Lancamento.Domain.Application.Repositories
{
    internal class MovimentacaoRepository : Repository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(MovimentacaoContext context) : base(context)
        {
        }

        public Task<List<ListarTudoMovimentacaoResponse>> PegarTodas()
        {
            return _dbEntity
                .AsNoTracking()
                .OrderByDescending(x => x.DataCriacao)
                .Select(x => new ListarTudoMovimentacaoResponse
                {
                    Id = x.Id,
                    TipoMovimentacao = x.TipoMovimentacao.ToString(),
                    Valor = x.Valor,
                    Descricao = x.Descricao,
                    Data = x.DataCriacao,
                })
                .ToListAsync();
        }
    }
}
