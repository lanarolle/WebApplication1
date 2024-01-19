﻿// <auto-generated />
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
    [Migration("20240118090752_dropuserid")]
    partial class dropuserid
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseCredit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("courses");
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
#pragma warning restore 612, 618
        }
    }
}
