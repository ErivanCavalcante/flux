using Flux.Consolidado.Domain.Application.Repositories;
using Flux.Consolidado.Domain.Entity.Entities;
using Flux.Consolidado.Domain.Entity.Enums;
using Flux.Consolidado.Infrastructure.Storage.Configs;
using Flux.Consolidado.Infrastructure.Storage.Extensions;
using Flux.Consolidado.Infrastructure.Storage.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using ConsolidadoEntity = Flux.Consolidado.Domain.Entity.Entities.Consolidado;

namespace Flux.Lancamento.Domain.Application.Repositories
{
    internal class ConsolidadoRepository : Repository<ConsolidadoEntity>, IConsolidadoRepository
    {
        public ConsolidadoRepository(ConsolidadoContext context) : base(context)
        {
        }

        public Task<float> ContarSaldoFiltro(Filtro filtro, DateTime data)
        {
            return _dbEntity
                .AsNoTracking()
                .OrderByDescending(x => x.DataCriacao)
                .AddCondition(() => filtro == Filtro.DIA, x => x.DataCriacao.Year == data.Year && x.DataCriacao.Month == data.Month && x.DataCriacao.Day == data.Day)
                .AddCondition(() => filtro == Filtro.MES, x => x.DataCriacao.Year == data.Year && x.DataCriacao.Month == data.Month)
                .AddCondition(() => filtro == Filtro.ANO, x => x.DataCriacao.Year == data.Year)
                .Select(x => x.Saldo)
                .FirstOrDefaultAsync();
        }

        public Task<ConsolidadoEntity?> PegarUltimo()
        {
            return _dbEntity
                .AsNoTracking()
                .OrderByDescending(x => x.DataCriacao)
                .FirstOrDefaultAsync();
        }
    }
}
