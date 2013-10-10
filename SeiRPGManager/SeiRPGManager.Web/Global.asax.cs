using SeiRPGManager.DAL.Repositorio;
using SeiRPGManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;

namespace SeiRPGManager.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        //private static SimpleMembershipInitializer _initializer;
        //private static object _initializerLock = new object();
        //private static bool _isInitialized;

        //protected void Application_Start()
        //{
        //    Database.SetInitializer<SeiRPGManagerContexto>(new SeiRPGManagerInicializador());

        //    AreaRegistration.RegisterAllAreas();
        //    WebApiConfig.Register(GlobalConfiguration.Configuration);
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //    AuthConfig.RegisterAuth();

        //    LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        //}

        //public class SimpleMembershipInitializer
        //{
        //    public SimpleMembershipInitializer()
        //    {
        //        using (var context = new UsersContext())
        //            context.UserProfiles.Find(1);

        //        if (!WebSecurity.Initialized)
        //            WebSecurity.InitializeDatabaseConnection("SeiRPGManagerCon", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        //    }
        //}

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // NOTICE: Initialize MySqlSimpleMembershipProvider for Roles in any pages.
            // by X10-MOBILE\xyz37(Kim Ki Won) in Friday, April 19, 2013 12:06 AM
            (new SeiRPGManager.Web.Filters.InitializeSimpleMembershipAttribute()).OnActionExecuting(null);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}