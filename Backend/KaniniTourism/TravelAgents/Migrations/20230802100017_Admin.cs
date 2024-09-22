using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgents.Migrations
{
    public partial class Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
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
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TravelAgents",
                columns: table => new
                {
                    TravelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgencyID = table.Column<int>(type: "int", nullable: true),
                    AgencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GSTnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgents", x => x.TravelId);
                    table.ForeignKey(
                        name: "FK_TravelAgents_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "EmailId", "PasswordHash", "PasswordKey", "Role" },
                values: new object[] { 1, "admin@gmail.com", new byte[] { 26, 236, 110, 116, 42, 238, 18, 124, 62, 185, 174, 26, 118, 62, 101, 153, 238, 123, 11, 230, 120, 97, 87, 7, 200, 37, 235, 210, 96, 144, 41, 179, 133, 135, 228, 35, 208, 195, 43, 234, 45, 226, 148, 42, 62, 51, 165, 236, 203, 132, 197, 52, 137, 163, 145, 151, 23, 37, 212, 136, 48, 255, 56, 109 }, new byte[] { 164, 91, 157, 132, 24, 81, 121, 3, 42, 230, 131, 203, 66, 50, 100, 183, 120, 168, 248, 204, 122, 38, 163, 108, 254, 76, 102, 100, 133, 81, 61, 38, 2, 239, 236, 51, 53, 138, 44, 44, 4, 240, 174, 115, 26, 152, 191, 168, 79, 104, 194, 215, 141, 205, 92, 141, 54, 34, 216, 67, 43, 17, 204, 166, 55, 160, 76, 175, 180, 31, 212, 72, 6, 241, 137, 88, 199, 20, 55, 73, 38, 43, 171, 54, 105, 42, 4, 216, 243, 128, 133, 45, 170, 37, 19, 124, 149, 179, 19, 154, 88, 164, 69, 234, 160, 107, 70, 94, 3, 93, 178, 225, 233, 250, 119, 193, 119, 86, 181, 60, 205, 236, 8, 180, 60, 56, 47, 254 }, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_TravelAgents_UsersUserId",
                table: "TravelAgents",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "TravelAgents");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
