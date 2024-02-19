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


        public DbSet<CourseSchedules> CourseSchedules { get; set; }



        public DbSet<People> People { get; set; }

        //public DbSet<CourseSchedules> CourseSchedules { get; set; }

        public DbSet<Sheduled> Sheduled { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(u => u.StuRegId);
            modelBuilder.Entity<courses>()
                .HasKey(s => s.CourseName);
            modelBuilder.Entity<People>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<Sheduled>()
                .HasKey(s => s.SheduledId);
            modelBuilder.Entity<StudentCourses>()
                .HasKey(s => s.StudentCoursesId);

            /*modelBuilder.Entity<Sheduled>()
                 .HasOne(s => s.SheduledId)
                 .WithMany(u => u.)
                 .HasForeignKey<Student>(s => s.UserId);*/

            modelBuilder.Entity<CourseSchedules>()
                .HasKey(cs => cs.CourseSchedulesID);

            modelBuilder.Entity<CourseSchedules>()
                .HasOne(cs => cs.Course)
                .WithMany(s => s.CourseSchedules)
                .HasForeignKey(cs => cs.CourseName)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CourseSchedules>()
               .HasOne(cs => cs.Sheduled)
               .WithMany(s => s.CourseSchedules)
               .HasForeignKey(cs => cs.SheduledId)
               .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

        }



    }
}
