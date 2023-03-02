using AccessHive.Write.Domain;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHive.Write.Data.Commands
{
    public class Commands
    {
        public record RoleAddCommand(Role Role) : IRequest<Result> { }
        public record RoleEditCommand(Role Role) : IRequest<Result> { }
        public record RoleDeleteCommand(int Id) : IRequest<Result> { }
    }
}
