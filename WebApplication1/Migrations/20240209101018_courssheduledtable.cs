using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class courssheduledtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "CourseSchedules",
               columns: table => new
               {
                   CourseSchedulesID = table.Column<int>(type: "int", nullable: false).
                   Annotation("SqlServer:Identity", "1, 1"),
                   SheduledId = table.Column<int>(type: "int", nullable: false),
                   CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                  
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_CourseSchedules", x => x.CourseSchedulesID);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSchedules");

        }
    }
}
