// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Linq;
using IdentityServer.Data;
using IdentityServer.Data.Entities;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                // uncomment to write to Azure diagnostics stream
                //.WriteTo.File(
                //    @"D:\home\LogFiles\Application\identityserver.txt",
                //    fileSizeLimitBytes: 1_000_000,
                //    rollOnFileSizeLimit: true,
                //    shared: true,
                //    flushToDiskInterval: TimeSpan.FromSeconds(1))
                .WriteTo.Console(
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}",
                    theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            try
            {
                Log.Information("Starting host...");
                var host = CreateHostBuilder(args).Build();

                //Create a super user
                using (var scope = host.Services.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var persistedGrantDbContext = scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();
                    var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();


                    try
                    {
                        ctx.Database.Migrate();
                        persistedGrantDbContext.Database.Migrate();
                        configurationDbContext.Database.Migrate();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        ctx.Database.EnsureCreated();
                        persistedGrantDbContext.Database.EnsureCreated();
                        configurationDbContext.Database.Migrate();
                    }


                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


                    if (!ctx.Roles.Any())
                    {
                        /*
                         * Create the following roles if there is no roles in database
                            SuperAdmin
                            BasicUser
                         */
                        var superAdminRole = new IdentityRole("SuperAdmin");
                        var basicUserRole = new IdentityRole("BasicUser");

                        roleMgr.CreateAsync(superAdminRole).GetAwaiter().GetResult();
                        Log.Information("Created SuperAdminRole...");

                        roleMgr.CreateAsync(basicUserRole).GetAwaiter().GetResult();
                        Log.Information("Created BasicUserRole...");
                    }

                    /*Create Admin if no admin exists*/
                    if (!ctx.Users.Any(u => u.UserName == "super.admin@finclusion.com"))
                    {
                        var adminUser = new ApplicationUser
                        {
                            FullName = "Super Admin",
                            UserName = "super.admin@finclusion.com",
                            Email = "super.admin@finclusion.com",
                            EmailConfirmed = true
                        };


                        userMgr.CreateAsync(adminUser, "0000").GetAwaiter().GetResult();
                        Log.Information("Created user...");

                        userMgr.AddToRoleAsync(adminUser, "SuperAdmin").GetAwaiter().GetResult();
                        Log.Information("Added user to SuperAdmin role...");
                    }

                    var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                    context.Database.Migrate();
                    if (!context.Clients.Any())
                    {
                        foreach (var client in Config.Clients)
                        {
                            context.Clients.Add(client.ToEntity());
                        }

                        context.SaveChanges();
                    }

                    if (!context.IdentityResources.Any())
                    {
                        foreach (var resource in Config.IdentityResources)
                        {
                            context.IdentityResources.Add(resource.ToEntity());
                        }

                        context.SaveChanges();
                    }

                    if (!context.ApiScopes.Any())
                    {
                        foreach (var apiScope in Config.ApiScopes)
                        {
                            context.ApiScopes.Add(apiScope.ToEntity());
                        }

                        context.SaveChanges();
                    }
                }

                host.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { 
                webBuilder.UseStartup<Startup>();
                });
    }
}