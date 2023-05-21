using Flux.Lancamento.Domain.Entity.Entities;
using Flux.Lancamento.Domain.Entity.Enums;
using Flux.Lancamento.Infrastructure.Storage.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flux.Lancamento.Infrastructure.Storage.Mappings
{
    internal class MovimentacaoMapping : BaseMap<Movimentacao>
    {
        public override void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            base.Configure(builder);
            builder.ToTable("movimentacao");

            builder.Property(x => x.TipoMovimentacao)
                .HasColumnName("tipo_movimentacao")
                .HasConversion(x => x.ToString(), x => (TipoMovimentacao)Enum.Parse(typeof(TipoMovimentacao), x))
                .IsRequired();

            builder.Property(x => x.Valor)
                .HasColumnName("valor")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .IsRequired();
        }
    }
}
