using Microsoft.Extensions.Diagnostics.HealthChecks;
using RabbitMQ.Client;

namespace AccessHive.API.CustomHealthChecks
{
    public class RabbitMQHealthCheck : IHealthCheck
    {
        private readonly string _connectionString;

        public RabbitMQHealthCheck(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                
                var factory = new ConnectionFactory() { HostName = _connectionString };
                using (var connection = factory.CreateConnection())
                    return await Task.FromResult(HealthCheckResult.Healthy());
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, exception: ex));
            }
        }
    }
}
