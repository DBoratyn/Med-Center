﻿// <auto-generated />
using System;
using Med_Center_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Med_Center_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Med_Center_API.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NameOfTreatment");

                    b.Property<bool>("allDay");

                    b.Property<string>("description");

                    b.Property<string>("doctor");

                    b.Property<long>("endDate");

                    b.Property<bool>("paid");

                    b.Property<string>("patientName");

                    b.Property<string>("patientSurname");

                    b.Property<string>("patientaddress");

                    b.Property<string>("patientpesel");

                    b.Property<double>("price");

                    b.Property<string>("specialization");

                    b.Property<long>("startDate");

                    b.Property<string>("text");

                    b.HasKey("Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Med_Center_API.Models.DoctorService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DoctorName");

                    b.Property<string>("NameOfTreatment");

                    b.Property<double>("Price");

                    b.Property<string>("Specialization");

                    b.HasKey("Id");

                    b.ToTable("DoctorServices");
                });

            modelBuilder.Entity("Med_Center_API.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApartmentNumber");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("DocumentCountry");

                    b.Property<string>("DocumentNumber");

                    b.Property<string>("Education");

                    b.Property<string>("Email");

                    b.Property<string>("Employment");

                    b.Property<string>("FileNumber");

                    b.Property<string>("Foreign");

                    b.Property<string>("Gender");

                    b.Property<string>("GuardianNameAndSurname");

                    b.Property<string>("HouseNumber");

                    b.Property<string>("Name");

                    b.Property<string>("PersonToAuthKinship");

                    b.Property<string>("PersonToAuthName");

                    b.Property<string>("PersonToAuthPesel");

                    b.Property<string>("PersonToAuthSurname");

                    b.Property<string>("Pesel");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PlaceOfBirth");

                    b.Property<string>("PostOffice");

                    b.Property<string>("Profession");

                    b.Property<string>("SecondName");

                    b.Property<string>("Series");

                    b.Property<string>("Street");

                    b.Property<string>("Surname");

                    b.Property<string>("Type");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Med_Center_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("HouseNumber");

                    b.Property<string>("Name");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Pesel");

                    b.Property<string>("PlaceOfBirth");

                    b.Property<string>("Profession");

                    b.Property<string>("Role");

                    b.Property<string>("SecondName");

                    b.Property<string>("Street");

                    b.Property<string>("Surname");

                    b.Property<string>("Username");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
