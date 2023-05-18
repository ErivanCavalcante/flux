using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flux.Consolidado.Infrastructure.Storage.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "consolidado",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    saldo = table.Column<float>(type: "REAL", nullable: false),
                    ativo = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    data_criacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    data_inativacao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consolidado", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consolidado");
        }
    }
}
