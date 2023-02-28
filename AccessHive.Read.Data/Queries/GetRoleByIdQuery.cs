using AccessHive.Read.Domain;
using MediatR;

namespace AccessHive.Read.Data.Queries
{
    public sealed class GetRoleByIdQuery : IRequest<Role>
    {
        public int Id { get; set; }

        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}