// Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// Licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Identity;
using PlanetSalvator.Infrastructure.Persistence.Contexts;

namespace PlanetSalvator.Api.Identity;

public class UserStore
    : IUserPasswordStore<User>, IUserRoleStore<User>
{
    private readonly ApplicationDbContext _context;

    public UserStore(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
    }

    public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
    {
        user.Username = normalizedName;
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
    {
        //TODO: _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return IdentityResult.Success;
    }

    public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        return await _context.Users
            .Includes(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Username == normalizedUserName, cancellationToken);
    }

    public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash);
    }

    public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}