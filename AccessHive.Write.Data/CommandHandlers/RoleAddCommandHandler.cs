using AccessHive.Write.Data.Commands;
using AccessHive.Write.Data.Events;
using AccessHive.Write.Data.Repositories;
using CSharpFunctionalExtensions;
using MediatR;

namespace AccessHive.Write.Data.CommandHandlers
{
    public sealed class RoleAddCommandHandler : IRequestHandler<RoleAddCommand, Result>
    {
        private readonly RoleRepository _roleRepository;

        public RoleAddCommandHandler(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Result> Handle(RoleAddCommand request, CancellationToken cancellationToken)
        {
            var errors = Validate(request);

            if (errors.Count == 0)
            {
                request.Role.RaiseDomainEvent(new RoleAddedEvent(request.Role.Name));
                await _roleRepository.CreateRoleAsync(request.Role);
                return Result.Success();
            }
            else
            {
                return Result.Failure(string.Join(",", errors));
            }
        }

        private List<string> Validate(RoleAddCommand request)
        {
            var errors = new List<string>();
            if (request.Role.Id != 0)
            {
                errors.Add("Id should be null");
            }

            return errors;
        }
    }
}