using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Address = table.Column<string>(maxLength: 60, nullable: false),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Table1s",
                columns: table => new
                {
                    KlientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table1s", x => x.KlientID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Position = table.Column<string>(maxLength: 20, nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Table2s",
                columns: table => new
                {
                    KlientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Tovar = table.Column<string>(maxLength: 30, nullable: false),
                    Money = table.Column<int>(nullable: false),
                    KlientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table2s", x => x.KlientID);
                    table.ForeignKey(
                        name: "FK_Table2s_Table1s_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Table1s",
                        principalColumn: "KlientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "IT_Solutions Ltd" },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "312 Forest Avenue, BF 923", "USA", "Admin_Solutions Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Table1s",
                columns: new[] { "KlientID", "City", "Name" },
                values: new object[,]
                {
                    { 1, "Москва", "Дубинин" },
                    { 2, "Брянск", "Иванов" },
                    { 3, "Самара", "Александров" },
                    { 4, "Калуга", "Кузнецов" },
                    { 5, "Рязань", "Пушкин" },
                    { 6, "Ульяновск", "Васькин" },
                    { 7, "Ярославль", "Бурлаков" },
                    { 8, "Архангельск", "Вертолеткин" },
                    { 9, "Вологда", "Гаспарян" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sam Raiden", "Software developer" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Jana McLeaf", "Software developer" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Kane Miller", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Table2s",
                columns: new[] { "KlientID", "Date", "KlientId", "Money", "Tovar" },
                values: new object[,]
                {
                    { 2, new DateTime(2016, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2520, "Нектарин" },
                    { 4, new DateTime(2016, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1786, "Лук" },
                    { 7, new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3068, "Морковь" },
                    { 3, new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1620, "Нектарин" },
                    { 8, new DateTime(2016, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 448, "Картофель" },
                    { 5, new DateTime(2016, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 14400, "Персик" },
                    { 1, new DateTime(2016, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 84, "Картофель" },
                    { 9, new DateTime(2016, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2590, "Картофель" },
                    { 6, new DateTime(2016, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 57, "Лук" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Table2s_KlientId",
                table: "Table2s",
                column: "KlientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Table2s");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Table1s");
        }
    }
}
