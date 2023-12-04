using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace drone_appli.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pilote",
                columns: table => new
                {
                    Id_Pilote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    prenom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Pilote);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "type_drone",
                columns: table => new
                {
                    Id_Type_Drone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    intitule = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Type_Drone);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "drone",
                columns: table => new
                {
                    Id_Drone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    prix = table.Column<decimal>(type: "decimal(15,2)", precision: 15, nullable: true),
                    Id_Type_Drone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_Drone);
                    table.ForeignKey(
                        name: "FK_DRONE_TYPE",
                        column: x => x.Id_Type_Drone,
                        principalTable: "type_drone",
                        principalColumn: "Id_Type_Drone");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "session",
                columns: table => new
                {
                    Id_Drone = table.Column<int>(type: "int", nullable: false),
                    Id_Pilote = table.Column<int>(type: "int", nullable: false),
                    Id_session = table.Column<int>(type: "int", nullable: false),
                    Date_session = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Id_Drone, x.Id_Pilote });
                    table.ForeignKey(
                        name: "FK_SESSION_DRONE",
                        column: x => x.Id_Drone,
                        principalTable: "drone",
                        principalColumn: "Id_Drone");
                    table.ForeignKey(
                        name: "FK_SESSION_PILOTE",
                        column: x => x.Id_Pilote,
                        principalTable: "pilote",
                        principalColumn: "Id_Pilote");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "FK_DRONE_TYPE",
                table: "drone",
                column: "Id_Type_Drone");

            migrationBuilder.CreateIndex(
                name: "FK_SESSION_PILOTE",
                table: "session",
                column: "Id_Pilote");

            migrationBuilder.CreateIndex(
                name: "Id_session",
                table: "session",
                column: "Id_session",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "session");

            migrationBuilder.DropTable(
                name: "drone");

            migrationBuilder.DropTable(
                name: "pilote");

            migrationBuilder.DropTable(
                name: "type_drone");
        }
    }
}
