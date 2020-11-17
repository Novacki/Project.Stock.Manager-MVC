using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Stock.Manager.Infrastructure.Data.Migrations
{
    public partial class FixedBatchAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Batch",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Batch");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
