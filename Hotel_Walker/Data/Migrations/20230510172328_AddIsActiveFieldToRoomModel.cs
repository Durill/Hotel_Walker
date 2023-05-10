using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Walker.Data.Migrations
{
    public partial class AddIsActiveFieldToRoomModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02831648-47db-4551-b5cc-c5f9c9cc2dc2", "AQAAAAEAACcQAAAAEGN4gaX9UtvCpwOV6sXt7YZxIDhlzetbxv2oQ+toJchlEtX2ZNBFeS/0xaT597F3VQ==", "b0bfb948-45b2-4a1d-becc-2c9688209e5e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Room");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6b0af7a-84d1-404b-9714-617303671d10", "AQAAAAEAACcQAAAAEBfs6gfoNXB7W7WraqemV22/ozehXk9bXUX8S6DCXAQZ7zNsTTudmIpjZvPR9m/B1w==", "7ce0a7dd-74a1-4d1d-8d52-82b0f4ca8514" });
        }
    }
}
