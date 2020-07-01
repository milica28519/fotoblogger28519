using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fotoblogger.EfDataAccess.Migrations
{
    public partial class ChangedUseCaseswithIds3234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 1, 10, 20, 53, 115, DateTimeKind.Utc).AddTicks(2835));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 1, 10, 20, 53, 115, DateTimeKind.Utc).AddTicks(3917));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 1, 10, 20, 53, 115, DateTimeKind.Utc).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Comment Vote");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Remove Comment Vote");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Get Use Case Logs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsActive" },
                values: new object[] { new DateTime(2020, 7, 1, 10, 20, 53, 115, DateTimeKind.Utc).AddTicks(6082), true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsActive" },
                values: new object[] { new DateTime(2020, 7, 1, 10, 20, 53, 115, DateTimeKind.Utc).AddTicks(9034), true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsActive" },
                values: new object[] { new DateTime(2020, 7, 1, 10, 20, 53, 115, DateTimeKind.Utc).AddTicks(9121), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 1, 7, 57, 57, 574, DateTimeKind.Utc).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 1, 7, 57, 57, 574, DateTimeKind.Utc).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 1, 7, 57, 57, 574, DateTimeKind.Utc).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Upvote Comment");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Downvote Comment");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Remove Vote From Comment");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsActive" },
                values: new object[] { new DateTime(2020, 7, 1, 7, 57, 57, 574, DateTimeKind.Utc).AddTicks(7091), true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsActive" },
                values: new object[] { new DateTime(2020, 7, 1, 7, 57, 57, 574, DateTimeKind.Utc).AddTicks(9866), true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsActive" },
                values: new object[] { new DateTime(2020, 7, 1, 7, 57, 57, 574, DateTimeKind.Utc).AddTicks(9937), true });
        }
    }
}
