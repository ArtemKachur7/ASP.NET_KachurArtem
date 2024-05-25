using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Globalization;
using System.Reflection;
using Asp_net_Lab_1.Models;
using Asp_net_Lab_1.Registration;
using Asp_net_Lab_1.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services
            .AddControllersWithViews()
            .AddDataAnnotationsLocalization();

        builder.Services.AddLocalization();

        ConfigureServices(builder.Services);

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            List<CultureInfo> supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("en-us"),
                new CultureInfo("uk-ua")
            };
            options.DefaultRequestCulture = new RequestCulture("en-us");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;

            var requestProvider = new RouteDataRequestCultureProvider();
            options.RequestCultureProviders.Insert(0, requestProvider);
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{culture=en-US}/{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }
}

