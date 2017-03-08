using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using api.Models.Config;
using api.Services;
using api.Mapper;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace api
{
    public class Startup
    {
        public const string CORS_POLICY_NAME = "CorsPolicy";
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("companyHouseConfig.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDependencies(services);

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {
                    Title = "Company Search API",
                    Description = "Search company house database by consuming Company House API",
                    Version = "v1",
                    TermsOfService = "These API's are developed for demo purposes and should be used for any other purpose.",
                    Contact = new Contact { Name = "Amit Rai Sharma", Email = "amit.sharma@aarcosolutions.co.uk"}
                });
                // Set the comments path for the swagger json and ui.

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "api.xml");
                c.IncludeXmlComments(xmlPath);
            });

            // Add framework services.
            services.AddCors(options=> {
                options.AddPolicy(CORS_POLICY_NAME, 
                        builder => builder
                                    .AllowAnyOrigin()
                                    .SetPreflightMaxAge(TimeSpan.FromSeconds(2520))
                                    .WithMethods(new string[] { "OPTIONS", "GET" }));
            });
            services.AddRouting();
            services.AddMvc();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //CORS should be enabled before enable MVC and registering routes
            app.UseCors(CORS_POLICY_NAME);

            app.UseMvcWithDefaultRoute();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aarco Solution API Demo - V1");
            });
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => {
                cfg.AddProfile(new CompanyHouseProfileConfiguration());
            });

            var mapper = config.CreateMapper();

            services.Configure<CompanyHouseConfig>(Configuration.GetSection("CompanyHouse"));
            services.AddSingleton(mapper);
            services.AddTransient<ICompanyHouseApiService, CompanyHouseApiService>();
        }
    }
}
