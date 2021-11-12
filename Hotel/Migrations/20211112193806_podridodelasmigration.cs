using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class podridodelasmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoMantenimiento",
                table: "Habitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMantenimiento",
                table: "Habitaciones");
        }
    }
}
