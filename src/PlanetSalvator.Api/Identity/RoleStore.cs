// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Identity;

namespace PlanetSalvator.Api.Identity;

public class RoleStore
    : IUserRoleStore<Role>
{
    public void Dispose()
    {
    }

    public Task<string> GetUserIdAsync(Role user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserNameAsync(Role user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetUserNameAsync(Role user, string userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetNormalizedUserNameAsync(Role user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(Role user, string normalizedName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> CreateAsync(Role user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(Role user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(Role user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Role> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Role> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task AddToRoleAsync(Role user, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task RemoveFromRoleAsync(Role user, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<string>> GetRolesAsync(Role user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsInRoleAsync(Role user, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Role>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}