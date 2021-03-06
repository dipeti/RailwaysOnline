﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RailwaysOnline.Data;
using RailwaysOnline.Models;

namespace RailwaysOnline
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get;}
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddDbContext<RailwaysDbContext>(options => options.UseSqlServer(
                connectionString: Configuration.GetConnectionString("RailwaysOnlineConnection"))
                );
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<RailwaysDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IJourneyRepository, JourneyRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped(SessionCart.GetCart);
            services.AddScoped<IEmailService, EmailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, RailwaysDbContext context)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();
            app.UseMvc(routeBuilder => routeBuilder.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}"
            ));
            DbInitializer.EnsureJourneyPopulated(context);
            DbInitializer.EnsureUsersPopulated(app);
        }
    }

    
}
