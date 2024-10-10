﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace UF5423_Aguas.Migrations
{
    public partial class AddMeterUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Meters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Meters");
        }
    }
}
