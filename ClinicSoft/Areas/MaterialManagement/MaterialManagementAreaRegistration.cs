using System.Linq;
using System.Web.Mvc;

namespace ClinicSoft.Areas.MaterialManagement
{
    public class MaterialManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MaterialManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MaterialManagement_default",
                "MaterialManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            // Configure view search locations
            RazorViewEngine razorViewEngine = ViewEngines.Engines.OfType<RazorViewEngine>().FirstOrDefault();
            if (razorViewEngine != null)
            {
                string[] viewLocations = new[]
                {
                    "~/Areas/MaterialManagement/Views/StockTransfer/DirectStockTransfer/{0}.cshtml",
                    "~/Areas/MaterialManagement/Views/StockTransfer/StockTransferRequest/{0}.cshtml",
                    "~/Areas/MaterialManagement/Views/StockTransfer/TransferStock/{0}.cshtml"
                };
                razorViewEngine.ViewLocationFormats = viewLocations;
            }

            if (razorViewEngine != null)
            {
                string[] partialViewLocations = new[]
                {
                    "~/Areas/MaterialManagement/Views/StockTransfer/DirectStockTransfer/{0}.cshtml",
                    "~/Areas/MaterialManagement/Views/StockTransfer/StockTransferRequest/{0}.cshtml",
                    "~/Areas/MaterialManagement/Views/StockTransfer/TransferStock/{0}.cshtml"
                };
                razorViewEngine.PartialViewLocationFormats = razorViewEngine.PartialViewLocationFormats.Concat(partialViewLocations).ToArray();
            }

        }
    }
}