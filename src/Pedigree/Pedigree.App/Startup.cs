using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Controllers;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Pedigree.App.Infrastructure;
using SimpleInjector.Integration.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Vouzamo.Interop.Interfaces;
using System.Reflection;
using Vouzamo.Command.Interfaces;
using Vouzamo.Command.SimpleInjector;
using Pedigree.Common.Interfaces;
using Pedigree.Core.Services;
using Pedigree.Common.ViewModels;
using Pedigree.Common.Models;
using Vouzamo.EntityFramework.CommandHandlers;
using Vouzamo.EntityFramework.Commands;
using Vouzamo.Pagination;
using Vouzamo.EntityFramework.SimpleInjector;
using Pedigree.Common.Specifications;
using Pedigree.Core.Commands;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Swashbuckle.Swagger.Model;

namespace Pedigree.App
{
    public class Startup
    {
        private readonly Container _container = new Container();

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services
                .AddMvc()
                .AddJsonOptions(o => { o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });

            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddTransient<DbContext, AppDbContext>();
            services.AddTransient<IMapper, Infrastructure.AutoMapper>();
            services.AddTransient<IDogService, DogService>();
            services.AddTransient<ICoatColorService, CoatColorService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<ITitleService, TitleService>();

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Pedigree API",
                    Description = "A simple api to manage dogs and their pedigree information",
                    TermsOfService = "None"
                });
                options.DescribeAllEnumsAsStrings();
            });

            services.AddTransient<ITitleService, TitleService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Logging
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // MVC
            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Entity Framework
            AppDbInitializer.Initialize(app.ApplicationServices);

            // Mapping
            Infrastructure.AutoMapper.Register();

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
