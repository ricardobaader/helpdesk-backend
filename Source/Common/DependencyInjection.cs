using Common.Application.Services.Email;
using Common.Application.Services.Rooms;
using Common.Application.Services.Tickets;
using Common.Application.Services.Users;
using Common.Configurations;
using Common.Domain;
using Common.Domain.Chats;
using Common.Domain.Tickets;
using Common.Domain.Users;
using Common.Infrastructure.SqlServer;
using Common.Infrastructure.SqlServer.Common;
using Common.Infrastructure.SqlServer.Repositories;
using Identity.Configurations;
using Identity.Data;
using Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Common
{
    public static class DependencyInjection
    {
        public static void AddCommon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPostgresConfig(configuration);
            services.AddAuthentication(configuration);
            services.AddServices();
        }

        internal static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailSenderService, EmailSenderService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ITicketsService, TicketsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRoomsService, RoomsService>();
            services.AddHostedService<CloseTicketService>();

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ITicketsRepository, TicketsRepository>();
            services.AddScoped<IChatsRepository, ChatRepository>();
        }

        internal static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var securityKeyEnv = Environment.GetEnvironmentVariable("SecurityKey");

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<PortugueseIdentityErrorDescriber>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtOptions));
#pragma warning disable CS8604 // Possible null reference argument.
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKeyEnv));
#pragma warning restore CS8604 // Possible null reference argument.

            services.Configure<JwtOptions>(options =>
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                options.Issuer = jwtAppSettingOptions[nameof(JwtOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
                options.Expiration = int.Parse(jwtAppSettingOptions[nameof(JwtOptions.Expiration)] ?? "3600");
#pragma warning restore CS8601 // Possible null reference assignment.
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
            });

            var issuerEnv = Environment.GetEnvironmentVariable("Issuer");
            var audienceEnv = Environment.GetEnvironmentVariable("Audience");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = issuerEnv,

                ValidateAudience = true,
                ValidAudience = audienceEnv,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                     policy => policy.RequireRole("Administrator"));

                options.AddPolicy("RequireSupportRole",
                    policy => policy.RequireAssertion(context => context.User.IsInRole("Support") || context.User.IsInRole("Administrator")));
            });
        }

        public static async Task InitializeDatabase(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var context = serviceProvider.GetRequiredService<DatabaseContext>();

            await context.Database.EnsureCreatedAsync();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roleName = "Administrator";

            IdentityResult result;

            var roleExists = await roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                result = await roleManager.CreateAsync(new IdentityRole(roleName));

                if (result.Succeeded)
                {
                    var userManager = serviceProvider
                        .GetRequiredService<UserManager<IdentityUser>>();

                    var emailAdmin = "administrador@gmail.com.br";
                    var admin = await userManager
                        .FindByEmailAsync(emailAdmin);

                    if (admin is null)
                    {
                        admin = new IdentityUser
                        {
                            UserName = emailAdmin,
                            Email = emailAdmin,
                            EmailConfirmed = true
                        };

                        result = await userManager
                            .CreateAsync(admin, "Admin@2023");

                        if (result.Succeeded)
                        {
                            var userRepository = serviceProvider.GetRequiredService<IBaseEntityRepository<User>>();
                            var userName = "administrador";
                            var userType = UserType.Admin;

                            await userRepository.InsertOne(new(userName, emailAdmin, "Admin@2023", "Admin@2023", userType));
                            await userRepository.Commit();

                            result = await userManager
                                .AddToRoleAsync(admin, roleName);

                            await userManager.SetLockoutEnabledAsync(admin, false);

                            if (!result.Succeeded)
                                throw new Exception("System failed to link role to user");
                        }
                    }
                }
            }

            roleName = "Support";
            roleExists = await roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
            {
                result = await roleManager.CreateAsync(new IdentityRole(roleName));

                if (!result.Succeeded)
                    throw new Exception("An error ocurred while creating the role");
            }

        }

        internal static void AddPostgresConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.PostgreSqlConnectionString();
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(connectionString, action =>
                {
                    action.MigrationsAssembly("Common");
                    action.EnableRetryOnFailure();
                }));

            services
                .BuildServiceProvider()
                .GetRequiredService<DatabaseContext>()
                .Database.Migrate();

            services.AddDbContext<IdentityDataContext>(options =>
              options.UseNpgsql(connectionString, action =>
              {
                  action.EnableRetryOnFailure();
              }));

            services
               .BuildServiceProvider()
               .GetRequiredService<IdentityDataContext>()
               .Database.Migrate();

            services.AddScoped(typeof(IBaseEntityRepository<>), typeof(BaseEntityRepository<>));
        }
    }
}
