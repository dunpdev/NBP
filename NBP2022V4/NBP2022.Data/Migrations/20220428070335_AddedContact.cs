using Microsoft.EntityFrameworkCore.Migrations;

namespace NBP2022.Data.Migrations
{
    public partial class AddedContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactAddress",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactAddress",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Authors");
        }
    }
}
