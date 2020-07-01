using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fotoblogger.EfDataAccess.Migrations
{
    public partial class ChangedUseCaseswithIds1620 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 30, 13, 15, 18, 366, DateTimeKind.Utc).AddTicks(1951));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 30, 13, 15, 18, 366, DateTimeKind.Utc).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 30, 13, 15, 18, 366, DateTimeKind.Utc).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Add Post Comment");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Edit Post Comment");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Delete Post Comment");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Get Post Comments");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Get Post Comment Replies");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 30, 13, 15, 18, 366, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 30, 13, 15, 18, 366, DateTimeKind.Utc).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 30, 13, 15, 18, 366, DateTimeKind.Utc).AddTicks(7829));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 22, 50, 0, 693, DateTimeKind.Utc).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 22, 50, 0, 693, DateTimeKind.Utc).AddTicks(5569));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 22, 50, 0, 693, DateTimeKind.Utc).AddTicks(5596));

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Add Comment");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Edit Comment");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Delete Comment");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Get Comment");

            migrationBuilder.UpdateData(
                table: "UseCases",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Get Comments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 22, 50, 0, 693, DateTimeKind.Utc).AddTicks(7397));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 22, 50, 0, 694, DateTimeKind.Utc).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 22, 50, 0, 694, DateTimeKind.Utc).AddTicks(1434));
        }
    }
}
