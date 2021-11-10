﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Migrations
{
    public partial class genio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TelefonoId",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefonoId",
                table: "Empleados");
        }
    }
}
