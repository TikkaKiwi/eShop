using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeOptionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionType",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "OptionType",
                table: "Fuels");

            migrationBuilder.DropColumn(
                name: "OptionType",
                table: "Colours");

            migrationBuilder.DropColumn(
                name: "OptionType",
                table: "Brands");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OptionType",
                table: "Models",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptionType",
                table: "Fuels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptionType",
                table: "Colours",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptionType",
                table: "Brands",
                type: "int",
                nullable: true);
        }
    }
}
