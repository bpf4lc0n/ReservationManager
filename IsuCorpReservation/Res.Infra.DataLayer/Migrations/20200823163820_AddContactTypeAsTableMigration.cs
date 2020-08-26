using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Res.Infra.DataLayer.Migrations
{
    public partial class AddContactTypeAsTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact_Type",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurants",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactTypeId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactTypeId",
                table: "Customers",
                column: "ContactTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerType_ContactTypeId",
                table: "Customers",
                column: "ContactTypeId",
                principalTable: "CustomerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerType_ContactTypeId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerType");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ContactTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactTypeId",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Contact_Type",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
