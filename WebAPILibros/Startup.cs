using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPILibros.Data;

namespace WebAPILibros
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        


        //Contenedor de servicios = Registrar una api o componente o libreria, Forma de como se crean las instancias por solicitud de un controlador
        //Injeccion de dependencia 

        public void ConfigureServices(IServiceCollection services)
        {
            //agregar a nuestro EF para usar inyeccion de dependencia en los api-controller
            services.AddDbContext<DBLibrosContext>(options => options.UseSqlServer(Configuration.GetConnectionString("KeyDBLibros")));
            services.AddControllers();
        }


        //Registra los middleWares
        //Activacion De componentes
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
        }
    }
}
