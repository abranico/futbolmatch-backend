using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CasualMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_AdminId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_AdminId",
                table: "Matches");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AdminId",
                table: "Matches",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_AdminId",
                table: "Matches",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
