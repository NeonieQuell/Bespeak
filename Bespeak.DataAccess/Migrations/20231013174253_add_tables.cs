using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bespeak.DataAccess.Migrations
{
    public partial class add_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    RoomTypeId = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    TypeName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.RoomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    RoomTypeId = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_RoomType_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    RoomId = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    BookedBy = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RoomId",
                table: "Booking",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}
