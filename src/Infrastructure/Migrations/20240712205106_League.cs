using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class League : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Users_AdminId",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_AdminId",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "LeagueStatus",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Leagues");

            migrationBuilder.RenameColumn(
                name: "Visibility",
                table: "Leagues",
                newName: "Private");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Private",
                table: "Leagues",
                newName: "Visibility");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Leagues",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeagueStatus",
                table: "Leagues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Leagues",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }
    }
}
