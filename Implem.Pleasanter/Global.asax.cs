﻿using Implem.DefinitionAccessor;
using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.Initializers;
using Implem.Pleasanter.Libraries.ServerData;
using Implem.Pleasanter.Libraries.Settings;
using Implem.Pleasanter.Libraries.Utilities;
using Implem.Pleasanter.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
namespace Implem.Pleasanter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Application["StartTime"] = DateTime.Now;
            Application["LastAccessTime"] = Application["StartTime"];
            Initialize();
            var log = new SysLogModel();
            ItemsInitializer.Initialize();
            SetConfigrations();
            log.Finish();
        }

        private void Initialize()
        {
            Initializer.Initialize(Server.MapPath("./"));
        }

        private void SetConfigrations()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        protected void Application_End()
        {
            var log = new SysLogModel();
            Performances.PerformanceCollection.Save(Directories.Logs());
            log.Finish();
        }

        protected void Application_Error()
        {
            if (Server != null)
            {
                var error = Server.GetLastError();
                if (error != null)
                {
                    try
                    {
                        var log = new SysLogModel();
                        log.SysLogType = SysLogModel.SysLogTypes.Execption;
                        log.ErrMessage = error.Message;
                        log.ErrStackTrace = error.StackTrace;
                        log.Finish();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        protected void Session_Start()
        {
            Session["StartTime"] = DateTime.Now;
            Session["LastAccessTime"] = Session["StartTime"];
            Session["SessionGuid"] = Strings.NewGuid();
            if (Sessions.LoggedIn())
            {
                var userModel = new UserModel(
                    SiteSettingsUtility.UsersSiteSettings(),
                    Permissions.Admins(),
                    HttpContext.Current.User.Identity.Name.ToInt());
                if (userModel.AccessStatus == Databases.AccessStatuses.Selected &&
                    !userModel.Disabled)
                {
                    userModel.SetSession();
                }
                else
                {
                    Securities.Logout();
                    SetAnonymouseSession();
                }
            }
            else
            {
                SetAnonymouseSession();
            }
            new SysLogModel().Finish();
        }

        private void SetAnonymouseSession()
        {
            var userModel = new UserModel(
                SiteSettingsUtility.UsersSiteSettings(),
                Permissions.Admins(),
                HttpContext.Current.User?.Identity.Name.ToInt() ?? 0);
            Session["Language"] = userModel.Language;
            Session["RdsUser"] = userModel.RdsUser();
            Session["Developer"] = userModel.Developer;
        }
    }
}