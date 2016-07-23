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
                .AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
            services
                .AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(_container));

            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Dependency Injection
            InitializeContainer(app);

            // Logging
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // MVC
            app.UseMvc();

            // Entity Framework
            AppDbInitializer.Initialize(app.ApplicationServices);

            // Mapping
            Infrastructure.AutoMapper.Register();
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Options
            app.UseSimpleInjectorAspNetRequestScoping(_container);
            _container.Options.DefaultScopedLifestyle = new AspNetRequestLifestyle();

            // Standard Registrations
            _container.RegisterMvcControllers(app);
            _container.RegisterMvcViewComponents(app);

            // Custom Registrations
            _container.Register<DbContext, AppDbContext>(Lifestyle.Scoped);
            _container.Register<IMapper, Infrastructure.AutoMapper>(Lifestyle.Singleton);
            _container.Register<ICommandDispatcher>(() => new SimpleInjectorCommandDispatcher(_container));

            app.UseBrowseCommand(_container, new PersonBrowseSpecificationContainer());
            app.UseGetCommand<Person, PersonViewModel>(_container);
            app.UsePostCommand<Person, PersonViewModel>(_container);
            app.UseSearchCommand<Person, PersonViewModel>(_container, new PersonSearchSpecification());
            app.UseBrowseCommand(_container, new DogBrowseSpecificationContainer());
            app.UseGetCommand<Dog, DogViewModel>(_container);
            app.UsePostCommand<Dog, DogViewModel>(_container);
            app.UseSearchCommand<Dog, DogViewModel>(_container, new DogSearchSpecification());
            app.UseBrowseCommand(_container, new CoatColorBrowseSpecificationContainer());
            app.UseGetCommand<CoatColor, CoatColorViewModel>(_container);
            app.UsePostCommand<CoatColor, CoatColorViewModel>(_container);
            app.UseSearchCommand<CoatColor, CoatColorViewModel>(_container, new CoatColorSearchSpecification());
            app.UseBrowseCommand(_container, new TitleBrowseSpecificationContainer());
            app.UseGetCommand<Title, TitleViewModel>(_container);
            app.UsePostCommand<Title, TitleViewModel>(_container);
            app.UseSearchCommand<Title, TitleViewModel>(_container, new TitleSearchSpecification());

            _container.Register(typeof(ICommandHandler<,>), new[] { GetType().GetTypeInfo().Assembly, typeof(DogRenameCommand).GetTypeInfo().Assembly });

            _container.Register<IDogService, DogService>(Lifestyle.Transient);
            _container.Register<IPersonService, PersonService>(Lifestyle.Transient);
            _container.Register<ICoatColorService, CoatColorService>(Lifestyle.Transient);
            _container.Register<ITitleService, TitleService>(Lifestyle.Transient);

            // Verify
            _container.Verify();
        }
    }
}
