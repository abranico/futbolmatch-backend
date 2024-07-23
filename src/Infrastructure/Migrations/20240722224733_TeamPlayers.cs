using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TeamPlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersTeams_Teams_TeamsId",
                table: "PlayersTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersTeams_Users_PlayersId",
                table: "PlayersTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayersTeams",
                table: "PlayersTeams");

            migrationBuilder.RenameTable(
                name: "PlayersTeams",
                newName: "PlayerTeam");

            migrationBuilder.RenameIndex(
                name: "IX_PlayersTeams_TeamsId",
                table: "PlayerTeam",
                newName: "IX_PlayerTeam_TeamsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerTeam",
                table: "PlayerTeam",
                columns: new[] { "PlayersId", "TeamsId" });

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_JoinCode",
                table: "Leagues",
                column: "JoinCode",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Teams_TeamsId",
                table: "PlayerTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeam_Users_PlayersId",
                table: "PlayerTeam");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_JoinCode",
                table: "Leagues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerTeam",
                table: "PlayerTeam");

            migrationBuilder.RenameTable(
                name: "PlayerTeam",
                newName: "PlayersTeams");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerTeam_TeamsId",
                table: "PlayersTeams",
                newName: "IX_PlayersTeams_TeamsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayersTeams",
                table: "PlayersTeams",
                columns: new[] { "PlayersId", "TeamsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersTeams_Teams_TeamsId",
                table: "PlayersTeams",
                column: "TeamsId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersTeams_Users_PlayersId",
                table: "PlayersTeams",
                column: "PlayersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
