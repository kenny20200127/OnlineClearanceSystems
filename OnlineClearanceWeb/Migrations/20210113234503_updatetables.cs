using Microsoft.EntityFrameworkCore.Migrations;

namespace EdoTrafficMgtWeb.Migrations
{
    public partial class updatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Incident",
                table: "ReportedIncidents",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "decision",
                table: "ReportedIncidents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "remarks",
                table: "ReportedIncidents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Incident",
                table: "ReportedIncidents");

            migrationBuilder.DropColumn(
                name: "decision",
                table: "ReportedIncidents");

            migrationBuilder.DropColumn(
                name: "remarks",
                table: "ReportedIncidents");
        }
    }
}
