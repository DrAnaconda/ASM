using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace AntiScreenMeter.WebApi.Startup
{
    internal static class StartupExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(gen =>
                {
                    gen.SwaggerDoc("default", new OpenApiInfo
                    {
                        Title = "AntiScreenMeter Control Panel",
                        Version = "Default",
                    });
                    
                    gen.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization", In = ParameterLocation.Header, Type = SecuritySchemeType.ApiKey, Scheme = "Bearer"
                    });
                    
                    gen.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme()
                            {
                                Reference = new OpenApiReference()
                                {
                                    Type = ReferenceType.SecurityScheme, Id = "Bearer"
                                }, Scheme = "oauth2", Name = "Bearer", In = ParameterLocation.Header
                            }, new List<string>()
                            
                        }
                    });
                    
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    gen.IncludeXmlComments(xmlPath);
                });
                //services.AddSwaggerGenNewtonsoftSupport(); TODO: fix required?
        }
    }
}