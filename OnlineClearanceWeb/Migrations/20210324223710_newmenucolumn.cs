using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineClearanceWeb.Migrations
{
    public partial class newmenucolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "menuicon",
                table: "Menus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "menuicon",
                table: "Menus");
        }
    }
}
