using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Walker.Data.Migrations
{
    public partial class addAcceptanceAndCancelationStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Reservation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Reservation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6b0af7a-84d1-404b-9714-617303671d10", "AQAAAAEAACcQAAAAEBfs6gfoNXB7W7WraqemV22/ozehXk9bXUX8S6DCXAQZ7zNsTTudmIpjZvPR9m/B1w==", "7ce0a7dd-74a1-4d1d-8d52-82b0f4ca8514" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Reservation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ca049b9-a24d-4097-811f-04e438a24880", "AQAAAAEAACcQAAAAEDl9w5na/FR37X/Auh7TS2NwbR36P2YLsEMnKdVa1G3m/7M7O3W8mWe8ESRs5RCTAw==", "1ad8c1be-0d60-48c3-bfd4-30b6868020f6" });
        }
    }
}
