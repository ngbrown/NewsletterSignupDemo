namespace Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Reflection;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;

    using Infrastructure.Authentication;
    using Infrastructure.Reporting;
    using Infrastructure.Storage;
    using Infrastructure.Storage.Raven;

    using Ninject;
    using Ninject.Extensions.Logging;
    using Ninject.Modules;
    using Ninject.Web.Mvc;

    using Reporting;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected override IKernel CreateKernel()
        {
            log4net.Config.XmlConfigurator.Configure();

            var kernel = new StandardKernel();
            kernel.Load(
                new SiteModule());
            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            
            RegisterRoutes(RouteTable.Routes);

            this.Kernel.Get<ILoggerFactory>().GetLogger(this.GetType())
                .Info("Application Started.");
        }

        class SiteModule : NinjectModule
        {
            public override void Load()
            {
                this.Bind<IAuthenticationService>()
                    .To<AspMembershipAuthenticationService>();

                this.Bind<IDataStorage>()
                    .ToConstant(new RavenDataStorage("http://localhost:8080"))
                    .InSingletonScope();

                var sessionFactory = Fluently.Configure()
                    .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2005
                                .ConnectionString(c => c.FromConnectionStringWithKey("SiteData")))
                    .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<UserActivity>(new ReportingAutomappingConfiguration())))
                    .BuildSessionFactory();
                this.Bind<IReporting>()
                    .ToConstant(new ReportingDataStorage(sessionFactory))
                    .InSingletonScope();
            }

            class ReportingAutomappingConfiguration : DefaultAutomappingConfiguration
            {
                public override bool ShouldMap(Type type)
                {
                    if (type.Namespace == null)
                    {
                        return false;
                    }

                    return type.Namespace.StartsWith("Web.Reporting");
                }
            }
        }
    }
}