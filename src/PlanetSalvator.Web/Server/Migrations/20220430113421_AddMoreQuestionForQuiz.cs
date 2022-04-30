using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetSalvator.Web.Server.Migrations
{
    public partial class AddMoreQuestionForQuiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: -1,
                column: "Points",
                value: 47);

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "Author", "CorrectAnswer", "Explanation", "Points", "Question" },
                values: new object[] { -7, "500kg / personne", "700kg/ déchets ménagers par personne", "150 kg / déchets ménagers par personne", "1 tonne / déchets ménagers par personne", "Alexis Chân Gridel", "500kg / personne", "Il génère 45% des émissions de CO2 liées à l'énergie", 3, "Sur une année, un français produit en moyenne :" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "Author", "CorrectAnswer", "Explanation", "Points", "Question" },
                values: new object[] { -6, "Le nucléaire", "Le charbon", "Le gaz", null, "Alexis Chân Gridel", "Le gaz", "Il génère 45% des émissions de CO2 liées à l'énergie", 27, "La source d'énergie la plus néfaste est :" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "Author", "CorrectAnswer", "Explanation", "Points", "Question" },
                values: new object[] { -5, "Le nucléaire", "Le charbon", "Le gaz", null, "Alexis Chân Gridel", "Le gaz", null, 51, "La source d'énergie la plus néfaste est :" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "Author", "CorrectAnswer", "Explanation", "Points", "Question" },
                values: new object[] { -4, "1979", "1988", "2000", null, "Alexis Chân Gridel", "1979", null, 38, "La 1ère COP a eu lieu en :" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "Author", "CorrectAnswer", "Explanation", "Points", "Question" },
                values: new object[] { -3, "L'océan", "La forêt", null, null, "Alexis Chân Gridel", "L'océan", null, 57, "Le principal \"poumon\" de la planète est :" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "Author", "CorrectAnswer", "Explanation", "Points", "Question" },
                values: new object[] { -2, "500 ans", "1 an", "1000 ans", null, "Alexis Chân Gridel", "1000 ans", null, 69, "Un sac plastique se décompose en :" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: -1,
                column: "Points",
                value: 79);
        }
    }
}
