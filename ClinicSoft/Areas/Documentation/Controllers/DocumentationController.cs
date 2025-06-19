using BusinessEntities.Documentation;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Documentation.Controllers
{
    [Authorize]
    public class DocumentationController : Controller
    {
        [HttpGet]
        public ActionResult Documentation()
        {
            return View();
        }
    }
}