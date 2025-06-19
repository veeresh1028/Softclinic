using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Authentication.Controllers
{
    public class CommonController : Controller
    {
        [HttpGet]
        public ActionResult ErrorTab()
        {
            ExceptionContext error = (ExceptionContext)TempData["errorTab"];
            TempData.Keep();

            ApplicationError _error = new ApplicationError();
            _error.ErrorMessage = error.Exception.Message;
            _error.ErrorTrace = error.Exception.StackTrace;
            _error.Controller = error.RouteData.Values["controller"].ToString();
            _error.Action = error.RouteData.Values["action"].ToString();

            return View(_error);
        }
    }
}