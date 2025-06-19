using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ClinicSoft.Areas.EMR
{
    public class EMRAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EMR";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EMR_default",
                "EMR/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}