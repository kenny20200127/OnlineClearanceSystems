using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineClearanceWeb.Migrations
{
    public partial class uldate30032021_04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "remarks",
                table: "Students",
                newName: "libremark");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByAdmin",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByHOD",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedByLibrary",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDateAdmin",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDateHOD",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDateLIB",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "adminremark",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hodremark",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedByAdmin",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApprovedByHOD",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApprovedByLibrary",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApprovedDateAdmin",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApprovedDateHOD",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApprovedDateLIB",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "adminremark",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "hodremark",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "libremark",
                table: "Students",
                newName: "remarks");
        }
    }
}
