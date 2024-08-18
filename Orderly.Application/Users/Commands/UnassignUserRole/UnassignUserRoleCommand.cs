using MediatR;

namespace Orderly.Application.Users.Commands.UnassignUserRole;

public class UnassignUserRoleCommand : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleNames { get; set; } = default!;
}
