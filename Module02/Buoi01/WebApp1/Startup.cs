﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Sql;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp1.Areas.Dashboard.Controllers;

namespace WebApp1
{
    public class Startup
    {
        IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        
        
        
        
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
            services.AddAuthentication("Cookies").AddCookie(p =>
            {
                p.LoginPath = "/auth/login";
                p.AccessDeniedPath = "/auth/denied";
                p.ExpireTimeSpan = TimeSpan.FromDays(60);
                p.Cookie.Name = "cse.net.vn";
            });
            //services.AddScoped(p => new SiteProvider(configuration));
            services.AddScoped(p => new SiteProvider(p.GetService<CSContext>()));
            services.AddDbContext<CSContext>(p => p.UseSqlServer(configuration.GetConnectionString("CS")));
            services.AddScoped(p => new AccessDashboardFilter(p.GetService<SiteProvider>()));

        }











        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            //Nhớ Authorize dùng sau Authentication
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(name: "dashboard", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
