using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class Seed_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2019, 11, 28, 17, 55, 39, 954, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2019, 11, 28, 17, 55, 39, 955, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "Nationality",
                columns: new[] { "Id", "Code", "CreateDate", "Deleted", "Name" },
                values: new object[] { 1, "tr", new DateTime(2019, 11, 28, 17, 55, 39, 955, DateTimeKind.Utc), false, "Türkiye" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreateDate", "Deleted", "Email", "Gender", "Name", "NationalityId", "Password", "Surname", "Username" },
                values: new object[] { 1, new DateTime(1986, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 28, 17, 55, 39, 955, DateTimeKind.Utc), false, "e.dedeoglu@gmail.com", 1, "Erçin", 1, "12345678", "Dedeoğlu", "ercin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nationality",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2019, 11, 28, 17, 42, 12, 726, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2019, 11, 28, 17, 42, 12, 727, DateTimeKind.Utc));
        }
    }
}
