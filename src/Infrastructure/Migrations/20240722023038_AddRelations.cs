using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Players",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "Admin",
                table: "Matches",
                newName: "AdminId");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "CasualMatchId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CasualMatchId",
                table: "Users",
                column: "CasualMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CaptainId",
                table: "Teams",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AdminId",
                table: "Matches",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_AdminId",
                table: "Leagues",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Users_AdminId",
                table: "Leagues",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_AdminId",
                table: "Matches",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_CaptainId",
                table: "Teams",
                column: "CaptainId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Matches_CasualMatchId",
                table: "Users",
                column: "CasualMatchId",
                principalTable: "Matches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Users_AdminId",
                table: "Leagues");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_AdminId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_CaptainId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Matches_CasualMatchId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CasualMatchId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CaptainId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Matches_AdminId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_AdminId",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "CasualMatchId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Matches",
                newName: "Admin");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Players",
                table: "Matches",
                type: "TEXT",
                nullable: true);
        }
    }
}
