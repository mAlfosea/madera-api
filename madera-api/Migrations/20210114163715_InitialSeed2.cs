using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace madera_api.Migrations
{
    public partial class InitialSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proposal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    CommercialId = table.Column<int>(type: "int", nullable: true),
                    creationdate = table.Column<byte[]>(name: "creation-date", type: "rowversion", rowVersion: true, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposal_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposal_User_CommercialId",
                        column: x => x.CommercialId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProposalModule",
                columns: table => new
                {
                    ProposalId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalModule", x => new { x.ProposalId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_ProposalModule_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProposalModule_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_CommercialId",
                table: "Proposal",
                column: "CommercialId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_ProjectId",
                table: "Proposal",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposalModule_ModuleId",
                table: "ProposalModule",
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProposalModule");

            migrationBuilder.DropTable(
                name: "Proposal");
        }
    }
}
