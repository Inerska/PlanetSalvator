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
                }
            );
    }
}