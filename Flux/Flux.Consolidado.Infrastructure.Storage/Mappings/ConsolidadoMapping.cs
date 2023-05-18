using ConsolidadoEntity = Flux.Consolidado.Domain.Entity.Entities.Consolidado;
using Flux.Consolidado.Infrastructure.Storage.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flux.Consolidado.Infrastructure.Storage.Mappings
{
    internal class ConsolidadoMapping : BaseMap<ConsolidadoEntity>
    {
        public override void Configure(EntityTypeBuilder<ConsolidadoEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("consolidado");

            builder.Property(x => x.Saldo)
                .HasColumnName("saldo")
                .IsRequired();
        }
    }
}
