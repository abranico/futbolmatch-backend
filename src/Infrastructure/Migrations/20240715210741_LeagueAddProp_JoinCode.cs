using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LeagueAddProp_JoinCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Private",
                table: "Leagues");

            migrationBuilder.AddColumn<string>(
                name: "JoinCode",
                table: "Leagues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinCode",
                table: "Leagues");

            migrationBuilder.AddColumn<bool>(
                name: "Private",
                table: "Leagues",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
