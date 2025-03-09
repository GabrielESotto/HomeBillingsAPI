using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBillings.Usuario.API.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ENDERECOS",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    RUA = table.Column<string>(type: "varchar(255)", nullable: false),
                    NUMERO = table.Column<int>(type: "int", nullable: false),
                    BAIRRO = table.Column<string>(type: "varchar(100)", nullable: false),
                    CIDADE = table.Column<string>(type: "varchar(100)", nullable: false),
                    ESTADO = table.Column<string>(type: "varchar(50)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FAMILIAS",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    NOME = table.Column<string>(type: "varchar(255)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(255)", nullable: false),
                    TIPO_PESSOA = table.Column<string>(type: "varchar(50)", nullable: false),
                    CRIADO_EM = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAMILIAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", nullable: false),
                    NOME = table.Column<string>(type: "varchar(50)", nullable: false),
                    SOBRENOME = table.Column<string>(type: "varchar(50)", nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDADE = table.Column<int>(type: "int", nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(100)", nullable: false),
                    TELEFONE = table.Column<string>(type: "varchar(20)", nullable: false),
                    TIPO_PESSOA = table.Column<string>(type: "varchar(20)", nullable: false),
                    AddressId = table.Column<string>(type: "varchar(36)", nullable: false),
                    FamilyId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USUARIOS_ENDERECOS_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "dbo",
                        principalTable: "ENDERECOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIOS_FAMILIAS_FamilyId",
                        column: x => x.FamilyId,
                        principalSchema: "dbo",
                        principalTable: "FAMILIAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_AddressId",
                schema: "dbo",
                table: "USUARIOS",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_FamilyId",
                schema: "dbo",
                table: "USUARIOS",
                column: "FamilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIOS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ENDERECOS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FAMILIAS",
                schema: "dbo");
        }
    }
}
