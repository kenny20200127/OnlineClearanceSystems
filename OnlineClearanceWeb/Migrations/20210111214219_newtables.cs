using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EdoTrafficMgtWeb.Migrations
{
    public partial class newtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncidentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 5, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportedIncidents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IncidentCode = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    OtherNames = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    IncidentDate = table.Column<string>(nullable: true),
                    ReportedBy = table.Column<string>(nullable: true),
                    IncidentType = table.Column<string>(nullable: true),
                    IncidentLocation = table.Column<string>(nullable: true),
                    Photo1 = table.Column<string>(nullable: true),
                    Photo2 = table.Column<string>(nullable: true),
                    lga = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    box = table.Column<string>(nullable: true),
                    tel = table.Column<string>(nullable: true),
                    AnyotherInfo = table.Column<string>(nullable: true),
                    NearestBusStop = table.Column<string>(nullable: true),
                    town = table.Column<string>(nullable: true),
                    datecreated = table.Column<DateTime>(nullable: false),
                    createdby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedIncidents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidentTypes");

            migrationBuilder.DropTable(
                name: "ReportedIncidents");
        }
    }
}
