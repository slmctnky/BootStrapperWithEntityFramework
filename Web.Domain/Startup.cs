using Base.Data.nConfiguration;
using Base.Web.nCustomDI;
using Bootstrapper.Boundary.nCore.nBootType;
using Bootstrapper.Core.nApplication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Web.Domain;

namespace GenericWebScaffold
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddControllersWithViews();
            services.AddSignalR(__Conf =>
            {
                __Conf.MaximumReceiveMessageSize = null;
            });

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
            }));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            /*services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });*/

            cDataConfiguration __Configuration = new cDataConfiguration(EBootType.Web);
            cApp __App = cApp.Start<cStarter>(__Configuration);

            __App.Factories.ObjectFactory.RegisterInstance<IConfiguration>(Configuration);

            var unityServiceProvider = new cUnityServiceProvider(__App.Factories.ObjectFactory.DependencyContainer);


            services.AddSingleton<IControllerActivator>(new cUnityControllerActivator(__App.Factories.ObjectFactory.DependencyContainer));

            var defaultProvider = services.BuildServiceProvider();

            __App.Factories.ObjectFactory.DependencyContainer.AddExtension(new cUnityFallbackProviderExtension(defaultProvider));

            return unityServiceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseSession();

            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new List<string> { "index.html" }
             });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                //endpoints.MapHub<SignalRHub>("/signalr");
                endpoints.MapFallbackToFile("index.html");
            });


            app.Use((context, next) =>
            {
                context.Request.EnableBuffering();
                return next();
            });
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
                    context.Context.Response.Headers.Add("Pragma", "no-cache");
                    context.Context.Response.Headers.Add("Expires", "0");
                }
            });

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }


            //app.Run();


            /*app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
#if DEBUG

                    spa.UseReactDevelopmentServer(npmScript: "start");
#endif
                    //
                }
            });*/



            app.UseCors("CorsPolicy");


            //app.UseSignalR(routes => { routes.MapHub<SignalRHub>("/chat"); });
        }

    }
}
