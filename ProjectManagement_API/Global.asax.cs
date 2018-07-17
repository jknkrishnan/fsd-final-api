﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using ProjectManagement_DataContext;

namespace ProjectManagement_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TaskContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ParentContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserContext>());
        }
    }
}