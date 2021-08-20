using HttpClientBestPractices.API.Infrastructure.Filters;
using HttpClientBestPractices.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HttpClientBestPractices.API.Infrastructure
{
    internal static class CustomExtensionsMethods
    {
        internal static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
            .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true)
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        internal static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<ICorrectPatternHttpService, CorrectPatternHttpService>();
            return services;
        }
    }
}
