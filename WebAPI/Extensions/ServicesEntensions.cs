using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using Repositories.EFCore;
using Services.Concrete;
using Services.Abstract;
using Presentation.ActionFilters;

namespace WebAPI.Extensions
{
    public static class ServicesEntensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();
        
        public static void ConfigureActionsFilters(this IServiceCollection services)
        {

            services.AddScoped<ValidationFilterAttribute>();
            services.AddSingleton<LogFilterAttribute>();

        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination")
                );
            });
        }

    }
}
