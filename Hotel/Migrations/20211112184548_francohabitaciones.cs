using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class francohabitaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Empleados_EmpleadoId",
                table: "Habitaciones");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "Habitaciones",
                newName: "EmpeladoAcargoId");

            migrationBuilder.RenameIndex(
                name: "IX_Habitaciones_EmpleadoId",
                table: "Habitaciones",
                newName: "IX_Habitaciones_EmpeladoAcargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Empleados_EmpeladoAcargoId",
                table: "Habitaciones",
                column: "EmpeladoAcargoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Empleados_EmpeladoAcargoId",
                table: "Habitaciones");

            migrationBuilder.RenameColumn(
                name: "EmpeladoAcargoId",
                table: "Habitaciones",
                newName: "EmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Habitaciones_EmpeladoAcargoId",
                table: "Habitaciones",
                newName: "IX_Habitaciones_EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Empleados_EmpleadoId",
                table: "Habitaciones",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
