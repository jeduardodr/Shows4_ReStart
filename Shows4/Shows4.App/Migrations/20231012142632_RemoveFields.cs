using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shows4.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Remove Serie
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Seasons_SeasonId",
                table: "Series");
            //--
            migrationBuilder.DropIndex(
                name: "IX_Series_SeasonId",
                table: "Series");
            //--
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Series");
            //-
            migrationBuilder.DropColumn(
                name: "RatingGlobal",
                table: "Series");
            //-
            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Series");
            //Remove de Season-----------------------------
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Episodes_EpisodeId",
                table: "Seasons");
            //-
            migrationBuilder.DropIndex(
                name: "IX_Seasons_EpisodeId",
                table: "Seasons");
            //-
            migrationBuilder.DropColumn(
               name: "Rating",
               table: "Seasons");
            //-
            migrationBuilder.DropColumn(
                name: "RatingGlobal",
                table: "Seasons");
            //-
            migrationBuilder.DropColumn(
                name: "EpisodeId",
                table: "Seasons");
            //Remove de Episode------------
           
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Episodes");
            //-
            migrationBuilder.DropColumn(
                name: "RatingGlobal",
                table: "Episodes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
