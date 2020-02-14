using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using HealthChecks.System;
using HealthChecks.UI.Configuration;

namespace TodoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
               opt.UseInMemoryDatabase("TodoList"));

            // services.AddHealthChecks()
            // .AddDiskStorageHealthCheck(delegate (DiskStorageOptions diskStorageOptions)
            // {
            //     diskStorageOptions.AddDrive(@"C:\", 5000);
            // }, "My Drive", Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded)
            // .AddCheck<RandomHealthCheck>("random");
            // services.AddHealthChecksUI();

            // services.AddHealthChecksUI()
            //          .AddHealthChecks()
            //          .AddCheck<RandomHealthCheck>("random");

            //services.AddHealthChecks();
            // .AddCheck<SqlServerHealthCheck>("sql");
            // services.AddSingleton<SqlServerHealthCheck>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // test 2
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // app.UseRouting()
            // .UseEndpoints(config =>
            //     {
            //         config.MapHealthChecks("healthz", new HealthCheckOptions()
            //         {
            //             Predicate = _ => true,
            //             ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //         });
            //         config.MapHealthChecksUI(setup =>
            //                 {
            //                     setup.AddCustomStylesheet("dotnet.css");
            //                 });
            //         config.MapDefaultControllerRoute();
            //     });
            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // app.UseHealthChecks("/todoitems");
            // app.UseHealthChecksUI()
            //     .UseHealthChecks("/todoitems");

            // app.UseHealthChecks("/hc", new HealthCheckOptions()
            // {
            //     Predicate = _ => true,
            //     ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            // });
            // app.UseHealthChecksUI(delegate (Options options)
            // {
            //     options.UIPath = "/hc-ui";
            // });
        }
    }
}
