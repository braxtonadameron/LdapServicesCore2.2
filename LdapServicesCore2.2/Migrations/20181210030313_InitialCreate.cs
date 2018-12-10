using Microsoft.EntityFrameworkCore.Migrations;

namespace LdapServicesCore2._2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesses",
                columns: table => new
                {
                    AccessName = table.Column<string>(nullable: false),
                    AccessDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesses", x => x.AccessName);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    ProcessName = table.Column<string>(nullable: false),
                    ProcessDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.ProcessName);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagName = table.Column<string>(nullable: false),
                    TagDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagName);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    BannerId = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BusinessAddress = table.Column<string>(nullable: true),
                    DisplayInDirectory = table.Column<bool>(nullable: false),
                    EmailNotification = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.BannerId);
                });

            migrationBuilder.CreateTable(
                name: "AssignedPriviledge",
                columns: table => new
                {
                    TagName = table.Column<string>(nullable: false),
                    AccessName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedPriviledge", x => new { x.AccessName, x.TagName });
                    table.ForeignKey(
                        name: "FK_AssignedPriviledge_Accesses_AccessName",
                        column: x => x.AccessName,
                        principalTable: "Accesses",
                        principalColumn: "AccessName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedPriviledge_Tags_TagName",
                        column: x => x.TagName,
                        principalTable: "Tags",
                        principalColumn: "TagName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorksOn",
                columns: table => new
                {
                    TagName = table.Column<string>(nullable: false),
                    ProcessName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksOn", x => new { x.ProcessName, x.TagName });
                    table.ForeignKey(
                        name: "FK_WorksOn_Processes_ProcessName",
                        column: x => x.ProcessName,
                        principalTable: "Processes",
                        principalColumn: "ProcessName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksOn_Tags_TagName",
                        column: x => x.TagName,
                        principalTable: "Tags",
                        principalColumn: "TagName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedTag",
                columns: table => new
                {
                    BannerId = table.Column<string>(nullable: false),
                    TagName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedTag", x => new { x.BannerId, x.TagName });
                    table.ForeignKey(
                        name: "FK_AssignedTag_Users_BannerId",
                        column: x => x.BannerId,
                        principalTable: "Users",
                        principalColumn: "BannerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedTag_Tags_TagName",
                        column: x => x.TagName,
                        principalTable: "Tags",
                        principalColumn: "TagName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedPriviledge_TagName",
                table: "AssignedPriviledge",
                column: "TagName");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTag_TagName",
                table: "AssignedTag",
                column: "TagName");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOn_TagName",
                table: "WorksOn",
                column: "TagName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedPriviledge");

            migrationBuilder.DropTable(
                name: "AssignedTag");

            migrationBuilder.DropTable(
                name: "WorksOn");

            migrationBuilder.DropTable(
                name: "Accesses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
