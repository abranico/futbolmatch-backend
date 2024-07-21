using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CasualMatchEditProp_Players : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "Players",
                table: "Matches",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Players",
                table: "Matches");

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
