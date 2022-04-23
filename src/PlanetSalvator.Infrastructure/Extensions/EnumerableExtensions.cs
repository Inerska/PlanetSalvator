// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Infrastructure.Extensions;

public static class EnumerableExtensions
{
    private static readonly Random Random = new();

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
    {
        var enumerableAsList = enumerable.ToList();
        var listCount = enumerableAsList.Count;
        while (listCount > 1)
        {
            listCount--;
            var k = Random.Next(listCount + 1);
            (enumerableAsList[k], enumerableAsList[listCount]) = (enumerableAsList[listCount], enumerableAsList[k]);
        }

        return enumerableAsList;
    }
    
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable) 
        => enumerable is null || !enumerable.Any();
}