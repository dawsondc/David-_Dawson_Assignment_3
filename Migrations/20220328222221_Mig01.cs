using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace David__Dawson_Assignment_3.Migrations
{
    public partial class Mig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Person",
                columns: table => new
                {
                    personID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.personID);
                });

            migrationBuilder.CreateTable(
                name: "PersonGame",
                columns: table => new
                {
                    personGameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    gameID = table.Column<int>(type: "int", nullable: false),
                    personID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGame", x => x.personGameID);
                    table.ForeignKey(
                        name: "FK_PersonGame_Game_gameID",
                        column: x => x.gameID,
                        principalTable: "Game",
                        principalColumn: "gameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonGame_Person_personID",
                        column: x => x.personID,
                        principalTable: "Person",
                        principalColumn: "personID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonGame_gameID",
                table: "PersonGame",
                column: "gameID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGame_personID",
                table: "PersonGame",
                column: "personID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonGame");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
