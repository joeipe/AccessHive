using AccessHive.Application.AutoMapper;

namespace AccessHive.API.Configurations
{
    public static class AutoMapperSetupExtensions
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AutoMapperConfig));

            AutoMapperConfig.RegisterMappings();
        }
    }
}