using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.SignalR.Demo.Serveur
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("demo",
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .WithOrigins("https://localhost:44334")
                                    .AllowCredentials());
            });

            services.AddSignalR(); // <-- SignalR
        }

        public void Configure(IApplicationBuilder app,IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseCors("demo");

            app.UseSignalR(routes =>
            {
                routes.MapHub<InfosPublisher>("/infosPublisher");
            });
        }
    }
}
