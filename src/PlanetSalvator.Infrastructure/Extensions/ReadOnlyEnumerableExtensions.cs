// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Infrastructure.Extensions;

public static class ReadOnlyEnumerableExtensions
{
    private static readonly Random Random = new();

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
    {
        var list = enumerable.ToList();
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = Random.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }

        return list;
    }
}