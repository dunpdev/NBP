using Microsoft.EntityFrameworkCore.Migrations;

namespace NBP2022.Data.Migrations
{
    public partial class SeedCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "Description", "FullPrice", "Level", "Name" },
                values: new object[] { 1, 1, "Learning patterns", 0f, 1, "Patterns" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
