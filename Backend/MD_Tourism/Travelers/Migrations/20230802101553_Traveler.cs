using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelers.Migrations
{
    public partial class Traveler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordKey = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Travellers",
                columns: table => new
                {
                    TravellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travellers", x => x.TravellerId);
                    table.ForeignKey(
                        name: "FK_Travellers_TravelUsers_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "TravelUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "TravelUsers",
                columns: new[] { "UserId", "EmailId", "PasswordHash", "PasswordKey", "Role" },
                values: new object[] { 1, "admin@gmail.com", new byte[] { 251, 230, 112, 15, 96, 80, 250, 116, 26, 132, 211, 207, 172, 127, 236, 235, 26, 51, 167, 30, 131, 51, 132, 26, 138, 137, 94, 198, 189, 55, 15, 76, 208, 114, 42, 78, 233, 25, 221, 100, 76, 175, 184, 248, 108, 111, 106, 178, 143, 27, 84, 228, 193, 213, 29, 242, 221, 13, 118, 52, 137, 3, 101, 25 }, new byte[] { 50, 224, 145, 157, 15, 165, 171, 82, 223, 93, 187, 124, 216, 225, 11, 61, 217, 76, 142, 104, 164, 177, 207, 210, 66, 249, 212, 106, 119, 34, 201, 163, 73, 229, 10, 242, 194, 112, 44, 125, 9, 249, 93, 119, 112, 3, 197, 155, 186, 229, 192, 178, 16, 205, 89, 115, 19, 254, 185, 93, 11, 108, 214, 131, 209, 214, 216, 47, 32, 168, 231, 206, 182, 160, 47, 80, 109, 30, 197, 243, 226, 129, 177, 146, 199, 248, 199, 47, 40, 128, 224, 62, 78, 138, 80, 166, 234, 171, 61, 193, 136, 60, 151, 209, 123, 116, 195, 27, 62, 60, 157, 7, 203, 201, 135, 15, 55, 97, 239, 138, 191, 216, 234, 140, 154, 3, 146, 14 }, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Travellers_UsersUserId",
                table: "Travellers",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travellers");

            migrationBuilder.DropTable(
                name: "TravelUsers");
        }
    }
}
