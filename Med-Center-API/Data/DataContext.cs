using Med_Center_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Med_Center_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users {get;set;}
    }
}