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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            List<Entity> entities = ChangeTracker
                .Entries()
                .Where(x => x.Entity is Entity)
                .Select(x => (Entity)x.Entity)
                .ToList();

            var result = base.SaveChangesAsync(cancellationToken);

            foreach (var entity in entities)
            {
                _eventDispatcher.Dispatch(entity.DomainEvents);
                entity.ClearDomainEvents();
            }

            return result;
        }
    }
}