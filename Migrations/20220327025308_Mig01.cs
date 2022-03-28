using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David__Dawson_Assignment_3.Migrations
{
    public partial class Mig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    companyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.companyID);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    gameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.gameID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyGameDevelopment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gameID = table.Column<int>(type: "int", nullable: false),
                    companyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyGameDevelopment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyGameDevelopment_Company_companyID",
                        column: x => x.companyID,
                        principalTable: "Company",
                        principalColumn: "companyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyGameDevelopment_Game_gameID",
                        column: x => x.gameID,
                        principalTable: "Game",
                        principalColumn: "gameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyGameDevelopment_companyID",
                table: "CompanyGameDevelopment",
                column: "companyID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyGameDevelopment_gameID",
                table: "CompanyGameDevelopment",
                column: "gameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyGameDevelopment");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
