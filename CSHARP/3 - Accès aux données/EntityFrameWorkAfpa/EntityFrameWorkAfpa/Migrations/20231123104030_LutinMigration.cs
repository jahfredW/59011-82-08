using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkAfpa.Migrations
{
    /// <inheritdoc />
    public partial class LutinMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nom_lutin",
                table: "lutin",
                type: "varchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 25,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "nom_lutin",
                table: "lutin",
                type: "int",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldMaxLength: 25,
                oldNullable: true);
        }
    }
}
