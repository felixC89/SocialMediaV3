using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialMediaV3.Core.Interfaces;
using SocialMediaV3.InfraStructure.Data;
using SocialMediaV3.InfraStructure.Repositories;

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

            #region Inyeccion de dependencia de la cadena de conexion al contexto de la base de datos
            services.AddDbContext<SocialMediadbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SocialMedia")));
            #endregion

            #region Inyeccion de dependencias Post Controller
            services.AddTransient<IPostRepository, PostRepository>();
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
