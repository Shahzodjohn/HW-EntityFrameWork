using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstStep.Новая_папка
{
    class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {

        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=WIN-5RSC18PG333\SQLEXPRESS;Initial catalog=Bank; Integrated security = true");
        }


    }
}
