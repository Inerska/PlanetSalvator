// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Server.Controllers;

using Microsoft.AspNetCore.Mvc;
using PlanetSalvator.Infrastructure.Extensions;

[ApiController]
[Route("[controller]")]
public class DailyPublicUserTaskController
    : Controller
{
    private static readonly IReadOnlySet<string> DailyTasks = new HashSet<string>
    {
        "Recyclez au moins 3 objets",
        "Prévilégiez l'achat d'au moins 3 produits sans emballage non recyclables",
        "Utilisez un sac réutilisable au supermarché",
        "Mangez au moins un fruit de saison",
        "Faites un don à un organisme de solidarité / écologie",
        "Couvrez les casseroles quand vous faites boullir de l'eau, cela économise 75% d'énergie",
        "Eteignez les lumières dans les pièces que vous n'utilisez pas.",
        "Eteignez vos équipements électriques quand vous n'utilisez pas.",
        "Remplissez votre bouilloire seulement jusqu'au niveau d'eau désiré.",
        "Compostez vos déchets alimentaires.",
        "Faites une réduction de votre facture d'électricité.",
        "Faites une réduction de votre facture d'eau.",
        "Faites une réduction de votre facture de gaz.",
        "Entretenez votre voiture, une voiture bien entretenue émet moins de fumées toxiques",
        "Séchez vos cheveux et habits naturellement à l'air libre.",
        "Conduisez pas aujourd'hui, préférez la marche à pieds et le vélo, ça vous permettra de faire plus d'exercice.",
    };

    private readonly ILogger<DailyPublicUserTaskController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DailyPublicUserTaskController"/> class.
    /// </summary>
    /// <param name="logger"></param>
    public DailyPublicUserTaskController(ILogger<DailyPublicUserTaskController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Simulate an extern api call to get the daily task.
    /// </summary>
    /// <param name="tasksCount">The count of daily tasks to retrieve.</param>
    /// <returns>The tasksCount daily tasks retrieved.</returns>
    [HttpGet]
    public IActionResult GetDailyPublicUserTask([FromQuery] int tasksCount = 3)
    {
        if (DailyTasks is { Count: 0 })
        {
            return NotFound();
        }

        return Ok(DailyTasks.Shuffle().Take(tasksCount));
    }
}