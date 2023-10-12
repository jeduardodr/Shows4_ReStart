using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shows4.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEpisodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EpisodeId",
                table: "Casts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Casts_EpisodeId",
                table: "Casts",
                column: "EpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casts_Episodes_EpisodeId",
                table: "Casts",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casts_Episodes_EpisodeId",
                table: "Casts");

            migrationBuilder.DropIndex(
                name: "IX_Casts_EpisodeId",
                table: "Casts");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "EpisodeId",
                table: "Casts");
        }
    }
}
