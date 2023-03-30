using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixpricetotableProductSkusdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductSkuValues");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ProductSkus",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductSkus");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ProductSkuValues",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
