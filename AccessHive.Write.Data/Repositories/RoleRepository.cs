using AccessHive.Write.Domain;

namespace AccessHive.Write.Data.Repositories
{
    public class RoleRepository : GenericRepository<Role>
    {
        protected WriteDbContext _dataContext;

        public RoleRepository(WriteDbContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateRoleAsync(Role data)
        {
            Create(data);
            await SaveAsync();
        }

        public async Task UpdateRoleAsync(Role data)
        {
            Update(data);
            await SaveAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var data = Find(id);
            if (data != null)
            {
                Delete(data);
                await SaveAsync();
            }
        }
    }
}