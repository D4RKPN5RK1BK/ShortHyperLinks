using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShortHyperLinks.Migrations
{
    public partial class HashToLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "HyperLinks",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hash",
                table: "HyperLinks");
        }
    }
}
