using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageAPI.Migrations
{
    public partial class Package : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    PicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    packageId = table.Column<int>(type: "int", nullable: false),
                    PicUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.PicId);
                });

            migrationBuilder.CreateTable(
                name: "Tourpackages",
                columns: table => new
                {
                    packageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: true),
                    destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    No_Days = table.Column<int>(type: "int", nullable: true),
                    No_Nights = table.Column<int>(type: "int", nullable: true),
                    FoodIncluded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccommodationIncluded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    available = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Places = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourpackages", x => x.packageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "Tourpackages");
        }
    }
}
