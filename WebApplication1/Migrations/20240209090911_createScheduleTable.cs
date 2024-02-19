using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class createScheduleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sheduled_courses_CourseName",
                table: "Sheduled");

            migrationBuilder.DropIndex(
                name: "IX_Sheduled_CourseName",
                table: "Sheduled");

            migrationBuilder.DropColumn(
                name: "Coursecode",
                table: "Sheduled");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Sheduled",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Sheduled",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Coursecode",
                table: "Sheduled",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sheduled_CourseName",
                table: "Sheduled",
                column: "CourseName");

            migrationBuilder.AddForeignKey(
                name: "FK_Sheduled_courses_CourseName",
                table: "Sheduled",
                column: "CourseName",
                principalTable: "courses",
                principalColumn: "CourseName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
