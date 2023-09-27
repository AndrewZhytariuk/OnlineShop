using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using OnlineShop.Lib.Constants;
using OnlineShop.Lib.Data;
using OnlineShop.Lib.Migrations;
using IdentityServer4.AccessTokenValidation;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Lib.Options;
using OnlineShop.Lib.Repositories.Interfaces;
using OnlineShop.Lib.Serveces.ArticlesService.Models;
using OnlineShop.Lib.Serveces.OrdersService.Models;
using OnlineShop.Lib.Serveces.OrdersService.Repo;
using OnlineShop.Lib.Serveces.UserManagementService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<OrdersDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionName.OrdersConnection)));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "OrdersService", Version = "v1" });
});

builder.Services.AddTransient<IRepos<Order>, OrdersRepo>();
builder.Services.AddTransient<IRepos<OrderedArticle>, OrdersArticlesRepo>();

string test = builder.Configuration.GetConnectionString(ConnectionName.UsersConnection);

builder.Services.AddDbContext<UsersDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionName.UsersConnection)));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<UsersDbContext>()
    .AddDefaultTokenProviders();

var serviceAddressOptions = new ServiceAdressOptions();
builder.Configuration.GetSection(ServiceAdressOptions.SectionName).Bind(serviceAddressOptions);

builder.Services.AddAuthentication(
    IdentityServerAuthenticationDefaults.AuthenticationScheme)
    .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Authority = serviceAddressOptions.IdentityServer;
        //options.ApiName = $"{serviceAddressOptions.IdentityServer}/resources";
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters() { ValidateAudience = false };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", IdConstants.ApiScope);
    });
});

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.jjson", "ArticlesService v1"));
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization("ApiScope");
});

app.Run();
