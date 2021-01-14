using Microsoft.EntityFrameworkCore.Migrations;

namespace madera_api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    trait = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    unite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<double>(type: "float", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    trait = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    unite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    role = table.Column<int>(type: "int", nullable: false),
                    civility = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionModule",
                columns: table => new
                {
                    CollectionsId = table.Column<int>(type: "int", nullable: false),
                    ModulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionModule", x => new { x.CollectionsId, x.ModulesId });
                    table.ForeignKey(
                        name: "FK_CollectionModule_Collection_CollectionsId",
                        column: x => x.CollectionsId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionModule_Module_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentModule",
                columns: table => new
                {
                    ComponentsId = table.Column<int>(type: "int", nullable: false),
                    ModulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentModule", x => new { x.ComponentsId, x.ModulesId });
                    table.ForeignKey(
                        name: "FK_ComponentModule_Component_ComponentsId",
                        column: x => x.ComponentsId,
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentModule_Module_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CommercialId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_User_ClientId",
                        column: x => x.ClientId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_User_CommercialId",
                        column: x => x.CommercialId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Collection",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { 1, "Printemps" },
                    { 2, "Eté" }
                });

            migrationBuilder.InsertData(
                table: "Component",
                columns: new[] { "Id", "name", "nature", "price", "trait", "unite" },
                values: new object[,]
                {
                    { 1, "Vis", "Vis", 15.0, "Fer", "Kg" },
                    { 2, "Boulon", "Boulon", 8.0, "Fer", "Kg" }
                });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "Id", "name", "nature", "trait", "unite" },
                values: new object[,]
                {
                    { 1, "Toit en bois d'Erable", "Toit", "Bois", "M²" },
                    { 2, "Mur en bois d'Erable", "Mur", "Bois", "M²" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "civility", "email", "first_name", "last_name", "password", "phone", "role" },
                values: new object[,]
                {
                    { 1, 1, "francis@madera.fr", "Francis", "Client", "1234", "", 1 },
                    { 2, 1, "roger@madera.fr", "Roger", "Commercial", "1234", "", 2 }
                });

            migrationBuilder.InsertData(
                table: "CollectionModule",
                columns: new[] { "CollectionsId", "ModulesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ComponentModule",
                columns: new[] { "ComponentsId", "ModulesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionModule_ModulesId",
                table: "CollectionModule",
                column: "ModulesId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentModule_ModulesId",
                table: "ComponentModule",
                column: "ModulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CommercialId",
                table: "Project",
                column: "CommercialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionModule");

            migrationBuilder.DropTable(
                name: "ComponentModule");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
