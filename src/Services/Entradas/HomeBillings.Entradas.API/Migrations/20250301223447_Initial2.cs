using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBillings.Entradas.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntryDate",
                schema: "dbo",
                table: "ENTRADAS",
                newName: "DATA_ENTRADA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DATA_ENTRADA",
                schema: "dbo",
                table: "ENTRADAS",
                newName: "EntryDate");
        }
    }
}
