using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class changepk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedules_courses_CourseId",
                table: "CourseSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheduled_courses_CourseNameCourseId",
                table: "Sheduled");

            migrationBuilder.DropIndex(
                name: "IX_Sheduled_CourseNameCourseId",
                table: "Sheduled");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSchedules",
                table: "CourseSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courses",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseSchedules");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "courses");

          

            migrationBuilder.AddColumn<string>(
                name: "CourseName1",
                table: "Sheduled",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "CourseSchedules",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "courses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSchedules",
                table: "CourseSchedules",
                columns: new[] { "CourseName", "SheduledId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_courses",
                table: "courses",
                column: "CourseName");

            migrationBuilder.CreateIndex(
                name: "IX_Sheduled_CourseName1",
                table: "Sheduled",
                column: "CourseName1");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedules_courses_CourseName",
                table: "CourseSchedules",
                column: "CourseName",
                principalTable: "courses",
                principalColumn: "CourseName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheduled_courses_CourseName1",
                table: "Sheduled",
                column: "CourseName1",
                principalTable: "courses",
                principalColumn: "CourseName",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedules_courses_CourseName",
                table: "CourseSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheduled_courses_CourseName1",
                table: "Sheduled");

            migrationBuilder.DropIndex(
                name: "IX_Sheduled_CourseName1",
                table: "Sheduled");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSchedules",
                table: "CourseSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courses",
                table: "courses");

           

            migrationBuilder.DropColumn(
                name: "CourseName1",
                table: "Sheduled");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "CourseSchedules");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "CourseSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "courses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSchedules",
                table: "CourseSchedules",
                columns: new[] { "CourseId", "SheduledId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_courses",
                table: "courses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheduled_CourseNameCourseId",
                table: "Sheduled",
                column: "CourseNameCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedules_courses_CourseId",
                table: "CourseSchedules",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheduled_courses_CourseNameCourseId",
                table: "Sheduled",
                column: "CourseNameCourseId",
                principalTable: "courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
