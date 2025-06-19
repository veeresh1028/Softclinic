using System.Web.Mvc;

namespace ClinicSoft.Areas.ConsentForms
{
    public class ConsentFormsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ConsentForms";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ConsentForms_default",
                "ConsentForms/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}