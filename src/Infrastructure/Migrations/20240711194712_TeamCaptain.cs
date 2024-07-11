using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TeamCaptain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_CaptainId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CaptainId",
                table: "Teams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teams_CaptainId",
                table: "Teams",
                column: "CaptainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_CaptainId",
                table: "Teams",
                column: "CaptainId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
