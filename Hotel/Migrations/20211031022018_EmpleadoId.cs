using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class EmpleadoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencia_Empleados_EmpleadoId",
                table: "Asistencia");

            migrationBuilder.AlterColumn<int>(
                name: "EmpleadoId",
                table: "Asistencia",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencia_Empleados_EmpleadoId",
                table: "Asistencia",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencia_Empleados_EmpleadoId",
                table: "Asistencia");

            migrationBuilder.AlterColumn<int>(
                name: "EmpleadoId",
                table: "Asistencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencia_Empleados_EmpleadoId",
                table: "Asistencia",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
