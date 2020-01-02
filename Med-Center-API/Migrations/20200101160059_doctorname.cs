using Microsoft.EntityFrameworkCore.Migrations;

namespace Med_Center_API.Migrations
{
    public partial class doctorname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "DoctorServices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "DoctorServices");
        }
    }
}
