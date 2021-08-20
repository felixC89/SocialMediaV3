using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialMediaV3.Core.Interfaces;
using SocialMediaV3.Core.Services;
using SocialMediaV3.InfraStructure.Data;
using SocialMediaV3.InfraStructure.Filters;
using SocialMediaV3.InfraStructure.Repositories;
using System;

namespace SocialMediaV3.Api
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

            #region Se manda a pedir con automapper que se busque los assemblies en toda la solucion y registra los mappers que esten configurados
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion

            #region Cuando ocurra una referencia circular al serializar las clases de las entidades newtonsoft ignorara estas referencias y no se serializaran
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            //.ConfigureApiBehaviorOptions(option => option.SuppressModelStateInvalidFilter = true); //Suprime la validacion del modelo(ModelState) del ApiController
            #endregion

            #region Inyeccion de dependencia de la cadena de conexion al contexto de la base de datos
            services.AddDbContext<SocialMediadbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SocialMedia")));
            #endregion

            #region Inyeccion de dependencias Post Controller
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPostRepository, PostRepository>();
            #endregion

            #region Registra el Validation Filter al contenedor de servicios
            services.AddMvc(options => {
                options.Filters.Add<ValidationFilter>();
            })
            .AddFluentValidation(options => options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));//Se registra los fluent validations en el contenedor de servicios
            #endregion
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
