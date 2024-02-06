﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.DataAccess;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240201064636_addcolumn")]
    partial class addcolumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.DataAccess.Models.CourseSchedules", b =>
                {
                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SheduledId")
                        .HasColumnType("int");

                    b.Property<int>("CourseSchedulesID")
                        .HasColumnType("int");

                    b.HasKey("CourseName", "SheduledId");

                    b.HasIndex("SheduledId");

                    b.ToTable("CourseSchedules");
                });

            modelBuilder.Entity("WebApplication1.DataAccess.Models.People", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StuEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentStuRegId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("StudentStuRegId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("WebApplication1.DataAccess.Models.Sheduled", b =>
                {
                    b.Property<int>("SheduledId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SheduledId"));

                    b.Property<string>("CourseName1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Coursecode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SheduledId");

                    b.HasIndex("CourseName1");

                    b.ToTable("Sheduled");
                });

            modelBuilder.Entity("WebApplication1.DataAccess.Models.Student", b =>
                {
                    b.Property<int>("StuRegId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StuRegId"));

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StuAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StuEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StuMobNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("memberSince")
                        .HasColumnType("datetime2");

                    b.Property<bool>("userRole")
                        .HasColumnType("bit");

                    b.HasKey("StuRegId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebApplication1.DataAccess.Models.StudentCourses", b =>
                {
                    b.Property<int>("StudentCoursesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentCoursesId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StuRegId")
                        .HasColumnType("int");

                    b.HasKey("StudentCoursesId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("WebApplication1.DataAccess.Models.courses", b =>
                {
                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseCredit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseName");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("WebApplication1.DataAccess.Models.CourseSchedules", b =>
                {
                    b.HasOne("WebApplication1.DataAccess.Models.courses", "Course")
                        .WithMany("CourseSchedules")
                        .HasForeignKey("CourseName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.DataAccess.Models.Sheduled", "Sheduled")
                        .WithMany("CourseSchedules")
                        .HasForeignKey("SheduledId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Sheduled");
                });

            modelBuilder.Entity("WebApplication1.DataAccess.Models.People", b =>
                {
                    b.HasOne("WebApplication1.DataAccess.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentStuRegId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WebApplication1.DataAccess.Models.Sheduled", b =>
                {
                    b.HasOne("WebApplication1.DataAccess.Models.courses", "CourseName")
                        .WithMany()
                        .HasForeignKey("CourseName1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseName");
                });

            modelBuilder.Entity("WebApplication1.DataAccess.Models.Sheduled", b =>
                {
                    b.Navigation("CourseSchedules");
                });

            modelBuilder.Entity("WebApplication1.DataAccess.Models.courses", b =>
                {
                    b.Navigation("CourseSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
