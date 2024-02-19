using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class craettables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCredit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.CourseName);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentCoursesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StuRegId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.StudentCoursesId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StuRegId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StuEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StuMobNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StuAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    memberSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userRole = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StuRegId);
                });

            migrationBuilder.CreateTable(
                name: "Sheduled",
                columns: table => new
                {
                    SheduledId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coursecode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheduled", x => x.SheduledId);
                    table.ForeignKey(
                        name: "FK_Sheduled_courses_CourseName",
                        column: x => x.CourseName,
                        principalTable: "courses",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StuEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentStuRegId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_People_Students_StudentStuRegId",
                        column: x => x.StudentStuRegId,
                        principalTable: "Students",
                        principalColumn: "StuRegId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSchedules",
                columns: table => new
                {
                    SheduledId = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseSchedulesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedules", x => new { x.CourseName, x.SheduledId });
                    table.ForeignKey(
                        name: "FK_CourseSchedules_Sheduled_SheduledId",
                        column: x => x.SheduledId,
                        principalTable: "Sheduled",
                        principalColumn: "SheduledId");
                    table.ForeignKey(
                        name: "FK_CourseSchedules_courses_CourseName",
                        column: x => x.CourseName,
                        principalTable: "courses",
                        principalColumn: "CourseName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedules_SheduledId",
                table: "CourseSchedules",
                column: "SheduledId");

            migrationBuilder.CreateIndex(
                name: "IX_People_StudentStuRegId",
                table: "People",
                column: "StudentStuRegId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheduled_CourseName",
                table: "Sheduled",
                column: "CourseName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSchedules");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Sheduled");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
