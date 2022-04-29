// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Shared;

using Microsoft.AspNetCore.Identity;

public class ApplicationUser
    : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string AvatarPath { get; set; }

    public int Points { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public List<DailyTask> DailyTasks { get; set; } = new();
}