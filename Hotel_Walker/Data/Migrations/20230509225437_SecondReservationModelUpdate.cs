using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Walker.Data.Migrations
{
    public partial class SecondReservationModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaidDays",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidDays",
                table: "Reservation");
        }
    }
}
