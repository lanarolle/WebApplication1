using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class sheduled3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Sheduled",
                columns: table => new
                {
                    SheduledId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseNameCourseId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheduled", x => x.SheduledId);
                    table.ForeignKey(
                        name: "FK_Sheduled_courses_CourseNameCourseId",
                        column: x => x.CourseNameCourseId,
                        principalTable: "courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sheduled_CourseNameCourseId",
                table: "Sheduled",
                column: "CourseNameCourseId");
        }

    

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sheduled");

        }
    }
}
