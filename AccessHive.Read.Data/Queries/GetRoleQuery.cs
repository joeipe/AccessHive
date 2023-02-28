using AccessHive.Read.Domain;
using MediatR;

namespace AccessHive.Read.Data.Queries
{
    public sealed class GetRoleQuery : IRequest<List<Role>>
    {
    }
}