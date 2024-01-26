using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Data;
using ChatApp.IRepository;
using ChatApp.Repository;

namespace ChatApp.Extentions
{
    public static class ExtentionMethod
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.WithOrigins("https://localhost:4200", "http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddSqlServer<AppDbContext>((configuration.GetConnectionString("sqlConnections")));

        public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped(typeof(IRepositoryManager<>), typeof(RepositoryManager<>));
        public static void ConfigureRepositoryRoom(this IServiceCollection services)
            => services.AddScoped<IRepositoryRoom, RepositoryRoom>();

        public static void ConfigureRepositoryUser(this IServiceCollection services)
            => services.AddScoped<IRepositoryUser, RepositoryUser>();

        public static void ConfigureRepositoryMessages(this IServiceCollection services)
            => services.AddScoped<IRepositoryMassages, RepositoryMessages>();
    }
}