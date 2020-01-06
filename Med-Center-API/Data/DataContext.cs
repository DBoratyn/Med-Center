using Med_Center_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Med_Center_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users {get;set;}
        public DbSet<Patient> Patients {get;set;}
        public DbSet<DoctorService> DoctorServices {get;set;}
        public DbSet<Appointment> Appointments {get;set;}
        public DbSet<Sickness> Sicknesses {get;set;}
        public DbSet<Visit> Visits {get;set;}
    }
}