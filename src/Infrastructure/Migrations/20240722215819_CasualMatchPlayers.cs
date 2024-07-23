using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CasualMatchPlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Matches_CasualMatchId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CasualMatchId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CasualMatchId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "CasualMatchPlayers",
                columns: table => new
                {
                    CasualMatchId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasualMatchPlayers", x => new { x.CasualMatchId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_CasualMatchPlayers_Matches_CasualMatchId",
                        column: x => x.CasualMatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasualMatchPlayers_Users_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CasualMatchPlayers_PlayersId",
                table: "CasualMatchPlayers",
                column: "PlayersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasualMatchPlayers");

            migrationBuilder.AddColumn<int>(
                name: "CasualMatchId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CasualMatchId",
                table: "Users",
                column: "CasualMatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Matches_CasualMatchId",
                table: "Users",
                column: "CasualMatchId",
                principalTable: "Matches",
                principalColumn: "Id");
        }
    }
}
