namespace Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Reflection;

    using Infrastructure.Authentication;

    using Ninject;
    using Ninject.Extensions.Logging;
    using Ninject.Modules;
    using Ninject.Web.Mvc;

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
            kernel.Load(Assembly.GetExecutingAssembly());
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
                this.Bind<IAuthenticationService>().To<DefaultLoginAuthenticationService>();
            }
        }
    }
}