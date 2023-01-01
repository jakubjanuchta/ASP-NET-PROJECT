using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projekt.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Furnitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Furnitures",
                columns: new[] { "Id", "Created", "Label", "ProductionDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 30, 23, 58, 54, 316, DateTimeKind.Local).AddTicks(4983), "ASP.NET 6.0.0", new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 12, 30, 23, 58, 54, 316, DateTimeKind.Local).AddTicks(5021), "C# 10.0", new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 12, 30, 23, 58, 54, 316, DateTimeKind.Local).AddTicks(5025), "Java 19", new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 12, 30, 23, 58, 54, 316, DateTimeKind.Local).AddTicks(5030), "JavaScript", new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 12, 30, 23, 58, 54, 316, DateTimeKind.Local).AddTicks(5035), "Node.js", new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Furnitures");
        }
    }
}
