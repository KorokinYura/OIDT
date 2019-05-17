using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyPurchases",
                columns: table => new
                {
                    UdId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Income = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyPurchases", x => x.UdId);
                });

            migrationBuilder.CreateTable(
                name: "FirstGameLaunches",
                columns: table => new
                {
                    UdId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstGameLaunches", x => x.UdId);
                });

            migrationBuilder.CreateTable(
                name: "GameLaunches",
                columns: table => new
                {
                    UdId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameLaunches", x => x.UdId);
                });

            migrationBuilder.CreateTable(
                name: "IngamePurchases",
                columns: table => new
                {
                    UdId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngamePurchases", x => x.UdId);
                });

            migrationBuilder.CreateTable(
                name: "StageEnds",
                columns: table => new
                {
                    UdId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Stage = table.Column<int>(nullable: false),
                    Win = table.Column<bool>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Income = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageEnds", x => x.UdId);
                });

            migrationBuilder.CreateTable(
                name: "StageStarts",
                columns: table => new
                {
                    UdId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Stage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageStarts", x => x.UdId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyPurchases");

            migrationBuilder.DropTable(
                name: "FirstGameLaunches");

            migrationBuilder.DropTable(
                name: "GameLaunches");

            migrationBuilder.DropTable(
                name: "IngamePurchases");

            migrationBuilder.DropTable(
                name: "StageEnds");

            migrationBuilder.DropTable(
                name: "StageStarts");
        }
    }
}
