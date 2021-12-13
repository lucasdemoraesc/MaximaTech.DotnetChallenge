using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaximaTech.DotnetChallenge.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEPARTAMENTOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    DESCRICAO = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CODIGO = table.Column<int>(type: "INT", nullable: false),
                    STATUS = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTAMENTOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    DESCRICAO = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    IDDEPARTAMENTO = table.Column<Guid>(type: "uuid", nullable: false),
                    PRECO = table.Column<decimal>(type: "numeric", nullable: false),
                    CODIGO = table.Column<int>(type: "INT", nullable: false),
                    STATUS = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_DEPARTAMENTOS_IDDEPARTAMENTO",
                        column: x => x.IDDEPARTAMENTO,
                        principalTable: "DEPARTAMENTOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IDX_CODIGODEPARTAMENTO",
                table: "DEPARTAMENTOS",
                column: "CODIGO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_CODIGOPRODUTO",
                table: "PRODUTOS",
                column: "CODIGO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_IDDEPARTAMENTO",
                table: "PRODUTOS",
                column: "IDDEPARTAMENTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "DEPARTAMENTOS");
        }
    }
}
