// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Newtonsoft.Json;

namespace PlanetSalvator.Infrastructure.Models.NaturalEvent;

public partial class Geometry
{
    [JsonProperty("date")]
    public DateTimeOffset Date { get; set; }

    [JsonProperty("type")]
    public TypeEnum Type { get; set; }

    [JsonProperty("coordinates")]
    public List<decimal> Coordinates { get; set; }
}