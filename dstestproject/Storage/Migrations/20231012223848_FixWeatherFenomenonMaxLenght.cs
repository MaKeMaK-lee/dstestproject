using Microsoft.EntityFrameworkCore.Migrations;

namespace dstestproject.Storage.Migrations
{
    public partial class FixWeatherFenomenonMaxLenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "szWeatherPhenomenon",
                table: "tblWeatherElements",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "szWeatherPhenomenon",
                table: "tblWeatherElements",
                type: "nvarchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
