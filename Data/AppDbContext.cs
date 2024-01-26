
using ChatApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace ChatApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // get all configuration and add in assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserSender> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}