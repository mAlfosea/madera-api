using Microsoft.EntityFrameworkCore.Migrations;

namespace madera_api.Migrations
{
    public partial class AddCollectionIdInProposal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "Proposal",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Proposal");
        }
    }
}
