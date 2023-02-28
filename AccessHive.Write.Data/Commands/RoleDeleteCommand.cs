using CSharpFunctionalExtensions;
using MediatR;

namespace AccessHive.Write.Data.Commands
{
    public sealed class RoleDeleteCommand : IRequest<Result>
    {
        public int Id { get; set; }

        public RoleDeleteCommand(int id)
        {
            Id = id;
        }
    }
}