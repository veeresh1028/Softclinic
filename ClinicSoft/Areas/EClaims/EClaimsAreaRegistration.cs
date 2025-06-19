using System.Web.Mvc;

namespace ClinicSoft.Areas.EClaims
{
    public class EClaimsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EClaims";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EClaims_default",
                "EClaims/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}