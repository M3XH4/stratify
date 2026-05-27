using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateBeta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 11, 48, 18, 177, DateTimeKind.Utc).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 11, 48, 18, 177, DateTimeKind.Utc).AddTicks(335));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 11, 48, 18, 177, DateTimeKind.Utc).AddTicks(336));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 11, 48, 18, 177, DateTimeKind.Utc).AddTicks(337));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 11, 40, 1, 355, DateTimeKind.Utc).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 11, 40, 1, 355, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 11, 40, 1, 355, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 27, 11, 40, 1, 355, DateTimeKind.Utc).AddTicks(4704));
        }
    }
}
