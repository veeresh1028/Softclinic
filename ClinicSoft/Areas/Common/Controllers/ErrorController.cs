using Antlr.Runtime.Misc;
using BusinessEntities.Common;
using BusinessEntities.EMR;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Common.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult Error()
        {
            ExceptionContext error = (ExceptionContext)TempData["error"];
            TempData.Keep();
            ApplicationError _error = new ApplicationError();
            _error.ErrorMessage = error.Exception.Message;
            _error.ErrorTrace = error.Exception.StackTrace;
            _error.Controller = error.RouteData.Values["controller"].ToString();
            _error.Action = error.RouteData.Values["action"].ToString();

            return View(_error);
        }

        [HttpGet]
        public ActionResult ErrorPartialView()
        {
            ExceptionContext error = (ExceptionContext)TempData["error"];

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