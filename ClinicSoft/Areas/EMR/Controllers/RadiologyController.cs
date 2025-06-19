using BusinessEntities;
using BusinessEntities.Common;
using BusinessEntities.EMR;
using BusinessEntities.MNR;
using Google.Protobuf.WellKnownTypes;
using Google.Type;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    public class RadiologyController : Controller
    {
        int PageId = (int)Pages.PatientTreatments;
        // GET: EMR/Radiology
        public PartialViewResult Radiology()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Radiology Page!"
                    });
                    return PartialView("Radiology");
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


        public JsonResult GetRadiologyTreatments(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PatientTreatments> narrative = BusinessLogicLayer.EMR.PatientTreatments.GetRadiologyTreatments(appId, "Radiology");

                return Json(narrative, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult UploadRadiologyPdf(int ptId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Radiology Rad = new Radiology();
                    Rad.ptId = ptId;
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed  Documents with ptId = {ptId}"
                    });

                    return PartialView("UploadRadiologyPdf", Rad);
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
        public async Task<ActionResult> UploadRadFiles(Radiology data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    MNRAck ack = new MNRAck();
                    bool issuccess = false;
                    DocErrorResponse err = new DocErrorResponse();

                    string file_path = Server.MapPath("~/images/Lab_Results/");

                    if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
                    {
                        file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                        Directory.CreateDirectory(file_path);
                    }
                    else
                    {
                        file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                    }

                    if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
                    {
                        file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                        Directory.CreateDirectory(file_path);
                    }
                    else
                    {
                        file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                    }

                    if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
                    {
                        file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                        Directory.CreateDirectory(file_path);
                    }
                    else
                    {
                        file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                    }

                    if (Request.Files.Count > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;

                        for (int j = 0; j < files.Count; j++)
                        {
                            HttpPostedFileBase _file = files[j];

                            if (_file.ContentLength > 0)
                            {
                                if (_file.ContentLength <= 5242880)
                                {
                                    issuccess = true;

                                    string _extension = Path.GetExtension(_file.FileName);
                                    string _file_name = DateTime.Now.ToString("yyyyMMddHHmmss") + _extension;
                                    string _path = Path.Combine(file_path, _file_name);

                                    Radiology Rad = new Radiology();
                                    Rad.lr_test = data.lr_test;
                                    Rad.lr_appId = data.lr_appId;
                                    Rad.lr_from = data.lr_from;
                                    Rad.lr_lab_name = data.lr_lab_name;
                                    Rad.lr_image1 = _path;
                                    Rad.lr_madeby = PageControl.getLoggedinId();

                                    if (data.lr_test > 0 && !string.IsNullOrEmpty(Rad.lr_image1))
                                    {
                                        if (BusinessLogicLayer.EMR.Radiology.UploadDocument(Rad))
                                        {
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            _file.SaveAs(_path);

                                            var value = data.lr_appId;
                                            DataSet ds = BusinessLogicLayer.EMR.EMR_Patient.GetPatientEMRInfo(value);
                                            DataTable dt = ds.Tables[0];

                                            if (dt.Rows[0]["set_sync"].ToString() == "Yes")
                                            {
                                                if (dt.Rows[0]["set_sync"].ToString() == "Yes")
                                                {
                                                    if (dt.Rows[0]["set_mnr"].ToString() == "Nabidh")
                                                    {
                                                        ack = await MNR.Nabidh.ORUR01_1(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), dt.Rows[0]["app_fdate_time"].ToString(), value);
                                                    }
                                                    else if (dt.Rows[0]["set_mnr"].ToString() == "Riayati")
                                                    {
                                                        //ack = await MNR.Riayati.ORUR01_1(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value, app.app_inout);

                                                    }
                                                    else if (dt.Rows[0]["set_mnr"].ToString() == "Malaffi")
                                                    {
                                                        //ack = await MNR.Malaffi.ORUR01_1(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value);

                                                    }
                                                    else
                                                    {
                                                        ack = new MNRAck
                                                        {
                                                            value = value,
                                                            message = "Documents uploaded Successfully and message send to nabidh"
                                                        };


                                                    }
                                                    return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                                                }
                                                else
                                                {
                                                    ack = new MNRAck
                                                    {
                                                        value = value,
                                                        message = "Documents uploaded Successfully"
                                                    };
                                                    return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                                                }
                                            }
                                            else
                                            {
                                                ack = new MNRAck
                                                {
                                                    value = value,
                                                    message = "Documents uploaded Successfully"
                                                };
                                                return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    err.success = false;
                                    err.errorcode = HttpStatusCode.RequestEntityTooLarge.ToString();
                                    err.error = "Uploaded File should not be exceed to 5MB";
                                }
                            }
                            else
                            {
                                err.success = false;
                                err.errorcode = HttpStatusCode.NotFound.ToString();
                                err.error = "File Not Received";
                            }
                        }
                    }

                    if (issuccess)
                    {
                        DocSuccessResponse success = new DocSuccessResponse();
                        success.success = true;

                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Uploaded Patient Documents"
                        });
                        ack = new MNRAck
                        {
                            value = data.lr_appId,
                            message = "Documents uploaded Successfully"
                        };
                        return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ack = new MNRAck
                        {
                            value = data.lr_appId,
                            message = "Uploading Documents failed!!"
                        };
                        return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    DocErrorResponse err = new DocErrorResponse();
                    err.success = false;
                    err.errorcode = HttpStatusCode.InternalServerError.ToString();
                    err.error = ex.Message;

                    return Json(err, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public JsonResult GetPDFDocuments(int appId, int ptId, string type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Radiology> narrative = BusinessLogicLayer.EMR.Radiology.GetPDFDocuments(appId, ptId, "Radiology");

                var jsonResult = Json(new { isAutherized = true, isSuccess = true, message = narrative }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public FileContentResult DownloadFile(int lrId, string path)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                byte[] fileContent = null;


                if (lrId > 0)
                {
                    if ((path.Trim() != "") &&
                    (path.Trim() != null) &&
                    (path.Trim() != "NA"))
                    {
                        string fileName = path;


                        System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(fileName).Length;
                        fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();

                        //data = fileContent;
                        string[] strArr = path.Trim().Split('\\');

                        if (strArr.Length > 0)
                        {
                            string _name = strArr[strArr.Length - 1];

                            Response.AppendHeader("Content-type", "." + _name.Split('.')[1].Trim());
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + _name);
                        }

                    }
                }

                return new FileContentResult(fileContent, "image/jpeg");
            }
            else
            {
                return new FileContentResult(null, "image/jpeg");
            }
        }


        [HttpGet]
        public PartialViewResult ReportResults(int ptId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    ReportResults Rad = new ReportResults();
                    Rad.ptId = ptId;
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed  Documents with ptId = {ptId}"
                    });

                    return PartialView("ReportResults", Rad);
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
        public async Task<ActionResult> AddReportResults(ReportResults item)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int val = BusinessLogicLayer.EMR.Radiology.CreateReportResults(item, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Created Report for  : {item.radr_ptId}"
                        });

                        var value = item.radr_appId;
                        DataSet ds = BusinessLogicLayer.EMR.EMR_Patient.GetPatientEMRInfo(value);
                        DataTable dt = ds.Tables[0];
                        MNRAck ack = new MNRAck();
                        if (dt.Rows[0]["set_sync"].ToString() == "Yes")
                        {
                            if (dt.Rows[0]["set_sync"].ToString() == "Yes")
                            {
                                if (dt.Rows[0]["set_mnr"].ToString() == "Nabidh")
                                {
                                    ack = await MNR.Nabidh.ORUR01_2(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), dt.Rows[0]["app_fdate_time"].ToString(), value);
                                }
                                else if (dt.Rows[0]["set_mnr"].ToString() == "Riayati")
                                {
                                    //ack = await MNR.Riayati.ORUR01_2(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value, app.app_inout);
                                }
                                else if (dt.Rows[0]["set_mnr"].ToString() == "Malaffi")
                                {
                                    //ack = await MNR.Malaffi.ORUR01_2(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value);
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = value,
                                        message = "Documents uploaded Successfully and message send to nabidh"
                                    };


                                }
                                return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = value,
                                    message = "Documents uploaded Successfully"
                                };
                                return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            ack = new MNRAck
                            {
                                value = value,
                                message = "Documents uploaded Successfully"
                            };
                            return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = -1 }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public JsonResult GetReportResults(int appId, int ptId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {

                List<BusinessEntities.EMR.ReportResults> list = new List<BusinessEntities.EMR.ReportResults>();
                try
                {
                    list = BusinessLogicLayer.EMR.Radiology.GetReportResults(appId, ptId);

                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteReportResults(int radrId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMR.Radiology.UpdateReportResultsStatus(radrId, "Deleted");

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted reports with radrId = {radrId}"
                        });



                        return Json(new { success = true, isAuthorized = true, message = "Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Unauthorised!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}