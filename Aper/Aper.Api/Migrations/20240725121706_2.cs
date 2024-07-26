using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aper.Api.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Channel",
                newName: "UploadsPlaylistId");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Channel",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Handle",
                table: "Channel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Since",
                table: "Channel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Channel",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "Handle",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "Since",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Channel");

            migrationBuilder.RenameColumn(
                name: "UploadsPlaylistId",
                table: "Channel",
                newName: "Name");
        }
    }
}
