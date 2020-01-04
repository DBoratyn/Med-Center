using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Med_Center_API.Migrations
{
    public partial class appointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    startDate = table.Column<long>(nullable: false),
                    endDate = table.Column<long>(nullable: false),
                    allDay = table.Column<bool>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    patientName = table.Column<string>(nullable: true),
                    patientSurname = table.Column<string>(nullable: true),
                    patientaddress = table.Column<string>(nullable: true),
                    patientpesel = table.Column<string>(nullable: true),
                    specialization = table.Column<string>(nullable: true),
                    doctor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameOfTreatment = table.Column<string>(nullable: true),
                    Specialization = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    DoctorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorServices", x => x.Id);
                });

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
                    Role = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    Pesel = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "DoctorServices");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
