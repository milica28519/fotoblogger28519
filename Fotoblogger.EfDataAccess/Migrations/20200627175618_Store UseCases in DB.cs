using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fotoblogger.EfDataAccess.Migrations
{
    public partial class StoreUseCasesinDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UseCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCases", x => x.Id);
                    table.UniqueConstraint("AK_UseCases_Name", x => x.Name);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 19, 56, 18, 51, DateTimeKind.Local).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 19, 56, 18, 56, DateTimeKind.Local).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 19, 56, 18, 56, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 19, 56, 18, 58, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 19, 56, 18, 58, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 27, 19, 56, 18, 58, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.CreateIndex(
                name: "IX_RoleUseCase_UseCaseId",
                table: "RoleUseCase",
                column: "UseCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUseCase_UseCases_UseCaseId",
                table: "RoleUseCase",
                column: "UseCaseId",
                principalTable: "UseCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUseCase_UseCases_UseCaseId",
                table: "RoleUseCase");

            migrationBuilder.DropTable(
                name: "UseCases");

            migrationBuilder.DropIndex(
                name: "IX_RoleUseCase_UseCaseId",
                table: "RoleUseCase");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 0, 10, 16, 513, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 0, 10, 16, 516, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 0, 10, 16, 516, DateTimeKind.Local).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 0, 10, 16, 518, DateTimeKind.Local).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 0, 10, 16, 518, DateTimeKind.Local).AddTicks(3191));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 0, 10, 16, 518, DateTimeKind.Local).AddTicks(3266));
        }
    }
}
