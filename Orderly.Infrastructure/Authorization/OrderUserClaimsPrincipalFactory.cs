﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Orderly.Domain.Entities;
using System.Security.Claims;

namespace Orderly.Infrastructure.Authorization;
{
    public class OrderUserClaimsPrincipalFactory(UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> options) : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
    {
    public override async Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var id = await GenerateClaimsAsync(user);

        if(user.DateOfBirth != null)
        {
            id.AddClaim(new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
        }
        
        return new ClaimsPrincipal(id);

    }

}
}
