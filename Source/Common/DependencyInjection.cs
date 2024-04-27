using Common.Application.Services.Email;
using Common.Application.Services.Rooms;
using Common.Application.Services.Tickets;
using Common.Application.Services.Users;
using Common.Configurations;
using Common.Domain;
using Common.Domain.Tickets;
using Common.Domain.Users;
using Common.Infrastructure.SqlServer;
using Common.Infrastructure.SqlServer.Common;
using Common.Infrastructure.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class DependencyInjection
    {
        public static void AddCommon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer(configuration);
            services.AddServices();
        }

        internal static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailSenderService, EmailSenderService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITicketsService, TicketsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRoomsService, RoomsService>();
            services.AddHostedService<CloseTicketService>();

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ITicketsRepository, TicketsRepository>();

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
