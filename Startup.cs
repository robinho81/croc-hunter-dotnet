using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Diagnostics;

namespace croc_hunter_dotnet
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddRazorPages();
        }

        private string getVersion()
        {
            var versionStr = Environment.GetEnvironmentVariable("CROC_APP_VERSION");
            if (string.IsNullOrEmpty(versionStr))
            {
                versionStr = "NotSet";
            }
            return versionStr;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHealthChecks("/hc");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
              {
                  endpoints.MapRazorPages();
                  endpoints.MapGet("/version", async context =>
                      {
                          await context.Response.WriteAsync(getVersion());
                      });
              });
        }
    }
}
