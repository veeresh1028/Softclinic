using System.Web.Mvc;

namespace ClinicSoft.Areas.PriorRequests
{
    public class PriorRequestsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PriorRequests";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PriorRequests_default",
                "PriorRequests/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}