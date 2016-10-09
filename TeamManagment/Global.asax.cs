﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TeamManagment.Models;

namespace TeamManagment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Team team = new Team();
            team.Id = 5;
            team.Name = "Barca";
            team.Players = null;

            using (var dbCtx = new ApplicationDbContext())
            {
                dbCtx.Teams.Add(team);
            }
        }
    }
}
