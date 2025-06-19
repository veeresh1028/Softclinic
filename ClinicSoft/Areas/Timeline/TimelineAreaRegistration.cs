using System.Web.Mvc;

namespace ClinicSoft.Areas.Timeline
{
    public class TimelineAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Timeline";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Timeline_default",
                "Timeline/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}