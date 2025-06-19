using System.Web.Mvc;

namespace ClinicSoft.Areas.NurseStation
{
    public class NurseStationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NurseStation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NurseStation_default",
                "NurseStation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}