using System.Web.Mvc;

namespace ClinicSoft.Areas.InsuranceForms
{
    public class InsuranceFormsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "InsuranceForms";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "InsuranceForms_default",
                "InsuranceForms/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}