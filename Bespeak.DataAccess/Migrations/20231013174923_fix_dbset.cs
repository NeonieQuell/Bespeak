using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bespeak.DataAccess.Migrations
{
    public partial class fix_dbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Room_RoomId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomType",
                table: "RoomType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "RoomType",
                newName: "RoomTypes");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Room_RoomTypeId",
                table: "Rooms",
                newName: "IX_Rooms_RoomTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_RoomId",
                table: "Bookings",
                newName: "IX_Bookings_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes",
                column: "RoomTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "RoomTypes",
                newName: "RoomType");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Room",
                newName: "IX_Room_RoomTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RoomId",
                table: "Booking",
                newName: "IX_Booking_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomType",
                table: "RoomType",
                column: "RoomTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Room_RoomId",
                table: "Booking",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
