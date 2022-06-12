using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortHyperLinks.Migrations
{
    public partial class RemovedIsActiveFromLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HyperLinks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HyperLinks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
