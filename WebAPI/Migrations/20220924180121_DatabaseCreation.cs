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
                    GroupID = table.Column<string>(nullable: false),
                    Starosta = table.Column<string>(maxLength: 100, nullable: false),
                    Fakultet = table.Column<string>(maxLength: 20, nullable: false),
                    Kurator = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table1s", x => x.GroupID);
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
                    StudentID = table.Column<string>(nullable: false),
                    FamilyName = table.Column<string>(maxLength: 30, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    GroupID = table.Column<string>(nullable: true),
                    Table1sId = table.Column<Guid>(nullable: true),
                    Table1Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table2s", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Table2s_Table1s_Table1Id",
                        column: x => x.Table1Id,
                        principalTable: "Table1s",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Table2s_Companies_Table1sId",
                        column: x => x.Table1sId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "GroupID", "Fakultet", "Kurator", "Starosta" },
                values: new object[,]
                {
                    { "101", "ФДП", "Хохлова Наталья Николавена ", "Гузнова Анастасия" },
                    { "201", "ФДП", "Бородулин Никита Дмитриевич", "Шашкин Сергей Дмитриевич" },
                    { "301", "ФДП", "Шумкин Александр Николаевич", "Юров Данила Алексеевич" }
                });

            migrationBuilder.InsertData(
                table: "Table2s",
                columns: new[] { "StudentID", "FamilyName", "GroupID", "Name", "Table1Id", "Table1sId" },
                values: new object[,]
                {
                    { "101_1", "Фиксина", "101", "Кристина", null, null },
                    { "101_2", "Котова", "101", "Евгения", null, null },
                    { "201_1", "Кто-тов", "201", "Кто-то", null, null },
                    { "201_2", "Зузин", "201", "Михаил", null, null },
                    { "301_1", "Крюкин", "301", "Евгений", null, null },
                    { "301_2", "Данилов", "301", "Алексей", null, null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sam Raiden", "Software developer" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Jana McLeaf", "Software developer" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Kane Miller", "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Table2s_Table1Id",
                table: "Table2s",
                column: "Table1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Table2s_Table1sId",
                table: "Table2s",
                column: "Table1sId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Table2s");

            migrationBuilder.DropTable(
                name: "Table1s");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
