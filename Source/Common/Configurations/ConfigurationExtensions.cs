using Microsoft.Extensions.Configuration;

namespace Common.Configurations
{
    public static class ConfigurationExtensions
    {
        public static string SqlServerConnectionString(this IConfiguration configuration) => GetEnvironmentVariable(configuration, "ConnectionStrings:connectionSqlServer");

        private static string GetEnvironmentVariable(IConfiguration configuration, string variableName) =>
           configuration[variableName]!;
    }
}
