using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projekt.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Furnitures",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "ImageLink" },
                values: new object[] { new DateTime(2022, 12, 31, 16, 49, 40, 688, DateTimeKind.Local).AddTicks(1830), null });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ImageLink" },
                values: new object[] { new DateTime(2022, 12, 31, 16, 49, 40, 688, DateTimeKind.Local).AddTicks(1879), null });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ImageLink" },
                values: new object[] { new DateTime(2022, 12, 31, 16, 49, 40, 688, DateTimeKind.Local).AddTicks(1889), null });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "ImageLink" },
                values: new object[] { new DateTime(2022, 12, 31, 16, 49, 40, 688, DateTimeKind.Local).AddTicks(1897), null });

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "ImageLink" },
                values: new object[] { new DateTime(2022, 12, 31, 16, 49, 40, 688, DateTimeKind.Local).AddTicks(1904), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Furnitures");

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 12, 30, 23, 58, 54, 316, DateTimeKind.Local).AddTicks(4983));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 12, 30, 23, 58, 54, 316, DateTimeKind.Local).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 12, 30, 23, 58, 54, 316, DateTimeKind.Local).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2022, 12, 30, 23, 58, 54, 316, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Furnitures",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2022, 12, 30, 23, 58, 54, 316, DateTimeKind.Local).AddTicks(5035));
        }
    }
}
