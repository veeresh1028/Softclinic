using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Tools.Controllers
{
    public class DeveloperToolController : Controller
    {
        // GET: Tools/DeveloperTool
        public ActionResult DeveloperTool()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
    }
}