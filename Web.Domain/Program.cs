using Base.Data.nConfiguration;
using Base.Web.nCustomDI;
using Bootstrapper.Boundary.nCore.nBootType;
using Bootstrapper.Core.nApplication;
using Data.Domain.nConfiguration;
using GenericWebScaffold;
using Microsoft.AspNetCore;
using Web.Domain;

public class Program
{
    public static void Main(string[] args)
    {
        //CreateWebHostBuilder(args).Build().Run();

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        cDomainDataConfiguration __Configuration = new cDomainDataConfiguration(EBootType.Web);
        cApp __App = cApp.Start<cStarter>(__Configuration);



        builder.Host.UseServiceProviderFactory(new cUnityServiceProviderFactory(__App));

        // Add services to the container.

        
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();


        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");

        app.MapFallbackToFile("index.html");

        app.Run();
    }

    /* public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
             .UseStartup<Startup>();*/
}

/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
*/
