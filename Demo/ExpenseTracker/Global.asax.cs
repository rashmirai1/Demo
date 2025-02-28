using ExpenseTracker.Data;
using ExpenseTracker.Interface;
using ExpenseTracker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Mvc5;

namespace ExpenseTracker
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new UnityContainer();
            container.RegisterType<ExpenseDBContext>();
            container.RegisterType<IExpenseRepository, ExpenseRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
