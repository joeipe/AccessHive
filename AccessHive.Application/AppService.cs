using AccessHive.Read.Data.Queries;
using AccessHive.ViewModels;
using AccessHive.Write.Data.Commands;
using AccessHive.Write.Domain;
using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;

namespace AccessHive.Application
{
    public class AppService : IAppService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AppService(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<RoleVM>> GetRoleAsync()
        {
            var query = new GetRoleQuery();
            var data = await _mediator.Send(query);
            var vm = _mapper.Map<List<RoleVM>>(data);
            return vm;
        }

        public async Task<RoleVM> GetRoleByIdAsync(int id)
        {
            var query = new GetRoleByIdQuery(id);
            var data = await _mediator.Send(query);
            var vm = _mapper.Map<RoleVM>(data);
            return vm;
        }

        public async Task<Result> AddRoleAsync(RoleVM value)
        {
            var data = _mapper.Map<Role>(value);
            var command = new RoleAddCommand(data);
            return await _mediator.Send(command);
        }

        public async Task<Result> UpdateRoleAsync(RoleVM value)
        {
            var data = _mapper.Map<Role>(value);
            var command = new RoleEditCommand(data);
            return await _mediator.Send(command);
        }

        public async Task<Result> DeletRoleAsync(int id)
        {
            var command = new RoleDeleteCommand(id);
            return await _mediator.Send(command);
        }
    }
}