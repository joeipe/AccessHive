using AccessHive.Write.Data.Commands;
using AccessHive.Write.Data.EventDispatchers;
using AccessHive.Write.Data.Events;
using AccessHive.Write.Data.Repositories;
using CSharpFunctionalExtensions;
using MediatR;

namespace AccessHive.Write.Data.CommandHandlers
{
    public sealed class RoleAddCommandHandler : IRequestHandler<RoleAddCommand, Result>
    {
        private readonly RoleRepository _roleRepository;
        private readonly EventDispatcher _eventDispatcher;

        public RoleAddCommandHandler(
            RoleRepository roleRepository, 
            EventDispatcher eventDispatcher)
        {
            _roleRepository = roleRepository;
            _eventDispatcher = eventDispatcher;
        }

        public async Task<Result> Handle(RoleAddCommand request, CancellationToken cancellationToken)
        {
            var errors = Validate(request);

            if (errors.Count == 0)
            {
                await _roleRepository.CreateRoleAsync(request.Role);
                _eventDispatcher.Dispatch(new RoleAddedEvent(request.Role.Name));
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