using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class empleaditos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Empleados_EmpeladoAcargoId",
                table: "Habitaciones");

            migrationBuilder.RenameColumn(
                name: "EmpeladoAcargoId",
                table: "Habitaciones",
                newName: "EmpleadoAcargoId");

            migrationBuilder.RenameIndex(
                name: "IX_Habitaciones_EmpeladoAcargoId",
                table: "Habitaciones",
                newName: "IX_Habitaciones_EmpleadoAcargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitaciones_Empleados_EmpleadoAcargoId",
                table: "Habitaciones",
                column: "EmpleadoAcargoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitaciones_Empleados_EmpleadoAcargoId",
                table: "Habitaciones");

            migrationBuilder.RenameColumn(
                name: "EmpleadoAcargoId",
                table: "Habitaciones",
                newName: "EmpeladoAcargoId");

            migrationBuilder.RenameIndex(
                name: "IX_Habitaciones_EmpleadoAcargoId",
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
    }
}
