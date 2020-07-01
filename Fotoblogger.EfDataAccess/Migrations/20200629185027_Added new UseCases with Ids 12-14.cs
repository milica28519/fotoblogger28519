using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fotoblogger.EfDataAccess.Migrations
{
    public partial class AddednewUseCaseswithIds1214 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 18, 50, 26, 616, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 18, 50, 26, 616, DateTimeKind.Utc).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 18, 50, 26, 616, DateTimeKind.Utc).AddTicks(5251));

            migrationBuilder.InsertData(
                table: "UseCases",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 12, "Get Photos" },
                    { 13, "Get Photo" },
                    { 14, "Score Photo" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 18, 50, 26, 616, DateTimeKind.Utc).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 18, 50, 26, 617, DateTimeKind.Utc).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 18, 50, 26, 617, DateTimeKind.Utc).AddTicks(186));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 17, 27, 26, 97, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 17, 27, 26, 101, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 17, 27, 26, 101, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 17, 27, 26, 101, DateTimeKind.Local).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 17, 27, 26, 101, DateTimeKind.Local).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 17, 27, 26, 101, DateTimeKind.Local).AddTicks(6593));
        }
    }
}
