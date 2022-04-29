// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Shared;

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

public class Quiz
{
    public int Id { get; set; }

    public string Author { get; set; } = "Alexis Chân Gridel";

    public int Points { get; set; } = new Random().Next(1, 100);

    public string Question { get; set; }

    public string AnswerA { get; set; }

    public string AnswerB { get; set; }

    public string? AnswerC { get; set; }

    public string? AnswerD { get; set; }

    public string CorrectAnswer { get; set; }

    public string? Explanation { get; set; }
}