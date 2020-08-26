using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Res.Infra.DataLayer.Migrations
{
    public partial class FieldsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CustomerType");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "ContactType",
                table: "CustomerType",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Customers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactType",
                table: "CustomerType");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Reserves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CustomerType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
