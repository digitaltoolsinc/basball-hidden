using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseballAPI.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "TeamsTest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamsTest",
                table: "TeamsTest",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_TeamsTest_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "TeamsTest",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_TeamsTest_TeamID",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamsTest",
                table: "TeamsTest");

            migrationBuilder.RenameTable(
                name: "TeamsTest",
                newName: "Teams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
