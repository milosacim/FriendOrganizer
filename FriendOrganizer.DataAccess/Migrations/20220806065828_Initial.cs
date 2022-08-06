using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendOrganizer.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FavoriteLanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_ProgrammingLanguages_FavoriteLanguageId",
                        column: x => x.FavoriteLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Email", "FavoriteLanguageId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, null, null, "Thomas", "Huber" },
                    { 2, null, null, "Andreas", "Boehler" },
                    { 3, null, null, "Julia", "Huber" },
                    { 4, null, null, "Chrissi", "Egin" }
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "TypeScript" },
                    { 3, "Julia" },
                    { 4, "F#" },
                    { 5, "Swift" },
                    { 6, "Java" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FavoriteLanguageId",
                table: "Friends",
                column: "FavoriteLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");
        }
    }
}
