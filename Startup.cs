using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Advantage.API.Models;


namespace Advantage.API
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
             services.AddCors(opt =>
                {
                    opt.AddPolicy("CorsPolicy",
                        b => b.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials());
                }
            );       
            
            services.AddMvc();
            services.AddDbContext<ApiContext>(options 
                => options.UseSqlServer(Configuration.GetConnectionString("LibraryConnection")));

                services.AddTransient<DataSeed>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // IWebHostEnvironment
        public void Configure(IApplicationBuilder app, IHostingEnvironment  env, DataSeed seed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           seed.SeedData(20,1000);
           app.UseMvc();
        }
    }
}
