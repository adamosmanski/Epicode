using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {

        }

        public static readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Epicode;Trusted_Connection=True;";
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                    .HasData(
                        new Employee
                        {
                            Id = 1,
                            Name = "Jan Kowalski",
                            SuperiorId = null
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Kamil Nowak",
                            SuperiorId = 1
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Anna Mariacka",
                            SuperiorId = 1
                        },
                        new Employee
                        {
                            Id = 4,
                            Name = "Andrzej Abacki",
                            SuperiorId = 2
                        }
                );

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
