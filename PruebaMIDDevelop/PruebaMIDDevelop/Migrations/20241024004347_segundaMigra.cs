using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaMIDDevelop.Migrations
{
    /// <inheritdoc />
    public partial class segundaMigra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Saldo",
                table: "Movimientos",
                newName: "SaldoDisponible");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaldoDisponible",
                table: "Movimientos",
                newName: "Saldo");
        }
    }
}
