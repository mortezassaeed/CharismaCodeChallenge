using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Charisma.Submission.Infra.SQLEF.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Submission");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Submission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderSubmission",
                schema: "Submission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmissionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderSubmission_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Submission",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Submission",
                table: "Products",
                columns: new[] { "Id", "ProductCode", "Type" },
                values: new object[,]
                {
                    { 1, "P_1", "Normal" },
                    { 2, "P_2", "Breakable" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderSubmission_ProductId",
                schema: "Submission",
                table: "OrderSubmission",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderSubmission",
                schema: "Submission");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Submission");
        }
    }
}
