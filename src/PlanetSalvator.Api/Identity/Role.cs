// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetSalvator.Api.Identity;

[Table(nameof(Role))]
public class Role
    : IdentityRole<long>
{
    public IEnumerable<UserRole> UserRoles { get; set; }
}