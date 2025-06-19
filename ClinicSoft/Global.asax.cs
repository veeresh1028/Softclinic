using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using static Google.Apis.Requests.BatchRequest;

namespace ClinicSoft
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Sid;
        }

        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
        }

        //protected void Session_End(object sender, EventArgs e)
        //{
        //    Session["SessionEnded"] = true;
        //}

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    Response.Clear();

        //    string[] _errorArr = exception.StackTrace.ToString().Split('\n');
        //    string _err = "";
        //    if (_errorArr.Length >= 3)
        //    {
        //        _err = _errorArr[0] + "\n" + _errorArr[1] + "\n" + _errorArr[2];
        //    }
        //    else
        //    {
        //        foreach (string error in _errorArr)
        //        {
        //            _err += error + "\n";
        //        }
        //    }

        //    if (_err.Length > 100)
        //    {
        //        _err = _err.Substring(0, 100);
        //    }

        //    // clear error on server
        //    Server.ClearError();

        //    Response.Redirect(string.Format("~/Common/Error/Error?message={0}&details={1}", HttpUtility.UrlEncode(exception.Message), HttpUtility.UrlEncode(_err)));
        //}
    }
}
