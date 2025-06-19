using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using BusinessEntities.MNR;
using Google.Type;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class CheifComplaintsController : Controller
    {
        #region Complaints
        // GET: EMR/CheifComplaints

        int PageId = (int)Pages.ChiefComplaints;
        public PartialViewResult CheifComplaints()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CheifComplaints");
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

        public JsonResult GetAllCheifComplaints(int appId, int? compId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CheifComplaints> CheifComplaints = BusinessLogicLayer.EMR.CheifComplaints.GetAllCheifComplaints(appId, compId);

                return Json(CheifComplaints, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/CheifComplaints

        public JsonResult GetAllPreCheifComplaints(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CheifComplaints> notes = BusinessLogicLayer.EMR.CheifComplaints.GetAllPreCheifComplaints(appId, patId);

                return Json(notes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //CREATE:CheifComplaints

        public PartialViewResult CreateCheifComplaints()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    CheifComplaints complaints = new CheifComplaints();
                    return PartialView("CreateCheifComplaints", complaints);
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

        //GET:Complaints Master

        public ActionResult GetComplaints(string query)
        {
            int Action = (int)Actions.Read;
            if(PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<GetByName> complaint = BusinessLogicLayer.EMR.CheifComplaints.GetComplaints(query);
                    var jsonResult = Json(complaint, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex) 
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }

            }
            else 
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InsertCheifComplaints(CheifComplaints data)
        {
            try
            {
                int val = 0;
                bool isInserted = false;
                data.comp_madeby=PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();
                    Dictionary<string,string> errors= new Dictionary<string,string>();
                    if (SecurityLayer.FormValidations.CheifComplaints.isValidCheifComplaints(data, out errors))
                    {
                        val = BusinessLogicLayer.EMR.CheifComplaints.InsertUpdateCheifComplaints(data);
                        if(val>0)
                        {
                            isInserted = true;
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.comp_madeby,
                                log_desc = $"Employee Created New Cheif Complaints (Id) : {data.compId}"
                            });
                            if (data.comp_severity == "Chronic")
                            {

                                if (emr.set_sync == "Yes")
                                {

                                    if (emr.set_mnr == "Nabidh")
                                    {
                                        if (emr.pat_class != "VIP")
                                        {
                                            ack = await MNR.Nabidh.PPRPC1(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Inserted");
                                        }
                                        else
                                        {
                                            ack = new MNRAck
                                            {
                                                value = -2,
                                                message = "Chronic Problems Inserted Successfully Without Sharing Data"
                                            };
                                        }
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Chronic Problems Inserted Successfully!"
                                        };
                                    }
                                    return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                                }
                                else
                                {
                                    return Json(new { isInserted = true, isSuccess = true, message = "Chronic Problems Inserted Successfully" }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Cheif Complaints Inserted Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else if (val == -1)
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Cheif Complaints already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (val == -2)
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Please Enter Vital Signs First!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Failed to Adding Cheif Complaints!" }, JsonRequestBehavior.AllowGet);
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

        //EDIT :Cheif Complaints
        public PartialViewResult EditCheifComplaints(int appId, int compId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<CheifComplaints> complaints = BusinessLogicLayer.EMR.CheifComplaints.GetAllCheifComplaints(appId, compId);
                    return PartialView("EditCheifComplaints", complaints.FirstOrDefault());
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
        public async Task<ActionResult> UpdateCheifComplaints(CheifComplaints data)
        {
            try
            {
                bool isInserted = false;
                int val = 0;
                data.comp_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.CheifComplaints.isValidCheifComplaints(data, out errors))
                    {
                        val = BusinessLogicLayer.EMR.CheifComplaints.InsertUpdateCheifComplaints(data);
                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.comp_madeby,
                                log_desc = $"Employee Created New Cheif Complaints (Id) : {data.compId}"
                            });
                            if (data.comp_severity == "Chronic")
                            {

                                if (emr.set_sync == "Yes")
                                {

                                    if (emr.set_mnr == "Nabidh")
                                    {
                                        if (emr.pat_class != "VIP")
                                        {
                                            ack = await MNR.Nabidh.PPRPC1(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Updated");
                                        }
                                        else
                                        {
                                            ack = new MNRAck
                                            {
                                                value = -2,
                                                message = "Chronic Problems Updated Successfully Without Sharing Data"
                                            };
                                        }
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Chronic Problems Updated Successfully!"
                                        };
                                    }
                                    return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                                }
                                else
                                {
                                    return Json(new { isInserted = true, isSuccess = true, message = "Chronic Problems Updated Successfully" }, JsonRequestBehavior.AllowGet);
                                }
                            }
                        }
                        else if (val == -2)
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Please Enter Vital Signs First!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Failed to Update Cheif Complaints!" }, JsonRequestBehavior.AllowGet);
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

        //DELETE :Cheif Complaints

        [HttpPost]
        public async Task <ActionResult> DeleteCheifComplaints(int compId,string comp_severity)
        {
            try
            {
                int comp_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Delete;
                if (PageControl.haveAccess(PageId,Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();
                    int val = BusinessLogicLayer.EMR.CheifComplaints.DeleteCheifComplaints(compId, comp_madeby);
                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = comp_madeby,
                            log_desc = $"Employee Deleted CheifComplaints for (Id) : {compId}"
                        });
                        if (comp_severity == "Chronic")
                        {

                            if (emr.set_sync == "Yes")
                            {

                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.PPRPC1(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Updated");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Chronic Problems Updated Successfully Without Sharing Data"
                                        };
                                    }
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Chronic Problems Updated Successfully!"
                                    };
                                }
                                return Json(new { success = true, isAuthorized = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                            }
                            else
                            {
                                return Json(new { success = true, isAuthorized = true, message = "Chronic Problems Updated Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { success = true, isAuthorized = true, message = "Cheif Complaints Updated Successfully" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Unauthorized!" },JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Copy/Previous
        public JsonResult CopyCheifComplaints(int compId)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CheifComplaints> complaints = BusinessLogicLayer.EMR.CheifComplaints.GetAllCheifComplaints(0, compId);

                return Json(complaints, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion 
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["errorEMR"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
    }
}