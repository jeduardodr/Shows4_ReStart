using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shows4.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Seasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Episodes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Seasons_SeasonId",
                table: "Episodes",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Seasons_SeasonId",
                table: "Episodes");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Episodes");
        }
    }
}
