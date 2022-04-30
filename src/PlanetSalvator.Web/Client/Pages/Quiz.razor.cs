// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Client.Pages;

using System.Net.Http.Json;
using AntDesign;
using Microsoft.AspNetCore.Components;

public partial class Quiz
{
    private readonly StepItem[] _steps =
    {
        new() {Title = "1", Content = "X"},
        new() {Title = "2", Content = "X"},
        new() {Title = "3", Content = "X"},
        new() {Title = "4", Content = "X"},
        new() {Title = "5", Content = "X"},
    };

    [Inject] private HttpClient Http { get; set; }
    
    [Inject] private MessageService _messageService { get; set; }

    public IEnumerable<Web.Shared.Quiz> Quizzes { get; set; }
    
    private int QuizIndex { get; set; }
    
    private bool QuizFinished { get; set; }

    private int Current { get; set; }
    

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        var quizzes = await Http.GetFromJsonAsync<IEnumerable<Web.Shared.Quiz>>("api/quiz");

        Quizzes = quizzes ?? new List<Web.Shared.Quiz>();
    }

    public async Task CompleteQuiz(Web.Shared.Quiz quiz)
    {
        // Change the steps content
        
        // Check if the answer is good or not
        
        Current++;
        QuizIndex++;
        
        // get children bindValue variable
        

        _messageService.Info($"Vous avez appuyé sur ");

        // When it's finished
        if (IsQuizFinished())
        {
            _messageService.Success("Terminé !");

            QuizFinished = true;
        }
    }
    
    private bool IsQuizFinished() =>
        QuizIndex == _steps.Length
        || QuizFinished;


    public class StepItem
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}