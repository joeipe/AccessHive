using AccessHive.API.CustomHealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AccessHive.API.Configurations
{
    public static class HealthCheckExtensions
    {
        public static IHealthChecksBuilder AddRabbitMQConnectionHealthCheck(
            this IHealthChecksBuilder builder,
            string connectionString,
            string name = default,
            HealthStatus failureStatus = HealthStatus.Degraded,
            IEnumerable<string> tags = default,
            TimeSpan? timeout = default)
        {
            return builder.AddCheck(name, new RabbitMQHealthCheck(connectionString), failureStatus, tags, timeout);
        }
    }
}
