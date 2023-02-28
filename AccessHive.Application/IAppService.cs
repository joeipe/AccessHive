using AccessHive.ViewModels;
using CSharpFunctionalExtensions;

namespace AccessHive.Application
{
    public interface IAppService
    {
        Task<List<RoleVM>> GetRoleAsync();

        Task<RoleVM> GetRoleByIdAsync(int id);

        Task<Result> AddRoleAsync(RoleVM value);

        Task<Result> UpdateRoleAsync(RoleVM value);

        Task<Result> DeletRoleAsync(int id);
    }
}