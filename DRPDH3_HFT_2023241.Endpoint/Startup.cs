using DRPDH3_HFT_2023241.Logic;
using DRPDH3_HFT_2023241.Models;
using DRPDH3_HFT_2023241.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRPDH3_HFT_2023241.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<AdoptionDbContext>();

            services.AddTransient<IRepository<Species>, SpeciesRepository>();
            services.AddTransient<IRepository<Pet>, PetRepository>();
            services.AddTransient<IRepository<Adoption>, AdoptionRepository>();

            services.AddTransient<ISpeciesLogic, SpeciesLogic>();
            services.AddTransient<IPetLogic, PetLogic>();
            services.AddTransient<IAdoptionLogic, AdoptionLogic>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
