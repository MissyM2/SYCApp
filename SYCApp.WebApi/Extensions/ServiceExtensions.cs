using System;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Core.Contracts.Persistence;
using SYCApp.Core.Services;
using SYCApp.Persistence.Repositories;

namespace SYCApp.WebApi.Extensions
{
	public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        //public static void ConfigureIISIntegration(this IServiceCollection services)
        //{
        //    services.Configure<IISOptions>(options =>
        //    {

        //    });
        //}

        //public static void ConfigureLoggerService(this IServiceCollection services)
        //{
        //    services.AddSingleton<ILoggerManager, LoggerManager>();
        //}

        //public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        //{
        //    var connectionString = config["mysqlconnection:connectionString"];

        //    services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString,
        //        MySqlServerVersion.LatestSupportedServerVersion));
        //}

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepositoryBase<>), typeof(AsyncRepositoryBase<>));
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ILoginRequestProcessor, LoginRequestProcessor>();
            services.AddScoped<IUserRequestProcessor, UserRequestProcessor>();
        }
    }
}

