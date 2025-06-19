using System.Web.Mvc;

namespace ClinicSoft.Areas.EMRForms
{
    public class EMRFormsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EMRForms";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EMRForms_default",
                "EMRForms/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}