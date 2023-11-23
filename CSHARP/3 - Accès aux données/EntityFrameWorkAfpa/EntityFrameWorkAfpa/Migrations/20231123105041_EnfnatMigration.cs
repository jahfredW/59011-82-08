using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkAfpa.Migrations
{
    /// <inheritdoc />
    public partial class EnfnatMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "nom_enfant",
                table: "enfant",
                type: "int",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldMaxLength: 25);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nom_enfant",
                table: "enfant",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 25);
        }
    }
}
