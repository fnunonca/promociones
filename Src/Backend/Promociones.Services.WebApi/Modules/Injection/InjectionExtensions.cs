using Microsoft.Extensions.DependencyInjection;
using Promociones.Transversal.Common;
using Promociones.Infrastructure.Data;
using Promociones.Infrastructure.Repository;
using Promociones.Application.Interface;
using Promociones.Application.Main;
using Promociones.Domain.Interface;
using Promociones.Domain.Core;
using Promociones.Infrastructure.Interface;
using Promociones.Transversal.Logging;
using Microsoft.Extensions.Configuration;

namespace Promociones.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IPromocionApplication, PromocionApplication>();
            services.AddScoped<IPromocionDomain, PromocionDomain>();
            services.AddScoped<IPromocionRepository, PromocionRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
