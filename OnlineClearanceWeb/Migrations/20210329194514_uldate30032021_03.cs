using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineClearanceWeb.Migrations
{
    public partial class uldate30032021_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Students");
        }
    }
}
