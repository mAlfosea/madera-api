using Microsoft.EntityFrameworkCore.Migrations;

namespace madera_api.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "civility", "email", "first_name", "last_name", "password", "phone", "role" },
                values: new object[] { 1, 1, "francis@madera.fr", "Francis", "Client", "1234", "", 1 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "civility", "email", "first_name", "last_name", "password", "phone", "role" },
                values: new object[] { 2, 1, "roger@madera.fr", "Roger", "Commercial", "1234", "", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
