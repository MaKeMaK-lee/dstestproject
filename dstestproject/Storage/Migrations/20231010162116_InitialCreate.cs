using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dstestproject.Storage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblWeatherElements",
                columns: table => new
                {
                    gId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tintTemperatureInteger = table.Column<byte>(type: "tinyint", nullable: false),
                    tintTemperatureFractional = table.Column<byte>(type: "tinyint", nullable: false),
                    tintHumidityInteger = table.Column<byte>(type: "tinyint", nullable: false),
                    tintHumidityFractional = table.Column<byte>(type: "tinyint", nullable: false),
                    tintDewPointInteger = table.Column<byte>(type: "tinyint", nullable: false),
                    tintDewPointFractional = table.Column<byte>(type: "tinyint", nullable: false),
                    sintPressure = table.Column<short>(type: "smallint", nullable: false),
                    szWindDirection = table.Column<string>(type: "nvarchar", nullable: false),
                    tintWindSpeed = table.Column<byte>(type: "tinyint", nullable: false),
                    tintСloudy = table.Column<byte>(type: "tinyint", nullable: false),
                    sintCloudHeight = table.Column<short>(type: "smallint", nullable: false),
                    tintHorizontalVisibilityInteger = table.Column<byte>(type: "tinyint", nullable: false),
                    tintHorizontalVisibilityFractional = table.Column<byte>(type: "tinyint", nullable: false),
                    szWeatherPhenomenon = table.Column<string>(type: "nvarchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWeatherElements", x => x.gId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblWeatherElements");
        }
    }
}
