using Microsoft.Extensions.Configuration;

namespace Common.Configurations
{
    public static class ConfigurationExtensions
    {
        public static string PostgreSqlConnectionString(this IConfiguration configuration) => GetEnvironmentVariable(configuration, "POSTGRESQL_CONNECTION_STRING");

        public static string JwtIssuer(this IConfiguration configuration) => GetEnvironmentVariable(configuration, "JWT_ISSUER") ?? "http://localhost";
        public static string JwtAudience(this IConfiguration configuration) => GetEnvironmentVariable(configuration, "JWT_AUDIENCE") ?? "Audience";
        public static string JwtSecurityKey(this IConfiguration configuration) => GetEnvironmentVariable(configuration, "JWT_SECURITY_KEY") ?? "a83e48bd-bf86-4a32-a87c-5d83b1c9cdf4";
        public static string JwtTokenExpiration(this IConfiguration configuration) => GetEnvironmentVariable(configuration, "JWT_TOKEN_EXPIRATION") ?? "3600";

        public static string ExecuteClosingTicketsJob(this IConfiguration configuration) => GetEnvironmentVariable(configuration, "EXECUTE_CLOSING_TICKETS_JOB") ?? "false";

        private static string GetEnvironmentVariable(IConfiguration configuration, string variableName) =>
           configuration[variableName]!;
    }
}
