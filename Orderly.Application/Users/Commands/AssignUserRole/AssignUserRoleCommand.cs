using MediatR;

namespace Orderly.Application.Users.Commands.AssignUserRole;

public class AssignUserRoleCommand : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleNames { get; set; } = default!;

}
