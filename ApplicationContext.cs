using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BillboardsProject
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Billboard> Billboards { get; set; }
      

        public ApplicationContext()
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
