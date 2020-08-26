using Microsoft.EntityFrameworkCore.Migrations;

namespace Res.Infra.DataLayer.Migrations
{
    public partial class ReservationMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Contact_Type",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Customers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact_Type",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");
        }
    }
}
