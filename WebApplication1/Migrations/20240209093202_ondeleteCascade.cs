using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class ondeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedules_Sheduled_SheduledId",
                table: "CourseSchedules");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedules_Sheduled_SheduledId",
                table: "CourseSchedules",
                column: "SheduledId",
                principalTable: "Sheduled",
                principalColumn: "SheduledId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedules_Sheduled_SheduledId",
                table: "CourseSchedules");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedules_Sheduled_SheduledId",
                table: "CourseSchedules",
                column: "SheduledId",
                principalTable: "Sheduled",
                principalColumn: "SheduledId");
        }
    }
}
