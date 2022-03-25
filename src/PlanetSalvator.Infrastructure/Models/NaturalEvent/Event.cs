// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Newtonsoft.Json;

namespace PlanetSalvator.Infrastructure.Models.NaturalEvent;

public partial class Event
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public Description Description { get; set; }

    [JsonProperty("link")]
    public Uri Link { get; set; }

    [JsonProperty("categories")]
    public List<Category> Categories { get; set; }

    [JsonProperty("sources")]
    public List<Source> Sources { get; set; }

    [JsonProperty("geometries")]
    public List<Geometry> Geometries { get; set; }
}