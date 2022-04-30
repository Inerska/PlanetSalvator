// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Server.Migrations.Seeders.Initial;

using Microsoft.EntityFrameworkCore;
using PlanetSalvator.Web.Shared;

public static class QuizSeeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quiz>()
            .HasData(
                new Quiz
                {
                    Id = -1,
                    Question =
                        "L'air intérieur (dans les habitations) est-il plus ou moins pollué que l'air extérieur ?",
                    CorrectAnswer = "Oui",
                    AnswerA = "Oui",
                    AnswerB = "Non",
                },
                new Quiz
                {
                    Id = -2,
                    Question =
                        "Un sac plastique se décompose en :",
                    CorrectAnswer = "1000 ans",
                    AnswerA = "500 ans",
                    AnswerB = "1 an",
                    AnswerC = "1000 ans",
                },
                new Quiz
                {
                    Id = -3,
                    Question =
                        "Le principal \"poumon\" de la planète est :",
                    CorrectAnswer = "L'océan",
                    AnswerA = "L'océan",
                    AnswerB = "La forêt",
                },
                new Quiz
                {
                    Id = -4,
                    Question =
                        "La 1ère COP a eu lieu en :",
                    CorrectAnswer = "1979",
                    AnswerA = "1979",
                    AnswerB = "1988",
                    AnswerC = "2000",
                },
                new Quiz
                {
                    Id = -5,
                    Question =
                        "La source d'énergie la plus néfaste est :",
                    CorrectAnswer = "Le gaz",
                    AnswerA = "Le nucléaire",
                    AnswerB = "Le charbon",
                    AnswerC = "Le gaz",
                },
                new Quiz
                {
                    Id = -6,
                    Question =
                        "La source d'énergie la plus néfaste est :",
                    CorrectAnswer = "Le gaz",
                    AnswerA = "Le nucléaire",
                    AnswerB = "Le charbon",
                    AnswerC = "Le gaz",
                    Explanation = "Il génère 45% des émissions de CO2 liées à l'énergie",
                },
                new Quiz
                {
                    Id = -7,
                    Question =
                        "Sur une année, un français produit en moyenne :",
                    CorrectAnswer = "500kg / personne",
                    AnswerA = "500kg / personne",
                    AnswerB = "700kg/ déchets ménagers par personne",
                    AnswerC = "150 kg / déchets ménagers par personne",
                    AnswerD = "1 tonne / déchets ménagers par personne",
                    Explanation = "Il génère 45% des émissions de CO2 liées à l'énergie",
                });
    }
}