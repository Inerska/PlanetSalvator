// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using PlanetSalvator.Web.Shared;

namespace PlanetSalvator.Web.Server.Queries;

using MediatR;

public record GetDailyTasksByEmailQuery(string Email) : IRequest<IEnumerable<DailyTask>>;