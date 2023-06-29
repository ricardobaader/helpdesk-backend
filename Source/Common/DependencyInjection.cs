using Common.Domain;
using Common.Infrastructure.SqlServer.Common;
using Common.Infrastructure.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Configurations;
using Microsoft.EntityFrameworkCore;
using Common.Application.Services.Tickets;

namespace Common
{
    public static class DependencyInjection
    {
        public static void AddCommon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer(configuration);
        }

        internal static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITicketsService, TicketsService>();
        }

        internal static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.SqlServerConnectionString();
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString, action =>
                {
                    action.MigrationsAssembly("Common");
                    action.EnableRetryOnFailure();
                    action.MigrationsHistoryTable("__EFMigrationsHistory", "dbo");
                }));

            services
                .BuildServiceProvider()
                .GetRequiredService<DatabaseContext>()
                .Database.Migrate();

            services.AddScoped(typeof(IBaseEntityRepository<>), typeof(BaseEntityRepository<>));
        }
    }
}
