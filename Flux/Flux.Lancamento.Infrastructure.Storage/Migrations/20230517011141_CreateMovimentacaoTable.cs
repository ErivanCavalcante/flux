using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flux.Lancamento.Infrastructure.Storage.Migrations
{
    /// <inheritdoc />
    public partial class CreateMovimentacaoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movimentacao",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    tipo_movimentacao = table.Column<string>(type: "TEXT", nullable: false),
                    valor = table.Column<float>(type: "REAL", nullable: false),
                    ultimo_saldo = table.Column<float>(type: "REAL", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    ativo = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    data_criacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    data_inativacao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimentacao", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimentacao");
        }
    }
}
