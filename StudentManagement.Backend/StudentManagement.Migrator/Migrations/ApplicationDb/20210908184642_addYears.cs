using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.Migrator.Migrations.ApplicationDb
{
    public partial class addYears : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-544c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "3b1655ed-bb62-4e19-a473-55932534802a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-546c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "85310fed-9d82-4f06-9348-1ec15c59fd52");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-554c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "377b40f7-35cb-4902-857f-ac2dd5e46695");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("12837d3d-793f-ea11-becb-5cea1d05f660"),
                column: "ConcurrencyStamp",
                value: "8bb3e6d5-c3a6-4a10-95b7-86c6b1d68f12");

            migrationBuilder.InsertData(
                schema: "settings",
                table: "SchoolYears",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("11737d3d-793f-ea11-becb-5cea1d05f660"), "2021-2022", 2021 },
                    { new Guid("21937d3d-793f-ea11-becb-5cea1d05f660"), "2022-2023", 2022 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "settings",
                table: "SchoolYears",
                keyColumn: "Id",
                keyValue: new Guid("11737d3d-793f-ea11-becb-5cea1d05f660"));

            migrationBuilder.DeleteData(
                schema: "settings",
                table: "SchoolYears",
                keyColumn: "Id",
                keyValue: new Guid("21937d3d-793f-ea11-becb-5cea1d05f660"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-544c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "9554015c-a8b1-4791-989d-423da2fecb0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-546c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "07dc2e3b-1ff4-469e-b3d1-a7dcd00fe184");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-554c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "5de2ec29-9e84-4090-a06a-e3c744858ef1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("12837d3d-793f-ea11-becb-5cea1d05f660"),
                column: "ConcurrencyStamp",
                value: "5a965e91-e264-4c08-b0e7-eec02af2a01c");
        }
    }
}
