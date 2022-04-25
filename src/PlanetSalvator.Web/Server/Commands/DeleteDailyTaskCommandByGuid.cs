// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

namespace PlanetSalvator.Web.Server.Commands;

using MediatR;

public record DeleteDailyTaskCommandByGuid(string Email, Guid Guid) : IRequest;