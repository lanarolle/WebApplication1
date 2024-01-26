using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.DataAccess.Models;

namespace WebApplication1.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        //tables in the db
        public DbSet<Student> Students { get; set; }

        public DbSet<courses> courses { get; set; } 

        public DbSet<StudentCourses> StudentCourses { get;set; }

        public DbSet<People> People { get; set; }

        public DbSet<Sheduled> Sheduleds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<User>()
                 .HasKey(u => u.UserId);
             modelBuilder.Entity<Student>()
                 .HasKey(s => s.StuRegId);*/


            /* modelBuilder.Entity<Student>()
                 .HasOne(s => s.UserUser)
                 .WithOne(u => u.Student)
                 .HasForeignKey<Student>(s => s.UserId);*/
            modelBuilder.Entity<Sheduled>()
          .Property(e => e.Day)
          .HasConversion(
              v => v.ToString("yyyy-MM-dd"), // Convert DateOnly to string when saving to the database
              v => DateOnly.Parse(v)          // Convert string to DateOnly when reading from the database
          );

        }



    }
}
