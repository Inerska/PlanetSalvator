using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetSalvator.Web.Server.Migrations
{
    public partial class ModelBuilderSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "Author", "CorrectAnswer", "Explanation", "Points", "Question" },
                values: new object[] { -1, "Oui", "Non", null, null, "Alexis Chân Gridel", "Oui", null, 73, "L'air intérieur (dans les habitations) est-il plus ou moins pollué que l'air extérieur ?" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
