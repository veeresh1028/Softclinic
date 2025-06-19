using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ClinicSoft.App_Start
{
    public partial class StartUp
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType= DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath= new PathString("/Authentication/Authentication/Login"),
                LogoutPath = new PathString("/Authentication/Authentication/LogOff"),
                ExpireTimeSpan = TimeSpan.FromMinutes(300),
                SlidingExpiration = true
            });
        }
    }
}