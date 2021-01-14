using Microsoft.EntityFrameworkCore.Migrations;

namespace madera_api.Migrations
{
    public partial class InitialSeed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProposalModule",
                table: "ProposalModule");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProposalModule",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProposalModule",
                table: "ProposalModule",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProposalModule_ProposalId",
                table: "ProposalModule",
                column: "ProposalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProposalModule",
                table: "ProposalModule");

            migrationBuilder.DropIndex(
                name: "IX_ProposalModule_ProposalId",
                table: "ProposalModule");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProposalModule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProposalModule",
                table: "ProposalModule",
                columns: new[] { "ProposalId", "ModuleId" });
        }
    }
}
