using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Promociones.Services.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiEcommerce";

            string cors = configuration["Config:OriginCors"];

            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(cors)
                                                                                        .AllowAnyHeader()
                                                                                        .AllowAnyMethod()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            return services;
        }
    }
}
