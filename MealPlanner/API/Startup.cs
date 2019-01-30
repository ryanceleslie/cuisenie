using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Data;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Logging;
using Newtonsoft.Json.Serialization;

namespace API
{
    public class Startup
    {
        private IServiceCollection _services;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<MealPlannerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MealPlannerConnection")));

            // Dependency injections
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Service injections
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            // set json rules for output
            services.AddMvc()
                .AddJsonOptions(config => {
                    config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            // AutoMapper dependcy injection
            services.AddAutoMapper(typeof(Startup));

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MealPlannerAPI", Version = "v1" });
            });
            _services = services; // used to debug registered services
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MealPlannerAPI V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
