using Microsoft.AspNetCore.Identity;

namespace Orderly.Domain.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }

}
