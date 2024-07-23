using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TeamPlayersForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Teams_TeamsId",
                table: "PlayerTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Users_PlayersId",
                table: "PlayerTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTeam",
                table: "PlayerTeam");

            migrationBuilder.RenameTable(
                name: "PlayerTeam",
                newName: "TeamPlayers");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTeam_TeamsId",
                table: "TeamPlayers",
                newName: "IX_TeamPlayers_TeamsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamPlayers",
                table: "TeamPlayers",
                columns: new[] { "PlayersId", "TeamsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayers_Teams_TeamsId",
                table: "TeamPlayers",
                column: "TeamsId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayers_Users_PlayersId",
                table: "TeamPlayers",
                column: "PlayersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayers_Teams_TeamsId",
                table: "TeamPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayers_Users_PlayersId",
                table: "TeamPlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamPlayers",
                table: "TeamPlayers");

            migrationBuilder.RenameTable(
                name: "TeamPlayers",
                newName: "PlayerTeam");

            migrationBuilder.RenameIndex(
                name: "IX_TeamPlayers_TeamsId",
                table: "PlayerTeam",
                newName: "IX_PlayerTeam_TeamsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTeam",
                table: "PlayerTeam",
                columns: new[] { "PlayersId", "TeamsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeam_Teams_TeamsId",
                table: "PlayerTeam",
                column: "TeamsId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeam_Users_PlayersId",
                table: "PlayerTeam",
                column: "PlayersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
