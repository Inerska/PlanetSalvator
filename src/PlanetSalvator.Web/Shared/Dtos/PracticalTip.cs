// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Shared.Dtos;

public record PracticalTip
(
    int Id = default,
    string? Title = null,
    string? Description = null,
    string? ImageUri = "https://picsum.photos/240")
{
    public PracticalTip()
        : this(default, "NO_TITLE", "NO_DESCRIPTION")
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PracticalTip" /> class.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="description"></param>
    public PracticalTip(string? title, string? description)
        : this()
    {
        Title = title;
        Description = description;
    }
}