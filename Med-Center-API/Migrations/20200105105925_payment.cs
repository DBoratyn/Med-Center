using Microsoft.EntityFrameworkCore.Migrations;

namespace Med_Center_API.Migrations
{
    public partial class payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "paid",
                table: "Appointments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Appointments",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paid",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Appointments");
        }
    }
}
