using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Infrastructure;
using FluentValidation.AspNetCore;
using FluentValidation;
using Domin.Entites;
using Application.Validitors;
using Application.Models.ViewModels;
using Application.Interfaces.AppServices;
using AppServices;
using AutoMapper;
using Infrastructure.AutoMapper;

namespace presentation
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
            services.AddDbContext<EventsContext>(
                (options) => options.UseSqlServer(Configuration.GetConnectionString("cs"))
                );

            //Business Services 
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEventAppService, EventAppService>();

            //Validitors 
            services.AddTransient<IValidator<EventModel>, EventValiditor>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //automapper config by assimbles

            #region AutoMapperConfigOneByOne
            //var mappingConfig = new AutoMapper.MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new EventProfile());
            //});
            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);
            #endregion

            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Event}/{action=Index}/{id?}");
            });
        }
    }
}
