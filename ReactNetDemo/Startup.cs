using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactNetDemo.Data;
using Microsoft.Extensions.Options;
using ReactNetDemo.Services;
using JavaScriptEngineSwitcher.ChakraCore;

namespace ReactNetDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            // Uncomment for Windows
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
                .AddV8();

            // Uncomment for MacOs and Linux (If using Mono, see ReactJs.Net for other options.)
            //services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
            //   .AddChakraCore();



            services.AddSwaggerGen();

            services.Configure<CollabHubDatabaseSettings>(
                Configuration.GetSection(nameof(CollabHubDatabaseSettings)));

            services.AddSingleton<ICollabHubDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CollabHubDatabaseSettings>>().Value);

            services.AddSingleton<ProfileService>();

            services.AddCors();

            services.AddControllersWithViews();


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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PostGradCollabHub API V1");
            });

            app.UseCors(
                      options => options.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
    );

            app.UseHttpsRedirection();

            app.UseReact(config =>
            {
                //Add all necessary Js Files here for Server-side Rendering
                //config
                //    .AddScript("~/js/remarkable.min.js")
                    
                
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
