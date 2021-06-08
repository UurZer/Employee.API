using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employee.API.Migrations
{
    public partial class updateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "01523855-c94f-469e-ae25-70ba4274b817");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "422589b7-889c-4237-beec-39fcdd9548f1");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TaskTitle = table.Column<string>(nullable: true),
                    TaskDescription = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    CompleteTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "Password" },
                values: new object[] { "31a0479c-8f92-441a-9f54-3eff79a09621", 50, "Selim", "Öztekin", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "FirstName", "LastName", "Password" },
                values: new object[] { "495136f3-63de-49a9-9680-01e0bcd41a79", 50, "Oğuzhan", "Aslan", null });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompleteTime", "IsCompleted", "TaskDescription", "TaskTitle", "UserId" },
                values: new object[] { "d35ddfd6-84ef-4374-a8e1-f0454a8ad4bf", new DateTime(2021, 6, 7, 23, 47, 11, 106, DateTimeKind.Local).AddTicks(9645), true, "Code Refactor", "Code Refactor", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "31a0479c-8f92-441a-9f54-3eff79a09621");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "495136f3-63de-49a9-9680-01e0bcd41a79");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "FirstName", "LastName" },
                values: new object[] { "01523855-c94f-469e-ae25-70ba4274b817", 50, "David", "Mike" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "FirstName", "LastName" },
                values: new object[] { "422589b7-889c-4237-beec-39fcdd9548f1", 50, "Steve", "Warner" });
        }
    }
}
