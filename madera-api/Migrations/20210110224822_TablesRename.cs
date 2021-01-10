using Microsoft.EntityFrameworkCore.Migrations;

namespace madera_api.Migrations
{
    public partial class TablesRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionModule_Collections_CollectionsId",
                table: "CollectionModule");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionModule_Modules_ModulesId",
                table: "CollectionModule");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentModule_Components_ComponentsId",
                table: "ComponentModule");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentModule_Modules_ModulesId",
                table: "ComponentModule");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_ClientId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_CommercialId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Components",
                table: "Components");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collections",
                table: "Collections");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "Module");

            migrationBuilder.RenameTable(
                name: "Components",
                newName: "Component");

            migrationBuilder.RenameTable(
                name: "Collections",
                newName: "Collection");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_CommercialId",
                table: "Project",
                newName: "IX_Project_CommercialId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ClientId",
                table: "Project",
                newName: "IX_Project_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module",
                table: "Module",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Component",
                table: "Component",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collection",
                table: "Collection",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionModule_Collection_CollectionsId",
                table: "CollectionModule",
                column: "CollectionsId",
                principalTable: "Collection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionModule_Module_ModulesId",
                table: "CollectionModule",
                column: "ModulesId",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentModule_Component_ComponentsId",
                table: "ComponentModule",
                column: "ComponentsId",
                principalTable: "Component",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentModule_Module_ModulesId",
                table: "ComponentModule",
                column: "ModulesId",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_CommercialId",
                table: "Project",
                column: "CommercialId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionModule_Collection_CollectionsId",
                table: "CollectionModule");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionModule_Module_ModulesId",
                table: "CollectionModule");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentModule_Component_ComponentsId",
                table: "ComponentModule");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentModule_Module_ModulesId",
                table: "ComponentModule");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_ClientId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_CommercialId",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module",
                table: "Module");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Component",
                table: "Component");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collection",
                table: "Collection");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "Module",
                newName: "Modules");

            migrationBuilder.RenameTable(
                name: "Component",
                newName: "Components");

            migrationBuilder.RenameTable(
                name: "Collection",
                newName: "Collections");

            migrationBuilder.RenameIndex(
                name: "IX_Project_CommercialId",
                table: "Projects",
                newName: "IX_Projects_CommercialId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ClientId",
                table: "Projects",
                newName: "IX_Projects_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                table: "Modules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Components",
                table: "Components",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collections",
                table: "Collections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionModule_Collections_CollectionsId",
                table: "CollectionModule",
                column: "CollectionsId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionModule_Modules_ModulesId",
                table: "CollectionModule",
                column: "ModulesId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentModule_Components_ComponentsId",
                table: "ComponentModule",
                column: "ComponentsId",
                principalTable: "Components",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentModule_Modules_ModulesId",
                table: "ComponentModule",
                column: "ModulesId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ClientId",
                table: "Projects",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_CommercialId",
                table: "Projects",
                column: "CommercialId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
