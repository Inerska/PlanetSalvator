// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.Collections;
using Newtonsoft.Json;

namespace PlanetSalvator.Infrastructure.Models.NaturalEvent;

public partial class NaturalEvent
    : FetchableData
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("link")]
    public Uri Link { get; set; }

    [JsonProperty("events")]
    public List<Event> Events { get; set; }
}