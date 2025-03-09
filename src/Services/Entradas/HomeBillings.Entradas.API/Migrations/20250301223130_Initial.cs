using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBillings.Entradas.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "CATEGORIAS",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    NOME = table.Column<string>(type: "varchar(36)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(100)", nullable: false),
                    SIGLA = table.Column<string>(type: "varchar(6)", nullable: false),
                    CRIADO_EM = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ENTRADAS",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    CATEGORIA_ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(100)", nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    EntryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTRADAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ENTRADAS_CATEGORIAS_CATEGORIA_ID",
                        column: x => x.CATEGORIA_ID,
                        principalSchema: "dbo",
                        principalTable: "CATEGORIAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENTRADAS_CATEGORIA_ID",
                schema: "dbo",
                table: "ENTRADAS",
                column: "CATEGORIA_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENTRADAS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CATEGORIAS",
                schema: "dbo");
        }
    }
}
