using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Projeto.Estudo.NetCore.Application.Service;
using Projeto.Estudo.NetCore.Data.Context;
using Projeto.Estudo.NetCore.Data.Decorators;
using Projeto.Estudo.NetCore.Data.Repository;
using Projeto.Estudo.NetCore.Domain.Interfaces.Application;
using Projeto.Estudo.NetCore.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Estudo.NetCore.Api
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

            services.AddControllers();

            services.AddDbContext<EstudoDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Estudo")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projeto.Estudo.NetCore.Api", Version = "v1" });
            });

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.Decorate<IUsuarioRepository, UsuarioRepositoryCacheDecorator>();
            var a = Configuration.GetValue<int>("MEM_CACHE_SIZE_LIMIT");

            services.AddSingleton<IMemoryCacheRepository>(
                new MemoryCacheRepository(
                    Configuration.GetValue<int>("MEM_CACHE_SIZE_LIMIT"), 
                    Configuration.GetValue<int>("MEM_CACHE_ABSOLUTE_EXPIRATION_IN_SEC"), 
                    Configuration.GetValue<int>("MEM_CACHE_SLIDING_EXPIRATION_IN_SEC")
                    ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto.Estudo.NetCore.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
