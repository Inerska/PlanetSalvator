// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Shared;

public class DailyTask
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string Task { get; set; }

    public int Points { get; set; }

    public int ApplicationUserId { get; set; }

    public ApplicationUser ApplicationUser { get; set; }

    public DailyTask(string Task, Guid guid)
    {
        this.Task = Task;
        this.Guid = guid;
        this.Points = new Random().Next(10, 100);
    }
}