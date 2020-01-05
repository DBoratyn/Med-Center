using Microsoft.EntityFrameworkCore.Migrations;

namespace Med_Center_API.Migrations
{
    public partial class nameoftreatment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameOfTreatment",
                table: "Appointments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOfTreatment",
                table: "Appointments");
        }
    }
}
