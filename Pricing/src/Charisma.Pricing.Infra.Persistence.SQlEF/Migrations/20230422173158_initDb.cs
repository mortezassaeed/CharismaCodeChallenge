using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charisma.Pricing.Infra.Persistence.SQlEF.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pricing");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Pricing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Base_Price_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Base_Price_CurrencyType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPricing",
                schema: "Pricing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Final_Price_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Final_Price_CurrencyType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Actual_Price_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Actual_Price_CurrencyType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPricing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPricing_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Pricing",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_ProductId",
                schema: "Pricing",
                table: "ProductPricing",
                column: "ProductId");

			migrationBuilder.InsertData(
				table: "Product",
				schema: "Pricing",
				columns: new[] { "ProductCode", "Base_Price_Amount", "Base_Price_CurrencyType" },
				values: new object[] { "P_1", 10000, "IRR" });

			migrationBuilder.InsertData(
				table: "Product",
				schema: "Pricing",
				columns: new[] { "ProductCode", "Base_Price_Amount", "Base_Price_CurrencyType" },
				values: new object[] { "P_2", 20000, "IRR" });
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPricing",
                schema: "Pricing");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Pricing");
        }
    }
}
