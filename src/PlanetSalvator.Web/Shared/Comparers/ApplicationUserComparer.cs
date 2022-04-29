// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Shared.Comparers;

public class ApplicationUserComparer
    : IComparer<ApplicationUser>
{
    /// <inheritdoc/>
    public int Compare(ApplicationUser x, ApplicationUser y)
    {
        return x.Points > y.Points ? -1 : x.Points < y.Points ? 1 : 0;
    }
}