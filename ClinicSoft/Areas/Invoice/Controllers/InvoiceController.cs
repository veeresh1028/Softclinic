using BusinessEntities.Appointment;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using BusinessEntities.Invoice;
using Newtonsoft.Json;
using RestSharp;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Security.Claims;
using System.Linq;
using BusinessEntities.MNR;

namespace ClinicSoft.Areas.Invoice.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        int PageId = (int)Pages.Invoice;
        int PageId_Whatsapp = (int)Pages.PatientWhatsapp;
        int PageId_Email = (int)Pages.PatientEmail;
        int PageId_PatientTreatments = (int)Pages.PatientTreatments;

        #region Invoices (Page Load & Search)
        public ActionResult InvoiceIndex()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetInvoices(BusinessEntities.Invoice.InvoiceSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Invoice.Invoice> invoiceList = new List<BusinessEntities.Invoice.Invoice>();

                try
                {
                    invoiceList = BusinessLogicLayer.Invoice.Invoice.GetInvoices(data);

                    var jsonResult = Json(invoiceList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(invoiceList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        #region Advanced Filters
        [HttpGet]
        public ActionResult GetBranches()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> branchList = new List<CommonDDL>();
                try
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranchesForAppointment();
                    branchList = SecurityLayer.TableToList.ConvertDataTable<CommonDDL>(dt);

                    var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetDepartments()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> departmentList = new List<CommonDDL>();
                try
                {
                    DataTable dt = BusinessLogicLayer.Appointment.Appointment.GetAllDepartments();
                    departmentList = SecurityLayer.TableToList.ConvertDataTable<CommonDDL>(dt);

                    var jsonResult = Json(departmentList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(departmentList, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetDoctorsByDepartment(DoctorsByDeptBranch depts)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> data = BusinessLogicLayer.Appointment.Appointment.GetDoctorsByDepartments(string.Join(",", depts.Departments), string.Join(",", depts.Branches));

                var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetPatients(GetPatients patient)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Appointment.Appointment.GetPatients(patient);

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
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetInsuranceTPA(int? icId)
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
        public ActionResult GetInsurancePayers(string ip_ins)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt_Payers = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsurancePayersByTPA(ip_ins);
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
        #endregion

        #region Invoices CRUD Operations & Miscellaenous Functions
        [HttpGet]
        public ActionResult InvoiceItems(int appId, int invId, int inv_insurance)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Invoice.InvoiceServices> inv_serviceList = new List<BusinessEntities.Invoice.InvoiceServices>();

                    inv_serviceList = BusinessLogicLayer.Invoice.Invoice.GetServicesByInvoices(appId, invId, inv_insurance);

                    return PartialView("InvoiceItems", inv_serviceList);
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
        public PartialViewResult QuickCashBilling(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.QuickCash qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfo(appId);

                    if (qc_info.qc_invoice_info.invId > 0)
                    {
                        BusinessEntities.Invoice.QuickCash edit_qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfoByInvId(qc_info.qc_invoice_info.invId);

                        return PartialView("EditCashBilling", edit_qc_info);
                    }
                    else
                    {
                        return PartialView("QuickCashBilling", qc_info);
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
        public PartialViewResult QuickCashMultiBilling(int appId,int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                
                if (PageControl.haveAccess(PageId, Action))
                {
                    if (string.IsNullOrEmpty(invId.ToString()))
                    {
                        invId = 0;
                    }
                    BusinessEntities.Invoice.QuickCash qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQCM_InvoiceInfo(appId, invId);
                    if (invId > 0)
                    {
                        BusinessEntities.Invoice.QuickCash edit_qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfoByInvId(invId);
                        return PartialView("QuickCashMultiBilling", edit_qc_info);
                    }
                    else
                    {
                        qc_info.qc_invoice_info.invId = 0;
                        return PartialView("QuickCashBilling", qc_info);
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
        public ActionResult SearchTreatments(string query, string appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_PatientTreatments, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Invoice.QuickCash.GetQC_Treatments(query, appId);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
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
        public ActionResult SearchTreatmentsforEdit(int trId, string appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_PatientTreatments, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Invoice.QuickCash.GetQC_TreatmentsEdit(trId, appId);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
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
        public ActionResult SelectTreatment(int trId, int appId, int isPackage)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_PatientTreatments, Action))
            {
                try
                {
                    QC_TreatmentSelection dt = BusinessLogicLayer.Invoice.QuickCash.GetQC_TreatmentValues(trId, appId, isPackage);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
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
        public ActionResult SelectTreatmentReceipts(int ptId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_PatientTreatments, Action))
            {
                try
                {
                    ServiceWiseReceiptsInfo dt = BusinessLogicLayer.Invoice.Receipts.GetServiceWiseReceipts(ptId);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
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
        public async Task<ActionResult> GenerateQCInvoice(QC_Invoice data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string inv_no = string.Empty;
                    int qcBill = 0;
                    bool isValid = int.TryParse(data.invoice_info.multi_bill, out qcBill);

                    int val = BusinessLogicLayer.Invoice.QuickCash.Generate_QCInvoice(data, PageControl.getLoggedinId(), qcBill, out inv_no);
                    MNRAck ack = new MNRAck();
                    if (val > 0)
                    {                        
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Generated Quick Cash Invoice for inv_no = {inv_no}"
                        });
                        if (data.invoice_info.set_sync == "Yes")
                        {
                            if (data.invoice_info.set_mnr == "Nabidh")
                            {
                                if (data.invoice_info.pat_class != "VIP")
                                {
                                    ack = await MNR.Nabidh.ADTA03(data.invoice_info.appId, int.Parse(data.invoice_info.pat_code), int.Parse(data.invoice_info.patId.ToString()), val, data.invoice_info.app_fdate_time);
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = val,
                                        message = "Patient Treatments Invoiced Successfully Without Sharing Data"
                                    };
                                }
                            }
                            else if (data.invoice_info.set_mnr == "Riayati")
                            {
                                ack = await MNR.Riayati.ADTA03(data.invoice_info.appId, int.Parse(data.invoice_info.pat_code), int.Parse(data.invoice_info.patId.ToString()), data.invoice_info.app_fdate_time, "Invoiced");

                            }
                            else if (data.invoice_info.set_mnr == "Malaffi")
                            {
                                ack = await MNR.Malaffi.ADTA03(data.invoice_info.appId, int.Parse(data.invoice_info.pat_code), int.Parse(data.invoice_info.patId.ToString()), data.invoice_info.app_fdate_time, "Invoiced");

                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = val,
                                    message = "Patient Treatments Invoiced Successfully! Please Update The conectivity for sharing data"
                                };
                            }
                            return Json(new { isInserted = true, isSuccess = true, msg = ack.message }, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            ack = new MNRAck
                            {
                                value = val,
                                message = "Patient Treatments Invoiced Successfully"
                            };
                            return Json(new { isInserted = true, isSuccess = true, invId = val, msg = ack.message }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else if(val==-2)
                    {
                        ack = new MNRAck
                        {
                            value = val,
                            message = "Please Enter Patient Diagnosis & Progress Notes!"
                        };
                        return Json(new { isInserted = false, isSuccess = false, invId = 0, msg = ack.message }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ack = new MNRAck
                        {
                            value = val,
                            message = "Error in creating the treatments"
                        };
                        return Json(new { isSuccess = false, invId = 0, msg = ack.message }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult PrintInvoice(int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.InvoicePrint print = BusinessLogicLayer.Invoice.Invoice.PrintCashInvoice(invId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Invoice with invId = {invId}"
                    });

                    return View("PrintInvoice", print);
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
        public ActionResult printInsInvoice(int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.InvoicePrint print = BusinessLogicLayer.Invoice.Invoice.PrintInsuranceInvoice(invId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Insurance Invoice with invId = {invId}"
                    });

                    return View("printInsInvoice", print);
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
        public ActionResult PrintInsuranceInvoice(int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.InvoicePrint print = BusinessLogicLayer.Invoice.Invoice.PrintInsuranceInvoice(invId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Invoice with invId = {invId}"
                    });

                    return View("PrintInsuranceInvoice", print);
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
        public ActionResult EditCashBilling(int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.QuickCash qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfoByInvId(invId);

                    return PartialView("EditCashBilling", qc_info);
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
        public ActionResult UpdateQCInvoice(QC_Invoice data)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string inv_no = string.Empty;

                    int val = BusinessLogicLayer.Invoice.QuickCash.Update_QCInvoice(data, PageControl.getLoggedinId(), out inv_no);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Generated Quick Cash Invoice for inv_no = {inv_no}"
                        });

                        return Json(new { isSuccess = true, invId = val, message = "Invoice No. " + inv_no + " is generated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in creating the treatments " }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public PartialViewResult EditCashInvoice(int invId, int patId, string inv_type, string ins_dept)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    TempData["Layout"] = true;
                    InvoiceKeys keys = new InvoiceKeys();
                    keys.invId = invId;
                    keys.patId = patId;
                    keys.inv_type = inv_type;
                    keys.ins_dept = ins_dept;
                    keys.appId = 0;
                    keys.appId = 0;

                    return PartialView("EditCashInvoice", keys);
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
        public ActionResult DeleteInvoice(int invId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int val = BusinessLogicLayer.Invoice.Invoice.DeleteInvoice(invId, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Invoice with invId = {invId}"
                        });

                        return Json(new { isAuthorized = true, isSuccess = true, invId = val }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, invId = 0 }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isAuthorized = true, isSuccess = false, invId = -1 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, isSuccess = false, invId = -1 }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult InvoiceLogs(int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Invoice.InvoiceLog> log = BusinessLogicLayer.Invoice.Invoice.GetInvoiceLog(invId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Invoice Logs for invId = {invId}"
                    });

                    return PartialView("InvoiceLogs", log);
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
        public ActionResult UpdateBulkInvoiceStatus(InvoiceBulkStatus data)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Invoice.Invoice.UpdateBulkInvoiceStatus(data.invIds, "Verified", PageControl.getLoggedinId());

                if (val > 0)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Updated Invoice(s) Status to Verified for invIds = {data.invIds}"
                    });

                    return Json(new { isSuccess = true, message = "Invoice(s) Status Updated to Verified" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isSuccess = false, message = "Error in updating the Invoice status " }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult PostToAccountInvoice(InvoiceBulkStatus data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Invoice.Invoice.PostToAccountInvoice(data.invIds, PageControl.getLoggedinId());

                if (val > 0)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Posted to Chart of Account for invIds = {data.invIds}"
                    });

                    return Json(new { isSuccess = true, message = "Selected Invoice(s) Posted to Chart of Account" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isSuccess = false, message = "Error in updating the Invoice to Chart of Account " }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetPackages(int tgId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.Packages> package = BusinessLogicLayer.Masters.TreatmentGroups.GetPackages(tgId);

                return Json(package, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GenerateQCInvoiceWithPackage(QC_Invoice data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string inv_no = string.Empty;

                    int val = BusinessLogicLayer.Invoice.QuickCash.Generate_QCInvoiceWithPackage(data, PageControl.getLoggedinId(), out inv_no);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Generated Quick Cash Invoice With Package for inv_no = {inv_no}"
                        });

                        return Json(new { isSuccess = true, invId = val, message = "Invoice No. " + inv_no + " is generated successfully and Package also Created!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error while creating the treatments!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetPatientInvoiceList(int patId, int? empId = 0)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Invoice.Invoice> list = new List<BusinessEntities.Invoice.Invoice>();

                try
                {
                    list = BusinessLogicLayer.Invoice.Invoice.GetInvoiceByPatId(patId, empId);

                    if (list.Count > 0)
                    {
                        return Json(new { isSuccess = true, data = list }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, data = list }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, data = list }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        [HttpPost]
        public async Task<ActionResult> SendInvoiceInWhatsapp(SendAttachment data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId_Whatsapp, Action))
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                string filePath = Server.MapPath("~/Documents/" + fileName);

                string htmlContent = BusinessLogicLayer.Invoice.PDFExport.HtmlInvoice(data.id);
                var pdfGenerator = new Rocket.PdfGenerator.HtmlToPdfConverter();
                var pdfBytes = pdfGenerator.GeneratePdf(htmlContent);
                //System.IO.File.WriteAllBytes(filePath, pdfBytes);

                string base64String = Convert.ToBase64String(pdfBytes, 0, pdfBytes.Length);

                MediaPost media = new MediaPost();
                media.Data = base64String;

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                var options_Media = new RestClientOptions("http://visionsoftwares.dyndns.org:1000")
                {
                    MaxTimeout = -1,
                };
                var client_Media = new RestClient(options_Media);
                var request_Media = new RestRequest("/api/InsertMedia/SavePDFinPath", Method.Post);
                request_Media.AddHeader("Content-Type", "application/json");

                string body_Media = JsonConvert.SerializeObject(media);

                request_Media.AddStringBody(body_Media, DataFormat.Json);
                RestResponse response_Media = await client_Media.ExecuteAsync(request_Media);

                if (response_Media.IsSuccessful)
                {
                    MediaResponse _responseMedia = new MediaResponse();
                    _responseMedia = JsonConvert.DeserializeObject<MediaResponse>(response_Media.Content);

                    //Sending Whatsapp
                    WhatsappConfig config = new WhatsappConfig();
                    try
                    {
                        if (BusinessLogicLayer.CommunicationMedia.isMediaEnabled("Whatsapp", "Patient", data.user))
                        {
                            int branchId = 0;
                            var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                            var bid = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
                            int.TryParse(bid, out branchId);

                            int empId = PageControl.getLoggedinId();

                            config = BusinessLogicLayer.CommunicationMedia.WhatsappConfig(empId, branchId);
                            WhatsappResponse _response = new WhatsappResponse();

                            if (!string.IsNullOrEmpty(config.InstanceId) && !string.IsNullOrEmpty(config.AccessToken))
                            {
                                string msg = "Dear " + data.user_name + ",\r\n\r\nI hope this message finds you well. Please find attached the invoice for " + data.ref_no + " that was recently provided to you. Kindly review the details and let me know if you have any questions or require further clarification.\r\n\r\nThank you for your prompt attention to this matter.\r\n\r\nThanking You.";

                                string format_message = BusinessLogicLayer.CommunicationMedia.FormatTemplateContent(msg, 0, data.user);
                                string end_point = "/api/send.php?number=" + data.mobile + "&type=media&media_url=" + _responseMedia.PublicPath +
                                    "&message=" + HttpUtility.UrlEncode(format_message) + "&instance_id=" + config.InstanceId + "&access_token=" + config.AccessToken;

                                var options = new RestClientOptions(ConfigurationManager.AppSettings["WhatsappEndPoint"].ToString())
                                {
                                    MaxTimeout = -1,
                                };
                                var client = new RestClient(options);
                                var request = new RestRequest(end_point, Method.Get);
                                RestResponse response = await client.ExecuteAsync(request);


                                if (response.IsSuccessful)
                                {
                                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                    {
                                        log_by = empId,
                                        log_desc = $"Employee Sent WhatsApp Message to : {data.mobile}"
                                    });


                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("WhatsApp", data.user, "Patient", data.mobile, empId, true, response.Content.ToString(), data.id, "Invoice");
                                    _response = JsonConvert.DeserializeObject<WhatsappResponse>(response.Content);
                                    return Json(new { isSuccess = true, message = "WhatsApp Sent Successfully to " + data.mobile, data = _response }, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("WhatsApp", data.user, "Patient", data.mobile, empId, false, response.Content.ToString(), data.id, "Invoice");
                                    return Json(new { isSuccess = false, message = "Error to Sent WhatsApp to " + data.mobile, data = new { } }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                return Json(new { isSuccess = false, message = "Instance ID/Access Token is Invalid", data = new { } }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Patient not enabled the WhatsApp", data = new { } }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    catch (Exception ex)
                    {
                        return Json(new { isSuccess = false, message = ex.Message, data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isSuccess = false, message = "Invoice PDF is not generated in Public Area", data = new { } }, JsonRequestBehavior.AllowGet);
                }


            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SendInvoiceInEmail(SendAttachment data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId_Whatsapp, Action))
            {
                string htmlContent = BusinessLogicLayer.Invoice.PDFExport.HtmlInvoice(data.id);

                try
                {
                    DataTable dt = new DataTable();

                    if (BusinessLogicLayer.CommunicationMedia.isMediaEnabled("Email", "Patient", data.user))
                    {
                        dt = BusinessLogicLayer.CommunicationMedia.EmailConfig(5);

                        if (dt.Rows.Count > 0)
                        {
                            int empId = PageControl.getLoggedinId();
                            string val = await BusinessLogicLayer.CommunicationMedia.SentEmail(htmlContent, dt, data.email);

                            if (!string.IsNullOrEmpty(val))
                            {
                                if (val.ToLower().Trim().Equals("success"))
                                {
                                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                    {
                                        log_by = empId,
                                        log_desc = $"Employee Sent Email to : {data.email}"
                                    });

                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("Email", data.user, "Patient", data.email, empId, true, "Email Sent Successfully", data.id, "Invoice");
                                    return Json(new { isSuccess = true, message = "Email Sent Successfully to " + data.email }, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("Email", data.user, "Patient", data.email, empId, false, "Email Not Sent", data.id, "Invoice");
                                    return Json(new { isSuccess = false, message = "Pending send Email to " + data.email }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("Email", data.user, "Patient", data.email, empId, false, val, data.id, "Invoice");
                                return Json(new { isSuccess = false, message = "Error to Sent Email to " + data.email }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Email is not setuped for this Template" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Patient not enabled the Email" }, JsonRequestBehavior.AllowGet);
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

        public JsonResult GetAppointmentPackages(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {

                List<QC_InvoiceItems> session = BusinessLogicLayer.Invoice.Invoice.GetAppointmentPackages(appId);

                return Json(session, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetInvoicesTreatments(int ptId, int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_PatientTreatments, Action))
            {
                try
                {

                    List<InvoiceServices> Services = BusinessLogicLayer.Invoice.QuickCash.GetInvoicesTreatments(ptId, appId);

                    return Json(Services, JsonRequestBehavior.AllowGet);

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
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult InvoicePatientDiagnosis()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;


                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Patient Diagnosis Page from Invoice edit!"
                    });
                    return PartialView("InvoicePatientDiagnosis");
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
        public ActionResult InvoiceNarrativeDiagnosis()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Narrative Diagnosis Page from Invoice edit!"
                    });
                    return PartialView("InvoiceNarrativeDiagnosis");
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
        public ActionResult InvoiceCoderDiagnosis()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Coder Diagnosis Page from Invoice edit!"
                    });
                    return PartialView("InvoiceCoderDiagnosis");
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
        public ActionResult InvoicePrintMedical()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Print Medical Page from Invoice edit!"
                    });
                    return PartialView("InvoicePrintMedical");
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
        public ActionResult InvoiceAudit()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Audit Sheet Page from Invoice edit!"
                    });
                    return PartialView("InvoiceAudit");
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
        public ActionResult InvoiceMsg2Doct()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Msg to Doctor Page from Invoice edit!"
                    });
                    return PartialView("InvoiceMsg2Doct");
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
        public ActionResult EditDentalInsuranceBilling(int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                int appId = int.Parse(emr.appId);

                BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);


                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Dental Insurance Treatments Edit Page from Invoice Edit!"
                    });

                    TempData["Layout"] = "True";

                    return PartialView("EditDentalInsuranceBilling", invoice_info);
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
        public ActionResult PostSalesInvoiceToAccount(string data)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.Invoice.Invoice.PostSalesInvoiceToAccount(data, empId);
                    if (isUpdated1 > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Posted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isUpdated1 == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Invoice Posting Error to Accounts" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = isUpdated1, message = "Error While Posting Invoice to Accounts!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = -3, message = "You are not authorized to perform this action!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isUpdated = -4, message = ex.Message }, JsonRequestBehavior.AllowGet);
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