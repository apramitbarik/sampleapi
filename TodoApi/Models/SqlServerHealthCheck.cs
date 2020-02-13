using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TodoApi.Models
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        SqlConnection _connection;
        public string Name => "sql";
        public SqlServerHealthCheck(SqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                _connection.Open();
            }
            catch (SqlException)
            {
                return HealthCheckResult.Unhealthy();
            }

            return HealthCheckResult.Healthy();
        }
    }
}