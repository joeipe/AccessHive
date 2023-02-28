using AccessHive.Write.Domain;
using CSharpFunctionalExtensions;
using MediatR;

namespace AccessHive.Write.Data.Commands
{
    public sealed class RoleEditCommand : IRequest<Result>
    {
        public Role Role { get; set; } = null!;

        public RoleEditCommand(Role role)
        {
            Role = role;
        }
    }
}