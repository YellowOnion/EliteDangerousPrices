using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StarSystems",
                columns: table => new
                {
                    StarName = table.Column<string>(nullable: false),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    Z = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarSystems", x => x.StarName);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    StationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StarSystemStarName = table.Column<string>(nullable: true),
                    StationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.StationId);
                    table.ForeignKey(
                        name: "FK_Station_StarSystems_StarSystemStarName",
                        column: x => x.StarSystemStarName,
                        principalTable: "StarSystems",
                        principalColumn: "StarName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commodity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Buy = table.Column<int>(nullable: false),
                    CName = table.Column<string>(nullable: true),
                    Sell = table.Column<int>(nullable: false),
                    StationId = table.Column<int>(nullable: true),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commodity_Station_StationId",
                        column: x => x.StationId,
                        principalTable: "Station",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PName = table.Column<string>(nullable: false),
                    Credit = table.Column<int>(nullable: false),
                    LocationStationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PName);
                    table.ForeignKey(
                        name: "FK_Players_Station_LocationStationId",
                        column: x => x.LocationStationId,
                        principalTable: "Station",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    IName = table.Column<string>(nullable: false),
                    PlayerPName = table.Column<string>(nullable: true),
                    Units = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.IName);
                    table.ForeignKey(
                        name: "FK_Item_Players_PlayerPName",
                        column: x => x.PlayerPName,
                        principalTable: "Players",
                        principalColumn: "PName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_StationId",
                table: "Commodity",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_PlayerPName",
                table: "Item",
                column: "PlayerPName");

            migrationBuilder.CreateIndex(
                name: "IX_Players_LocationStationId",
                table: "Players",
                column: "LocationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Station_StarSystemStarName",
                table: "Station",
                column: "StarSystemStarName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commodity");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "StarSystems");
        }
    }
}
