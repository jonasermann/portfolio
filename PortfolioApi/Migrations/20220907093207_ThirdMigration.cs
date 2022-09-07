using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApi.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioImage",
                table: "PortfolioImage");

            migrationBuilder.RenameTable(
                name: "PortfolioImage",
                newName: "PortfolioImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioImages",
                table: "PortfolioImages",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioImages",
                table: "PortfolioImages");

            migrationBuilder.RenameTable(
                name: "PortfolioImages",
                newName: "PortfolioImage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioImage",
                table: "PortfolioImage",
                column: "Id");
        }
    }
}
