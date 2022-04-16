// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Server.Handlers;

using MediatR;
using PlanetSalvator.Web.Server.Queries;

public record GetDailyTasksHandler
    : IRequestHandler<GetDailyTasksQuery, IEnumerable<string>>
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
        "Conduisez pas aujourd'hui, préférez la marche à pieds et le vélo, ça vous permettra de faire plus d'exercice."
    };

    public Task<IEnumerable<string>> Handle(GetDailyTasksQuery request, CancellationToken cancellationToken)
    {
        if (DailyTasks is null
            || DailyTasks.Count == 0)
        {
            return Task.FromResult(Enumerable.Empty<string>());
        }

        return Task.FromResult(DailyTasks.Take(request.tasksCount));
    }
}