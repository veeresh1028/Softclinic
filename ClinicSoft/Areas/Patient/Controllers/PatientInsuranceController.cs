 using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessEntities.Patient;

namespace ClinicSoft.Areas.Patient.Controllers
{
    [Authorize]
    public class PatientInsuranceController : Controller
    {
        int PageId = (int)Pages.PatientInsurances;

        [HttpGet]
        public ActionResult GetPatientInsurancesById(int patId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<PatientInsurance> detailModal = BusinessLogicLayer.Patient.PatientInsurance.GetInsuranceDataByID(patId);

                    return PartialView("PatientInsurance", detailModal);
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

        [HttpGet]
        public ActionResult GetPatientInsurancesById_Json(int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<PatientInsurance> detailModal = new List<PatientInsurance>();
                    detailModal = BusinessLogicLayer.Patient.PatientInsurance.GetInsuranceDataByID(patId);
                    var jsonResult = Json(detailModal, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult GetPatient_InsuranceTPA(int? icId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt_TPAs = BusinessLogicLayer.Patient.PatientInsurance.GetPatient_InsuranceTPA(icId);
                    SelectList TPAList = Models.Helper.ToSelectList(dt_TPAs, "icId", "ic_name");
                    var jsonResult = Json(TPAList, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult GetPatient_InsurancePayers(int? ipId, int? ip_ins)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt_Payers = BusinessLogicLayer.Patient.PatientInsurance.GetPatient_InsurancePayers(ipId, ip_ins);
                    SelectList PayersList = Models.Helper.ToSelectList(dt_Payers, "ipId", "ip_name");
                    var jsonResult = Json(PayersList, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult GetPatient_InsuranceNetworks(int? isId, int? is_icId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt_Networks = BusinessLogicLayer.Patient.PatientInsurance.GetPatient_InsuranceNetworks(isId, is_icId);
                    SelectList NetworkList = Models.Helper.ToSelectList(dt_Networks, "isId", "is_title");
                    var jsonResult = Json(NetworkList, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public FileContentResult DownloadFile(string type, int id)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                byte[] fileContent = null;
                DataTable dt = BusinessLogicLayer.Lists.DownloadFile.GetFilePathDownload(id, type);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if ((row["file_path"].ToString().Trim() != "") &&
                    (row["file_path"].ToString().Trim() != null) &&
                    (row["file_path"].ToString().Trim() != "NA"))
                    {
                        string fileName = Path.Combine(Server.MapPath("~/images/patient_images/"), row["file_path"].ToString().Trim());


                        System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(fileName).Length;
                        fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();

                        //data = fileContent;
                        string[] strArr = row["file_path"].ToString().Trim().Split('\\');

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
        public ActionResult ViewDocument(string type, int id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Lists.DownloadFile file = new BusinessEntities.Lists.DownloadFile();
                    DataTable dt = BusinessLogicLayer.Lists.DownloadFile.GetFilePathDownload(id, type);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        if ((row["file_path"].ToString().Trim() != "") &&
                        (row["file_path"].ToString().Trim() != null) &&
                        (row["file_path"].ToString().Trim() != "NA"))
                        {
                            if (type == "pat_doc")
                            {
                                string[] path = row["file_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/uploaded_documents" }, StringSplitOptions.None);
                                file.file = ConfigurationManager.AppSettings["ClinicSoftEndPoint"] + "images/uploaded_documents" + path[1].Trim().ToString();
                            }
                            else
                            {
                                string fileName = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images/patient_images/", row["file_path"].ToString().Trim());
                                file.file = fileName;
                            }

                            file.id = id;
                            file.type = type;

                            return PartialView("ViewDocument", file);
                        }
                        else
                        {
                            return PartialView("ViewDocument", file);
                        }
                    }
                    else
                    {
                        return PartialView("ViewDocument", file);
                    }
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

        [HttpGet]
        public ActionResult CreatePatientInsurance(BusinessEntities.Patient.PatientInsuranceDetails insurance)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    insurance.pi_cded = 0;
                    insurance.pi_cded_limit = 0;
                    insurance.pi_cded_type = "Fixed";

                    insurance.pi_dded = 0;
                    insurance.pi_dded_limit = 0;
                    insurance.pi_dded_type = "Fixed";

                    insurance.pi_ip_dcopay = 0;
                    insurance.pi_ip_dcopay_limit = 0;
                    insurance.pi_ip_dcopay_type = "Fixed";

                    insurance.pi_dcopay = 0;
                    insurance.pi_dcopay_limit = 0;
                    insurance.pi_dcopay_type = "Fixed";

                    insurance.pi_copay = 0;
                    insurance.pi_copay_limit = 0;
                    insurance.pi_copay_type = "Fixed";

                    insurance.pi_hdcopay = 0;
                    insurance.pi_hdcopay_limit = 0;
                    insurance.pi_hdcopay_type = "Fixed";

                    insurance.pi_pded = 0;
                    insurance.pi_pded_limit = 0;
                    insurance.pi_pded_type = "Fixed";

                    insurance.pi_ided = 0;
                    insurance.pi_ided_limit = 0;
                    insurance.pi_ided_type = "Fixed";

                    insurance.pi_mded = 0;
                    insurance.pi_mded_limit = 0;
                    insurance.pi_mded_type = "Fixed";

                    insurance.pi_rded = 0;
                    insurance.pi_rded_limit = 0;
                    insurance.pi_rded_type = "Fixed";

                    return PartialView("CreatePatientInsurance", insurance);
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
        public ActionResult InsertPatientInsurance(PatientInsuranceDetails data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Patient.isValidPatientInsurance(data, out errors))
                    {
                        string file_path = Server.MapPath("~/images/patient_images/");

                        string file_name_ins_front = "ins_front_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string file_name_ins_back = "ins_back_" + DateTime.Now.ToString("yyyyMMddHHmmss");

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
                                HttpPostedFileBase file = files[j];

                                if (files.AllKeys[j] == "pi_image")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_ins_front = file_name_ins_front + _extension;
                                            string _path = Path.Combine(file_path, file_name_ins_front);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            data.pi_image = _path.Replace(Server.MapPath("~/images/patient_images/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("pi_image", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                                else if (files.AllKeys[j] == "pi_image2")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_ins_back = file_name_ins_back + _extension;
                                            string _path = Path.Combine(file_path, file_name_ins_back);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            data.pi_image2 = _path.Replace(Server.MapPath("~/images/patient_images/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("pi_image2", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                            }
                        }

                        int val = BusinessLogicLayer.Patient.PatientInsurance.InsertPatientInsurance(data, PageControl.getLoggedinId(), data.pi_patient);

                        if (val > 0)
                        {
                            Dictionary<string, int> dic = new Dictionary<string, int>();
                            dic.Add("piId", val);
                            return Json(new { isSuccess = true, message = dic }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {

                            if (System.IO.File.Exists(Path.Combine(file_path, file_name_ins_front))) { System.IO.File.Delete(Path.Combine(file_path, file_name_ins_front)); }
                            if (System.IO.File.Exists(Path.Combine(file_path, file_name_ins_back))) { System.IO.File.Delete(Path.Combine(file_path, file_name_ins_back)); }


                            if (val == -1)
                            {
                                errors.Add("pi_payer,pi_insurance,pi_scheme", "Patient already have the Same insurance");
                            }

                            return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult EditPatientInsurance(int piId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    PatientInsuranceDetails insurance = BusinessLogicLayer.Patient.PatientInsurance.GetInsuranceDataByInsuranceID(piId);

                    return PartialView("EditPatientInsurance", insurance);
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
        public ActionResult UpdatePatientInsurance(PatientInsuranceDetails data)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.Patient.isValidPatientInsurance(data, out errors))
                    {
                        string file_path = Server.MapPath("~/images/patient_images/");
                        string file_name_ins_front = "ins_front_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string file_name_ins_back = "ins_back_" + DateTime.Now.ToString("yyyyMMddHHmmss");

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
                                HttpPostedFileBase file = files[j];

                                if (files.AllKeys[j] == "upi_image")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_ins_front = file_name_ins_front + _extension;
                                            string _path = Path.Combine(file_path, file_name_ins_front);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            data.pi_image = _path.Replace(Server.MapPath("~/images/patient_images/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("upi_image", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                                else if (files.AllKeys[j] == "upi_image2")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_ins_back = file_name_ins_back + _extension;
                                            string _path = Path.Combine(file_path, file_name_ins_back);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            data.pi_image2 = _path.Replace(Server.MapPath("~/images/patient_images/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("upi_image2", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                            }
                        }

                        int val = BusinessLogicLayer.Patient.PatientInsurance.UpdatePatientInsurance(data, PageControl.getLoggedinId());

                        if (val > 0)
                        {
                            Dictionary<string, int> dic = new Dictionary<string, int>();
                            dic.Add("piId", val);

                            return Json(new { isSuccess = true, message = dic }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            if (System.IO.File.Exists(Path.Combine(file_path, file_name_ins_front))) { System.IO.File.Delete(Path.Combine(file_path, file_name_ins_front)); }
                            if (System.IO.File.Exists(Path.Combine(file_path, file_name_ins_back))) { System.IO.File.Delete(Path.Combine(file_path, file_name_ins_back)); }

                            if (val == -1)
                            {
                                errors.Add("upi_payer,upi_insurance,upi_scheme", "Patient already have the Same insurance");
                            }

                            return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult GetPatientInfo(int patId)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                PatientDetails patient = BusinessLogicLayer.Patient.Patient.GetPatientById(patId);
                string pat_info = (patient.pat_name + " " + patient.pat_mname + " " + patient.pat_lname).Replace("  ", " ") + " (" + patient.pat_code + ")";
                var jsonResult = Json(pat_info, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult DeletePatientInsurance(int piId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Patient.PatientInsurance.ChangePatientInsuranceStatus(piId, "Deleted", PageControl.getLoggedinId());

                if (val == 1)
                {
                    return Json(new { isAuthorized = true, success = true, message = val }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = true, success = false, message = val }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = -1 }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult UpdateInsuranceStatus(int piId, string status)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Patient.PatientInsurance.ChangePatientInsuranceStatus(piId, status, PageControl.getLoggedinId());

                if (val == 1)
                {
                    return Json(new { isAuthorized = true, success = true, message = val }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = true, success = false, message = val }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #region Miscellaneous Functions
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            bool isPartial = filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            TempData["error"] = filterContext;

            string actionName = isPartial ? "ErrorPartialView" : "Error";

            filterContext.Result = RedirectToAction(actionName, "Error", new { area = "Common" });
        }
        #endregion
    }
}