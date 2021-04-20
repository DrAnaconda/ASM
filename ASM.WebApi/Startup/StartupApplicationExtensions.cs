using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace ASM.WebApi.Startup
{
    internal static class StartupApplicationExtensions
    {
        public static void ConfigureStaticContent(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); // For the wwwroot folder.
            /*
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "wwwroot/images")),
                RequestPath = "/images",
                EnableDirectoryBrowsing = true
            });
            */
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint($"/swagger/default/swagger.json", "Default");
                opt.RoutePrefix = "swagger";
            });
        }
    }
}