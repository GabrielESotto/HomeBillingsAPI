using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBillings.Usuario.API.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonRegister : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "REGISTRO_PESSOA",
                schema: "dbo",
                table: "USUARIOS",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "REGISTRO_PESSOA",
                schema: "dbo",
                table: "USUARIOS");
        }
    }
}
