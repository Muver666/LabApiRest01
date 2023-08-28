using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using NLog;
using Repository;
using Service;
using Service.Contracts;
using Services.Contracts;

namespace LabApiRest01.Extensions
{
    public static class ServiceExtencions
    {
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
        {
            options.AddPolicy("corspolicy", builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });


        public static void ConfigureIISIntegration(this IServiceCollection services) => services
            .Configure<IISOptions>(options => { });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();


        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
        builder.AddMvcOptions(config => config.OutputFormatters.Add(new
        CsvOutputFormatter()));

    }
}



