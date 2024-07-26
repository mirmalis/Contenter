using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aper.Api.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavoritesPlaylist",
                table: "Channel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikedPlaylist",
                table: "Channel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WatchLaterPlaylist",
                table: "Channel",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoritesPlaylist",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "LikedPlaylist",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "WatchLaterPlaylist",
                table: "Channel");
        }
    }
}
