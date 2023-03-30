using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixpricetotableProductSkusdatabase5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSkuValues_ProductSkus_ProductId_Id",
                table: "ProductSkuValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSkuValues",
                table: "ProductSkuValues");

            migrationBuilder.DropIndex(
                name: "IX_ProductSkuValues_ProductId_Id",
                table: "ProductSkuValues");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductSkuValues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSkuValues",
                table: "ProductSkuValues",
                columns: new[] { "ProductId", "ProductSkuId", "OptionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSkuValues_ProductSkus_ProductId_ProductSkuId",
                table: "ProductSkuValues",
                columns: new[] { "ProductId", "ProductSkuId" },
                principalTable: "ProductSkus",
                principalColumns: new[] { "ProductId", "Id" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSkuValues_ProductSkus_ProductId_ProductSkuId",
                table: "ProductSkuValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSkuValues",
                table: "ProductSkuValues");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductSkuValues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSkuValues",
                table: "ProductSkuValues",
                columns: new[] { "ProductId", "ProductSkuId", "OptionId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSkuValues_ProductId_Id",
                table: "ProductSkuValues",
                columns: new[] { "ProductId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSkuValues_ProductSkus_ProductId_Id",
                table: "ProductSkuValues",
                columns: new[] { "ProductId", "Id" },
                principalTable: "ProductSkus",
                principalColumns: new[] { "ProductId", "Id" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
