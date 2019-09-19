using CQRS_Lite_Union_API.Application.Workshops.Commands;
using CQRS_Lite_Union_API.Common.Database;
using CQRS_Lite_Union_API.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CQRS_Lite_Union_API.WebApi
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; set; }
        public IConfiguration Configuration { get; set; }

        public Startup(IWebHostEnvironment env, IConfiguration config)
        {
            Environment = env;
            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddNewtonsoftJson().AddDataAnnotations();
            services.AddDepenencyResolution();
            services.AddMediatR(typeof(CreateWorkshopCommand).Assembly);
            services.AddSettings(Configuration);
            services.AddAutomapperAssemblies();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDatabaseInitializer databaseInit)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            databaseInit.Init();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
