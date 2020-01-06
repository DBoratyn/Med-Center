using Microsoft.EntityFrameworkCore.Migrations;

namespace Med_Center_API.Migrations
{
    public partial class newTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sicknesses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sicknessName = table.Column<string>(nullable: true),
                    sicknessDescription = table.Column<string>(nullable: true),
                    cured = table.Column<bool>(nullable: false),
                    appointmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sicknesses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dateOfVisit = table.Column<long>(nullable: false),
                    descriptionOfVisit = table.Column<string>(nullable: true),
                    appointmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sicknesses");

            migrationBuilder.DropTable(
                name: "Visits");
        }
    }
}
