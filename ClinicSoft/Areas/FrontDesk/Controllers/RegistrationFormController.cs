using BusinessEntities;
using BusinessEntities.FrontDesk;
using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.FrontDesk.Controllers
{
    [Authorize]
    public class RegistrationFormController : Controller
    {
        int PageId = (int)Pages.RegistrationForm;

        #region Registration Form        
        public PartialViewResult RegistrationForm()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int appId = Convert.ToInt32(TempData["appId"]);

                DataTable dt_nationalities = BusinessLogicLayer.Nationality.GetNationalities();
                SelectList NationalityList = Models.Helper.ToSelectList(dt_nationalities, "natId", "nationality");
                ViewData["NationalityList"] = NationalityList;
                DataTable dt_referals = BusinessLogicLayer.Referal.GetReferals();
                SelectList ReferalList = Models.Helper.ToSelectList(dt_referals, "refId", "ref_name");
                ViewData["ReferalList"] = ReferalList;
                List<BusinessEntities.FrontDesk.RegistrationForm> regiform = BusinessLogicLayer.FrontDesk.RegistrationForm.GetRegistrationForm(appId);
                return PartialView("RegistrationForm", regiform.FirstOrDefault());
                //return View();
            }
            else
            {
                return PartialView("UnAuthorizedAccess");
            }
        }

        public ActionResult RegistrationFormTab()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int appId = Convert.ToInt32(TempData["appId"]);

                DataTable dt_nationalities = BusinessLogicLayer.Nationality.GetNationalities();
                SelectList NationalityList = Models.Helper.ToSelectList(dt_nationalities, "natId", "nationality");
                ViewData["NationalityList"] = NationalityList;
                DataTable dt_referals = BusinessLogicLayer.Referal.GetReferals();
                SelectList ReferalList = Models.Helper.ToSelectList(dt_referals, "refId", "ref_name");
                ViewData["ReferalList"] = ReferalList;
                List<BusinessEntities.FrontDesk.RegistrationForm> regiform = BusinessLogicLayer.FrontDesk.RegistrationForm.GetRegistrationForm(appId);
                return PartialView("RegistrationForm", regiform.FirstOrDefault());
                //return View();
            }
            else
            {
                return PartialView("UnAuthorizedAccess");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateRegistrationForm(BusinessEntities.FrontDesk.RegistrationForm data)
        {
            bool isInserted = false;
            int Action = (int)Actions.Update;
            data.pat_madeby = PageControl.getLoggedinId();

            if (PageControl.haveAccess(PageId, Action))
            {
                data.pat_mob = (data.pat_mob.Trim() == "+971") ? "" : data.pat_mob.Trim().Replace("+", "");
                data.pat_tel = (data.pat_tel.Trim() == "+971") ? "" : data.pat_tel.Trim().Replace("+", "");
                Dictionary<string, string> errors = new Dictionary<string, string>();
                if (SecurityLayer.FormValidations.RegistrationForm.isValidRegistrationForm(data, out errors))
                {
                    isInserted = BusinessLogicLayer.FrontDesk.RegistrationForm.UpdateRegistrationForm(data);

                    if (isInserted)
                    {
                        BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                        {
                            AJ_AJCId = 2,
                            AJ_AJSCId = 4,
                            AJ_AppId = data.appId
                        });

                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = " Already Exists!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion 

        [HttpGet]
        public JsonResult GetSignature(int? appId, string person, string form)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                List<BusinessEntities.Common.eSignature> data = BusinessLogicLayer.Common.eSignature.GetSignature(appId, person, form);
                var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}