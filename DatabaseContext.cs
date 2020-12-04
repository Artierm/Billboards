using System;
using System.Collections.Generic;
using System.Text;
using BillboardsProject.Model.Components;
using Microsoft.EntityFrameworkCore;

namespace BillboardsProject
{
    class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Billboard> Billboards { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Schedule> Schedules { get; set; }


        public DatabaseContext()
        {
            //Database.EnsureDeleted(); // удаляем бд со старой схемой
            //Database.EnsureCreated(); // создаем бд с новой схемой
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database.db");
        }
    }
}
