using Employee.API.DataAccess.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Employee.DataAccessLayer.DBContexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Task> Tasks { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data

            
            modelBuilder.Entity<Employee>().HasKey(e => new { e.Id });
            modelBuilder.Entity<Task>().HasKey(e => new { e.Id });

            Console.WriteLine("Seeding data to Employee table");

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    FirstName = "Selim",
                    LastName = "Öztekin",
                    Age = 50
                },
               new Employee
               {
                   FirstName = "Oğuzhan",
                   LastName = "Aslan",
                   Age = 50
               }
               );

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    UserId = "1",
                    TaskTitle="Code Refactor",
                    IsCompleted = true,
                    CompleteTime =DateTime.Now,
                    TaskDescription= "Code Refactor"
                }
               );



            base.OnModelCreating(modelBuilder);
        }
    }
}
