using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ASM.ApiServices.FilesService.Abstractions;
using ASM.ApiServices.FilesService.Configuration;
using ASM.ApiServices.FilesService.Implementations;
using ASM.ApiServices.SMRepeater;
using ASM.ApiServices.SMRepeater.Configuration;
using ASM.ScreenMeterFaker.Abstractions;
using ASM.ScreenMeterFaker.Configuration;
using ASM.ScreenMeterFaker.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Tools.Library.Analyzers.String.Abstractions;
using Tools.Library.Analyzers.String.Implementations.SimilarityTool.LevenshteinTools;
using Tools.Library.Authorization.Schemes.WhiteListAuthorizationScheme;
using Tools.Library.Authorization.Schemes.WhiteListAuthorizationScheme.Options;

namespace ASM.WebApi.Startup
{
    internal static class StartupServiceExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("default", new OpenApiInfo
                {
                    Title = "ASM Control Panel",
                    Version = "Default",
                });

                gen.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization", In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey, Scheme = "Bearer"
                });

                gen.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme, Id = "Bearer"
                            },
                            Scheme = "oauth2", Name = "Bearer", In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                gen.IncludeXmlComments(xmlPath);
            });
            //services.AddSwaggerGenNewtonsoftSupport(); TODO: fix required?
        }
        
        public static void ConfigureAuthorizationSchemes(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<WhiteListAuthSchemeOptions>(
                options => configuration.GetSection(nameof(WhiteListAuthSchemeOptions)).Bind(options));
            services.AddAuthentication(x => x.DefaultScheme = "Default")
                .AddScheme<WhiteListAuthSchemeOptions, WhiteListAuthorizationScheme>("Default", 
                    options => configuration.Get<WhiteListAuthSchemeOptions>());
        }

        public static void ConfigureFilesService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FilesServiceConfiguration>(
                options => configuration.GetSection(nameof(FilesServiceConfiguration)).Bind(options));
            services.AddSingleton<IStringSimilarityTool, LevenshteinStringSimilarityTool>();
            services.AddSingleton<IFilesService, SMSpecificFilesService>();
        }
        
        public static void ConfigureSMRepeater(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RepeaterConfiguration>(
                options => configuration.GetSection(nameof(RepeaterConfiguration)).Bind(options));
            services.Configure<SMConfiguration>(
                options => configuration.GetSection(nameof(SMConfiguration)).Bind(options));
            services.AddSingleton<ISM, IsmFaker>();
            services.AddHostedService<RepeaterScheduler>();
        }
    }
}