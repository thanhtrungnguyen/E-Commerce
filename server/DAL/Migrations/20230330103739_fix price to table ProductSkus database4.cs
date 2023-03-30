using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixpricetotableProductSkusdatabase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSkuValues",
                table: "ProductSkuValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSkuValues",
                table: "ProductSkuValues",
                columns: new[] { "ProductId", "ProductSkuId", "OptionId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSkuValues",
                table: "ProductSkuValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSkuValues",
                table: "ProductSkuValues",
                columns: new[] { "ProductId", "ProductSkuId", "OptionId" });
        }
    }
}
