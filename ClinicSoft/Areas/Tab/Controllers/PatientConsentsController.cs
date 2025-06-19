using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Tab.Controllers
{
    [Authorize]
    public class PatientConsentsController : Controller
    {
        #region Patient Consents (Page Load)
        [HttpGet]
        public ActionResult PatientConsents()
        {
            return View();
        }
        #endregion

        #region Load Drodpowns & Datatable
        [HttpGet]
        public ActionResult SearchPatients(string query, string type)
        {
            try
            {
                List<CommonDDL> dt = BusinessLogicLayer.Tab.PatientConsents.SearchPatients(int.Parse(type), query);

                var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            catch (Exception ex)
            {
                var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
        }

        [HttpGet]
        public JsonResult GetPatientAppointments(int patId)
        {
            try
            {
                List<AppointmentHistory> list = BusinessLogicLayer.Appointment.Appointment.GetAppointmentByPatId(patId);

                return Json(new { list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Form Manager
        [HttpGet]
        public PartialViewResult FormManager(int appId, string app_type)
        {
            BusinessEntities.Tab.FormManager fm = new BusinessEntities.Tab.FormManager();
            fm.appId = appId;
            fm.app_type = app_type;

            return PartialView(fm);
        }
        #endregion

        #region Electronic Medical Record(s)
        [HttpPost]
        public JsonResult GetTabPatientInfo(int appId)
        {
            EMRInfo emr = new EMRInfo();

            try
            {
                DataSet ds = BusinessLogicLayer.EMR.EMR_Patient.GetPatientEMRInfo(appId);

                if (ds.Tables.Count > 0)
                {
                    string signs = string.Empty;
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        emr.pat_code = dt.Rows[0]["pat_code"].ToString();
                        emr.pat_name = dt.Rows[0]["pat_name"].ToString();
                        emr.pat_fname = dt.Rows[0]["pat_fname"].ToString();
                        emr.pat_mname = dt.Rows[0]["pat_mname"].ToString();
                        emr.pat_lname = dt.Rows[0]["pat_lname"].ToString();
                        emr.pat_emirateid = dt.Rows[0]["pat_emirateid"].ToString();
                        emr.pat_age = dt.Rows[0]["pat_age"].ToString();
                        emr.pat_gender = dt.Rows[0]["pat_gender"].ToString();
                        emr.pat_nationality = dt.Rows[0]["pat_nationality"].ToString();
                        emr.pat_photo = dt.Rows[0]["pat_photo"].ToString();
                        emr.pat_ms = (dt.Rows[0]["pat_ms"].ToString() == "S") ? "Single" : ((dt.Rows[0]["pat_ms"].ToString() == "M") ? "Married" : dt.Rows[0]["pat_ms"].ToString());
                        emr.appId = dt.Rows[0]["appId"].ToString();
                        emr.app_ic_name = dt.Rows[0]["app_ic_name"].ToString();
                        emr.app_fdate_time = dt.Rows[0]["app_fdate_time"].ToString();
                        emr.app_doctor_department = dt.Rows[0]["emp_name"].ToString() + " - " + dt.Rows[0]["emp_dept_name"].ToString() + " (" + dt.Rows[0]["emp_license"].ToString() + ")";
                        emr.set_emr_lock = dt.Rows[0]["set_emr_lock"].ToString();
                        emr.patId = int.Parse(dt.Rows[0]["patId"].ToString());
                        emr.icId = int.Parse(dt.Rows[0]["icId"].ToString());
                        emr.app_branch = int.Parse(dt.Rows[0]["app_branch"].ToString());
                        emr.app_ae_date = DateTime.Parse(dt.Rows[0]["app_ae_date"].ToString());
                        emr.app_ae_date1 = Convert.ToDateTime(dt.Rows[0]["app_ae_date"]);
                        emr.emp_photo = dt.Rows[0]["emp_photo"].ToString();
                        emr.app_doctor = int.Parse(dt.Rows[0]["app_doctor"].ToString());
                        emr.set_header_image = dt.Rows[0]["set_header_image"].ToString();
                        emr.set_footer_image = dt.Rows[0]["set_footer_image"].ToString();
                        emr.app_category = dt.Rows[0]["app_category"].ToString();
                        emr.pat_mob = dt.Rows[0]["pat_mob"].ToString();
                        emr.pat_email = dt.Rows[0]["pat_email"].ToString();
                        emr.pat_address = dt.Rows[0]["pat_address"].ToString();
                        emr.pi_insno = dt.Rows[0]["pi_insno"].ToString();
                        emr.pi_polocyno = dt.Rows[0]["pi_polocyno"].ToString();
                        emr.pat_dob = dt.Rows[0]["pat_dob"].ToString();
                        emr.app_fdate = dt.Rows[0]["app_fdate"].ToString();
                        emr.is_title = dt.Rows[0]["is_title"].ToString();
                        emr.ic_name = dt.Rows[0]["ic_name"].ToString();
                        emr.doc_name = dt.Rows[0]["doc_name"].ToString();
                        emr.pat_city = dt.Rows[0]["pat_city"].ToString();
                        emr.pat_country = dt.Rows[0]["pat_country"].ToString();
                        emr.pat_pobox = dt.Rows[0]["pat_pobox"].ToString();
                        emr.set_company = dt.Rows[0]["set_company"].ToString();
                        emr.set_permit_no = dt.Rows[0]["set_permit_no"].ToString();
                        emr.emp_license = dt.Rows[0]["emp_license"].ToString();
                        emr.emp_tel = dt.Rows[0]["emp_tel"].ToString();
                        emr.emp_fax = dt.Rows[0]["emp_fax"].ToString();
                        emr.emp_address = dt.Rows[0]["emp_address"].ToString();
                        emr.emp_nat = dt.Rows[0]["emp_nat"].ToString();
                        emr.emp_email = dt.Rows[0]["emp_email"].ToString();
                        emr.app_room = int.Parse(dt.Rows[0]["app_room"].ToString());
                        emr.emp_dept_name = dt.Rows[0]["emp_dept_name"].ToString();
                        emr.pat_fax = dt.Rows[0]["pat_fax"].ToString();
                        emr.set_fax = dt.Rows[0]["set_fax"].ToString();
                        emr.set_tel = dt.Rows[0]["set_tel"].ToString();
                        emr.set_address = dt.Rows[0]["set_address"].ToString();
                        emr.set_city = dt.Rows[0]["set_city"].ToString();
                        emr.emp_speciality = dt.Rows[0]["emp_speciality"].ToString();
                        emr.pat_contact_role = dt.Rows[0]["pat_contact_role"].ToString();
                        emr.pi_edate = dt.Rows[0]["pi_edate"].ToString();
                        emr.set_email = dt.Rows[0]["set_email"].ToString();
                        emr.emp_speciality = dt.Rows[0]["emp_speciality"].ToString();
                        emr.doc_sign = (dt.Rows[0]["emp_sign"].ToString() == "") ? string.Empty : Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dt.Rows[0]["emp_sign"].ToString());
                        emr.pi_image = (dt.Rows[0]["pi_image"].ToString() == "") ? string.Empty : Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Insurance_Cards", dt.Rows[0]["pi_image"].ToString());
                        emr.is_allowed_limit = Convert.ToDecimal(dt.Rows[0]["is_allowed_limit"].ToString());
                        emr.app_status = dt.Rows[0]["app_status"].ToString();
                        emr.pat_class = dt.Rows[0]["pat_class"].ToString();
                        emr.set_sync = dt.Rows[0]["set_sync"].ToString();
                        emr.set_mnr = dt.Rows[0]["set_mnr"].ToString();
                        emr.app_ip_code = dt.Rows[0]["app_ip_code"].ToString();
                    }

                    DataTable dt_signs = ds.Tables[1];

                    if (dt_signs.Rows.Count > 0)
                    {
                        DataRow dr = dt_signs.Rows[0];
                        signs += (!string.IsNullOrEmpty(dr["sign_temp"].ToString())) ? (" Temp:" + dr["sign_temp"].ToString() + "°C,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_pulse"].ToString())) ? (" Pulse:" + dr["sign_pulse"].ToString() + "bpm,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_bp"].ToString())) ? (" BPS:" + dr["sign_bp"].ToString() + "mmHg,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_bpd"].ToString())) ? (" BPD:" + dr["sign_bpd"].ToString() + "mmHg,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_height"].ToString())) ? (" Height:" + dr["sign_height"].ToString() + "cm,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_weight"].ToString())) ? (" Weight:" + dr["sign_weight"].ToString() + "kg,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_bmi"].ToString())) ? (" BMI:" + dr["sign_bmi"].ToString()) : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_uri"].ToString())) ? (" Blood Sugar:" + dr["sign_uri"].ToString()) : string.Empty;
                    }

                    emr.vital_sign = signs;

                    string allergy = string.Empty;
                    DataTable dt_allergy = ds.Tables[2];

                    if (dt_allergy.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt_allergy.Rows)
                        {
                            string _for = dr["all_for"].ToString();
                            string _pexam = dr["all_pexam"].ToString();

                            allergy += (!string.IsNullOrEmpty(_for)) ? (!string.IsNullOrEmpty(_pexam) ? (_for.ToString() + " " + _pexam + ",") : (_for + ",")) : string.Empty;
                        }
                    }

                    emr.allergy = allergy;

                    if (!string.IsNullOrEmpty(signs) || !string.IsNullOrEmpty(allergy))
                    {
                        emr.isAlert = true;
                    }
                    else
                    {
                        emr.isAlert = false;
                    }
                }

                TempData["emr_data"] = emr;

                return Json(new { data = emr, result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.EMR_Data = ex.Message;

                return Json(new { data = emr, result = false }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;

            filterContext.Result = RedirectToAction("ErrorTab", "Common", new { area = "Tab" });
        }
    }
}