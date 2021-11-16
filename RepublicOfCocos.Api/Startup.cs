using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RepublicOfCocos.Core.Interfaces;
using RepublicOfCocos.Core.Services;
using RepublicOfCocos.Infraestructure.Data;
using RepublicOfCocos.Infraestructure.Filters;
using RepublicOfCocos.Infraestructure.Repositories;
using RepublicOfCocos.Infraestructure.Validators;
using System;
using System.IO;
using System.Reflection;

namespace RepublicOfCocos.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            services.AddDbContext<RepublicOfCocosDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RepublicOfCocosDB"))
            );

            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<ISurgeryRepository, SurgeryRepository>();
            services.AddTransient<ISurgeryService, SurgeryService>();
            services.AddTransient<ITriageValidator, TriageValidator>();

            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Republic Of Cocos API", Version = "V1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                doc.IncludeXmlComments(xmlPath);
            });

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options => 
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Republic Of Cocos API V1");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
