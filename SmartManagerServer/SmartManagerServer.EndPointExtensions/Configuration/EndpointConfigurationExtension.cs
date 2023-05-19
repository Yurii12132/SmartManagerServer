using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartManagerServer.Core.Models.Configuration;
using SmartManagerServer.Core.Repositories;
using SmartManagerServer.Core.Repositories.SmartManagerServer;
using SmartManagerServer.Core.Services;
using SmartManagerServer.Core.UoWs;
using SmartManagerServer.Domain.Contracts.Services;
using SmartManagerServer.Domain.Mappers;
using SmartManagerServer.Domain.Services;
using SmartManagerServer.Infrastructure.Data;
using SmartManagerServer.Infrastructure.Repositories.SmartManagerServer;
using SmartManagerServer.Infrastructure.Resources;
using SmartManagerServer.Infrastructure.Service;
using SmartManagerServer.Infrastructure.UoWs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.EndPointExtensions.Configuration
{
    public static class EndpointConfigurationExtension
    {
        public static void AddEndpointConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<SmartManagerServerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SmartManagerServerConnection"));
            });

            services.Configure<FileStorageConfiguration>(Configuration.GetSection("FileStorage"));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IObjectRepository, ObjectRepository>();
            services.AddTransient<IPayoutRepository, PayoutRepository>();
            services.AddTransient<IOutlayMaterialRepository, OutlayMaterialRepository>();
            services.AddTransient<IOutlayEmployeeRepository, OutlayEmployeeRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<ISmartManagerServerUnitOfWork, SmartManagerServerUnitOfWork>();

            services.AddTransient<IOutlayMaterialService, OutlayMaterialService>();
            services.AddTransient<IOutlayEmployeeService, OutlayEmployeeService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IPayoutService, PayoutService>();
            services.AddTransient<IObjectService, ObjectService>();
            services.AddTransient<IEducationService, EducationService>();
            services.AddTransient<IEmployeeCalculaationService, EmployeeCalculationService>();

            services.AddTransient<IFIleService, FileService>();
            services.AddTransient<IImageService, ImageService>();

            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EmployeeMappingProfile());
                mc.AddProfile(new ObjectMappingProfile());
                mc.AddProfile(new OutlayMaterialMappingProfile());
                mc.AddProfile(new OutlayEmployeeMappingProfile());
                mc.AddProfile(new PayoutMappingProfile());
                mc.AddProfile(new FileMappingProfile());
                mc.AddProfile(new EducationMappingProfile());
            })
            .CreateMapper()
            );
        }
    }
}
