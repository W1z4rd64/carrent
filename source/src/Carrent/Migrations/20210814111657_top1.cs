using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carrent.Migrations
{
    public partial class top1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PickUp",
                table: "CarRent_CustomerContracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Return",
                table: "CarRent_CustomerContracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUp",
                table: "CarRent_CustomerContracts");

            migrationBuilder.DropColumn(
                name: "Return",
                table: "CarRent_CustomerContracts");
        }
    }
}
