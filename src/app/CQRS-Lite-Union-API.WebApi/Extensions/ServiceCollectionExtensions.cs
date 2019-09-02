using CQRS_Lite_Union_API.Common.Options;
using CQRS_Lite_Union_API.Infra.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Lite_Union_API.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDepenencyResolution(this IServiceCollection services, IWebHostEnvironment environment)
        {
            var env = environment.IsDevelopment() ? "Debug" : "Release";
            var path = environment.IsDevelopment() ? Path.Combine(environment.ContentRootPath, $"bin/{env}") : Path.GetFullPath(environment.ContentRootPath);

            var dlls = Directory.GetFiles(path, "CQRS-Lite-Union-API.*.dll", SearchOption.AllDirectories);
            services.RegisterTypes(dlls);
        }

        public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
        }
    }
}
