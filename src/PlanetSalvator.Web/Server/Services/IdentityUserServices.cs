// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using System.Security.Principal;
using PlanetSalvator.Web.Server.Data;

namespace PlanetSalvator.Web.Server.Services;

public class IdentityUserServices
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="IdentityUserServices"/> class.
    /// </summary>
    /// <param name="context"></param>
    public IdentityUserServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public string GetEmailAddressByName(IIdentity identity)
    {
        var name = identity.Name;
        var result = _context.Users.FirstOrDefault(u => string.Equals(u.UserName, name, StringComparison.InvariantCultureIgnoreCase));

        return result?.Email ??
            throw new KeyNotFoundException("User not found");
    }
}