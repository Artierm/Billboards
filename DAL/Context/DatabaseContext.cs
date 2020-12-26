using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Billboard> Billboards { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Log> Logs { get; set; }

        public  DbSet<ScheduleAndVideo> ScheduleAndVideo { get; set;}

        public DatabaseContext()
        {
           //Database.EnsureDeleted(); // удаляем бд со старой схемой
           // Database.EnsureCreated(); // создаем бд с новой схемой
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database.db");
        }
    }
}
