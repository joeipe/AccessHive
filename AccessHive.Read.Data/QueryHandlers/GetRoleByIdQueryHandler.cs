using AccessHive.Read.Data.Queries;
using AccessHive.Read.Domain;
using Dapper.Contrib.Extensions;
using MediatR;

namespace AccessHive.Read.Data.QueryHandlers
{
    public sealed class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Role>
    {
        private readonly ReadDbContext _dataContext;

        public GetRoleByIdQueryHandler(ReadDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _dataContext.db.GetAsync<Role>(request.Id);
            return data;
        }
    }
}