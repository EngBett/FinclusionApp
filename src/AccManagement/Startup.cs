using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccManagement.Data;
using AccManagement.Data.Repositories;
using AccManagement.Data.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AccManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            //Add automapper
            services.AddAutoMapper(typeof(Startup));
            
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthentication(c =>
                {
                    c.DefaultScheme = "Cookie";
                    c.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookie")
                .AddOpenIdConnect("oidc", c =>
                {
                    c.Authority = "https://localhost:5001/";
                    c.ClientId = "AccManagementId";
                    c.ClientSecret = "AccManagementSecret";
                    c.SaveTokens = true;

                    c.ResponseType = "code";

                    c.GetClaimsFromUserInfoEndpoint = true;
                    c.ClaimActions.MapJsonKey("role","role","role");
                    c.TokenValidationParameters.NameClaimType = "name";
                    c.TokenValidationParameters.RoleClaimType = "role";
                });
            
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddSession(options => {  
                options.IdleTimeout = TimeSpan.FromMinutes(10);   
            });

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.Use(async (context, next) =>
            {
                await next();
                switch (context.Response.StatusCode)
                {
                    case 404:
                        context.Request.Path = "/error/e404";
                        await next();
                        break;/*
                    case 403:
                        context.Request.Path = "/error/e403";
                        await next();
                        break;
                    case 500:
                        context.Request.Path = "/error/e500";
                        await next();
                        break;*/
                    default:
                        break;
                }
            });

            app.UseSession(); 
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}