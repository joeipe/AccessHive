using AccessHive.Write.Data.EventDispatchers;
using AccessHive.Write.Domain;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace AccessHive.Write.Data
{
    public class WriteDbContext : DbContext
    {
        private readonly EventDispatcher _eventDispatcher;

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options, EventDispatcher eventDispatcher)
            : base(options)
        {
            _eventDispatcher = eventDispatcher;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=AccessHiveDB;User Id=sa;Password=Admin1234;TrustServerCertificate=True");
        //}
    }
}