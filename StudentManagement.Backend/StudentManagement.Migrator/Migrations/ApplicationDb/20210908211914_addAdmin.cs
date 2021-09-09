using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.Migrator.Migrations.ApplicationDb
{
    public partial class addAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-544c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "16283a6a-5a7d-4e15-ba97-923642faca58");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-546c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "415c0232-7541-4e38-9b5a-1bdef54f0f94");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-554c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "b1ed4617-9ce7-4ac4-bf1b-8b9ae8f84718");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("12837d3d-793f-ea11-becb-5cea1d05f660"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d118829f-bf20-4e92-a193-c8ee8d80d05f", "ADMIN", "AQAAAAEAACcQAAAAEEjYGaTgBROnY9mpeyZy6Imme/lvja+QHRHHp8f/r3kf50njFkEo9L8LoKeJP7XCEg==", "E2RDVSK6IIYBIP5OJOHTPGWZVD6NMIB6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bb3e6d5-c3a6-4a10-95b7-86c6b1d68f12", "Admin@admin.COM", "AQAAAAEAACcQAAAAELBcKuXWkiRQEYAkD/qKs9neac5hxWs3bkegIHpGLtf+zFHuKnuI3lBqkWO9TMmFAQ==", "5M2QLL65J6H6VFIS7VZETKXY27KNVVYJ" });
        }
    }
}
