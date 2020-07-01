using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fotoblogger.EfDataAccess.Migrations
{
    public partial class AddedpropertyIsMastertoentityRoleandpropertyUseCaseIdtoentityUseCaseLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UseCaseId",
                table: "UseCaseLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsMaster",
                table: "Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsMaster" },
                values: new object[] { new DateTime(2020, 6, 29, 12, 48, 1, 541, DateTimeKind.Local).AddTicks(4926), true });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 12, 48, 1, 545, DateTimeKind.Local).AddTicks(362));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 12, 48, 1, 545, DateTimeKind.Local).AddTicks(423));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 12, 48, 1, 545, DateTimeKind.Local).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 12, 48, 1, 545, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 29, 12, 48, 1, 545, DateTimeKind.Local).AddTicks(6541));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseCaseId",
                table: "UseCaseLogs");

            migrationBuilder.DropColumn(
                name: "IsMaster",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 19, 3, 7, 712, DateTimeKind.Local).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 19, 3, 7, 716, DateTimeKind.Local).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 19, 3, 7, 716, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 19, 3, 7, 716, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 19, 3, 7, 716, DateTimeKind.Local).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 19, 3, 7, 716, DateTimeKind.Local).AddTicks(8528));
        }
    }
}
