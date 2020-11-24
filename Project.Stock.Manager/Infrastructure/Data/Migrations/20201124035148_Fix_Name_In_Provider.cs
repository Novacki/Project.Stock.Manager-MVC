using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Stock.Manager.Infrastructure.Data.Migrations
{
    public partial class Fix_Name_In_Provider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Provider");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Provider",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Provider");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Provider",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
