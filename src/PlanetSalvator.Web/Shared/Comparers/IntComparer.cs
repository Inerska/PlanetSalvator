// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Shared.Comparers;

public class IntComparer
    : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return x.CompareTo(y);
    }
}