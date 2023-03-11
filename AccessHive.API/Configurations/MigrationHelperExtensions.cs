using AccessHive.Write.Data;
using Microsoft.EntityFrameworkCore;

namespace AccessHive.API.Configurations
{
    public static class MigrationHelperExtensions
    {
        public static void ApplyDatabaseSchema(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            try
            {
                serviceScope?.ServiceProvider.GetRequiredService<WriteDbContext>().Database.Migrate();
            }
            catch (Exception)
            {
                Thread.Sleep(TimeSpan.FromSeconds(15));
                app.ApplyDatabaseSchema();
            }
        }
    }
}
