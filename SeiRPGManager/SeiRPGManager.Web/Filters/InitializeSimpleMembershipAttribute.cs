using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using MySql.Web.Security;
using WebMatrix.WebData;
using SeiRPGManager.DAL.Repositorio;

namespace SeiRPGManager.Web.Filters
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<SeiRPGManagerContexto>(null);

                try
                {
                    using (var context = SeiRPGManagerContexto.CriarContexto())
                    {
                        if (context.Database.Exists() == false)
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    MySqlWebSecurity.InitializeDatabaseConnection("SeiRPGManagerCon");

                    const string ADMIN_ROLES = "Administrators";
                    const string ADMIN_USER = "admin";

                    if (System.Web.Security.Roles.RoleExists(ADMIN_ROLES) == false)
                    {
                        System.Web.Security.Roles.CreateRole(ADMIN_ROLES);

                        if (WebSecurity.UserExists(ADMIN_USER) == false)
                            WebSecurity.CreateUserAndAccount(ADMIN_USER, "password");

                        if (System.Web.Security.Roles.GetRolesForUser(ADMIN_USER).Contains(ADMIN_ROLES) == false)
                            System.Web.Security.Roles.AddUserToRole(ADMIN_USER, ADMIN_ROLES);
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }

    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    //public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    //{
    //    private static SimpleMembershipInitializer _initializer;
    //    private static object _initializerLock = new object();
    //    private static bool _isInitialized;

    //    protected void Application_Start()
    //    {
    //        AreaRegistration.RegisterAllAreas();
    //        WebApiConfig.Register(GlobalConfiguration.Configuration);
    //        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    //        RouteConfig.RegisterRoutes(RouteTable.Routes);
    //        BundleConfig.RegisterBundles(BundleTable.Bundles);
    //        AuthConfig.RegisterAuth();

    //        LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
    //    }

    //    public class SimpleMembershipInitializer
    //    {
    //        public SimpleMembershipInitializer()
    //        {
    //            using (var context = new UsersContext())
    //                context.UserProfiles.Find(1);

    //            if (!WebSecurity.Initialized)
    //                WebSecurity.InitializeDatabaseConnection("SeiRPGManagerCon", "UserProfile", "UserId", "UserName", autoCreateTables: true);
    //        }
    //    }
        //private static SimpleMembershipInitializer _initializer;
        //private static object _initializerLock = new object();
        //private static bool _isInitialized;

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    // Ensure ASP.NET Simple Membership is initialized only once per app start
        //    LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        //}

        //private class SimpleMembershipInitializer
        //{
        //    public SimpleMembershipInitializer()
        //    {
        //        Database.SetInitializer<SeiRPGManagerContexto>(null);

        //        try
        //        {
        //            using (var context = new SeiRPGManagerContexto())
        //            {
        //                if (!context.Database.Exists())
        //                {
        //                    // Create the SimpleMembership database without Entity Framework migration schema
        //                    ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
        //                }
        //            }

        //            //WebSecurity.InitializeDatabaseConnection("SeiRPGManagerCon", "Users", "UserId", "UserName", autoCreateTables: false);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
        //        }
        //    }
        //}
    }
}

