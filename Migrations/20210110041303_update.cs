using Microsoft.EntityFrameworkCore.Migrations;

namespace IThong.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Capacity",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineIDNo",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EngineIDNo",
                table: "Vehicles");
        }
    }
}
