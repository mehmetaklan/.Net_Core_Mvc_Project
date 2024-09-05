using Microsoft.EntityFrameworkCore.Migrations;

namespace Departman_Management.Migrations
{
    public partial class RemoveCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "departments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
