using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class scheduleCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseSchedules",
                columns: table => new
                {
                    SheduledId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedules", x => new { x.CourseId, x.SheduledId });
                    table.ForeignKey(
                        name: "FK_CourseSchedules_Sheduled_SheduledId",
                        column: x => x.SheduledId,
                        principalTable: "Sheduled",
                        principalColumn: "SheduledId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSchedules_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "CourseId"
                        /*,onDelete: ReferentialAction.Cascade*/);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedules_SheduledId",
                table: "CourseSchedules",
                column: "SheduledId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSchedules");
        }
    }
}
