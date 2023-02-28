using AccessHive.Write.Data.Commands;
using AccessHive.Write.Data.Repositories;
using CSharpFunctionalExtensions;
using MediatR;

namespace AccessHive.Write.Data.CommandHandlers
{
    public sealed class RoleDeleteCommandHandler : IRequestHandler<RoleDeleteCommand, Result>
    {
        private readonly RoleRepository _roleRepository;

        public RoleDeleteCommandHandler(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Result> Handle(RoleDeleteCommand request, CancellationToken cancellationToken)
        {
            var errors = Validate(request);

            if (errors.Count == 0)
            {
                await _roleRepository.DeleteRoleAsync(request.Id);
                return Result.Success();
            }
            else
            {
                return Result.Failure(string.Join(",", errors));
            }
        }

        private List<string> Validate(RoleDeleteCommand request)
        {
            var errors = new List<string>();
            if (request.Id == 0)
            {
                errors.Add("Id should be not 0");
            }

            return errors;
        }
    }
}