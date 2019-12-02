using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreateDate", "Deleted", "Description", "Name" },
                values: new object[] { 1, new DateTime(2019, 11, 28, 17, 42, 12, 726, DateTimeKind.Utc), false, "...", "Aşk" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreateDate", "Deleted", "Description", "Name" },
                values: new object[] { 2, new DateTime(2019, 11, 28, 17, 42, 12, 727, DateTimeKind.Utc), false, "!!!", "Meşk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
