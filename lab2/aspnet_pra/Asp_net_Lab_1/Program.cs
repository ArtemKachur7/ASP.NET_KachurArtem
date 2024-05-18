using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Asp_net_Lab_1.Models;
using Asp_net_Lab_1.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddControllersWithViews()
    .AddDataAnnotationsLocalization();
builder.Services.AddLocalization(/*options => options.ResourcesPath = "Resources"*/);
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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseRequestLocalization(app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{culture=en-US}/{controller=Home}/{action=Index}/{id?}");

app.Run();