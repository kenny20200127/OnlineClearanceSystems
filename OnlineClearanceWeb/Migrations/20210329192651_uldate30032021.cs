using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineClearanceWeb.Migrations
{
    public partial class uldate30032021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GPA",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GraduatedDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GPA",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GraduatedDate",
                table: "Students");
        }
    }
}
