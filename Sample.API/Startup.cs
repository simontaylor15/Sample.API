using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Sample.API.Entities;
using Microsoft.EntityFrameworkCore;
using Sample.API.Services;
using AutoMapper;

namespace Sample.API
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ProductInfoContext>(options => options.UseSqlServer(Startup.Configuration["connectionStrings:DefaultConnection"]));
            //services.AddScoped<IProductInfoRepository, ProductsDataStore>();
            services.AddScoped<IProductInfoRepository, ProductInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.ProductModel, Models.ProductModelWithoutProductDto>()
                            .ForMember(dest => dest.Id,
                                       opts => opts.MapFrom(src => src.ProductModelId));
                cfg.CreateMap<Entities.ProductModel, Models.ProductModelDto>()
                            .ForMember(dest => dest.Id,
                                       opts => opts.MapFrom(src => src.ProductModelId));
                cfg.CreateMap<Entities.Product, Models.ProductDto>()
                            .ForMember(dest => dest.Colour, 
                                       opts => opts.MapFrom(src => src.Color))
                            .ForMember(dest => dest.Id, 
                                       opts => opts.MapFrom(src => src.ProductId));
            });

            app.UseMvc();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
