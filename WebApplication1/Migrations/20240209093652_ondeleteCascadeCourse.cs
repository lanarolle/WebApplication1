using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class ondeleteCascadeCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedules_courses_CourseName",
                table: "CourseSchedules");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedules_courses_CourseName",
                table: "CourseSchedules",
                column: "CourseName",
                principalTable: "courses",
                principalColumn: "CourseName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedules_courses_CourseName",
                table: "CourseSchedules");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedules_courses_CourseName",
                table: "CourseSchedules",
                column: "CourseName",
                principalTable: "courses",
                principalColumn: "CourseName");
        }
    }
}
