using Microsoft.EntityFrameworkCore.Migrations;

namespace Res.Infra.DataLayer.Migrations
{
    public partial class SpSample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContactType",
                table: "CustomerTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContactType",
                table: "CustomerTypes",
                type: "nchar(20)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
