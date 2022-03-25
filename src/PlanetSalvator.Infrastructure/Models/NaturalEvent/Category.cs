// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Newtonsoft.Json;

namespace PlanetSalvator.Infrastructure.Models.NaturalEvent;

public partial class Category
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("title")]
    public Title Title { get; set; }
}