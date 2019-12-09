using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Med_Center_API.Migrations
{
    public partial class addingPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pesel = table.Column<string>(nullable: true),
                    FileNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    GuardianNameAndSurname = table.Column<string>(nullable: true),
                    Foreign = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PostOffice = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    Education = table.Column<string>(nullable: true),
                    Employment = table.Column<string>(nullable: true),
                    DocumentNumber = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Series = table.Column<string>(nullable: true),
                    DocumentCountry = table.Column<string>(nullable: true),
                    PersonToAuthName = table.Column<string>(nullable: true),
                    PersonToAuthSurname = table.Column<string>(nullable: true),
                    PersonToAuthPesel = table.Column<string>(nullable: true),
                    PersonToAuthKinship = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
