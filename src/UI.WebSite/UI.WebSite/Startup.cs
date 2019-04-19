using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Domain.Interfaces.Repositories;
using ApplicationCore.Domain.Interfaces.Services;
using ApplicationCore.Domain.Services;
using InfraStructure.Data.EntityFramework;
using InfraStructure.Data.EntityFramework.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UI.WebSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Contexto>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();

            //services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            services.AddScoped<ILancheRepository, LancheRepository>();
            services.AddScoped<ILancheService, LancheService>();

            services.AddScoped<IIngredienteRepository, IngredienteRepository>();
            services.AddScoped<IIngredienteService, IngredienteService>();

            services.AddScoped<ILancheIngredienteRepository, LancheIngredienteRepository>();
            services.AddScoped<ILancheIngredienteService, LancheIngredienteService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
