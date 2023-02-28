using AccessHive.Write.Data.Commands;
using AccessHive.Write.Data.Repositories;
using CSharpFunctionalExtensions;
using MediatR;

namespace AccessHive.Write.Data.CommandHandlers
{
    public sealed class RoleEditCommandHandler : IRequestHandler<RoleEditCommand, Result>
    {
        private readonly RoleRepository _roleRepository;

        public RoleEditCommandHandler(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Result> Handle(RoleEditCommand request, CancellationToken cancellationToken)
        {
            var errors = Validate(request);

            if (errors.Count == 0)
            {
                await _roleRepository.UpdateRoleAsync(request.Role);
                return Result.Success();
            }
            else
            {
                return Result.Failure(string.Join(",", errors));
            }
        }

        private List<string> Validate(RoleEditCommand request)
        {
            var errors = new List<string>();
            if (request.Role.Id == 0)
            {
                errors.Add("Id should be not 0");
            }

            return errors;
        }
    }
}