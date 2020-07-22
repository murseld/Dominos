using System;
using System.IO;
using AutoMapper;
using Dominos.Core.Bus.RabbitMq;
using Dominos.Core.Extensions;
using Dominos.Services.DbWrite.Data;
using Dominos.Services.DbWrite.Data.UnitOfWorks;
using Dominos.Services.DbWrite.Domain.Commands;
using Dominos.Services.DbWrite.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;

namespace Dominos.Services.DbWrite
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
            services.AddControllers().AddNewtonsoftJson();

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<LocationDbContext>(p =>
            {
                p.UseSqlServer(Configuration.GetConnectionString("DominosDb"));
            });

            //Log Configurations
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            return services.BuildContainer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseRabbitMq()
                .SubscribeCommand<CreateLocationCommand>();
            SeedData.Initialize(app.ApplicationServices);
        }
    }
}
