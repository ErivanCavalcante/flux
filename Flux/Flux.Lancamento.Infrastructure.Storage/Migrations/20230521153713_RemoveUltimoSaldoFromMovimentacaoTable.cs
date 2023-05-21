using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flux.Lancamento.Infrastructure.Storage.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUltimoSaldoFromMovimentacaoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ultimo_saldo",
                table: "movimentacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ultimo_saldo",
                table: "movimentacao",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
