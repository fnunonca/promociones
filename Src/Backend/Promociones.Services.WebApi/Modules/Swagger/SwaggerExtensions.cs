using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace Promociones.Services.WebApi.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Services API Promocion",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://www.linkedin.com/in/fvasquezn/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Fernando Vasquez",
                        Email = "fnunonca@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/fvasquezn/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://www.linkedin.com/in/fvasquezn/")
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization by API key.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });
            return services;
        }
    }
}
