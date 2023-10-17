using Microsoft.EntityFrameworkCore.Migrations;

namespace dstestproject.Storage.Migrations
{
    public partial class FixWindSpeedColumnsNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tintWindSpeed",
                table: "tblWeatherElements",
                newName: "tintWindSpeedInteger");

            migrationBuilder.AddColumn<byte>(
                name: "tintWindSpeedFractional",
                table: "tblWeatherElements",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tintWindSpeedFractional",
                table: "tblWeatherElements");

            migrationBuilder.RenameColumn(
                name: "tintWindSpeedInteger",
                table: "tblWeatherElements",
                newName: "tintWindSpeed");
        }
    }
}
