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
                    GroupID = table.Column<string>(nullable: false),
                    Starosta = table.Column<string>(maxLength: 100, nullable: false),
                    Fakultet = table.Column<string>(maxLength: 20, nullable: false),
                    Kurator = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    StudentID = table.Column<string>(nullable: false),
                    FamilyName = table.Column<string>(maxLength: 30, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    GroupID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Companies",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "GroupID", "Fakultet", "Kurator", "Starosta" },
                values: new object[] { "101", "ФДП", "Хохлова Наталья Николавена ", "Гузнова Анастасия" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "GroupID", "Fakultet", "Kurator", "Starosta" },
                values: new object[] { "201", "ФДП", "Бородулин Никита Дмитриевич", "Шашкин Сергей Дмитриевич" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "GroupID", "Fakultet", "Kurator", "Starosta" },
                values: new object[] { "301", "ФДП", "Шумкин Александр Николаевич", "Юров Данила Алексеевич" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "StudentID", "FamilyName", "GroupID", "Name" },
                values: new object[,]
                {
                    { "101_1", "Фиксина", "101", "Кристина" },
                    { "101_2", "Котова", "101", "Евгения" },
                    { "201_1", "Кто-тов", "201", "Кто-то" },
                    { "201_2", "Зузин", "201", "Михаил" },
                    { "301_1", "Крюкин", "301", "Евгений" },
                    { "301_2", "Данилов", "301", "Алексей" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GroupID",
                table: "Employees",
                column: "GroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
