using System.Web.Mvc;

namespace ClinicSoft.Areas.RnD
{
    public class RnDAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RnD";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RnD_default",
                "RnD/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}