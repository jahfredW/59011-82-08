using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace nppApplication.Migrations
{
    /// <inheritdoc />
    public partial class Discount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReductionId",
                table: "order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reductions", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    ReductionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Reductions_ReductionId",
                        column: x => x.ReductionId,
                        principalTable: "Reductions",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_order_ReductionId",
                table: "order",
                column: "ReductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ReductionId",
                table: "Discounts",
                column: "ReductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_Reductions_ReductionId",
                table: "order",
                column: "ReductionId",
                principalTable: "Reductions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_Reductions_ReductionId",
                table: "order");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Reductions");

            migrationBuilder.DropIndex(
                name: "IX_order_ReductionId",
                table: "order");

            migrationBuilder.DropColumn(
                name: "ReductionId",
                table: "order");
        }
    }
}
