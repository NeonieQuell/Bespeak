using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bespeak.DataAccess.Migrations
{
    public partial class recreate_indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
