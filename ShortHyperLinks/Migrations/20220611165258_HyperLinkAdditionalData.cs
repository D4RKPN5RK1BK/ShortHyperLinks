using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortHyperLinks.Migrations
{
    public partial class HyperLinkAdditionalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clicks",
                table: "HyperLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "HyperLinks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clicks",
                table: "HyperLinks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "HyperLinks");
        }
    }
}
