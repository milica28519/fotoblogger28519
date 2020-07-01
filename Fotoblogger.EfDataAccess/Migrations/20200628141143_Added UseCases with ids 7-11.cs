using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fotoblogger.EfDataAccess.Migrations
{
    public partial class AddedUseCaseswithids711 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 16, 11, 42, 664, DateTimeKind.Local).AddTicks(5615));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 16, 11, 42, 668, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 16, 11, 42, 668, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.InsertData(
                table: "UseCases",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Edit Role" },
                    { 8, "Get Role" },
                    { 9, "Delete Role" },
                    { 10, "Delete Post" },
                    { 11, "Get Post" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 16, 11, 42, 668, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 16, 11, 42, 669, DateTimeKind.Local).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 16, 11, 42, 669, DateTimeKind.Local).AddTicks(182));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 23, 40, 31, 727, DateTimeKind.Local).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 23, 40, 31, 730, DateTimeKind.Local).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 23, 40, 31, 730, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 23, 40, 31, 731, DateTimeKind.Local).AddTicks(3931));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 23, 40, 31, 731, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 23, 40, 31, 731, DateTimeKind.Local).AddTicks(8409));
        }
    }
}
