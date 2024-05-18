var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



//sdfojsd;fj;sjfd;sdjfs;djf;sjdf;sdjf;sdjihfsdjsd;jif
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "order",
        pattern: "Order/{action=Index}/{id?}",
        defaults: new { controller = "Order", action = "Index" });

});



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "user",
        pattern: "User/{action=Index}/{id?}",
        defaults: new { controller = "User", action = "Index" });
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "product",
        pattern: "Product/{action=Privacy}/{id?}",
        defaults: new { controller = "Product" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Privacy}/{id?}");
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
