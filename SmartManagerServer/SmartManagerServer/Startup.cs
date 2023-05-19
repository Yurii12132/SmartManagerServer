using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartManagerServer.Core.Exceptions;
using SmartManagerServer.Core.Infrastructure.TypeExtensions;
using SmartManagerServer.EndPointExtensions.Configuration;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace SmartManagerServer
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
            services.AddCors();
            services.AddHttpContextAccessor();

            services.AddEndpointConfiguration(Configuration);

            services.AddControllersWithViews();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = Text.Plain;

                    var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();

                    var exceptionModel = new ExceptionHandlerModel()
                    {
                        Message = exceptionHandlerPathFeature.Error.GetMessages(),
                        Path = exceptionHandlerPathFeature.Path,
                        Stack = exceptionHandlerPathFeature.Error.StackTrace
                    };
                    Console.WriteLine(exceptionModel);
                    await context.Response.WriteAsync(exceptionModel.ToJson());
                });
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
