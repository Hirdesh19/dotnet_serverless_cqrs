using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AWSServerless.Domain;
using AWSServerless.Domain.Contexts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AWSServerless.API
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(corsOptions => {
                corsOptions.AddPolicy(
                    "CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        // https://stackoverflow.com/a/59473385/1778164
                        .SetIsOriginAllowed(o => true)
                        .AllowCredentials()
                );
            });


            services.AddControllers();

            // Add S3 to the ASP.NET Core dependency injection framework.
            services.AddAWSService<Amazon.S3.IAmazonS3>();
            // Add Configuration for DBContexts
            services.AddSingleton(Configuration);

            services.AddDbContext<ISchoolContext, SchoolContext>(options => {
                options.UseMySql("Server=localhost;Database=cqrs_test;User=root;Password=password", sqlOptions => {
                    sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            });

            // Mediator
            services.AddMediatR(typeof(Startup));

            // AutoMapper
            var config = new MapperConfiguration(
                cfg => {
                    cfg.AddProfile(new MappingProfile());
                }
            );
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(typeof(Startup));

            var handlerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t =>
                    t.IsClass
                    && t.Namespace != null
                    && (
                        t.Namespace.StartsWith("AWSServerless.Domain.Commands")
                    )
                    && t.GetInterfaces().Any(i =>
                        i.Name.StartsWith("IRequestHandler")
                        || i.Name.StartsWith("INotificationHandler")
                    )
                );

            foreach (var handlerType in handlerTypes)
            {
                var interfaceType = handlerType
                    .GetInterfaces()
                    .First(i =>
                        i.Name.StartsWith("IRequestHandler")
                        || i.Name.StartsWith("INotificationHandler")
                    );
                services.AddScoped(interfaceType, handlerType);
            }

            // Queries - using reflection to simplify.
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t =>
                    t.IsClass
                    && t.Namespace != null
                    && (
                        t.Namespace.StartsWith("AWSServerless.Domain.Queries", StringComparison.CurrentCulture)
                    )
                );

            foreach (var type in types)
            {
                // assume that we want to inject any class that implements an interface
                // whose name is the type's name prefixed with I
                if (type.GetInterface($"I{type.Name}") != null)
                {
                    services.AddScoped(type.GetInterface($"I{type.Name}"), type);
                }
            }


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
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
