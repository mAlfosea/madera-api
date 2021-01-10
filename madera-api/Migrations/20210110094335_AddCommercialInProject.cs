using Microsoft.EntityFrameworkCore.Migrations;

namespace madera_api.Migrations
{
    public partial class AddCommercialInProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommercialId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CommercialId",
                table: "Projects",
                column: "CommercialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_CommercialId",
                table: "Projects",
                column: "CommercialId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_CommercialId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CommercialId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CommercialId",
                table: "Projects");
        }
    }
}
