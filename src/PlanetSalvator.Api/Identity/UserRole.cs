// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetSalvator.Api.Identity;

[Table(nameof(UserRole))]
public class UserRole
{
    [ForeignKey(nameof(Identity.User.Id))]
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    [ForeignKey(nameof(Identity.Role.Id))]
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
}