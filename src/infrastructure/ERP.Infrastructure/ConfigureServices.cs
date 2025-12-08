using ERP.Application.Common.Interfaces.Authentication;
using ERP.Application.Common.Interfaces.DbContext;
using ERP.Domain.Repositories.Modules.FinanceManagement;
using ERP.Domain.Repositories.Modules.HumanResourcesManagement;
using ERP.Domain.Repositories.Users;
using ERP.Infrastructure.CacheDatabase.Context;
using ERP.Infrastructure.MainDatabase.Context;
using ERP.Infrastructure.MainDatabase.Repositories.Modules.FinanceManagement;
using ERP.Infrastructure.MainDatabase.Repositories.Modules.HumanResourcesManagement;
using ERP.Infrastructure.MainDatabase.Repositories.Users;
using ERP.Infrastructure.Services.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace ERP.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMainDbContext, MainDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUserSessionRepository, UserSessionRepository>();
            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            services.AddScoped<IHumanRepository, HumanRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddDbContext<IMainDbContext, MainDbContext>(option =>
            {
                var sqlServerConnectionString = configuration["ConnectionStrings:MainDatabase"];
                option.UseSqlServer(sqlServerConnectionString);
            });

            services.AddScoped<ICacheDbContext, CacheDbContext>();
            services.AddScoped<IOneTimePasswordService, OneTimePasswordService>();
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var redisConnectionString = configuration["ConnectionStrings:CacheDatabase"];
                var configurationOptions = ConfigurationOptions.Parse(redisConnectionString ?? throw new ArgumentNullException(redisConnectionString));
                //configurationOptions.User = "";
                //configurationOptions.Password = "";
                configurationOptions.AbortOnConnectFail = false;
                return ConnectionMultiplexer.Connect(configurationOptions);
            });

            return services;
        }
    }
}
