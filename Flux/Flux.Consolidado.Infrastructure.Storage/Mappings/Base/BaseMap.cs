using Flux.Consolidado.Domain.Entity.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flux.Consolidado.Infrastructure.Storage.Mappings.Base
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedNever()
                .IsRequired();
            builder.Property(x => x.Ativo)
                .HasColumnName("ativo")
                .HasDefaultValue(true)
                .IsRequired();
            builder.Property(x => x.DataAlteracao)
                .HasColumnName("data_alteracao")
                .HasDefaultValue(null);
            builder.Property(x => x.DataCriacao).HasColumnName("data_criacao")
                .IsRequired();
            builder.Property(x => x.DataInativacao)
                .HasColumnName("data_inativacao")
                .HasDefaultValue(null);
        }
    }
}
