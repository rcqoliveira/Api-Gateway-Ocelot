using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Collections.Generic;

namespace RC.GetewayApi
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot(this.configuration);
            services.AddSwaggerForOcelot(this.configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UsePathBase("/gateway");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSwaggerForOcelotUI(this.configuration, opt =>
            {
                opt.DownstreamSwaggerEndPointBasePath = "/gateway/swagger/docs";
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });
            
           app.UseOcelot().Wait();
        }
    }
}
