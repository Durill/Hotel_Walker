using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Walker.Data.Migrations
{
    public partial class InitRoomData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.Room Values" +
                "('Red Walker (King bed)', 1, 80, 1)," +
                "('Red Walker (Separate beds)', 2, 100, 1)," +
                "('Black Walker (King bed)', 1, 160, 1)," +
                "('Black Walker (Separate beds)', 2, 200, 1)," +
                "('Green Walker (King bed)', 1, 240, 1)," +
                "('Green Walker (Separate beds)', 2, 300, 1)," +
                "('GOLD Walker (King bed)', 1, 350, 1)," +
                "('BLACK Walker (King bed)', 1, 500, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM dbo.Room WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8)");
        }
    }
}
