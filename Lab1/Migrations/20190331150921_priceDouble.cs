using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab1.Migrations
{
    public partial class priceDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "StageStarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "StageEnds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "IngamePurchases",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "IngamePurchases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "GameLaunches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "FirstGameLaunches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "CurrencyPurchases",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventId",
                table: "StageStarts");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "StageEnds");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "IngamePurchases");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "GameLaunches");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "FirstGameLaunches");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "CurrencyPurchases");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "IngamePurchases",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
