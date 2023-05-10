using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Walker.Data.Migrations
{
    public partial class AddStatusToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservation");
        }
    }
}
