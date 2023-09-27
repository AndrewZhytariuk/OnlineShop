// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using OnlineShop.Lib.Data;
using OnlineShop.Lib.Common.Models;
using OnlineShop.Lib.Serveces.UserManagementService.Models;

namespace OnlineShopI.IdentityServer
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<UsersDbContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UsersDbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<UsersDbContext>();
                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var andrii = userMgr.FindByNameAsync("andrey").Result;
                    if (andrii == null)
                    {
                        andrii = new ApplicationUser
                        {
                            UserName = "andrii",
                            Email = "AliceSmith@email.com",
                            FirstName = "Andrii",
                            LastName = "Zhytariuk",
                            EmailConfirmed = true,
                            DefaultAddress = new Address()
                            {
                                City = "Chernivtsy",
                                Country = "Ukraine",
                                PostalCode = "000-003",
                                AddressLine1 = "Roventska 12",
                                AddressLine2 = "28"
                            },
                            DeliveryAddress = new Address()
                            {
                                City = "Chernivtsy",
                                Country = "Ukraine",
                                PostalCode = "000-003",
                                AddressLine1 = "Rovintska 12A"
                            }
                        };
                        var result = userMgr.CreateAsync(andrii, "Pass_123$").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(andrii, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Andrey Zhytariuk"),
                            new Claim(JwtClaimTypes.GivenName, "Andrey"),
                            new Claim(JwtClaimTypes.FamilyName, "Zhytariuk"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        }).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("alice created");
                    }
                    else
                    {
                        Log.Debug("alice already exists");
                    }


                   
                }
            }
        }
    }
}
