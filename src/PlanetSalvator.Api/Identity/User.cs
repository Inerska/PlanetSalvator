// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetSalvator.Api.Identity;

[Table(nameof(User))]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }
    
    public IEnumerable<UserRole> UserRoles { get; set; }
}