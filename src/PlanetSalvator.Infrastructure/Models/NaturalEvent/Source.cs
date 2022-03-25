// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Newtonsoft.Json;

namespace PlanetSalvator.Infrastructure.Models.NaturalEvent;

public partial class Source
{
    [JsonProperty("id")]
    public Id Id { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }
}