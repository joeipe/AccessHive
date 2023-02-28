using AccessHive.Write.Domain;
using CSharpFunctionalExtensions;
using MediatR;

namespace AccessHive.Write.Data.Commands
{
    public sealed class RoleAddCommand : IRequest<Result>
    {
        public Role Role { get; set; } = null!;

        public RoleAddCommand(Role role)
        {
            Role = role;
        }
    }
}