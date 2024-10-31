using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_map_reference_in_location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerLocations",
                table: "PlayerLocations");

            migrationBuilder.DropColumn(
                name: "MapId",
                table: "PlayerLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerLocations",
                table: "PlayerLocations",
                columns: new[] { "PlayerId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerLocations",
                table: "PlayerLocations");

            migrationBuilder.AddColumn<Guid>(
                name: "MapId",
                table: "PlayerLocations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerLocations",
                table: "PlayerLocations",
                column: "Id");
        }
    }
}
