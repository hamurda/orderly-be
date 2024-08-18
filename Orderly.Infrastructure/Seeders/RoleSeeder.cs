using Microsoft.AspNetCore.Identity;
using Orderly.Domain.Constants;
using Orderly.Infrastructure.Persistence;

namespace Orderly.Infrastructure.Seeders;

internal class RoleSeeder(OrderlyDbContext dbContext) : IRoleSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }

    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
            [
                new (UserRoles.User){
                    NormalizedName = UserRoles.User.ToUpper(),
                },
                new (UserRoles.Owner){
                    NormalizedName = UserRoles.Owner.ToUpper(),
                },
                new (UserRoles.Admin){
                    NormalizedName = UserRoles.Admin.ToUpper(),
                }
            ];

        return roles;
    }
}
