﻿// <auto-generated />
using System;
using Flux.Lancamento.Infrastructure.Storage.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Flux.Lancamento.Infrastructure.Storage.Migrations
{
    [DbContext(typeof(MovimentacaoContext))]
    [Migration("20230517011141_CreateMovimentacaoTable")]
    partial class CreateMovimentacaoTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Flux.Lancamento.Domain.Entity.Entities.Movimentacao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true)
                        .HasColumnName("ativo");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("TEXT")
                        .HasColumnName("data_alteracao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT")
                        .HasColumnName("data_criacao");

                    b.Property<DateTime?>("DataInativacao")
                        .HasColumnType("TEXT")
                        .HasColumnName("data_inativacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("descricao");

                    b.Property<string>("TipoMovimentacao")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("tipo_movimentacao");

                    b.Property<float>("UltimoSaldo")
                        .HasColumnType("REAL")
                        .HasColumnName("ultimo_saldo");

                    b.Property<float>("Valor")
                        .HasColumnType("REAL")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.ToTable("movimentacao", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
