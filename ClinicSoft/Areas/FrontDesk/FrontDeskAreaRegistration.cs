using System.Web.Mvc;

namespace ClinicSoft.Areas.FrontDesk
{
    public class FrontDeskAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FrontDesk";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FrontDesk_default",
                "FrontDesk/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}