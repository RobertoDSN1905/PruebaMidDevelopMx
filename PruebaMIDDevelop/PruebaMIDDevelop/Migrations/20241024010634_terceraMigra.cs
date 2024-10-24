using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaMIDDevelop.Migrations
{
    /// <inheritdoc />
    public partial class terceraMigra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Clientes_clienteID",
                table: "Cuentas");

            migrationBuilder.RenameColumn(
                name: "clienteID",
                table: "Cuentas",
                newName: "ClienteID");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_clienteID",
                table: "Cuentas",
                newName: "IX_Cuentas_ClienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Clientes_ClienteID",
                table: "Cuentas",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Clientes_ClienteID",
                table: "Cuentas");

            migrationBuilder.RenameColumn(
                name: "ClienteID",
                table: "Cuentas",
                newName: "clienteID");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_ClienteID",
                table: "Cuentas",
                newName: "IX_Cuentas_clienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Clientes_clienteID",
                table: "Cuentas",
                column: "clienteID",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
