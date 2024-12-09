using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIDM_3312_Final_Project_1.Migrations
{
    /// <inheritdoc />
    public partial class FixOptionalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Teams_TeamID1",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamID1",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamID1",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Inn",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "K",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RBI",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SLG",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "team",
                table: "Players");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamID1",
                table: "Teams",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Inn",
                table: "Players",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "K",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RBI",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SLG",
                table: "Players",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "team",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamID1",
                table: "Teams",
                column: "TeamID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Teams_TeamID1",
                table: "Teams",
                column: "TeamID1",
                principalTable: "Teams",
                principalColumn: "TeamID");
        }
    }
}
