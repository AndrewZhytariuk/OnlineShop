// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System.Linq;
using OnlineShop.Lib.Data;
using OnlineShop.Lib.Constants;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using OnlineShop.Lib.Serveces.UserManagementService.Models;

namespace OnlineShopI.IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddControllersWithViews();

                var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

                var indentityConnectionString = Configuration.GetConnectionString(ConnectionName.IdentityServerConnection);

                services.AddDbContext<UsersDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString(ConnectionName.UsersConnection)));

                services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<UsersDbContext>()
                    .AddDefaultTokenProviders();

                var builder = services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;

                    // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                    options.EmitStaticAudienceClaim = true;
                })
                 .AddConfigurationStore(options =>
                 {
                     options.ConfigureDbContext = b => b.UseSqlServer(
                         Configuration.GetConnectionString(ConnectionName.IdentityServerConnection),
                     sql =>
                     {
                         sql.MigrationsAssembly(migrationAssembly);
                         sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                     })
                     .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
                 })
                    .AddOperationalStore(options =>
                    {
                        options.ConfigureDbContext = b => b.UseSqlServer(
                            Configuration.GetConnectionString(ConnectionName.IdentityServerConnection),
                        sql =>
                        {
                            sql.MigrationsAssembly(migrationAssembly);
                            sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        })
                        .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
                    })
                    .AddAspNetIdentity<ApplicationUser>();

                // not recommended for production - you need to store your key material somewhere secure
                builder.AddDeveloperSigningCredential();

                services.AddAuthentication()
                    .AddGoogle(options =>
                    {
                        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                        // register your IdentityServer with Google at https://console.developers.google.com
                        // enable the Google+ API
                        // set the redirect URI to https://localhost:5001/signin-google
                        options.ClientId = "copy client ID from Google here";
                        options.ClientSecret = "copy client secret from Google here";
                    });

                services.AddCors(option =>
                {
                    option.AddDefaultPolicy(policyBuilder =>
                    {
                        policyBuilder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                    });
                });
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Configure(IApplicationBuilder app)
        {
            //InitializeDatabase(app);

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();
            app.UseCors();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                if (!context.Clients.Any())
                {
                    foreach (var client in Config.Clients)
                    {
                        dynamic c = client.ToEntity();
                        context.Clients.Add(client.ToEntity());
                    }

                     context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resours in Config.IdentityResources)
                    {
                        context.IdentityResources.Add(resours.ToEntity());
                    }

                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach(var scope in Config.ApiScopes)
                    {
                        context.ApiScopes.Add(scope.ToEntity());
                    }

                    context.SaveChanges();
                }

            }

        }
    }
}