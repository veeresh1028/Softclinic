using BusinessEntities.NurseStation;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities.MNR;
using System.Threading.Tasks;

namespace ClinicSoft.Areas.NurseStation.Controllers
{
    [Authorize]
    public class PastHistoryController : Controller
    {
        #region PastHistory

        // GET: NurseStation/PastHistory

        int PageId = (int)Pages.PastHistory;
        public PartialViewResult PastHistory()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("PastHistory");
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }

        }

        public JsonResult GetAllPastHistory(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PastHistory> pasthis = BusinessLogicLayer.NurseStation.PastHistory.GetAllPastHistory(appId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/PastHistory

        public JsonResult GetAllPrePastHistory(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PastHistory> pasthis = BusinessLogicLayer.NurseStation.PastHistory.GetAllPrePastHistory(appId, patId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Create: PastHistory
        public PartialViewResult CreatePastHistory()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    PastHistory pasthis = new PastHistory();
                    return PartialView("CreatePastHistory", pasthis);
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InsertPastHistory(PastHistory data)
        {
            bool isInserted = false;
            int val = 0;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();
                    data.pf_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.PastHistory.isValidPastHistory(data, out errors))
                    {
                        val = BusinessLogicLayer.NurseStation.PastHistory.InsertUpdatePastHistory(data);

                        if (val>0)
                        {
                            isInserted = true;
                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 3,
                                AJ_AJSCId = 8,
                                AJ_AppId = int.Parse(emr.appId)
                            });
                            if (emr.set_sync == "Yes")
                            {

                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08_2(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Inserted");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Past Family History Inserted Successfully Without Sharing Data"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ADTA31_2(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Inserted");

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Past Family History Inserted Successfully!"
                                    };
                                }
                                return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                            }
                            else
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Past Family History Inserted Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else if(val ==-1)
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Past Family History already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (val == -2)
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Please Enter Patient Allergies First!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Failed to Insert Allergies!" }, JsonRequestBehavior.AllowGet);
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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }

        // Edit: PastHistory
        [HttpGet]
        public PartialViewResult EditPastHistory(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<PastHistory> allergy = BusinessLogicLayer.NurseStation.PastHistory.GetAllPastHistory(appId );

                    return PartialView("EditPastHistory", allergy.FirstOrDefault());
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdatePastHistory(PastHistory data)
        {
            try
            {
                bool isInserted = false;
                int val = 0;
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.pf_madeby = PageControl.getLoggedinId();
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.PastHistory.isValidPastHistory(data, out errors))
                    {

                        val = BusinessLogicLayer.NurseStation.PastHistory.InsertUpdatePastHistory(data);

                        if (val>0)
                        {
                            isInserted = true;
                            if (emr.set_sync == "Yes")
                            {

                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08_2(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Updated");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Past Family History Updated Successfully Without Sharing Data"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ADTA31_2(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Updated");

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Past Family History Updated Successfully!"
                                    };
                                }
                                return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                            }
                            else
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Past Family History Updated Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Past Family History already exists!" }, JsonRequestBehavior.AllowGet);
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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }

        // Delete: NurseStation/PastHistory
        [HttpPost]
        public async Task<ActionResult> DeletePastHistory(int pfId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int pf_madeby = PageControl.getLoggedinId();
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                MNRAck ack = new MNRAck();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.NurseStation.PastHistory.DeletePastHistory(pfId, pf_madeby);

                    if (val == 1)
                    {
                        if (emr.set_sync == "Yes")
                        {

                            if (emr.set_mnr == "Nabidh")
                            {
                                if (emr.pat_class != "VIP")
                                {
                                    ack = await MNR.Nabidh.ADTA08_2(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Deleted");
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Past Family History Deleted Successfully Without Sharing Data"
                                    };
                                }
                            }
                            else if (emr.set_mnr == "Riayati")
                            {
                                ack = await MNR.Riayati.ADTA31_2D(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time);

                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = -2,
                                    message = "Past Family History Deleted Successfully!"
                                };
                            }
                            return Json(new { success = true, isAuthorized = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            return Json(new { success = true, isAuthorized = true, message = "Past Family History Deleted Successfully" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Unauthorized!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion 
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}