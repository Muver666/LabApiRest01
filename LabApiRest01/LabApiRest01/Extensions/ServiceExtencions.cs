﻿namespace LabApiRest01.Extensions
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
    }
}
