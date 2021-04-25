using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppiDiscotienda
{
    public class Startup
    {
        //readonly string Cors = "Cors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            //Estas lineas me permiten autorizar las politicas que utilizan los navegadores , para que la aplicaicon pueda recibir peticiones desde otro servidor
            //Con las lineas siguientes cualquier aplicaicon puede hacerle una peticion a nuestra API , pero no e slo mas recomendable, aqui deberiamos colocar la aplicaicon permitida
            services.AddCors(options => options.AddPolicy("AllowAll",
                p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: Cors,
            //                      builder =>
            //                      {
            //                          builder.WithOrigins("*");

            //                      });
            //});

            services.AddControllers();
            services.AddDbContext<Context>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("strcon")));

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

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
