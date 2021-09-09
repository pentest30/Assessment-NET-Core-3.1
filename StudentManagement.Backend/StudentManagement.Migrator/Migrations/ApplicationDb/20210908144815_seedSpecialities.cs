using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.Migrator.Migrations.ApplicationDb
{
    public partial class seedSpecialities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "hr",
                table: "Students",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                schema: "settings",
                table: "Specialities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("11837d3d-793f-ea11-becb-5cea1d05f660"), "Computer science", "Computer science" },
                    { new Guid("21837d3d-793f-ea11-becb-5cea1d05f660"), "Medecine", "Medecine" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "settings",
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("11837d3d-793f-ea11-becb-5cea1d05f660"));

            migrationBuilder.DeleteData(
                schema: "settings",
                table: "Specialities",
                keyColumn: "Id",
                keyValue: new Guid("21837d3d-793f-ea11-becb-5cea1d05f660"));

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "hr",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-544c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "beaa4716-dc3f-4fd3-8701-136e400e80b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-546c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "3fe285da-f72c-479d-ae8f-963701fcd93e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b512f030-554c-eb11-9ce0-a4c3f0d0208b"),
                column: "ConcurrencyStamp",
                value: "9fe6cf7a-ff60-41e2-a5b1-3b958593818d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("12837d3d-793f-ea11-becb-5cea1d05f660"),
                column: "ConcurrencyStamp",
                value: "0cc8f036-ae51-4679-ac89-810f17f21d98");
        }
    }
}
