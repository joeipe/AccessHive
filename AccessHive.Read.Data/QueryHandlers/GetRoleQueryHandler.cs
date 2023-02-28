using AccessHive.Read.Data.Queries;
using AccessHive.Read.Domain;
using Dapper.Contrib.Extensions;
using MediatR;

namespace AccessHive.Read.Data.QueryHandlers
{
    public sealed class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, List<Role>>
    {
        private readonly ReadDbContext _dataContext;

        public GetRoleQueryHandler(ReadDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Role>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var data = await _dataContext.db.GetAllAsync<Role>();
            return data.ToList();
        }
    }
}