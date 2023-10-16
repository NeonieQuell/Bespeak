using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bespeak.DataAccess.Migrations
{
    public partial class add_property_in_bookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateBooked",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBooked",
                table: "Bookings");
        }
    }
}
