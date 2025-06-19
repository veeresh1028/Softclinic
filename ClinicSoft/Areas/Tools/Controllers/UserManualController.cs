using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Tools.Controllers
{
    public class UserManualController : Controller
    {
        public ActionResult UserManual()
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