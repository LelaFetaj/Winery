using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Winery.API.Data.Migrations
{
    public partial class Updated_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tank_Sector_SectorId",
                table: "Tank");

            migrationBuilder.AddForeignKey(
                name: "FK_Tank_Sector_SectorId",
                table: "Tank",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tank_Sector_SectorId",
                table: "Tank");

            migrationBuilder.AddForeignKey(
                name: "FK_Tank_Sector_SectorId",
                table: "Tank",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
