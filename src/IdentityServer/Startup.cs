using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using IdentityServer.Data;
using IdentityServer.Data.Entities;
using IdentityServer.Services;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddControllersWithViews();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            //Database connection
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));


            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(
                    options =>
                    {
                        options.Password.RequireDigit = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequiredLength = 4;
                    }
                )
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.ConfigureApplicationCookie(c =>
            {
                c.Cookie.Name = "IdentityServe.Cookie";
                c.LoginPath = "/auth/login";
            });

            var assembly = typeof(Startup).Assembly.GetName().Name;

            var builder = services
                .AddIdentityServer(options => { options.EmitStaticAudienceClaim = true; })
                .AddAspNetIdentity<ApplicationUser>()
                /*.AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)*/
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(assembly));
                })
                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(assembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                })
                .AddProfileService<ProfileService>();
            builder.AddDeveloperSigningCredential();

            services.AddScoped<IProfileService, ProfileService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
        
    }
}