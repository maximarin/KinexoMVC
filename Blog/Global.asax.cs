﻿using Blog.Contrats;
using Blog.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Services.Description;
using static Blog.Contrats.IServiceCategory;
using static Blog.Contrats.IServiceComment;
using static Blog.Contrats.IServiceNote;
using static Blog.Contrats.IServiceUser;

namespace Blog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<IServicesCategories, ServiceCategory>(Lifestyle.Scoped);
            container.Register<IServicesNotes, ServiceNote>(Lifestyle.Scoped);
            container.Register<IServicesComments, ServiceComment>(Lifestyle.Scoped);
            container.Register<IServicesUsers, ServiceUser>(Lifestyle.Scoped);

            container.RegisterMvcControllers(System.Reflection.Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
