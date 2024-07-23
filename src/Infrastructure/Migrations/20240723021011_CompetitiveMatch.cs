using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompetitiveMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_JoinCode",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Matches_JoinCode",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_JoinCode",
                table: "Leagues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teams_JoinCode",
                table: "Teams",
                column: "JoinCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_JoinCode",
                table: "Matches",
                column: "JoinCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_JoinCode",
                table: "Leagues",
                column: "JoinCode",
                unique: true);
        }
    }
}
