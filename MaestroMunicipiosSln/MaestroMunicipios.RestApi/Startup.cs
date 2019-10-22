using MaestroMunicipios.Domain.IRepositories;
using MaestroMunicipios.Domain.Services;
using MaestroMunicipios.Infraestructure;
using MaestroMunicipios.Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Microsoft.OpenApi.Models;
using System;

namespace MaestroMunicipios.RestApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<MaestroMunicipioContext>(opt =>
               opt
               .UseSqlServer(Configuration.GetConnectionString("database")));
            services.AddMediatR(Assembly.Load("MaestroMunicipios.Application"), Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IERepository<>), typeof(ERepository<>));
            services.AddTransient(typeof(CityManagerService));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Agaval Pasarela", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var basePath = Environment.GetEnvironmentVariable("ApiPath") ?? Configuration.GetValue<string>("ApiPath");
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Servers.Add(new OpenApiServer
                { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{basePath}" }));
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
