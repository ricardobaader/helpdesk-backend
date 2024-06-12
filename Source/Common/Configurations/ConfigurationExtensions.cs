using Microsoft.Extensions.Configuration;

namespace Common.Configurations
{
    public static class ConfigurationExtensions
    {
        public static string PostgreSqlConnectionString(this IConfiguration configuration) => GetEnvironmentVariable(configuration, "POSTGRESQL_CONNECTION_STRING");

        private static string GetEnvironmentVariable(IConfiguration configuration, string variableName) =>
           configuration[variableName]!;
    }
}
