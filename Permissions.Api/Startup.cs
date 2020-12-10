using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Permissions.DAL.Context;
using Permissions.BL.Mappers;
using AutoMapper;
using System.Reflection;
using Permissions.BL.IRepositories;
using Permissions.BL.Repositories;

namespace Permissions.Api
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins(Configuration["PathsConfig:PortalUrl"])
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers();

            services.AddDbContext<PermissionsContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Permissions.Api"));
            });

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<PermitProfile>();
            });


            services.AddTransient<IPermitRepository, PermitRepository>();
            services.AddTransient<IPermitTypeRepository, PermitTypeRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseWelcomePage();


        }
    }
}
