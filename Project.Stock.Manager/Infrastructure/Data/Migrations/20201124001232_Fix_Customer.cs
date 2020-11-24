using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Stock.Manager.Infrastructure.Data.Migrations
{
    public partial class Fix_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Customer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Customer");
        }
    }
}
