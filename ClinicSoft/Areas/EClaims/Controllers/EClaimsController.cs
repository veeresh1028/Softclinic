using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using Google.Protobuf.WellKnownTypes;
using BusinessEntities.EMR;
using Microsoft.Ajax.Utilities;
using System.Security.Claims;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using WebGrease.Activities;
using System.Configuration;
using BusinessEntities.EClaims;
using System.Drawing;
using System.Web.Http.Results;
using static BusinessEntities.PriorRequests.PriorRequestsMOH;
using RestSharp;
using BusinessEntities.PriorRequests;
using Method = RestSharp.Method;
using System.Threading.Tasks;

namespace ClinicSoft.Areas.EClaims.Controllers
{
    public class EClaimsController : Controller
    {
        int PageId = (int)Pages.eClaims;
        DataTable dt_Inv = new DataTable();
        // GET: EClaims/EClaims
        [HttpGet]
        public ActionResult Submissions()
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
        public ActionResult SubmissionsHAAD()
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
        public ActionResult SubmissionsRiyati()
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
        public ActionResult GetInvoicesSubmissions(BusinessEntities.EClaims.SubmissionsSearch data)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.EClaims.Submissions> invoiceList = new List<BusinessEntities.EClaims.Submissions>();
                try
                {
                    invoiceList = BusinessLogicLayer.EClaims.EClaims.GetInvoicesSubmissions(data);
                    dt_Inv = BusinessLogicLayer.EClaims.EClaims.GetInvoicesSubmissionsFullXML(data);
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

        [HttpGet]
        public ActionResult GetInsuranceTPAeClaim(int? icId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt_TPAs = BusinessLogicLayer.EClaims.EClaims.GetPatient_InsuranceTPAeClaim(icId);
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
        public ActionResult GenerateSelectedXmlManual(string inv_ids, string s_flag, int no_of_claims)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    DateTime TransactionDate = DateTime.Now;
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    int val = 0;
                    DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                    dt = ds.Tables[0];
                    DataTable dt_signs = ds.Tables[0];
                    string ins_clinic_code = "";
                    string ic_name = "";
                    string filename = Server.MapPath("~/submissions/GeneratedXmls/DHA/Manual/Sub_" + dt.Rows[0]["set_permit_no"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + ".xml").Replace(" ", "");  // Specify the output filename


                    XmlTextWriter writer = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                    writer.Formatting = System.Xml.Formatting.Indented;
                    writer.WriteStartDocument();

                    if (dt_signs.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        writer.WriteStartElement("Claim.Submission");
                        writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                        writer.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
                        writer.WriteStartElement("Header");
                        // Write Header elements
                        writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                        writer.WriteElementString("ReceiverID", dr["ic_code"].ToString());
                        writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        writer.WriteElementString("RecordCount", no_of_claims.ToString());
                        writer.WriteElementString("DispositionFlag", s_flag);
                        // End Header element
                        writer.WriteEndElement();
                        int x = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            x = x + 1;
                            float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            float inv_net_cash = float.Parse(row["inv_net"].ToString());
                            float inv_vat = float.Parse(row["inv_vat"].ToString());
                            //float inv_net = float.Parse(row["inv_net"].ToString());
                            float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                            float inv_copay = float.Parse(row["inv_copay"].ToString());
                            float inv_share = float.Parse(row["inv_share"].ToString());
                            float pat_share = 0;
                            if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                            {
                                pat_share = inv_tded + inv_copay + inv_share;
                            }
                            else
                            {
                                pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            }
                            float inv_total = inv_net + pat_share;
                            string ins_no = row["inv_pi_insno"].ToString();
                            string claim_no = row["inv_claimno"].ToString();
                            string policy_no = row["inv_pi_polocyno"].ToString();
                            string inv_no = row["inv_no"].ToString();
                            string pat_emirateid = row["pat_emirateid"].ToString();
                            ins_clinic_code = row["inv_ic_payercode"].ToString();

                            ic_name = row["inv_insurance_name"].ToString();
                            DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                            DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                            int d_ay = app__fdate.Day;
                            string d__ay = "";
                            if (d_ay < 10)
                            {
                                d__ay = "0" + d_ay.ToString();
                            }
                            else
                            {
                                d__ay = d_ay.ToString();
                            }

                            int m_onth = app__fdate.Month;
                            string m__onth = "";
                            if (m_onth < 10)
                            {
                                m__onth = "0" + m_onth.ToString();
                            }
                            else
                            {
                                m__onth = m_onth.ToString();
                            }
                            writer.WriteStartElement("Claim");
                            writer.WriteElementString("ID", inv_no);
                            string MemberID_ = "";
                            if (ic_name == "'Cash'")
                            {
                                MemberID_ = dr["set_permit_no"].ToString() + "#" + row["pat_code"].ToString();
                                writer.WriteElementString("MemberID", MemberID_);

                                // MEDICAL TOURISAM START HERE

                                if (row["pat_city"].ToString() == "Abu Dhabi")
                                {
                                    writer.WriteElementString("PayerID", "SelfPay");
                                }
                                else
                                {
                                    if (row["app_emergency"].ToString() == "YES")
                                    {
                                        writer.WriteElementString("PayerID", "SelfPay");
                                    }
                                    else
                                    {
                                        writer.WriteElementString("PayerID", "MedicalTourismSelfPay");
                                    }
                                }
                                // MEDICAL TOURISAM END HERE
                            }
                            else
                            {
                                writer.WriteElementString("MemberID", ins_no);
                                writer.WriteElementString("PayerID", ins_clinic_code);
                            }
                            writer.WriteElementString("ProviderID", dr["set_permit_no"].ToString());
                            if (claim_no != "")
                            {
                                writer.WriteElementString("ClaimNo", claim_no);
                                if (policy_no != "")
                                {
                                    writer.WriteElementString("InsurancePolicyNo", policy_no);
                                }
                            }
                            if (row["pat_emirateid"].ToString() == "")
                            {
                                writer.WriteElementString("EmiratesIDNumber", "999-9999-9999999-9");
                            }
                            else
                            {
                                writer.WriteElementString("EmiratesIDNumber", pat_emirateid);
                            }
                            if (ic_name == "'Cash'")
                            {
                                writer.WriteElementString("Gross", inv_net_cash.ToString("0.00"));
                                writer.WriteElementString("PatientShare", inv_net_cash.ToString("0.00"));
                                writer.WriteElementString("Net", "0");
                                writer.WriteElementString("VAT", inv_vat.ToString("0.00"));
                            }
                            else
                            {
                                writer.WriteElementString("Gross", inv_total.ToString("0.00"));
                                writer.WriteElementString("PatientShare", pat_share.ToString("0.00"));
                                writer.WriteElementString("Net", inv_net.ToString("0.00"));
                            }
                            writer.WriteStartElement("Encounter");
                            writer.WriteElementString("FacilityID", dr["set_permit_no"].ToString());
                            writer.WriteElementString("Type", "1");
                            writer.WriteElementString("PatientID", row["pat_code"].ToString());
                            writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                            writer.WriteElementString("End", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ttime"].ToString());
                            writer.WriteElementString("StartType", "1");
                            // End Encounter element
                            writer.WriteEndElement();

                            //Diagnosis Generation Starts Here.....
                            DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(dr["appId"].ToString()), 0);
                            int diag_count = 0;
                            string diag__codes = "";
                            foreach (DataRow drDiag in dtDiag.Rows)
                            {
                                diag_count = diag_count + 1;
                                writer.WriteStartElement("Diagnosis");
                                if (drDiag["pad_type"].ToString() == "Primary")
                                {
                                    writer.WriteElementString("Type", "Principal");
                                }
                                else if (drDiag["pad_type"].ToString() == "Secondary")
                                {
                                    writer.WriteElementString("Type", "Secondary");
                                }
                                else
                                {
                                    writer.WriteElementString("Type", "ReasonForVisit");
                                }
                                diag__codes = diag__codes + "," + drDiag["diag_code"].ToString();
                                writer.WriteElementString("Code", drDiag["Diag_Code"].ToString());
                                if (drDiag["pad_year"].ToString() != "0")
                                {
                                    writer.WriteStartElement("DxInfo");
                                    writer.WriteElementString("Type", "Year of Onset");
                                    writer.WriteElementString("Code", drDiag["pad_year"].ToString());
                                    writer.WriteEndElement();
                                }
                                writer.WriteEndElement();
                            }
                            //Diagnosis Generation Ends Here.....                           


                            DataTable dtTreat = new DataTable();
                            dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            int y = 0;
                            // int z = 0;
                            foreach (DataRow drTreat in dtTreat.Rows)
                            {


                                float pt_net = float.Parse(drTreat["pt_net"].ToString());
                                float pt_vat = float.Parse(drTreat["pt_vat"].ToString());
                                DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString());
                                y = y + 1;
                                string act_no = drTreat["ptId"].ToString();
                                int ActDetails = BusinessLogicLayer.EMR.PatientTreatments.InsertActivityDetails(int.Parse(drTreat["ptId"].ToString()), int.Parse(dr["appId"].ToString()), "Claims", act_no, PageControl.getLoggedinId(), pt_net, "Claims");

                                writer.WriteStartElement("Activity");
                                writer.WriteElementString("ID", act_no);
                                writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                                writer.WriteElementString("Type", drTreat["tr_itype"].ToString());
                                writer.WriteElementString("Code", drTreat["tr_code"].ToString());
                                writer.WriteElementString("Quantity", drTreat["pt_qty"].ToString());
                                if (ic_name == "'Cash'")
                                {
                                    writer.WriteElementString("Net", "0");
                                }
                                else
                                {
                                    writer.WriteElementString("Net", float.Parse(pt_net.ToString("0.00")).ToString());
                                }
                                if (dr["set_city"].ToString() == "HAAD")
                                {
                                    writer.WriteElementString("OrderingClinician", drTreat["emp_license"].ToString());
                                }
                                writer.WriteElementString("Clinician", drTreat["emp_license"].ToString());
                                if (drTreat["pt_auth_code"].ToString() != "")
                                {
                                    if (drTreat["pt_auth_code"].ToString() != "Not Required")
                                    {
                                        writer.WriteElementString("PriorAuthorizationID", drTreat["pt_auth_code"].ToString());
                                    }
                                }
                                if (ic_name == "'Cash'")
                                {
                                    writer.WriteElementString("VAT", pt_vat.ToString("0.00"));
                                    if (pt_vat > 0)
                                    {
                                        writer.WriteElementString("VATPercent", "5");
                                    }
                                    else
                                    {
                                        writer.WriteElementString("VATPercent", "0");
                                    }
                                }

                                DataTable dtTreat2 = new DataTable();
                                dtTreat2 = BusinessLogicLayer.EClaims.EClaims.GetPrescriptions(int.Parse(dr["appId"].ToString()));
                                foreach (DataRow dtpresc in dtTreat2.Rows)
                                {
                                    if (dtpresc["pre_eRxRefNo"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "ERX");
                                        writer.WriteElementString("Code", dtpresc["pre_eRxRefNo"].ToString());
                                        writer.WriteElementString("Value", dtpresc["preId"].ToString());
                                        writer.WriteElementString("ValueType", "Reference");
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "InvoiceNumber");
                                writer.WriteElementString("Value", row["inv_no"].ToString());
                                writer.WriteElementString("ValueType", "Text");
                                // End Observation element
                                writer.WriteEndElement();

                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "InvoiceDate");
                                writer.WriteElementString("Value", DateTime.Parse(row["inv_date"].ToString()).ToString("dd-MM-yyyy"));
                                writer.WriteElementString("ValueType", "Text");
                                // End Observation element
                                writer.WriteEndElement();

                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Financial");
                                writer.WriteElementString("Code", "ActivityGross");
                                writer.WriteElementString("Value", (float.Parse(drTreat["pt_total"].ToString()) - float.Parse(drTreat["pt_disc"].ToString())).ToString("0.00"));
                                writer.WriteElementString("ValueType", "Float");
                                // End Observation element
                                writer.WriteEndElement();

                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Financial");
                                writer.WriteElementString("Code", "PSDeductible");
                                writer.WriteElementString("Value", (float.Parse(drTreat["pt_ded"].ToString()) + float.Parse(drTreat["pt_dded"].ToString()) + float.Parse(drTreat["pt_rded"].ToString()) + float.Parse(drTreat["pt_mded"].ToString()) + float.Parse(drTreat["pt_lded"].ToString())).ToString("0.00"));
                                writer.WriteElementString("ValueType", "Float");
                                // End Observation element
                                writer.WriteEndElement();


                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Financial");
                                writer.WriteElementString("Code", "PSCoPayment");
                                writer.WriteElementString("Value", (float.Parse(drTreat["pt_copay"].ToString()) + float.Parse(drTreat["pt_dcopay"].ToString())).ToString("0.00"));
                                writer.WriteElementString("ValueType", "Float");
                                // End Observation element
                                writer.WriteEndElement();

                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Financial");
                                writer.WriteElementString("Code", "PSOutOfPocket");
                                writer.WriteElementString("Value", "0.00");
                                writer.WriteElementString("ValueType", "Float");
                                // End Observation element
                                writer.WriteEndElement();
                                // LOINC CODES STARTS
                                if (drTreat["ti_loinc_1"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_1"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_2"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_3"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_4"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_4"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_5"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_6"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_7"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_7"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_8"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_9"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_10"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_10"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_11"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_12"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_13"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_13"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_14"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_15"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                // LOINC CODES ENDS
                                if ((drTreat["tr_code"].ToString() == "9") || (drTreat["tr_code"].ToString() == "10") || (drTreat["tr_code"].ToString() == "11") || (drTreat["tr_code"].ToString() == "9.1") || (drTreat["tr_code"].ToString() == "10.1") || (drTreat["tr_code"].ToString() == "11.1"))
                                {
                                    if (drTreat["ti_lab_8"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BPS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_8"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_9"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BPD");
                                        writer.WriteElementString("Value", drTreat["ti_lab_9"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "82565")
                                {
                                    if (drTreat["ti_lab_7"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CR");
                                        writer.WriteElementString("Value", drTreat["ti_lab_7"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "82043")
                                {
                                    if (drTreat["ti_lab_6"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "UA");
                                        writer.WriteElementString("Value", drTreat["ti_lab_6"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "84478")
                                {
                                    if (drTreat["ti_lab_5"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TRIG");
                                        writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "83721")
                                {
                                    if (drTreat["ti_lab_4"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "LDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "83718")
                                {
                                    if (drTreat["ti_lab_3"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "HDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "82465")
                                {
                                    if (drTreat["ti_lab_2"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CHOL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "80061")
                                {
                                    if (drTreat["ti_image_7"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "NONHDL");
                                        writer.WriteElementString("Value", drTreat["ti_image_7"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "80061")
                                {
                                    if (drTreat["ti_lab_2"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CHOL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_3"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "HDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_4"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "LDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }

                                    if (drTreat["ti_lab_5"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TRIG");
                                        writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }

                                }
                                if (drTreat["tr_code"].ToString() == "83036")
                                {
                                    if (drTreat["ti_lab_1"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "A1c");
                                        writer.WriteElementString("Value", drTreat["ti_lab_1"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (diag__codes.Contains("E66.9") == true)
                                {
                                    if (drTreat["ti_lab_10"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BMI");
                                        writer.WriteElementString("Value", drTreat["ti_lab_10"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                                {
                                    if (drTreat["ti_lab_11"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "Albumin");
                                        writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                                {
                                    if (drTreat["ti_lab_11"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "Albumin");
                                        writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_12"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALP");
                                        writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_13"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALT");
                                        writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_14"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "AST");
                                        writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_8"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TotalBilirubin");
                                        writer.WriteElementString("Value", drTreat["ti_image_8"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_9"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "DirectBilirubin");
                                        writer.WriteElementString("Value", drTreat["ti_image_9"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_10"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TotalProtein");
                                        writer.WriteElementString("Value", drTreat["ti_image_10"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                                {
                                    if (drTreat["ti_lab_12"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALP");
                                        writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84460"))
                                {
                                    if (drTreat["ti_lab_13"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALT");
                                        writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84450"))
                                {
                                    if (drTreat["ti_lab_14"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "AST");
                                        writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                {
                                    if (drTreat["ti_lab_15"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "FBS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_15"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                {
                                    if (drTreat["ti_lab_16"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "RBS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_16"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["ti_lab_17"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "FCR");
                                    writer.WriteElementString("Value", drTreat["ti_lab_17"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }

                                // NEW CODES ENDS
                                if (drTreat["pt_notes"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "Description");
                                    writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["pt_teeth"].ToString() != "")
                                {
                                    if (drTreat["pt_teeth"].ToString() != "NA")
                                    {
                                        string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                        for (int j = 0; j < pt__teeth.Length; j++)
                                        {
                                            //MessageBox.Show(words[j]);
                                            if (pt__teeth[j].Trim() != "")
                                            {
                                                writer.WriteStartElement("Observation");
                                                writer.WriteElementString("Type", "Universal Dental");
                                                writer.WriteElementString("Code", pt__teeth[j].Trim());
                                                // End Observation element
                                                writer.WriteEndElement();
                                            }
                                        }
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "17999")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "Activity Description");
                                    writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["tr_code"].ToString() == "0232T")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "Activity Description");
                                    writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if ((drTreat["pt_notes"].ToString() != "") && (ic_name.Contains("MADALLAH") == true))
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "CLAIM-FORM-NUMBER");
                                    writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                    writer.WriteElementString("ValueType", "CLAIM-FORM-NUMBER");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_1"].ToString() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");
                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_1"].ToString());

                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_2"].ToString() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");
                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_2"].ToString());

                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();

                                }
                                if (drTreat["ti_image_3"].ToString() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");
                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_3"].ToString());

                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_4"].ToString() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");

                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_4"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);

                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_5"].ToString() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");

                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_5"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                DataTable dt_lab = new DataTable();
                                dt_lab = BusinessLogicLayer.EClaims.EClaims.GetLabResultsAppointmentID(int.Parse(drTreat["ptId"].ToString()));
                                foreach (DataRow dr_lab in dt_lab.Rows)
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", dr_lab["cll_code"].ToString());
                                    writer.WriteElementString("Value", drTreat["cll_result"].ToString());
                                    writer.WriteElementString("ValueType", dr_lab["cll_units"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                // End Activity element
                                writer.WriteEndElement();
                            }
                            // End Claim element
                            writer.WriteEndElement();
                        }
                        // End Claim Submission element
                        writer.WriteEndElement();
                        // End Document
                        writer.WriteEndDocument();
                        // string val= stringWriter.ToString();
                        writer.Flush();
                        writer.Close();
                        byte[] fileContent = null;
                        string fileName = Path.Combine(filename);
                        System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(fileName).Length;
                        fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();
                        return new FileContentResult(fileContent, "application/xml");

                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Please select Treatments" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult GenerateSelectedXmlDirect(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    DateTime TransactionDate = DateTime.Now;
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    int val = 0;
                    DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                    dt = ds.Tables[0];
                    DataTable dt_signs = ds.Tables[0];
                    string ins_clinic_code = "";
                    string ic_name = "";
                    string filename = Server.MapPath("~/submissions/GeneratedXmls/DHA/Direct/Sub_" + dt.Rows[0]["set_permit_no"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".xml").Replace(" ", ""); // Specify the output filename

                    StringWriter stringWriter = new StringWriter();
                    XmlTextWriter writer = new XmlTextWriter(stringWriter);
                    writer.Formatting = System.Xml.Formatting.Indented;
                    writer.WriteStartDocument();

                    if (dt_signs.Rows.Count > 0)
                    {
                        //string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                        DataRow dr = dt.Rows[0];
                        writer.WriteStartElement("Claim.Submission");
                        writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                        writer.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");

                        writer.WriteStartElement("Header");
                        // Write Header elements
                        writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                        if (ic_names == "'Cash (HAAD)'")
                        {
                            writer.WriteElementString("ReceiverID", "HAAD");
                        }
                        else
                        {
                            writer.WriteElementString("ReceiverID", dr["ic_code"].ToString());
                        }
                        writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        writer.WriteElementString("RecordCount", no_of_claims.ToString());
                        writer.WriteElementString("DispositionFlag", s_flag);
                        // End Header element
                        writer.WriteEndElement();
                        int x = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            x = x + 1;
                            float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            float inv_net_cash = float.Parse(row["inv_net"].ToString());
                            float inv_vat = float.Parse(row["inv_vat"].ToString());
                            //float inv_net = float.Parse(row["inv_net"].ToString());
                            float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                            float inv_copay = float.Parse(row["inv_copay"].ToString());
                            float inv_share = float.Parse(row["inv_share"].ToString());
                            float pat_share = 0;
                            if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                            {
                                pat_share = inv_tded + inv_copay + inv_share;
                            }
                            else
                            {
                                pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            }
                            float inv_total = inv_net + pat_share;
                            string ins_no = row["inv_pi_insno"].ToString();
                            string claim_no = row["inv_claimno"].ToString();
                            string policy_no = row["inv_pi_polocyno"].ToString();
                            string inv_no = row["inv_no"].ToString();
                            string pat_emirateid = row["pat_emirateid"].ToString();
                            ins_clinic_code = row["inv_ic_payercode"].ToString();

                            ic_name = row["inv_insurance_name"].ToString();
                            DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                            DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                            int d_ay = app__fdate.Day;
                            string d__ay = "";
                            if (d_ay < 10)
                            {
                                d__ay = "0" + d_ay.ToString();
                            }
                            else
                            {
                                d__ay = d_ay.ToString();
                            }

                            int m_onth = app__fdate.Month;
                            string m__onth = "";
                            if (m_onth < 10)
                            {
                                m__onth = "0" + m_onth.ToString();
                            }
                            else
                            {
                                m__onth = m_onth.ToString();
                            }
                            writer.WriteStartElement("Claim");
                            writer.WriteElementString("ID", inv_no);
                            string MemberID_ = "";
                            if (row["inv_insurance_name"].ToString() == "'Cash'")
                            {
                                MemberID_ = dr["set_permit_no"].ToString() + "#" + row["pat_code"].ToString();
                                writer.WriteElementString("MemberID", MemberID_);

                                // MEDICAL TOURISAM START HERE

                                if (row["pat_city"].ToString() == "Abu Dhabi")
                                {
                                    writer.WriteElementString("PayerID", "SelfPay");
                                }
                                else
                                {
                                    if (row["app_emergency"].ToString() == "YES")
                                    {
                                        writer.WriteElementString("PayerID", "SelfPay");
                                    }
                                    else
                                    {
                                        writer.WriteElementString("PayerID", "MedicalTourismSelfPay");
                                    }
                                }

                                // MEDICAL TOURISAM END HERE
                            }
                            else
                            {
                                writer.WriteElementString("MemberID", ins_no);
                                writer.WriteElementString("PayerID", ins_clinic_code);
                            }
                            writer.WriteElementString("ProviderID", dr["set_permit_no"].ToString());
                            if (claim_no != "")
                            {
                                writer.WriteElementString("ClaimNo", claim_no);
                                if (policy_no != "")
                                {
                                    writer.WriteElementString("InsurancePolicyNo", policy_no);
                                }
                            }
                            if (row["pat_emirateid"].ToString() == " ")
                            {
                                writer.WriteElementString("EmiratesIDNumber", "999-9999-9999999-9");
                            }
                            else
                            {
                                writer.WriteElementString("EmiratesIDNumber", pat_emirateid);
                            }
                            if (row["inv_insurance_name"].ToString() == "'Cash'")
                            {
                                writer.WriteElementString("Gross", inv_net_cash.ToString("0.00"));
                                writer.WriteElementString("PatientShare", inv_net_cash.ToString("0.00"));
                                writer.WriteElementString("Net", "0");
                                writer.WriteElementString("VAT", inv_vat.ToString("0.00"));
                            }
                            else
                            {
                                writer.WriteElementString("Gross", inv_total.ToString("0.00"));
                                writer.WriteElementString("PatientShare", pat_share.ToString("0.00"));
                                writer.WriteElementString("Net", inv_net.ToString("0.00"));
                            }
                            writer.WriteStartElement("Encounter");
                            writer.WriteElementString("FacilityID", dr["set_permit_no"].ToString());
                            writer.WriteElementString("Type", "1");
                            writer.WriteElementString("PatientID", row["pat_code"].ToString());
                            //if (row["app_eligibility"].ToString() != "0")
                            //{
                            //    writer.WriteElementString("EligibilityIDPayer", row["app_eligibility"].ToString());
                            //}
                            writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                            writer.WriteElementString("End", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ttime"].ToString());
                            writer.WriteElementString("StartType", "1");
                            // End Encounter element
                            writer.WriteEndElement();

                            //Diagnosis Generation Starts Here.....
                            DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(dr["appId"].ToString()), 0);
                            int diag_count = 0;
                            string diag__codes = "";
                            foreach (DataRow drDiag in dtDiag.Rows)
                            {
                                diag_count = diag_count + 1;
                                writer.WriteStartElement("Diagnosis");
                                if (drDiag["pad_type"].ToString() == "Primary")
                                {
                                    writer.WriteElementString("Type", "Principal");
                                }
                                else if (drDiag["pad_type"].ToString() == "Secondary")
                                {
                                    writer.WriteElementString("Type", "Secondary");
                                }
                                else
                                {
                                    writer.WriteElementString("Type", "ReasonForVisit");
                                }
                                diag__codes = diag__codes + "," + drDiag["diag_code"].ToString();
                                writer.WriteElementString("Code", drDiag["Diag_Code"].ToString());
                                if (drDiag["pad_year"].ToString() != "0")
                                {
                                    writer.WriteStartElement("DxInfo");
                                    writer.WriteElementString("Type", "Year of Onset");
                                    writer.WriteElementString("Code", drDiag["pad_year"].ToString());
                                    writer.WriteEndElement();
                                }
                                writer.WriteEndElement();
                            }
                            //Diagnosis Generation Ends Here.....                           


                            DataTable dtTreat = new DataTable();
                            dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            int y = 0;
                            // int z = 0;
                            foreach (DataRow drTreat in dtTreat.Rows)
                            {


                                float pt_net = float.Parse(drTreat["pt_net"].ToString());
                                float pt_vat = float.Parse(drTreat["pt_vat"].ToString());
                                DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString());
                                y = y + 1;
                                string act_no = drTreat["ptId"].ToString();
                                int ActDetails = BusinessLogicLayer.EMR.PatientTreatments.InsertActivityDetails(int.Parse(drTreat["ptId"].ToString()), int.Parse(dr["appId"].ToString()), "Claims", act_no, PageControl.getLoggedinId(), pt_net, "Claims");

                                writer.WriteStartElement("Activity");
                                writer.WriteElementString("ID", act_no);
                                writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                                writer.WriteElementString("Type", drTreat["tr_itype"].ToString());
                                writer.WriteElementString("Code", drTreat["tr_code"].ToString());
                                writer.WriteElementString("Quantity", drTreat["pt_qty"].ToString());
                                if (drTreat["ic_name"].ToString() == "'Cash'")
                                {
                                    writer.WriteElementString("Net", "0");
                                }
                                else
                                {
                                    writer.WriteElementString("Net", float.Parse(pt_net.ToString("0.00")).ToString());
                                }
                                if (dr["set_city"].ToString() == "HAAD")
                                {
                                    writer.WriteElementString("OrderingClinician", drTreat["emp_license"].ToString());
                                }
                                writer.WriteElementString("Clinician", drTreat["emp_license"].ToString());
                                if (drTreat["pt_auth_code"].ToString() != "")
                                {
                                    if (drTreat["pt_auth_code"].ToString() != "Not Required")
                                    {
                                        writer.WriteElementString("PriorAuthorizationID", drTreat["pt_auth_code"].ToString());
                                    }
                                }
                                if (drTreat["ic_name"].ToString() == "'Cash'")
                                {
                                    writer.WriteElementString("VAT", pt_vat.ToString("0.00"));
                                    if (pt_vat > 0)
                                    {
                                        writer.WriteElementString("VATPercent", "5");
                                    }
                                    else
                                    {
                                        writer.WriteElementString("VATPercent", "0");
                                    }
                                }

                                DataTable dtTreat2 = new DataTable();
                                dtTreat2 = BusinessLogicLayer.EClaims.EClaims.GetPrescriptions(int.Parse(dr["appId"].ToString()));
                                foreach (DataRow dtpresc in dtTreat2.Rows)
                                {
                                    if (dtpresc["pre_eRxRefNo"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "ERX");
                                        writer.WriteElementString("Code", dtpresc["pre_eRxRefNo"].ToString());
                                        writer.WriteElementString("Value", dtpresc["preId"].ToString());
                                        writer.WriteElementString("ValueType", "Reference");
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "InvoiceNumber");
                                writer.WriteElementString("Value", row["inv_no"].ToString());
                                writer.WriteElementString("ValueType", "Text");
                                // End Observation element
                                writer.WriteEndElement();

                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "InvoiceDate");
                                writer.WriteElementString("Value", DateTime.Parse(row["inv_date"].ToString()).ToString("dd-MM-yyyy"));
                                writer.WriteElementString("ValueType", "Text");
                                // End Observation element
                                writer.WriteEndElement();

                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Financial");
                                writer.WriteElementString("Code", "ActivityGross");
                                writer.WriteElementString("Value", (float.Parse(drTreat["pt_total"].ToString()) - float.Parse(drTreat["pt_disc"].ToString())).ToString("0.00"));
                                writer.WriteElementString("ValueType", "Float");
                                // End Observation element
                                writer.WriteEndElement();

                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Financial");
                                writer.WriteElementString("Code", "PSDeductible");
                                writer.WriteElementString("Value", (float.Parse(drTreat["pt_ded"].ToString()) + float.Parse(drTreat["pt_dded"].ToString()) + float.Parse(drTreat["pt_rded"].ToString()) + float.Parse(drTreat["pt_mded"].ToString()) + float.Parse(drTreat["pt_lded"].ToString())).ToString("0.00"));
                                writer.WriteElementString("ValueType", "Float");
                                // End Observation element
                                writer.WriteEndElement();


                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Financial");
                                writer.WriteElementString("Code", "PSCoPayment");
                                writer.WriteElementString("Value", (float.Parse(drTreat["pt_copay"].ToString()) + float.Parse(drTreat["pt_dcopay"].ToString())).ToString("0.00"));
                                writer.WriteElementString("ValueType", "Float");
                                // End Observation element
                                writer.WriteEndElement();

                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Financial");
                                writer.WriteElementString("Code", "PSOutOfPocket");
                                writer.WriteElementString("Value", "0.00");
                                writer.WriteElementString("ValueType", "Float");
                                // End Observation element
                                writer.WriteEndElement();
                                // LOINC CODES STARTS
                                if (drTreat["ti_loinc_1"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_1"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_2"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_3"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_4"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_4"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_5"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_6"].ToString());
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_7"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_7"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_8"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_9"].ToString());
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_10"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_10"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_11"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_12"].ToString());
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_13"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_13"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_14"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_15"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                // LOINC CODES ENDS
                                if ((drTreat["tr_code"].ToString() == "9") || (drTreat["tr_code"].ToString() == "10") || (drTreat["tr_code"].ToString() == "11") || (drTreat["tr_code"].ToString() == "9.1") || (drTreat["tr_code"].ToString() == "10.1") || (drTreat["tr_code"].ToString() == "11.1"))
                                {
                                    if (drTreat["ti_lab_8"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BPS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_8"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_9"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");

                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BPD");
                                        writer.WriteElementString("Value", drTreat["ti_lab_9"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "82565")
                                {
                                    if (drTreat["ti_lab_7"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CR");
                                        writer.WriteElementString("Value", drTreat["ti_lab_7"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "82043")
                                {
                                    if (drTreat["ti_lab_6"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "UA");
                                        writer.WriteElementString("Value", drTreat["ti_lab_6"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "84478")
                                {
                                    if (drTreat["ti_lab_5"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TRIG");
                                        writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "83721")
                                {
                                    if (drTreat["ti_lab_4"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "LDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "83718")
                                {
                                    if (drTreat["ti_lab_3"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "HDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "82465")
                                {
                                    if (drTreat["ti_lab_2"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CHOL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "80061")
                                {
                                    if (drTreat["ti_image_7"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "NONHDL");
                                        writer.WriteElementString("Value", drTreat["ti_image_7"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "80061")
                                {
                                    if (drTreat["ti_lab_2"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CHOL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_3"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "HDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_4"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "LDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }

                                    if (drTreat["ti_lab_5"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TRIG");
                                        writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }

                                }
                                if (drTreat["tr_code"].ToString() == "83036")
                                {
                                    if (drTreat["ti_lab_1"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "A1c");
                                        writer.WriteElementString("Value", drTreat["ti_lab_1"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (diag__codes.Contains("E66.9") == true)
                                {
                                    if (drTreat["ti_lab_10"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BMI");
                                        writer.WriteElementString("Value", drTreat["ti_lab_10"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                                {
                                    if (drTreat["ti_lab_11"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "Albumin");
                                        writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                                {
                                    if (drTreat["ti_lab_11"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "Albumin");
                                        writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_12"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALP");
                                        writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_13"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALT");
                                        writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_14"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "AST");
                                        writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_8"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TotalBilirubin");
                                        writer.WriteElementString("Value", drTreat["ti_image_8"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_9"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "DirectBilirubin");
                                        writer.WriteElementString("Value", drTreat["ti_image_9"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_10"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TotalProtein");
                                        writer.WriteElementString("Value", drTreat["ti_image_10"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                                {
                                    if (drTreat["ti_lab_12"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALP");
                                        writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84460"))
                                {
                                    if (drTreat["ti_lab_13"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALT");
                                        writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84450"))
                                {
                                    if (drTreat["ti_lab_14"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "AST");
                                        writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                {
                                    if (drTreat["ti_lab_15"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "FBS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_15"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                {
                                    if (drTreat["ti_lab_16"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "RBS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_16"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["ti_lab_17"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "FCR");
                                    writer.WriteElementString("Value", drTreat["ti_lab_17"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }

                                // NEW CODES ENDS
                                if (drTreat["pt_notes"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "Description");
                                    writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["pt_teeth"].ToString() != "")
                                {
                                    if (drTreat["pt_teeth"].ToString() != "NA")
                                    {
                                        string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                        for (int j = 0; j < pt__teeth.Length; j++)
                                        {
                                            //MessageBox.Show(words[j]);
                                            if (pt__teeth[j].Trim() != "")
                                            {
                                                writer.WriteStartElement("Observation");
                                                writer.WriteElementString("Type", "Universal Dental");
                                                writer.WriteElementString("Code", pt__teeth[j].Trim());
                                                // End Observation element
                                                writer.WriteEndElement();
                                            }
                                        }
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "17999")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "Activity Description");
                                    writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["tr_code"].ToString() == "0232T")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "Activity Description");
                                    writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if ((drTreat["pt_notes"].ToString() != "") && (ic_name.Contains("MADALLAH") == true))
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "CLAIM-FORM-NUMBER");
                                    writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                    writer.WriteElementString("ValueType", "CLAIM-FORM-NUMBER");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_1"].ToString() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");

                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_1"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_2"].ToString() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");

                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_2"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();

                                }
                                if (drTreat["ti_image_3"].ToString() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");

                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_3"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_4"].ToString() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");

                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_4"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_5"].ToString() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");

                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_5"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                DataTable dt_lab = new DataTable();
                                dt_lab = BusinessLogicLayer.EClaims.EClaims.GetLabResultsAppointmentID(int.Parse(drTreat["ptId"].ToString()));
                                foreach (DataRow dr_lab in dt_lab.Rows)
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", dr_lab["cll_code"].ToString());
                                    writer.WriteElementString("Value", drTreat["cll_result"].ToString());
                                    writer.WriteElementString("ValueType", dr_lab["cll_units"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                // End Activity element
                                writer.WriteEndElement();
                            }
                            // End Claim element
                            writer.WriteEndElement();
                        }
                        // End Claim Submission element
                        writer.WriteEndElement();
                        // End Document
                        writer.WriteEndDocument();
                        //string writerVal = stringWriter.ToString();
                        writer.Flush();
                        writer.Close();
                        string file_name = dr["set_permit_no"].ToString() + "_" + s_ic_id + "_" + s_date_from.ToString("ddMMyyyy") + "_" + s_date_to.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xml";

                        string eClaim_ErrorMessage = "";
                        byte[] eClaim_ErrorReport = new byte[99];

                        ae.eclaimlink.dhpo1.ValidateTransactions e_Claim = new ae.eclaimlink.dhpo1.ValidateTransactions();
                        e_Claim.UploadTransaction(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), Encoding.UTF8.GetBytes(stringWriter.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"")), file_name, out eClaim_ErrorMessage, out eClaim_ErrorReport);

                        TempData["ErrorMessage"] = eClaim_ErrorMessage;
                        string atr = "";

                        if (eClaim_ErrorMessage.Contains("successful") == false)
                        {
                            if (eClaim_ErrorMessage.Contains("invalid") == false)
                            {
                                if (eClaim_ErrorMessage.Contains("input") == false)
                                {
                                    if (eClaim_ErrorReport != null)
                                    {
                                        string fileName = "~/submissions/GeneratedXmls/DHA/Error/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls".Replace(" ", "");
                                        using (FileStream destFile = System.IO.File.Open(Server.MapPath(fileName), FileMode.Create))
                                        {
                                            destFile.Write(eClaim_ErrorReport, 0, eClaim_ErrorReport.Length);
                                        }

                                        string atr1 = "Error Msg: " + eClaim_ErrorMessage + " Error Report <a href='/submissions/GeneratedXmls/DHA/Error/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls' class='fs-25 text-primary font-weight-bold text-center'><i class='fa fa-file-archive-o text-white'></i ></a>";
                                        atr = HttpUtility.HtmlDecode(atr1);

                                        //return Json(new { message = atr, response = eClaim_ErrorReport }, JsonRequestBehavior.AllowGet);

                                        // Return the file as a download
                                        return File(eClaim_ErrorReport, "application/vnd.ms-excel", fileName);
                                    }
                                    else
                                    {
                                        atr = "Error Msg: " + eClaim_ErrorMessage;

                                    }

                                }
                                else
                                {
                                    atr = "Error Msg: " + eClaim_ErrorMessage;
                                }
                            }
                            else
                            {
                                atr = "Error Msg: " + eClaim_ErrorMessage;
                            }
                        }
                        else
                        {
                            int eclId = 0;
                            string xmlString = stringWriter.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");
                            string FolderPath = Server.MapPath("~/submissions/GeneratedXmls/DHA/Direct/Sub_" + file_name); // Specify the output filename

                            eclId = BusinessLogicLayer.EClaims.EClaims.eClaim_Insert(s_ic_id, s_date_from, s_date_to, file_name, FolderPath, eClaim_ErrorMessage);

                            int uinv_id = 0;
                            if (s_flag == "PRODUCTION")
                            {
                                SqlCommand cmd_insert = new SqlCommand();
                                uinv_id = BusinessLogicLayer.EClaims.EClaims.SP_UpdateInvoiceStatus(inv_ids);
                            }
                            String contents = stringWriter.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");

                            // Get the length of the contents
                            int length = contents.Length;
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + file_name);
                            Response.AppendHeader("Content-Length", length.ToString());
                            Response.ContentType = "text/xml";
                            Response.Write(contents.ToString());
                            Response.End();
                        }
                        return Json(atr, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Please select Treatments" }, JsonRequestBehavior.AllowGet);
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

        static string SpliceText(string text, int spliceLength)
        {
            // Implement your SpliceText logic here
            // This is just a placeholder implementation
            return text;
        }

        [HttpGet]
        public ActionResult GenerateFullXmlManual(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    DateTime TransactionDate = DateTime.Now;
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                    DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                    dt = ds.Tables[0];
                    //dt = dt_Inv;
                    DataTable dt_signs = ds.Tables[0];
                    string ins_clinic_code = "";
                    string ic_name = "";
                    string filename = Server.MapPath("~/submissions/GeneratedXmls/DHA/Manual/Sub_" + dt.Rows[0]["set_permit_no"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + ".xml").Replace(" ", ""); // Specify the output filename
                    //StringWriter stringWriter = new StringWriter();
                    XmlTextWriter writer = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                    //XmlTextWriter writer = new XmlTextWriter(System.Text.Encoding.UTF8);
                    writer.Formatting = System.Xml.Formatting.Indented;
                    writer.WriteStartDocument();
                    // Start Claim.Submission element

                    DataRow dr = dt.Rows[0];
                    writer.WriteStartElement("Claim.Submission");
                    writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                    writer.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");

                    writer.WriteStartElement("Header");
                    // Write Header elements
                    writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                    writer.WriteElementString("ReceiverID", ins_code);
                    writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    writer.WriteElementString("RecordCount", no_of_claims.ToString());
                    writer.WriteElementString("DispositionFlag", s_flag);
                    // End Header element
                    writer.WriteEndElement();
                    int x = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        x = x + 1;
                        float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        float inv_net_cash = float.Parse(row["inv_net"].ToString());
                        float inv_vat = float.Parse(row["inv_vat"].ToString());
                        //float inv_net = float.Parse(row["inv_net"].ToString());
                        float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                        float inv_copay = float.Parse(row["inv_copay"].ToString());
                        float inv_share = float.Parse(row["inv_share"].ToString());
                        float pat_share = 0;
                        if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                        {
                            pat_share = inv_tded + inv_copay + inv_share;
                        }
                        else
                        {
                            pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        }
                        float inv_total = inv_net + pat_share;
                        string ins_no = row["inv_pi_insno"].ToString();
                        string claim_no = row["inv_claimno"].ToString();
                        string policy_no = row["inv_pi_polocyno"].ToString();
                        string inv_no = row["inv_no"].ToString();
                        string pat_emirateid = row["pat_emirateid"].ToString();
                        ins_clinic_code = row["inv_ic_payercode"].ToString();

                        ic_name = row["inv_insurance_name"].ToString();
                        DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                        DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                        int d_ay = app__fdate.Day;
                        string d__ay = "";
                        if (d_ay < 10)
                        {
                            d__ay = "0" + d_ay.ToString();
                        }
                        else
                        {
                            d__ay = d_ay.ToString();
                        }

                        int m_onth = app__fdate.Month;
                        string m__onth = "";
                        if (m_onth < 10)
                        {
                            m__onth = "0" + m_onth.ToString();
                        }
                        else
                        {
                            m__onth = m_onth.ToString();
                        }
                        writer.WriteStartElement("Claim");
                        writer.WriteElementString("ID", inv_no);
                        string MemberID_ = "";
                        if (ic_name == "'Cash'")
                        {
                            MemberID_ = dr["set_permit_no"].ToString() + "#" + row["pat_code"].ToString();
                            writer.WriteElementString("MemberID", MemberID_);

                            // MEDICAL TOURISAM START HERE

                            if (row["pat_city"].ToString() == "Abu Dhabi")
                            {
                                writer.WriteElementString("PayerID", "SelfPay");
                            }
                            else
                            {
                                if (row["app_emergency"].ToString() == "YES")
                                {
                                    writer.WriteElementString("PayerID", "SelfPay");
                                }
                                else
                                {
                                    writer.WriteElementString("PayerID", "MedicalTourismSelfPay");
                                }
                            }

                            // MEDICAL TOURISAM END HERE
                        }
                        else
                        {
                            writer.WriteElementString("MemberID", ins_no);
                            writer.WriteElementString("PayerID", ins_clinic_code);
                        }
                        writer.WriteElementString("ProviderID", dr["set_permit_no"].ToString());
                        if (claim_no != "")
                        {
                            writer.WriteElementString("ClaimNo", claim_no);
                            if (policy_no != "")
                            {
                                writer.WriteElementString("InsurancePolicyNo", policy_no);
                            }
                        }
                        if (row["pat_emirateid"].ToString() == " ")
                        {
                            writer.WriteElementString("EmiratesIDNumber", "999-9999-9999999-9");
                        }
                        else
                        {
                            writer.WriteElementString("EmiratesIDNumber", pat_emirateid);
                        }
                        if (ic_name == "'Cash'")
                        {
                            writer.WriteElementString("Gross", inv_net_cash.ToString("0.00"));
                            writer.WriteElementString("PatientShare", inv_net_cash.ToString("0.00"));
                            writer.WriteElementString("Net", "0");
                            writer.WriteElementString("VAT", inv_vat.ToString("0.00"));
                        }
                        else
                        {
                            writer.WriteElementString("Gross", inv_total.ToString("0.00"));
                            writer.WriteElementString("PatientShare", pat_share.ToString("0.00"));
                            writer.WriteElementString("Net", inv_net.ToString("0.00"));
                        }
                        writer.WriteStartElement("Encounter");
                        writer.WriteElementString("FacilityID", dr["set_permit_no"].ToString());
                        writer.WriteElementString("Type", "1");
                        writer.WriteElementString("PatientID", row["pat_code"].ToString());
                        if (row["app_eligibility"].ToString() != "0")
                        {
                            writer.WriteElementString("EligibilityIDPayer", row["app_eligibility"].ToString());
                        }
                        writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                        writer.WriteElementString("End", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ttime"].ToString());
                        writer.WriteElementString("StartType", "1");
                        // End Encounter element
                        writer.WriteEndElement();

                        //Diagnosis Generation Starts Here.....
                        DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(dr["appId"].ToString()), 0);
                        int diag_count = 0;
                        string diag__codes = "";
                        foreach (DataRow drDiag in dtDiag.Rows)
                        {
                            diag_count = diag_count + 1;
                            writer.WriteStartElement("Diagnosis");
                            if (drDiag["pad_type"].ToString() == "Primary")
                            {
                                writer.WriteElementString("Type", "Principal");
                            }
                            else if (drDiag["pad_type"].ToString() == "Secondary")
                            {
                                writer.WriteElementString("Type", "Secondary");
                            }
                            else
                            {
                                writer.WriteElementString("Type", "ReasonForVisit");
                            }
                            diag__codes = diag__codes + "," + drDiag["diag_code"].ToString();
                            writer.WriteElementString("Code", drDiag["Diag_Code"].ToString());
                            if (drDiag["pad_year"].ToString() != "0")
                            {
                                writer.WriteStartElement("DxInfo");
                                writer.WriteElementString("Type", "Year of Onset");
                                writer.WriteElementString("Code", drDiag["pad_year"].ToString());
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            // End Diagnosis element
                        }
                        //Diagnosis Generation Ends Here.....                           


                        DataTable dtTreat = new DataTable();
                        dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        int y = 0;
                        // int z = 0;
                        foreach (DataRow drTreat in dtTreat.Rows)
                        {


                            float pt_net = float.Parse(drTreat["pt_net"].ToString());
                            float pt_vat = float.Parse(drTreat["pt_vat"].ToString());
                            DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString());
                            y = y + 1;
                            string act_no = drTreat["ptId"].ToString();
                            int ActDetails = BusinessLogicLayer.EMR.PatientTreatments.InsertActivityDetails(int.Parse(drTreat["ptId"].ToString()), int.Parse(dr["appId"].ToString()), "Claims", act_no, PageControl.getLoggedinId(), pt_net, "Claims");

                            writer.WriteStartElement("Activity");
                            writer.WriteElementString("ID", act_no);
                            writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                            writer.WriteElementString("Type", drTreat["tr_itype"].ToString());
                            writer.WriteElementString("Code", drTreat["tr_code"].ToString());
                            writer.WriteElementString("Quantity", drTreat["pt_qty"].ToString());
                            if (ic_name == "'Cash'")
                            {
                                writer.WriteElementString("Net", "0");
                            }
                            else
                            {
                                writer.WriteElementString("Net", float.Parse(pt_net.ToString("0.00")).ToString());
                            }
                            writer.WriteElementString("Clinician", drTreat["emp_license"].ToString());
                            if (drTreat["pt_auth_code"].ToString() != "")
                            {
                                if (drTreat["pt_auth_code"].ToString() != "Not Required")
                                {
                                    writer.WriteElementString("PriorAuthorizationID", drTreat["pt_auth_code"].ToString());
                                }
                            }
                            if (ic_name == "'Cash'")
                            {
                                writer.WriteElementString("VAT", pt_vat.ToString("0.00"));
                                if (pt_vat > 0)
                                {
                                    writer.WriteElementString("VATPercent", "5");
                                }
                                else
                                {
                                    writer.WriteElementString("VATPercent", "0");
                                }
                            }

                            DataTable dtTreat2 = new DataTable();
                            dtTreat2 = BusinessLogicLayer.EClaims.EClaims.GetPrescriptions(int.Parse(dr["appId"].ToString()));
                            foreach (DataRow dtpresc in dtTreat2.Rows)
                            {
                                if (dtpresc["pre_eRxRefNo"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "ERX");
                                    writer.WriteElementString("Code", dtpresc["pre_eRxRefNo"].ToString());
                                    writer.WriteElementString("Value", dtpresc["preId"].ToString());
                                    writer.WriteElementString("ValueType", "Reference");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            writer.WriteStartElement("Observation");
                            writer.WriteElementString("Type", "Text");
                            writer.WriteElementString("Code", "InvoiceNumber");
                            writer.WriteElementString("Value", row["inv_no"].ToString());
                            writer.WriteElementString("ValueType", "Text");
                            // End Observation element
                            writer.WriteEndElement();

                            writer.WriteStartElement("Observation");
                            writer.WriteElementString("Type", "Text");
                            writer.WriteElementString("Code", "InvoiceDate");
                            writer.WriteElementString("Value", DateTime.Parse(row["inv_date"].ToString()).ToString("dd-MM-yyyy"));
                            writer.WriteElementString("ValueType", "Text");
                            // End Observation element
                            writer.WriteEndElement();

                            writer.WriteStartElement("Observation");
                            writer.WriteElementString("Type", "Financial");
                            writer.WriteElementString("Code", "ActivityGross");
                            writer.WriteElementString("Value", (float.Parse(drTreat["pt_total"].ToString()) - float.Parse(drTreat["pt_disc"].ToString())).ToString("0.00"));
                            writer.WriteElementString("ValueType", "Float");
                            // End Observation element
                            writer.WriteEndElement();

                            writer.WriteStartElement("Observation");
                            writer.WriteElementString("Type", "Financial");
                            writer.WriteElementString("Code", "PSDeductible");
                            writer.WriteElementString("Value", (float.Parse(drTreat["pt_ded"].ToString()) + float.Parse(drTreat["pt_dded"].ToString()) + float.Parse(drTreat["pt_rded"].ToString()) + float.Parse(drTreat["pt_mded"].ToString()) + float.Parse(drTreat["pt_lded"].ToString())).ToString("0.00"));
                            writer.WriteElementString("ValueType", "Float");
                            // End Observation element
                            writer.WriteEndElement();


                            writer.WriteStartElement("Observation");
                            writer.WriteElementString("Type", "Financial");
                            writer.WriteElementString("Code", "PSCoPayment");
                            writer.WriteElementString("Value", (float.Parse(drTreat["pt_copay"].ToString()) + float.Parse(drTreat["pt_dcopay"].ToString())).ToString("0.00"));
                            writer.WriteElementString("ValueType", "Float");
                            // End Observation element
                            writer.WriteEndElement();

                            writer.WriteStartElement("Observation");
                            writer.WriteElementString("Type", "Financial");
                            writer.WriteElementString("Code", "PSOutOfPocket");
                            writer.WriteElementString("Value", "0.00");
                            writer.WriteElementString("ValueType", "Float");
                            // End Observation element
                            writer.WriteEndElement();
                            // LOINC CODES STARTS
                            if (drTreat["ti_loinc_1"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", drTreat["ti_loinc_1"].ToString());
                                writer.WriteElementString("Value", drTreat["ti_loinc_2"].ToString());
                                writer.WriteElementString("ValueType", drTreat["ti_loinc_3"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_loinc_4"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", drTreat["ti_loinc_4"].ToString());
                                writer.WriteElementString("Value", drTreat["ti_loinc_5"].ToString());
                                writer.WriteElementString("ValueType", drTreat["ti_loinc_6"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_loinc_7"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", drTreat["ti_loinc_7"].ToString());
                                writer.WriteElementString("Value", drTreat["ti_loinc_8"].ToString());
                                writer.WriteElementString("ValueType", drTreat["ti_loinc_9"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_loinc_10"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", drTreat["ti_loinc_10"].ToString());
                                writer.WriteElementString("Value", drTreat["ti_loinc_11"].ToString());
                                writer.WriteElementString("ValueType", drTreat["ti_loinc_12"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_loinc_13"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", drTreat["ti_loinc_13"].ToString());
                                writer.WriteElementString("Value", drTreat["ti_loinc_14"].ToString());
                                writer.WriteElementString("ValueType", drTreat["ti_loinc_15"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            // LOINC CODES ENDS
                            if ((drTreat["tr_code"].ToString() == "9") || (drTreat["tr_code"].ToString() == "10") || (drTreat["tr_code"].ToString() == "11") || (drTreat["tr_code"].ToString() == "9.1") || (drTreat["tr_code"].ToString() == "10.1") || (drTreat["tr_code"].ToString() == "11.1"))
                            {
                                if (drTreat["ti_lab_8"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "BPS");
                                    writer.WriteElementString("Value", drTreat["ti_lab_8"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_9"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "BPD");
                                    writer.WriteElementString("Value", drTreat["ti_lab_9"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "82565")
                            {
                                if (drTreat["ti_lab_7"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "CR");
                                    writer.WriteElementString("Value", drTreat["ti_lab_7"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "82043")
                            {
                                if (drTreat["ti_lab_6"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "UA");
                                    writer.WriteElementString("Value", drTreat["ti_lab_6"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "84478")
                            {
                                if (drTreat["ti_lab_5"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "TRIG");
                                    writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "83721")
                            {
                                if (drTreat["ti_lab_4"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "LDL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "83718")
                            {
                                if (drTreat["ti_lab_3"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "HDL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "82465")
                            {
                                if (drTreat["ti_lab_2"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "CHOL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "80061")
                            {
                                if (drTreat["ti_image_7"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "NONHDL");
                                    writer.WriteElementString("Value", drTreat["ti_image_7"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "80061")
                            {
                                if (drTreat["ti_lab_2"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "CHOL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_3"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "HDL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_4"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "LDL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }

                                if (drTreat["ti_lab_5"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "TRIG");
                                    writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }

                            }
                            if (drTreat["tr_code"].ToString() == "83036")
                            {
                                if (drTreat["ti_lab_1"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "A1c");
                                    writer.WriteElementString("Value", drTreat["ti_lab_1"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (diag__codes.Contains("E66.9") == true)
                            {
                                if (drTreat["ti_lab_10"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "BMI");
                                    writer.WriteElementString("Value", drTreat["ti_lab_10"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                            {
                                if (drTreat["ti_lab_11"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "Albumin");
                                    writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                            {
                                if (drTreat["ti_lab_11"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "Albumin");
                                    writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_12"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "ALP");
                                    writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_13"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "ALT");
                                    writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_14"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "AST");
                                    writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_8"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "TotalBilirubin");
                                    writer.WriteElementString("Value", drTreat["ti_image_8"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_9"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "DirectBilirubin");
                                    writer.WriteElementString("Value", drTreat["ti_image_9"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_10"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "TotalProtein");
                                    writer.WriteElementString("Value", drTreat["ti_image_10"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                            {
                                if (drTreat["ti_lab_12"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "ALP");
                                    writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84460"))
                            {
                                if (drTreat["ti_lab_13"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "ALT");
                                    writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84450"))
                            {
                                if (drTreat["ti_lab_14"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "AST");
                                    writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                            {
                                if (drTreat["ti_lab_15"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "FBS");
                                    writer.WriteElementString("Value", drTreat["ti_lab_15"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                            {
                                if (drTreat["ti_lab_16"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "RBS");
                                    writer.WriteElementString("Value", drTreat["ti_lab_16"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["ti_lab_17"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Result");
                                writer.WriteElementString("Code", "FCR");
                                writer.WriteElementString("Value", drTreat["ti_lab_17"].ToString());
                                writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                // End Observation element
                                writer.WriteEndElement();
                            }

                            // NEW CODES ENDS

                            if (drTreat["tr_code"].ToString() == "17999")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "Activity Description");
                                writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                writer.WriteElementString("ValueType", "Text");
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["tr_code"].ToString() == "0232T")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "Activity Description");
                                writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                writer.WriteElementString("ValueType", "Text");
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["pt_notes"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "Description");
                                writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["pt_teeth"].ToString() != "")
                            {
                                if (drTreat["pt_teeth"].ToString() != "NA")
                                {
                                    string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                    for (int j = 0; j < pt__teeth.Length; j++)
                                    {
                                        //MessageBox.Show(words[j]);
                                        if (pt__teeth[j].Trim() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Universal Dental");
                                            writer.WriteElementString("Code", pt__teeth[j].Trim());
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                }
                            }
                            if (claim_no != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "CLAIM-FORM-NUMBER");
                                writer.WriteElementString("Value", claim_no);
                                writer.WriteElementString("ValueType", "CLAIM-FORM-NUMBER");
                                // End Observation element
                                writer.WriteEndElement();
                            }

                            if ((drTreat["pt_notes"].ToString() != "") && (ic_name.Contains("MADALLAH") == true))
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "CLAIM-FORM-NUMBER");
                                writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                writer.WriteElementString("ValueType", "CLAIM-FORM-NUMBER");
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_1"].ToString() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");

                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_1"].ToString());
                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_2"].ToString() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");

                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_2"].ToString());
                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();

                            }
                            if (drTreat["ti_image_3"].ToString() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");

                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_3"].ToString());
                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_4"].ToString() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");

                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_4"].ToString());
                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_5"].ToString() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");

                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_5"].ToString());
                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            DataTable dt_lab = new DataTable();
                            dt_lab = BusinessLogicLayer.EClaims.EClaims.GetLabResultsAppointmentID(int.Parse(drTreat["ptId"].ToString()));
                            foreach (DataRow dr_lab in dt_lab.Rows)
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", dr_lab["cll_code"].ToString());
                                writer.WriteElementString("Value", drTreat["cll_result"].ToString());
                                writer.WriteElementString("ValueType", dr_lab["cll_units"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            // End Activity element
                            writer.WriteEndElement();
                        }
                        // End Claim element
                        writer.WriteEndElement();
                    }
                    // End Claim Submission element
                    writer.WriteEndElement();
                    // End Document
                    writer.WriteEndDocument();
                    // string val= stringWriter.ToString();
                    writer.Flush();
                    writer.Close();
                    byte[] fileContent = null;
                    string fileName = Path.Combine(filename);
                    System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                    long byteLength = new System.IO.FileInfo(fileName).Length;
                    fileContent = binaryReader.ReadBytes((Int32)byteLength);
                    fs.Close();
                    fs.Dispose();
                    binaryReader.Close();
                    return new FileContentResult(fileContent, "application/xml");

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
        public ActionResult GenerateFullXmlDirect(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    DateTime TransactionDate = DateTime.Now;
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                    dt = ds.Tables[0];
                    //dt = dt_Inv;
                    DataTable dt_signs = ds.Tables[0];
                    string ins_clinic_code = "";
                    string ic_name = "";
                    string filename = Server.MapPath("~/submissions/GeneratedXmls/DHA/Direct/Sub_" + dt.Rows[0]["set_permit_no"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".xml").Replace(" ", ""); // Specify the output filename

                    StringWriter stringWriter = new StringWriter();
                    XmlTextWriter writer = new XmlTextWriter(stringWriter);
                    writer.Formatting = System.Xml.Formatting.Indented;
                    writer.WriteStartDocument();
                    // Start Claim.Submission element
                    if (BusinessLogicLayer.EClaims.EClaims.Check_Already_Submitted(s_ic_id, DateTime.Parse(s_date_from.ToString("MM/dd/yyyy")), DateTime.Parse(s_date_to.ToString("MM/dd/yyyy"))) == false)
                    {
                        if (dt_signs.Rows.Count > 0)
                        {
                            string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                            DataRow dr = dt.Rows[0];
                            writer.WriteStartElement("Claim.Submission");
                            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                            writer.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");

                            writer.WriteStartElement("Header");
                            // Write Header elements
                            writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                            writer.WriteElementString("ReceiverID", ins_code);
                            writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                            writer.WriteElementString("RecordCount", no_of_claims.ToString());
                            writer.WriteElementString("DispositionFlag", s_flag);
                            // End Header element
                            writer.WriteEndElement();
                            int x = 0;
                            foreach (DataRow row in dt.Rows)
                            {
                                x = x + 1;
                                float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                                float inv_net_cash = float.Parse(row["inv_net"].ToString());
                                float inv_vat = float.Parse(row["inv_vat"].ToString());
                                //float inv_net = float.Parse(row["inv_net"].ToString());
                                float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                                float inv_copay = float.Parse(row["inv_copay"].ToString());
                                float inv_share = float.Parse(row["inv_share"].ToString());
                                float pat_share = 0;
                                if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                                {
                                    pat_share = inv_tded + inv_copay + inv_share;
                                }
                                else
                                {
                                    pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                                }
                                float inv_total = inv_net + pat_share;
                                string ins_no = row["inv_pi_insno"].ToString();
                                string claim_no = row["inv_claimno"].ToString();
                                string policy_no = row["inv_pi_polocyno"].ToString();
                                string inv_no = row["inv_no"].ToString();
                                string pat_emirateid = row["pat_emirateid"].ToString();
                                ins_clinic_code = row["inv_ic_payercode"].ToString();

                                ic_name = row["inv_insurance_name"].ToString();
                                DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                                DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                                int d_ay = app__fdate.Day;
                                string d__ay = "";
                                if (d_ay < 10)
                                {
                                    d__ay = "0" + d_ay.ToString();
                                }
                                else
                                {
                                    d__ay = d_ay.ToString();
                                }

                                int m_onth = app__fdate.Month;
                                string m__onth = "";
                                if (m_onth < 10)
                                {
                                    m__onth = "0" + m_onth.ToString();
                                }
                                else
                                {
                                    m__onth = m_onth.ToString();
                                }
                                writer.WriteStartElement("Claim");
                                writer.WriteElementString("ID", inv_no);
                                writer.WriteElementString("MemberID", ins_no);
                                writer.WriteElementString("PayerID", ins_clinic_code);
                                writer.WriteElementString("ProviderID", dr["set_permit_no"].ToString());
                                if (claim_no != "")
                                {
                                    writer.WriteElementString("ClaimNo", claim_no);
                                    if (policy_no != "")
                                    {
                                        writer.WriteElementString("InsurancePolicyNo", policy_no);
                                    }
                                }
                                if (row["pat_emirateid"].ToString() == " ")
                                {
                                    writer.WriteElementString("EmiratesIDNumber", "999-9999-9999999-9");
                                }
                                else
                                {
                                    writer.WriteElementString("EmiratesIDNumber", pat_emirateid);
                                }
                                writer.WriteElementString("Gross", inv_total.ToString("0.00"));
                                writer.WriteElementString("PatientShare", pat_share.ToString("0.00"));
                                writer.WriteElementString("Net", inv_net.ToString("0.00"));

                                writer.WriteStartElement("Encounter");
                                writer.WriteElementString("FacilityID", dr["set_permit_no"].ToString());
                                writer.WriteElementString("Type", "1");
                                writer.WriteElementString("PatientID", row["pat_code"].ToString());
                                if (row["app_eligibility"].ToString() != "0")
                                {
                                    writer.WriteElementString("EligibilityIDPayer", row["app_eligibility"].ToString());
                                }
                                writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                                writer.WriteElementString("End", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ttime"].ToString());
                                writer.WriteElementString("StartType", "1");
                                // End Encounter element
                                writer.WriteEndElement();

                                //Diagnosis Generation Starts Here.....
                                DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(dr["appId"].ToString()), 0);
                                int diag_count = 0;
                                string diag__codes = "";
                                foreach (DataRow drDiag in dtDiag.Rows)
                                {
                                    diag_count = diag_count + 1;
                                    writer.WriteStartElement("Diagnosis");
                                    if (drDiag["pad_type"].ToString() == "Primary")
                                    {
                                        writer.WriteElementString("Type", "Principal");
                                    }
                                    else if (drDiag["pad_type"].ToString() == "Secondary")
                                    {
                                        writer.WriteElementString("Type", "Secondary");
                                    }
                                    else
                                    {
                                        writer.WriteElementString("Type", "ReasonForVisit");
                                    }
                                    diag__codes = diag__codes + "," + drDiag["diag_code"].ToString();
                                    writer.WriteElementString("Code", drDiag["Diag_Code"].ToString());
                                    if (drDiag["pad_year"].ToString() != "0")
                                    {
                                        writer.WriteStartElement("DxInfo");
                                        writer.WriteElementString("Type", "Year of Onset");
                                        writer.WriteElementString("Code", drDiag["pad_year"].ToString());
                                        writer.WriteEndElement();
                                    }
                                    writer.WriteEndElement();
                                }
                                //Diagnosis Generation Ends Here.....                           


                                DataTable dtTreat = new DataTable();
                                dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                                int y = 0;
                                // int z = 0;
                                foreach (DataRow drTreat in dtTreat.Rows)
                                {


                                    float pt_net = float.Parse(drTreat["pt_net"].ToString());
                                    float pt_vat = float.Parse(drTreat["pt_vat"].ToString());
                                    DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString());
                                    y = y + 1;
                                    string act_no = drTreat["ptId"].ToString();
                                    int ActDetails = BusinessLogicLayer.EMR.PatientTreatments.InsertActivityDetails(int.Parse(drTreat["ptId"].ToString()), int.Parse(dr["appId"].ToString()), "Claims", act_no, PageControl.getLoggedinId(), pt_net, "Claims");

                                    writer.WriteStartElement("Activity");
                                    writer.WriteElementString("ID", act_no);
                                    writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                                    writer.WriteElementString("Type", drTreat["tr_itype"].ToString());
                                    writer.WriteElementString("Code", drTreat["tr_code"].ToString());
                                    writer.WriteElementString("Quantity", drTreat["pt_qty"].ToString());
                                    writer.WriteElementString("Net", float.Parse(pt_net.ToString("0.00")).ToString());
                                    writer.WriteElementString("Clinician", drTreat["emp_license"].ToString());
                                    if (drTreat["pt_auth_code"].ToString() != "")
                                    {
                                        if (drTreat["pt_auth_code"].ToString() != "Not Required")
                                        {
                                            writer.WriteElementString("PriorAuthorizationID", drTreat["pt_auth_code"].ToString());
                                        }
                                    }
                                    if (drTreat["ic_name"].ToString() == "'Cash'")
                                    {
                                        writer.WriteElementString("VAT", pt_vat.ToString("0.00"));
                                        if (pt_vat > 0)
                                        {
                                            writer.WriteElementString("VATPercent", "5");
                                        }
                                        else
                                        {
                                            writer.WriteElementString("VATPercent", "0");
                                        }
                                    }

                                    DataTable dtTreat2 = new DataTable();
                                    dtTreat2 = BusinessLogicLayer.EClaims.EClaims.GetPrescriptions(int.Parse(dr["appId"].ToString()));
                                    foreach (DataRow dtpresc in dtTreat2.Rows)
                                    {
                                        if (dtpresc["pre_eRxRefNo"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "ERX");
                                            writer.WriteElementString("Code", dtpresc["pre_eRxRefNo"].ToString());
                                            writer.WriteElementString("Value", dtpresc["preId"].ToString());
                                            writer.WriteElementString("ValueType", "Reference");
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "InvoiceNumber");
                                    writer.WriteElementString("Value", row["inv_no"].ToString());
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();

                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "InvoiceDate");
                                    writer.WriteElementString("Value", DateTime.Parse(row["inv_date"].ToString()).ToString("dd-MM-yyyy"));
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();

                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Financial");
                                    writer.WriteElementString("Code", "ActivityGross");
                                    writer.WriteElementString("Value", (float.Parse(drTreat["pt_total"].ToString()) - float.Parse(drTreat["pt_disc"].ToString())).ToString("0.00"));
                                    writer.WriteElementString("ValueType", "Float");
                                    // End Observation element
                                    writer.WriteEndElement();

                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Financial");
                                    writer.WriteElementString("Code", "PSDeductible");
                                    writer.WriteElementString("Value", (float.Parse(drTreat["pt_ded"].ToString()) + float.Parse(drTreat["pt_dded"].ToString()) + float.Parse(drTreat["pt_rded"].ToString()) + float.Parse(drTreat["pt_mded"].ToString()) + float.Parse(drTreat["pt_lded"].ToString())).ToString("0.00"));
                                    writer.WriteElementString("ValueType", "Float");
                                    // End Observation element
                                    writer.WriteEndElement();


                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Financial");
                                    writer.WriteElementString("Code", "PSCoPayment");
                                    writer.WriteElementString("Value", (float.Parse(drTreat["pt_copay"].ToString()) + float.Parse(drTreat["pt_dcopay"].ToString())).ToString("0.00"));
                                    writer.WriteElementString("ValueType", "Float");
                                    // End Observation element
                                    writer.WriteEndElement();

                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Financial");
                                    writer.WriteElementString("Code", "PSOutOfPocket");
                                    writer.WriteElementString("Value", "0.00");
                                    writer.WriteElementString("ValueType", "Float");
                                    // End Observation element
                                    writer.WriteEndElement();
                                    // LOINC CODES STARTS
                                    if (drTreat["ti_loinc_1"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", drTreat["ti_loinc_1"].ToString());
                                        writer.WriteElementString("Value", drTreat["ti_loinc_2"].ToString());
                                        writer.WriteElementString("ValueType", drTreat["ti_loinc_3"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_loinc_4"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", drTreat["ti_loinc_4"].ToString());
                                        writer.WriteElementString("Value", drTreat["ti_loinc_5"].ToString());
                                        writer.WriteElementString("ValueType", drTreat["ti_loinc_6"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_loinc_7"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", drTreat["ti_loinc_7"].ToString());
                                        writer.WriteElementString("Value", drTreat["ti_loinc_8"].ToString());
                                        writer.WriteElementString("ValueType", drTreat["ti_loinc_9"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_loinc_10"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", drTreat["ti_loinc_10"].ToString());
                                        writer.WriteElementString("Value", drTreat["ti_loinc_11"].ToString());
                                        writer.WriteElementString("ValueType", drTreat["ti_loinc_12"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_loinc_13"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", drTreat["ti_loinc_13"].ToString());
                                        writer.WriteElementString("Value", drTreat["ti_loinc_14"].ToString());
                                        writer.WriteElementString("ValueType", drTreat["ti_loinc_15"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    // LOINC CODES ENDS
                                    if ((drTreat["tr_code"].ToString() == "9") || (drTreat["tr_code"].ToString() == "10") || (drTreat["tr_code"].ToString() == "11") || (drTreat["tr_code"].ToString() == "9.1") || (drTreat["tr_code"].ToString() == "10.1") || (drTreat["tr_code"].ToString() == "11.1"))
                                    {
                                        if (drTreat["ti_lab_8"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "BPS");
                                            writer.WriteElementString("Value", drTreat["ti_lab_8"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_9"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "BPD");
                                            writer.WriteElementString("Value", drTreat["ti_lab_9"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "82565")
                                    {
                                        if (drTreat["ti_lab_7"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "CR");
                                            writer.WriteElementString("Value", drTreat["ti_lab_7"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "82043")
                                    {
                                        if (drTreat["ti_lab_6"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "UA");
                                            writer.WriteElementString("Value", drTreat["ti_lab_6"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "84478")
                                    {
                                        if (drTreat["ti_lab_5"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "TRIG");
                                            writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "83721")
                                    {
                                        if (drTreat["ti_lab_4"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "LDL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "83718")
                                    {
                                        if (drTreat["ti_lab_3"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "HDL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "82465")
                                    {
                                        if (drTreat["ti_lab_2"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "CHOL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "80061")
                                    {
                                        if (drTreat["ti_image_7"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "NONHDL");
                                            writer.WriteElementString("Value", drTreat["ti_image_7"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "80061")
                                    {
                                        if (drTreat["ti_lab_2"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "CHOL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_3"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "HDL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_4"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "LDL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }

                                        if (drTreat["ti_lab_5"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "TRIG");
                                            writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }

                                    }
                                    if (drTreat["tr_code"].ToString() == "83036")
                                    {
                                        if (drTreat["ti_lab_1"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "A1c");
                                            writer.WriteElementString("Value", drTreat["ti_lab_1"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }

                                    if (diag__codes.Contains("E66.9") == true)
                                    {
                                        if (drTreat["ti_lab_10"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "BMI");
                                            writer.WriteElementString("Value", drTreat["ti_lab_10"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                                    {
                                        if (drTreat["ti_lab_11"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "Albumin");
                                            writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                                    {
                                        if (drTreat["ti_lab_11"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "Albumin");
                                            writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_12"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "ALP");
                                            writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_13"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "ALT");
                                            writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_14"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "AST");
                                            writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_image_8"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "TotalBilirubin");
                                            writer.WriteElementString("Value", drTreat["ti_image_8"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_image_9"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "DirectBilirubin");
                                            writer.WriteElementString("Value", drTreat["ti_image_9"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_image_10"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "TotalProtein");
                                            writer.WriteElementString("Value", drTreat["ti_image_10"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                                    {
                                        if (drTreat["ti_lab_12"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "ALP");
                                            writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84460"))
                                    {
                                        if (drTreat["ti_lab_13"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "ALT");
                                            writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84450"))
                                    {
                                        if (drTreat["ti_lab_14"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "AST");
                                            writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                    {
                                        if (drTreat["ti_lab_15"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "FBS");
                                            writer.WriteElementString("Value", drTreat["ti_lab_15"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                    {
                                        if (drTreat["ti_lab_16"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "RBS");
                                            writer.WriteElementString("Value", drTreat["ti_lab_16"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["ti_lab_17"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "FCR");
                                        writer.WriteElementString("Value", drTreat["ti_lab_17"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["tr_code"].ToString() == "17999")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Text");
                                        writer.WriteElementString("Code", "Activity Description");
                                        writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                        writer.WriteElementString("ValueType", "Text");
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["tr_code"].ToString() == "0232T")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Text");
                                        writer.WriteElementString("Code", "Activity Description");
                                        writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                        writer.WriteElementString("ValueType", "Text");
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    // NEW CODES ENDS
                                    if (drTreat["pt_notes"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "Description");
                                        writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["pt_teeth"].ToString() != "")
                                    {
                                        if (drTreat["pt_teeth"].ToString() != "NA")
                                        {
                                            string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                            for (int j = 0; j < pt__teeth.Length; j++)
                                            {
                                                //MessageBox.Show(words[j]);
                                                if (pt__teeth[j].Trim() != "")
                                                {
                                                    writer.WriteStartElement("Observation");
                                                    writer.WriteElementString("Type", "Universal Dental");
                                                    writer.WriteElementString("Code", pt__teeth[j].Trim());
                                                    // End Observation element
                                                    writer.WriteEndElement();
                                                }
                                            }
                                        }
                                    }

                                    if (claim_no != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Text");
                                        writer.WriteElementString("Code", "CLAIM-FORM-NUMBER");
                                        writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                        writer.WriteElementString("ValueType", "CLAIM-FORM-NUMBER");
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }

                                    if (drTreat["ti_image_1"].ToString() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "File");
                                        writer.WriteElementString("Code", "PDF");

                                        string path = "";
                                        path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                        string file_path = Path.Combine(path, drTreat["ti_image_1"].ToString());
                                        byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                        string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                        writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                        writer.WriteElementString("ValueType", "PDF File");
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_2"].ToString() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "File");
                                        writer.WriteElementString("Code", "PDF");

                                        string path = "";
                                        path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                        string file_path = Path.Combine(path, drTreat["ti_image_2"].ToString());
                                        byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                        string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                        writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                        writer.WriteElementString("ValueType", "PDF File");
                                        writer.WriteEndElement();

                                    }
                                    if (drTreat["ti_image_3"].ToString() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "File");
                                        writer.WriteElementString("Code", "PDF");

                                        string path = "";
                                        path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                        string file_path = Path.Combine(path, drTreat["ti_image_3"].ToString());
                                        byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                        string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                        writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                        writer.WriteElementString("ValueType", "PDF File");
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_4"].ToString() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "File");
                                        writer.WriteElementString("Code", "PDF");

                                        string path = "";
                                        path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                        string file_path = Path.Combine(path, drTreat["ti_image_4"].ToString());
                                        byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                        string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                        writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                        writer.WriteElementString("ValueType", "PDF File");
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_5"].ToString() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "File");
                                        writer.WriteElementString("Code", "PDF");

                                        string path = "";
                                        path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                        string file_path = Path.Combine(path, drTreat["ti_image_5"].ToString());
                                        byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                        string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                        writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                        writer.WriteElementString("ValueType", "PDF File");
                                        writer.WriteEndElement();
                                    }
                                    DataTable dt_lab = new DataTable();
                                    dt_lab = BusinessLogicLayer.EClaims.EClaims.GetLabResultsAppointmentID(int.Parse(drTreat["ptId"].ToString()));
                                    foreach (DataRow dr_lab in dt_lab.Rows)
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", dr_lab["cll_code"].ToString());
                                        writer.WriteElementString("Value", drTreat["cll_result"].ToString());
                                        writer.WriteElementString("ValueType", dr_lab["cll_units"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    // End Activity element
                                    writer.WriteEndElement();
                                }
                                // End Claim element
                                writer.WriteEndElement();
                            }
                            // End Claim Submission element
                            writer.WriteEndElement();
                            // End Document
                            writer.WriteEndDocument();
                            // string val= stringWriter.ToString();
                            writer.Flush();
                            writer.Close();
                            string file_name = dr["set_permit_no"].ToString() + "_" + s_ic_id + "_" + s_date_from.ToString("ddMMyyyy") + "_" + s_date_to.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xml";

                            string eClaim_ErrorMessage = "";
                            byte[] eClaim_ErrorReport = new byte[99];

                            ae.eclaimlink.dhpo1.ValidateTransactions e_Claim = new ae.eclaimlink.dhpo1.ValidateTransactions();
                            e_Claim.UploadTransaction(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), Encoding.UTF8.GetBytes(stringWriter.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"")), file_name, out eClaim_ErrorMessage, out eClaim_ErrorReport);

                            TempData["ErrorMessage"] = eClaim_ErrorMessage;
                            string atr = "";
                            if (eClaim_ErrorMessage.Contains("successful") == false)
                            {
                                if (eClaim_ErrorMessage.Contains("invalid") == false)
                                {
                                    if (eClaim_ErrorMessage.Contains("input") == false)
                                    {
                                        string fileName = "~/submissions/GeneratedXmls/DHA/Error/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls".Replace(" ", "");
                                        using (FileStream destFile = System.IO.File.Open(Server.MapPath(fileName), FileMode.Create))
                                        {
                                            destFile.Write(eClaim_ErrorReport, 0, eClaim_ErrorReport.Length);
                                        }

                                        string atr1 = "Error Msg: " + eClaim_ErrorMessage + " Error Report <a href='/submissions/GeneratedXmls/DHA/Error/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls' class='fs-25 text-primary font-weight-bold text-center'><i class='fa fa-file-archive-o text-white'></i ></a>";
                                        atr = HttpUtility.HtmlDecode(atr1);
                                        return File(eClaim_ErrorReport, "application/vnd.ms-excel", fileName);
                                    }
                                    else
                                    {
                                        atr = "Error Msg: " + eClaim_ErrorMessage;
                                    }
                                }
                                else
                                {
                                    atr = "Error Msg: " + eClaim_ErrorMessage;
                                }
                            }
                            else
                            {
                                int eclId = 0;
                                string xmlString = stringWriter.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");

                                string FolderPath = Server.MapPath("~/submissions/GeneratedXmls/DHA/Direct/Sub_" + file_name); // Specify the output filename
                                eclId = BusinessLogicLayer.EClaims.EClaims.eClaim_Insert(s_ic_id, s_date_from, s_date_to, file_name, FolderPath, eClaim_ErrorMessage);
                                int uinv_id = 0;
                                if (s_flag == "PRODUCTION")
                                {
                                    uinv_id = BusinessLogicLayer.EClaims.EClaims.SP_UpdateInvoiceStatus(inv_ids);
                                }
                                String contents = writer.ToString();

                                // Get the length of the contents
                                int length = contents.Length;
                                Response.AppendHeader("Content-Disposition", "attachment; filename=" + file_name);
                                Response.AppendHeader("Content-Length", length.ToString());
                                Response.ContentType = "text/xml";
                                Response.Write(contents.ToString());
                                Response.End();
                            }
                            return Json(atr, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Please select Treatments" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Selected Insurance Company claims during selected period already submitted" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult GenerateHAADSelectedXmlManual(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    DateTime TransactionDate = DateTime.Now;
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    int val = 0;
                    DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                    dt = ds.Tables[0];
                    DataTable dt_signs = ds.Tables[0];
                    string ins_clinic_code = "";
                    string ic_name = "";
                    string filename = Server.MapPath("~/submissions/GeneratedXmls/HAAD/Manual/Sub_" + dt.Rows[0]["set_permit_no"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + ".xml").Replace(" ", ""); // Specify the output filename
                    //StringWriter stringWriter = new StringWriter();
                    XmlTextWriter writer = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                    //XmlTextWriter writer = new XmlTextWriter(System.Text.Encoding.UTF8);
                    writer.Formatting = System.Xml.Formatting.Indented;
                    writer.WriteStartDocument();
                    // Start Claim.Submission element


                    if (dt_signs.Rows.Count > 0)
                    {
                        string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                        DataRow dr = dt.Rows[0];
                        writer.WriteStartElement("Claim.Submission");
                        writer.WriteAttributeString("xmlns:tns", "http://www.haad.ae/DataDictionary/CommonTypes");
                        writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                        writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "http://www.haad.ae/DataDictionary/CommonTypes/DataDictionary.xsd");
                        writer.WriteStartElement("Header");
                        // Write Header elements
                        writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                        if (ic_names == "'Cash'")
                        {
                            writer.WriteElementString("ReceiverID", "HAAD");
                        }
                        else
                        {
                            writer.WriteElementString("ReceiverID", ins_code);
                        }
                        writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        writer.WriteElementString("RecordCount", no_of_claims.ToString());
                        writer.WriteElementString("DispositionFlag", s_flag);
                        // End Header element
                        writer.WriteEndElement();
                        int x = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            x = x + 1;
                            float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            float inv_net_cash = float.Parse(row["inv_net"].ToString());
                            float inv_vat = float.Parse(row["inv_vat"].ToString());
                            //float inv_net = float.Parse(row["inv_net"].ToString());
                            float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                            float inv_copay = float.Parse(row["inv_copay"].ToString());
                            float inv_share = float.Parse(row["inv_share"].ToString());
                            float pat_share = 0;
                            if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                            {
                                pat_share = inv_tded + inv_copay + inv_share;
                            }
                            else
                            {
                                pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            }
                            float inv_total = inv_net + pat_share;
                            string ins_no = row["inv_pi_insno"].ToString();
                            string claim_no = row["inv_claimno"].ToString();
                            string policy_no = row["inv_pi_polocyno"].ToString();
                            string inv_no = row["inv_no"].ToString();
                            string pat_emirateid = row["pat_emirateid"].ToString();
                            ins_clinic_code = row["inv_ic_payercode"].ToString();

                            ic_name = row["inv_insurance_name"].ToString();
                            DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                            DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                            int d_ay = app__fdate.Day;
                            string d__ay = "";
                            if (d_ay < 10)
                            {
                                d__ay = "0" + d_ay.ToString();
                            }
                            else
                            {
                                d__ay = d_ay.ToString();
                            }

                            int m_onth = app__fdate.Month;
                            string m__onth = "";
                            if (m_onth < 10)
                            {
                                m__onth = "0" + m_onth.ToString();
                            }
                            else
                            {
                                m__onth = m_onth.ToString();
                            }
                            writer.WriteStartElement("Claim");
                            writer.WriteElementString("ID", inv_no);
                            string MemberID_ = "";
                            if (ic_name == "'Cash'")
                            {
                                MemberID_ = dr["set_permit_no"].ToString() + "#" + row["pat_code"].ToString();
                                writer.WriteElementString("MemberID", MemberID_);

                                // MEDICAL TOURISAM START HERE

                                if (row["pat_city"].ToString() == "Abu Dhabi")
                                {
                                    writer.WriteElementString("PayerID", "SelfPay");
                                }
                                else
                                {
                                    if (row["app_emergency"].ToString() == "YES")
                                    {
                                        writer.WriteElementString("PayerID", "SelfPay");
                                    }
                                    else
                                    {
                                        writer.WriteElementString("PayerID", "MedicalTourismSelfPay");
                                    }
                                }

                                // MEDICAL TOURISAM END HERE
                            }
                            else
                            {
                                writer.WriteElementString("MemberID", ins_no);
                                writer.WriteElementString("PayerID", ins_clinic_code);
                            }
                            writer.WriteElementString("ProviderID", dr["set_permit_no"].ToString());
                            if (claim_no != "")
                            {
                                writer.WriteElementString("ClaimNo", claim_no);
                                if (policy_no != "")
                                {
                                    writer.WriteElementString("InsurancePolicyNo", policy_no);
                                }
                            }
                            if (row["pat_emirateid"].ToString() == " ")
                            {
                                writer.WriteElementString("EmiratesIDNumber", "999-9999-9999999-9");
                            }
                            else
                            {
                                writer.WriteElementString("EmiratesIDNumber", pat_emirateid);
                            }
                            if (ic_name == "'Cash'")
                            {
                                writer.WriteElementString("Gross", inv_net_cash.ToString("0.00"));
                                writer.WriteElementString("PatientShare", inv_net_cash.ToString("0.00"));
                                writer.WriteElementString("Net", "0");
                                writer.WriteElementString("VAT", inv_vat.ToString("0.00"));
                            }
                            else
                            {
                                writer.WriteElementString("Gross", inv_total.ToString("0.00"));
                                writer.WriteElementString("PatientShare", pat_share.ToString("0.00"));
                                writer.WriteElementString("Net", inv_net.ToString("0.00"));
                            }
                            writer.WriteStartElement("Encounter");
                            writer.WriteElementString("FacilityID", dr["set_permit_no"].ToString());
                            writer.WriteElementString("Type", "1");
                            writer.WriteElementString("PatientID", row["pat_code"].ToString());
                            if (row["app_eligibility"].ToString() != "0")
                            {
                                writer.WriteElementString("EligibilityIDPayer", row["app_eligibility"].ToString());
                            }
                            writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                            writer.WriteElementString("End", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ttime"].ToString());
                            writer.WriteElementString("StartType", "1");
                            // End Encounter element
                            writer.WriteEndElement();

                            //Diagnosis Generation Starts Here.....
                            DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(dr["appId"].ToString()), 0);
                            int diag_count = 0;
                            string diag__codes = "";
                            foreach (DataRow drDiag in dtDiag.Rows)
                            {
                                diag_count = diag_count + 1;
                                writer.WriteStartElement("Diagnosis");
                                if (drDiag["pad_type"].ToString() == "Primary")
                                {
                                    writer.WriteElementString("Type", "Principal");
                                }
                                else if (drDiag["pad_type"].ToString() == "Secondary")
                                {
                                    writer.WriteElementString("Type", "Secondary");
                                }
                                else
                                {
                                    writer.WriteElementString("Type", "ReasonForVisit");
                                }
                                diag__codes = diag__codes + "," + drDiag["diag_code"].ToString();
                                writer.WriteElementString("Code", drDiag["Diag_Code"].ToString());
                                if (drDiag["pad_year"].ToString() != "0")
                                {
                                    writer.WriteStartElement("DxInfo");
                                    writer.WriteElementString("Type", "Year of Onset");
                                    writer.WriteElementString("Code", drDiag["pad_year"].ToString());
                                    writer.WriteEndElement();
                                }
                                writer.WriteEndElement();
                            }
                            //Diagnosis Generation Ends Here.....                           

                            DataTable dtTreat = new DataTable();
                            dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            int y = 0;
                            // int z = 0;
                            foreach (DataRow drTreat in dtTreat.Rows)
                            {


                                float pt_net = float.Parse(drTreat["pt_net"].ToString());
                                float pt_vat = float.Parse(drTreat["pt_vat"].ToString());
                                DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString());
                                y = y + 1;
                                string act_no = drTreat["ptId"].ToString();
                                int ActDetails = BusinessLogicLayer.EMR.PatientTreatments.InsertActivityDetails(int.Parse(drTreat["ptId"].ToString()), int.Parse(dr["appId"].ToString()), "Claims", act_no, PageControl.getLoggedinId(), pt_net, "Claims");

                                writer.WriteStartElement("Activity");
                                writer.WriteElementString("ID", act_no);
                                writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                                writer.WriteElementString("Type", drTreat["tr_itype"].ToString());
                                writer.WriteElementString("Code", drTreat["tr_code"].ToString());
                                writer.WriteElementString("Quantity", drTreat["pt_qty"].ToString());
                                if (ic_name == "'Cash'")
                                {
                                    writer.WriteElementString("Net", "0");
                                }
                                else
                                {
                                    writer.WriteElementString("Net", float.Parse(pt_net.ToString("0.00")).ToString());
                                }
                                writer.WriteElementString("OrderingClinician", drTreat["emp_license"].ToString());
                                writer.WriteElementString("Clinician", drTreat["emp_license"].ToString());
                                if (drTreat["pt_auth_code"].ToString() != "")
                                {
                                    if (drTreat["pt_auth_code"].ToString() != "Not Required")
                                    {
                                        writer.WriteElementString("PriorAuthorizationID", drTreat["pt_auth_code"].ToString());
                                    }
                                }
                                if (ic_name == "'Cash'")
                                {
                                    writer.WriteElementString("VAT", pt_vat.ToString("0.00"));
                                    if (pt_vat > 0)
                                    {
                                        writer.WriteElementString("VATPercent", "5");
                                    }
                                    else
                                    {
                                        writer.WriteElementString("VATPercent", "0");
                                    }
                                }

                                // LOINC CODES STARTS
                                if (drTreat["ti_loinc_1"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_1"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_2"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_3"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_4"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_4"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_5"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_6"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_7"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_7"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_8"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_9"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_10"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_10"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_11"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_12"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_13"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_13"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_14"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_15"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }

                                // LOINC CODES ENDS
                                if ((drTreat["tr_code"].ToString() == "9") || (drTreat["tr_code"].ToString() == "10") || (drTreat["tr_code"].ToString() == "11") || (drTreat["tr_code"].ToString() == "9.1") || (drTreat["tr_code"].ToString() == "10.1") || (drTreat["tr_code"].ToString() == "11.1"))
                                {
                                    if (drTreat["ti_lab_8"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BPS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_8"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_9"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BPD");
                                        writer.WriteElementString("Value", drTreat["ti_lab_9"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }

                                if (drTreat["tr_code"].ToString() == "82565")
                                {
                                    if (drTreat["ti_lab_7"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CR");
                                        writer.WriteElementString("Value", drTreat["ti_lab_7"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "82043")
                                {
                                    if (drTreat["ti_lab_6"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "UA");
                                        writer.WriteElementString("Value", drTreat["ti_lab_6"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "84478")
                                {
                                    if (drTreat["ti_lab_5"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TRIG");
                                        writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "83721")
                                {
                                    if (drTreat["ti_lab_4"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "LDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "83718")
                                {
                                    if (drTreat["ti_lab_3"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "HDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "82465")
                                {
                                    if (drTreat["ti_lab_2"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CHOL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "80061")
                                {
                                    if (drTreat["ti_image_7"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "NONHDL");
                                        writer.WriteElementString("Value", drTreat["ti_image_7"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "80061")
                                {
                                    if (drTreat["ti_lab_2"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CHOL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_3"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "HDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_4"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "LDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }

                                    if (drTreat["ti_lab_5"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TRIG");
                                        writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }

                                }
                                if (drTreat["tr_code"].ToString() == "83036")
                                {
                                    if (drTreat["ti_lab_1"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "A1c");
                                        writer.WriteElementString("Value", drTreat["ti_lab_1"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (diag__codes.Contains("E66.9") == true)
                                {
                                    if (drTreat["ti_lab_10"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BMI");
                                        writer.WriteElementString("Value", drTreat["ti_lab_10"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                                {
                                    if (drTreat["ti_lab_11"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "Albumin");
                                        writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                                {
                                    if (drTreat["ti_lab_11"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "Albumin");
                                        writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_12"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALP");
                                        writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_13"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALT");
                                        writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_14"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "AST");
                                        writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_8"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TotalBilirubin");
                                        writer.WriteElementString("Value", drTreat["ti_image_8"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_9"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "DirectBilirubin");
                                        writer.WriteElementString("Value", drTreat["ti_image_9"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_10"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TotalProtein");
                                        writer.WriteElementString("Value", drTreat["ti_image_10"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                                {
                                    if (drTreat["ti_lab_12"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALP");
                                        writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84460"))
                                {
                                    if (drTreat["ti_lab_13"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALT");
                                        writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84450"))
                                {
                                    if (drTreat["ti_lab_14"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "AST");
                                        writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                {
                                    if (drTreat["ti_lab_15"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "FBS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_15"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                {
                                    if (drTreat["ti_lab_16"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "RBS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_16"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["ti_lab_17"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "FCR");
                                    writer.WriteElementString("Value", drTreat["ti_lab_17"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }

                                // NEW CODES ENDS
                                if (drTreat["pt_notes"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "Description");
                                    writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["pt_teeth"].ToString() != "")
                                {
                                    if (drTreat["pt_teeth"].ToString() != "NA")
                                    {
                                        string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                        for (int j = 0; j < pt__teeth.Length; j++)
                                        {
                                            //MessageBox.Show(words[j]);
                                            if (pt__teeth[j].Trim() != "")
                                            {
                                                writer.WriteStartElement("Observation");
                                                writer.WriteElementString("Type", "Universal Dental");
                                                writer.WriteElementString("Code", pt__teeth[j].Trim());
                                                // End Observation element
                                                writer.WriteEndElement();
                                            }
                                        }
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "17999")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "Activity Description");
                                    writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["tr_code"].ToString() == "0232T")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "Activity Description");
                                    writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if ((drTreat["pt_notes"].ToString() != "") && (ic_name.Contains("MADALLAH") == true))
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "CLAIM-FORM-NUMBER");
                                    writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                    writer.WriteElementString("ValueType", "CLAIM-FORM-NUMBER");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_1"].ToString() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");

                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_1"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_2"].ToString() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");
                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_2"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();

                                }
                                if (drTreat["ti_image_3"].ToString() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");
                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_4"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_4"].ToString() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");
                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_4"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_5"].ToString() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");

                                    byte[] pdfByte = System.IO.File.ReadAllBytes(Server.MapPath("images/Treatment_Images/" + drTreat["ti_image_5"].ToString()));
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                DataTable dt_lab = new DataTable();
                                dt_lab = BusinessLogicLayer.EClaims.EClaims.GetLabResultsAppointmentID(int.Parse(drTreat["ptId"].ToString()));
                                foreach (DataRow dr_lab in dt_lab.Rows)
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", dr_lab["cll_code"].ToString());
                                    writer.WriteElementString("Value", drTreat["cll_result"].ToString());
                                    writer.WriteElementString("ValueType", dr_lab["cll_units"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                // End Activity element
                                writer.WriteEndElement();
                            }
                            // End Claim element
                            writer.WriteEndElement();
                        }
                        // End Claim Submission element
                        writer.WriteEndElement();
                        // End Document
                        writer.WriteEndDocument();
                        // string val= stringWriter.ToString();
                        writer.Flush();
                        writer.Close();
                        byte[] fileContent = null;
                        string fileName = Path.Combine(filename);
                        System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(fileName).Length;
                        fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();
                        return new FileContentResult(fileContent, "application/xml");

                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Please select Treatments" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult GenerateHAADSelectedXmlDirect(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    DateTime TransactionDate = DateTime.Now;
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    int val = 0;
                    DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                    dt = ds.Tables[0];
                    DataTable dt_signs = ds.Tables[0];
                    string ins_clinic_code = "";
                    string ic_name = "";
                    string filename = Server.MapPath("~/submissions/GeneratedXmls/HAAD/Direct/Sub_" + dt.Rows[0]["set_permit_no"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".xml").Replace(" ", ""); // Specify the output filename

                    StringWriter stringWriter = new StringWriter();
                    XmlTextWriter writer = new XmlTextWriter(stringWriter);
                    writer.Formatting = System.Xml.Formatting.Indented;
                    writer.WriteStartDocument();
                    // Start Claim.Submission element

                    if (dt_signs.Rows.Count > 0)
                    {
                        string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                        DataRow dr = dt.Rows[0];
                        writer.WriteStartElement("Claim.Submission");
                        writer.WriteAttributeString("xmlns:tns", "http://www.haad.ae/DataDictionary/CommonTypes");
                        writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                        writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "http://www.haad.ae/DataDictionary/CommonTypes/DataDictionary.xsd");

                        writer.WriteStartElement("Header");
                        // Write Header elements
                        writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                        if (ic_names == "'Cash (HAAD)'")
                        {
                            writer.WriteElementString("ReceiverID", "HAAD");
                        }
                        else
                        {
                            writer.WriteElementString("ReceiverID", ins_code);
                        }
                        writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        writer.WriteElementString("RecordCount", no_of_claims.ToString());
                        writer.WriteElementString("DispositionFlag", s_flag);
                        // End Header element
                        writer.WriteEndElement();
                        int x = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            x = x + 1;
                            float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            float inv_net_cash = float.Parse(row["inv_net"].ToString());
                            float inv_vat = float.Parse(row["inv_vat"].ToString());
                            //float inv_net = float.Parse(row["inv_net"].ToString());
                            float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                            float inv_copay = float.Parse(row["inv_copay"].ToString());
                            float inv_share = float.Parse(row["inv_share"].ToString());
                            float pat_share = 0;
                            if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                            {
                                pat_share = inv_tded + inv_copay + inv_share;
                            }
                            else
                            {
                                pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            }
                            float inv_total = inv_net + pat_share;
                            string ins_no = row["inv_pi_insno"].ToString();
                            string claim_no = row["inv_claimno"].ToString();
                            string policy_no = row["inv_pi_polocyno"].ToString();
                            string inv_no = row["inv_no"].ToString();
                            string pat_emirateid = row["pat_emirateid"].ToString();
                            ins_clinic_code = row["inv_ic_payercode"].ToString();

                            ic_name = row["inv_insurance_name"].ToString();
                            DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                            DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                            int d_ay = app__fdate.Day;
                            string d__ay = "";
                            if (d_ay < 10)
                            {
                                d__ay = "0" + d_ay.ToString();
                            }
                            else
                            {
                                d__ay = d_ay.ToString();
                            }

                            int m_onth = app__fdate.Month;
                            string m__onth = "";
                            if (m_onth < 10)
                            {
                                m__onth = "0" + m_onth.ToString();
                            }
                            else
                            {
                                m__onth = m_onth.ToString();
                            }
                            writer.WriteStartElement("Claim");
                            writer.WriteElementString("ID", inv_no);
                            string MemberID_ = "";
                            if (row["inv_insurance_name"].ToString() == "'Cash'")
                            {
                                MemberID_ = dr["set_permit_no"].ToString() + "#" + row["pat_code"].ToString();
                                writer.WriteElementString("MemberID", MemberID_);

                                // MEDICAL TOURISAM START HERE

                                if (row["pat_city"].ToString() == "Abu Dhabi")
                                {
                                    writer.WriteElementString("PayerID", "SelfPay");
                                }
                                else
                                {
                                    if (row["app_emergency"].ToString() == "YES")
                                    {
                                        writer.WriteElementString("PayerID", "SelfPay");
                                    }
                                    else
                                    {
                                        writer.WriteElementString("PayerID", "MedicalTourismSelfPay");
                                    }
                                }

                                // MEDICAL TOURISAM END HERE
                            }
                            else
                            {
                                writer.WriteElementString("MemberID", ins_no);
                                writer.WriteElementString("PayerID", ins_clinic_code);
                            }
                            writer.WriteElementString("ProviderID", dr["set_permit_no"].ToString());
                            if (claim_no != "")
                            {
                                writer.WriteElementString("ClaimNo", claim_no);
                                if (policy_no != "")
                                {
                                    writer.WriteElementString("InsurancePolicyNo", policy_no);
                                }
                            }
                            if (row["pat_emirateid"].ToString() == " ")
                            {
                                writer.WriteElementString("EmiratesIDNumber", "999-9999-9999999-9");
                            }
                            else
                            {
                                writer.WriteElementString("EmiratesIDNumber", pat_emirateid);
                            }
                            if (row["inv_insurance_name"].ToString() == "'Cash'")
                            {
                                writer.WriteElementString("Gross", inv_net_cash.ToString("0.00"));
                                writer.WriteElementString("PatientShare", inv_net_cash.ToString("0.00"));
                                writer.WriteElementString("Net", "0");
                                writer.WriteElementString("VAT", inv_vat.ToString("0.00"));
                            }
                            else
                            {
                                writer.WriteElementString("Gross", inv_total.ToString("0.00"));
                                writer.WriteElementString("PatientShare", pat_share.ToString("0.00"));
                                writer.WriteElementString("Net", inv_net.ToString("0.00"));
                            }
                            writer.WriteStartElement("Encounter");
                            writer.WriteElementString("FacilityID", dr["set_permit_no"].ToString());
                            writer.WriteElementString("Type", "1");
                            writer.WriteElementString("PatientID", row["pat_code"].ToString());
                            if (row["app_eligibility"].ToString() != "0")
                            {
                                writer.WriteElementString("EligibilityIDPayer", row["app_eligibility"].ToString());
                            }
                            writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                            writer.WriteElementString("End", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ttime"].ToString());
                            writer.WriteElementString("StartType", "1");
                            // End Encounter element
                            writer.WriteEndElement();

                            //Diagnosis Generation Starts Here.....
                            DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(dr["appId"].ToString()), 0);
                            int diag_count = 0;
                            string diag__codes = "";
                            foreach (DataRow drDiag in dtDiag.Rows)
                            {
                                diag_count = diag_count + 1;
                                writer.WriteStartElement("Diagnosis");
                                if (drDiag["pad_type"].ToString() == "Primary")
                                {
                                    writer.WriteElementString("Type", "Principal");
                                }
                                else if (drDiag["pad_type"].ToString() == "Secondary")
                                {
                                    writer.WriteElementString("Type", "Secondary");
                                }
                                else
                                {
                                    writer.WriteElementString("Type", "ReasonForVisit");
                                }
                                diag__codes = diag__codes + "," + drDiag["diag_code"].ToString();
                                writer.WriteElementString("Code", drDiag["Diag_Code"].ToString());
                                if (drDiag["pad_year"].ToString() != "0")
                                {
                                    writer.WriteStartElement("DxInfo");
                                    writer.WriteElementString("Type", "Year of Onset");
                                    writer.WriteElementString("Code", drDiag["pad_year"].ToString());
                                    writer.WriteEndElement();
                                }
                                writer.WriteEndElement();
                            }
                            //Diagnosis Generation Ends Here.....                           


                            DataTable dtTreat = new DataTable();
                            dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                            int y = 0;
                            // int z = 0;
                            foreach (DataRow drTreat in dtTreat.Rows)
                            {


                                float pt_net = float.Parse(drTreat["pt_net"].ToString());
                                float pt_vat = float.Parse(drTreat["pt_vat"].ToString());
                                DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString());
                                y = y + 1;
                                string act_no = drTreat["ptId"].ToString();
                                int ActDetails = BusinessLogicLayer.EMR.PatientTreatments.InsertActivityDetails(int.Parse(drTreat["ptId"].ToString()), int.Parse(dr["appId"].ToString()), "Claims", act_no, PageControl.getLoggedinId(), pt_net, "Claims");

                                writer.WriteStartElement("Activity");
                                writer.WriteElementString("ID", act_no);
                                writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                                writer.WriteElementString("Type", drTreat["tr_itype"].ToString());
                                writer.WriteElementString("Code", drTreat["tr_code"].ToString());
                                writer.WriteElementString("Quantity", drTreat["pt_qty"].ToString());
                                if (drTreat["ic_name"].ToString() == "'Cash'")
                                {
                                    writer.WriteElementString("Net", "0");
                                }
                                else
                                {
                                    writer.WriteElementString("Net", float.Parse(pt_net.ToString("0.00")).ToString());
                                }
                                if (dr["set_city"].ToString() == "HAAD")
                                {
                                    writer.WriteElementString("OrderingClinician", drTreat["emp_license"].ToString());
                                }
                                writer.WriteElementString("Clinician", drTreat["emp_license"].ToString());
                                if (drTreat["pt_auth_code"].ToString() != "")
                                {
                                    if (drTreat["pt_auth_code"].ToString() != "Not Required")
                                    {
                                        writer.WriteElementString("PriorAuthorizationID", drTreat["pt_auth_code"].ToString());
                                    }
                                }
                                if (drTreat["ic_name"].ToString() == "'Cash'")
                                {
                                    writer.WriteElementString("VAT", pt_vat.ToString("0.00"));
                                    if (pt_vat > 0)
                                    {
                                        writer.WriteElementString("VATPercent", "5");
                                    }
                                    else
                                    {
                                        writer.WriteElementString("VATPercent", "0");
                                    }
                                }


                                // LOINC CODES STARTS
                                if (drTreat["ti_loinc_1"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_1"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_2"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_3"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_4"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_4"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_5"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_6"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_7"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_7"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_8"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_9"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_10"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_10"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_11"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_12"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_loinc_13"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", drTreat["ti_loinc_13"].ToString());
                                    writer.WriteElementString("Value", drTreat["ti_loinc_14"].ToString());
                                    writer.WriteElementString("ValueType", drTreat["ti_loinc_15"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                // LOINC CODES ENDS
                                if ((drTreat["tr_code"].ToString() == "9") || (drTreat["tr_code"].ToString() == "10") || (drTreat["tr_code"].ToString() == "11") || (drTreat["tr_code"].ToString() == "9.1") || (drTreat["tr_code"].ToString() == "10.1") || (drTreat["tr_code"].ToString() == "11.1"))
                                {
                                    if (drTreat["ti_lab_8"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BPS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_8"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_9"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BPD");
                                        writer.WriteElementString("Value", drTreat["ti_lab_9"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "82565")
                                {
                                    if (drTreat["ti_lab_7"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CR");
                                        writer.WriteElementString("Value", drTreat["ti_lab_7"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "82043")
                                {
                                    if (drTreat["ti_lab_6"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "UA");
                                        writer.WriteElementString("Value", drTreat["ti_lab_6"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "84478")
                                {
                                    if (drTreat["ti_lab_5"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TRIG");
                                        writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "83721")
                                {
                                    if (drTreat["ti_lab_4"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "LDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "83718")
                                {
                                    if (drTreat["ti_lab_3"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "HDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "82465")
                                {
                                    if (drTreat["ti_lab_2"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CHOL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "80061")
                                {
                                    if (drTreat["ti_image_7"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "NONHDL");
                                        writer.WriteElementString("Value", drTreat["ti_image_7"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "80061")
                                {
                                    if (drTreat["ti_lab_2"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "CHOL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_3"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "HDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_4"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "LDL");
                                        writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }

                                    if (drTreat["ti_lab_5"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TRIG");
                                        writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }

                                }
                                if (drTreat["tr_code"].ToString() == "83036")
                                {
                                    if (drTreat["ti_lab_1"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "A1c");
                                        writer.WriteElementString("Value", drTreat["ti_lab_1"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (diag__codes.Contains("E66.9") == true)
                                {
                                    if (drTreat["ti_lab_10"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "BMI");
                                        writer.WriteElementString("Value", drTreat["ti_lab_10"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                                {
                                    if (drTreat["ti_lab_11"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "Albumin");
                                        writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                                {
                                    if (drTreat["ti_lab_11"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "Albumin");
                                        writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_12"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALP");
                                        writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_13"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALT");
                                        writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_lab_14"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "AST");
                                        writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_8"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TotalBilirubin");
                                        writer.WriteElementString("Value", drTreat["ti_image_8"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_9"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "DirectBilirubin");
                                        writer.WriteElementString("Value", drTreat["ti_image_9"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_10"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "TotalProtein");
                                        writer.WriteElementString("Value", drTreat["ti_image_10"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                                {
                                    if (drTreat["ti_lab_12"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALP");
                                        writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84460"))
                                {
                                    if (drTreat["ti_lab_13"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "ALT");
                                        writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84450"))
                                {
                                    if (drTreat["ti_lab_14"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "AST");
                                        writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                {
                                    if (drTreat["ti_lab_15"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "FBS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_15"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                {
                                    if (drTreat["ti_lab_16"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "RBS");
                                        writer.WriteElementString("Value", drTreat["ti_lab_16"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                }
                                if (drTreat["ti_lab_17"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "FCR");
                                    writer.WriteElementString("Value", drTreat["ti_lab_17"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }

                                // NEW CODES ENDS
                                if (drTreat["pt_notes"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "Description");
                                    writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["pt_teeth"].ToString() != "")
                                {
                                    if (drTreat["pt_teeth"].ToString() != "NA")
                                    {
                                        string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                        for (int j = 0; j < pt__teeth.Length; j++)
                                        {
                                            //MessageBox.Show(words[j]);
                                            if (pt__teeth[j].Trim() != "")
                                            {
                                                writer.WriteStartElement("Observation");
                                                writer.WriteElementString("Type", "Universal Dental");
                                                writer.WriteElementString("Code", pt__teeth[j].Trim());
                                                // End Observation element
                                                writer.WriteEndElement();
                                            }
                                        }
                                    }
                                }
                                if (drTreat["tr_code"].ToString() == "17999")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "Activity Description");
                                    writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["tr_code"].ToString() == "0232T")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "Activity Description");
                                    writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if ((drTreat["pt_notes"].ToString() != "") && (ic_name.Contains("MADALLAH") == true))
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "CLAIM-FORM-NUMBER");
                                    writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                    writer.WriteElementString("ValueType", "CLAIM-FORM-NUMBER");
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_1"].ToString() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");
                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_1"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_2"].ToString() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");
                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_2"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();

                                }
                                if (drTreat["ti_image_3"].ToString() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");
                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_3"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_4"].ToString() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");
                                    string path = "";
                                    path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                    string file_path = Path.Combine(path, drTreat["ti_image_4"].ToString());
                                    byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_5"].ToString() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "File");
                                    writer.WriteElementString("Code", "PDF");

                                    byte[] pdfByte = System.IO.File.ReadAllBytes(Server.MapPath("images/Treatment_Images/" + drTreat["ti_image_5"].ToString()));
                                    string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                    writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                    writer.WriteElementString("ValueType", "PDF File");
                                    writer.WriteEndElement();
                                }
                                DataTable dt_lab = new DataTable();
                                dt_lab = BusinessLogicLayer.EClaims.EClaims.GetLabResultsAppointmentID(int.Parse(drTreat["ptId"].ToString()));
                                foreach (DataRow dr_lab in dt_lab.Rows)
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "LOINC");
                                    writer.WriteElementString("Code", dr_lab["cll_code"].ToString());
                                    writer.WriteElementString("Value", drTreat["cll_result"].ToString());
                                    writer.WriteElementString("ValueType", dr_lab["cll_units"].ToString());
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                // End Activity element
                                writer.WriteEndElement();
                            }
                            // End Claim element
                            writer.WriteEndElement();
                        }
                        // End Claim Submission element
                        writer.WriteEndElement();
                        // End Document
                        writer.WriteEndDocument();
                        // string val= stringWriter.ToString();
                        writer.Flush();
                        writer.Close();
                        //string file_name = dr["set_permit_no"].ToString() + "_" + s_date_from.ToString("ddMMyyyy") + "_" + s_date_to.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xml";
                        string file_name = dr["set_permit_no"].ToString() + "_" + s_ic_id + "_" + s_date_from.ToString("ddMMyyyy") + "_" + s_date_to.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xml";

                        string eClaim_ErrorMessage = "";

                        byte[] eClaim_ErrorReport = new byte[99];

                        string eClaim_TransactionId = "";
                        ae.gov.doh.shafafiya.Webservices e_Claim = new ae.gov.doh.shafafiya.Webservices();
                        e_Claim.UploadTransaction(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), Encoding.UTF8.GetBytes(stringWriter.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"")), file_name, out eClaim_ErrorMessage, out eClaim_ErrorReport, out eClaim_TransactionId);


                        TempData["ErrorMessage"] = eClaim_ErrorMessage;
                        string atr = "";
                        if (eClaim_ErrorMessage.Contains("successful") == false)
                        {
                            if (eClaim_ErrorMessage.Contains("invalid") == false)
                            {
                                if (eClaim_ErrorMessage.Contains("input") == false)
                                {
                                    string fileName = "~/submissions/HAAD/Error/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls".Replace(" ", "");
                                    using (FileStream destFile = System.IO.File.Open(Server.MapPath(fileName), FileMode.Create))
                                    {
                                        destFile.Write(eClaim_ErrorReport, 0, eClaim_ErrorReport.Length);
                                    }

                                    string atr1 = "Error Msg: " + eClaim_ErrorMessage + " Error Report <a href='/submissions/HAAD/Error/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls' class='fs-25 text-primary font-weight-bold text-center'><i class='fa fa-file-archive-o text-white'></i ></a>";
                                    atr = HttpUtility.HtmlDecode(atr1);
                                }
                                else
                                {
                                    atr = "Error Msg: " + eClaim_ErrorMessage;
                                }
                            }
                            else
                            {
                                atr = "Error Msg: " + eClaim_ErrorMessage;
                            }
                        }
                        else
                        {
                            int eclId = 0;
                            string xmlString = writer.ToString();
                            string FolderPath = Server.MapPath("~/submissions/GeneratedXmls/HAAD/Direct/Sub_" + file_name);
                            eclId = BusinessLogicLayer.EClaims.EClaims.eClaim_Insert(s_ic_id, s_date_from, s_date_to, file_name, FolderPath, eClaim_ErrorMessage);

                            int uinv_id = 0;
                            if (s_flag == "PRODUCTION")
                            {
                                SqlCommand cmd_insert = new SqlCommand();
                                uinv_id = BusinessLogicLayer.EClaims.EClaims.SP_UpdateInvoiceStatus(inv_ids);
                            }
                            String contents = writer.ToString();

                            // Get the length of the contents
                            int length = contents.Length;
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + file_name);
                            Response.AppendHeader("Content-Length", length.ToString());
                            Response.ContentType = "text/xml";
                            Response.Write(contents.ToString());
                            Response.End();
                        }
                        return Json(atr, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Please select Treatments" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult GenerateHAADFullXmlManual(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    DateTime TransactionDate = DateTime.Now;
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                    DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                    dt = ds.Tables[0];
                    //dt = dt_Inv;
                    DataTable dt_signs = ds.Tables[0];
                    string ins_clinic_code = "";
                    string ic_name = "";
                    string filename = Server.MapPath("~/submissions/GeneratedXmls/HAAD/Manual/Sub_" + dt.Rows[0]["set_permit_no"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + ".xml").Replace(" ", ""); // Specify the output filename
                    //StringWriter stringWriter = new StringWriter();
                    XmlTextWriter writer = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                    //XmlTextWriter writer = new XmlTextWriter(System.Text.Encoding.UTF8);
                    writer.Formatting = System.Xml.Formatting.Indented;
                    writer.WriteStartDocument();
                    // Start Claim.Submission element

                    DataRow dr = dt.Rows[0];
                    writer.WriteStartElement("Claim.Submission");
                    writer.WriteAttributeString("xmlns:tns", "http://www.haad.ae/DataDictionary/CommonTypes");
                    writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                    writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "http://www.haad.ae/DataDictionary/CommonTypes/DataDictionary.xsd");

                    writer.WriteStartElement("Header");
                    // Write Header elements
                    writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                    if (ic_names == "'Cash (HAAD)'")
                    {
                        writer.WriteElementString("ReceiverID", "HAAD");
                    }
                    else
                    {
                        writer.WriteElementString("ReceiverID", ins_code);
                    }
                    writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    writer.WriteElementString("RecordCount", no_of_claims.ToString());
                    writer.WriteElementString("DispositionFlag", s_flag);
                    // End Header element
                    writer.WriteEndElement();
                    int x = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        x = x + 1;
                        float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        float inv_net_cash = float.Parse(row["inv_net"].ToString());
                        float inv_vat = float.Parse(row["inv_vat"].ToString());
                        //float inv_net = float.Parse(row["inv_net"].ToString());
                        float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                        float inv_copay = float.Parse(row["inv_copay"].ToString());
                        float inv_share = float.Parse(row["inv_share"].ToString());
                        float pat_share = 0;
                        if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                        {
                            pat_share = inv_tded + inv_copay + inv_share;
                        }
                        else
                        {
                            pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        }
                        float inv_total = inv_net + pat_share;
                        string ins_no = row["inv_pi_insno"].ToString();
                        string claim_no = row["inv_claimno"].ToString();
                        string policy_no = row["inv_pi_polocyno"].ToString();
                        string inv_no = row["inv_no"].ToString();
                        string pat_emirateid = row["pat_emirateid"].ToString();
                        ins_clinic_code = row["inv_ic_payercode"].ToString();

                        ic_name = row["inv_insurance_name"].ToString();
                        DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                        DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                        int d_ay = app__fdate.Day;
                        string d__ay = "";
                        if (d_ay < 10)
                        {
                            d__ay = "0" + d_ay.ToString();
                        }
                        else
                        {
                            d__ay = d_ay.ToString();
                        }

                        int m_onth = app__fdate.Month;
                        string m__onth = "";
                        if (m_onth < 10)
                        {
                            m__onth = "0" + m_onth.ToString();
                        }
                        else
                        {
                            m__onth = m_onth.ToString();
                        }
                        writer.WriteStartElement("Claim");
                        writer.WriteElementString("ID", inv_no);
                        string MemberID_ = "";
                        if (ic_name == "'Cash'")
                        {
                            MemberID_ = dr["set_permit_no"].ToString() + "#" + row["pat_code"].ToString();
                            writer.WriteElementString("MemberID", MemberID_);

                            // MEDICAL TOURISAM START HERE

                            if (row["pat_city"].ToString() == "Abu Dhabi")
                            {
                                writer.WriteElementString("PayerID", "SelfPay");
                            }
                            else
                            {
                                if (row["app_emergency"].ToString() == "YES")
                                {
                                    writer.WriteElementString("PayerID", "SelfPay");
                                }
                                else
                                {
                                    writer.WriteElementString("PayerID", "MedicalTourismSelfPay");
                                }
                            }

                            // MEDICAL TOURISAM END HERE
                        }
                        else
                        {
                            writer.WriteElementString("MemberID", ins_no);
                            writer.WriteElementString("PayerID", ins_clinic_code);
                        }
                        writer.WriteElementString("ProviderID", dr["set_permit_no"].ToString());
                        if (claim_no != "")
                        {
                            writer.WriteElementString("ClaimNo", claim_no);
                            if (policy_no != "")
                            {
                                writer.WriteElementString("InsurancePolicyNo", policy_no);
                            }
                        }
                        if (row["pat_emirateid"].ToString() == " ")
                        {
                            writer.WriteElementString("EmiratesIDNumber", "999-9999-9999999-9");
                        }
                        else
                        {
                            writer.WriteElementString("EmiratesIDNumber", pat_emirateid);
                        }
                        if (ic_name == "'Cash'")
                        {
                            writer.WriteElementString("Gross", inv_net_cash.ToString("0.00"));
                            writer.WriteElementString("PatientShare", inv_net_cash.ToString("0.00"));
                            writer.WriteElementString("Net", "0");
                            writer.WriteElementString("VAT", inv_vat.ToString("0.00"));
                        }
                        else
                        {
                            writer.WriteElementString("Gross", inv_total.ToString("0.00"));
                            writer.WriteElementString("PatientShare", pat_share.ToString("0.00"));
                            writer.WriteElementString("Net", inv_net.ToString("0.00"));
                        }
                        writer.WriteStartElement("Encounter");
                        writer.WriteElementString("FacilityID", dr["set_permit_no"].ToString());
                        writer.WriteElementString("Type", "1");
                        writer.WriteElementString("PatientID", row["pat_code"].ToString());
                        if (row["app_eligibility"].ToString() != "0")
                        {
                            writer.WriteElementString("EligibilityIDPayer", row["app_eligibility"].ToString());
                        }
                        writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                        writer.WriteElementString("End", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ttime"].ToString());
                        writer.WriteElementString("StartType", "1");
                        // End Encounter element
                        writer.WriteEndElement();

                        //Diagnosis Generation Starts Here.....
                        DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(dr["appId"].ToString()), 0);
                        int diag_count = 0;
                        string diag__codes = "";
                        foreach (DataRow drDiag in dtDiag.Rows)
                        {
                            diag_count = diag_count + 1;
                            writer.WriteStartElement("Diagnosis");
                            if (drDiag["pad_type"].ToString() == "Primary")
                            {
                                writer.WriteElementString("Type", "Principal");
                            }
                            else if (drDiag["pad_type"].ToString() == "Secondary")
                            {
                                writer.WriteElementString("Type", "Secondary");
                            }
                            else
                            {
                                writer.WriteElementString("Type", "ReasonForVisit");
                            }
                            diag__codes = diag__codes + "," + drDiag["diag_code"].ToString();
                            writer.WriteElementString("Code", drDiag["Diag_Code"].ToString());
                            if (drDiag["pad_year"].ToString() != "0")
                            {
                                writer.WriteStartElement("DxInfo");
                                writer.WriteElementString("Type", "Year of Onset");
                                writer.WriteElementString("Code", drDiag["pad_year"].ToString());
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            // End Diagnosis element
                        }
                        //Diagnosis Generation Ends Here.....                           


                        DataTable dtTreat = new DataTable();
                        dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        int y = 0;
                        // int z = 0;
                        foreach (DataRow drTreat in dtTreat.Rows)
                        {


                            float pt_net = float.Parse(drTreat["pt_net"].ToString());
                            float pt_vat = float.Parse(drTreat["pt_vat"].ToString());
                            DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString());
                            y = y + 1;
                            string act_no = drTreat["ptId"].ToString();
                            int ActDetails = BusinessLogicLayer.EMR.PatientTreatments.InsertActivityDetails(int.Parse(drTreat["ptId"].ToString()), int.Parse(dr["appId"].ToString()), "Claims", act_no, PageControl.getLoggedinId(), pt_net, "Claims");

                            writer.WriteStartElement("Activity");
                            writer.WriteElementString("ID", act_no);
                            writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                            writer.WriteElementString("Type", drTreat["tr_itype"].ToString());
                            writer.WriteElementString("Code", drTreat["tr_code"].ToString());
                            writer.WriteElementString("Quantity", drTreat["pt_qty"].ToString());
                            if (ic_name == "'Cash'")
                            {
                                writer.WriteElementString("Net", "0");
                            }
                            else
                            {
                                writer.WriteElementString("Net", float.Parse(pt_net.ToString("0.00")).ToString());
                            }
                            writer.WriteElementString("OrderingClinician", drTreat["emp_license"].ToString());
                            writer.WriteElementString("Clinician", drTreat["emp_license"].ToString());
                            if (drTreat["pt_auth_code"].ToString() != "")
                            {
                                if (drTreat["pt_auth_code"].ToString() != "Not Required")
                                {
                                    writer.WriteElementString("PriorAuthorizationID", drTreat["pt_auth_code"].ToString());
                                }
                            }
                            if (ic_name == "'Cash'")
                            {
                                writer.WriteElementString("VAT", pt_vat.ToString("0.00"));
                                if (pt_vat > 0)
                                {
                                    writer.WriteElementString("VATPercent", "5");
                                }
                                else
                                {
                                    writer.WriteElementString("VATPercent", "0");
                                }
                            }


                            // LOINC CODES STARTS
                            if (drTreat["ti_loinc_1"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", drTreat["ti_loinc_1"].ToString());
                                writer.WriteElementString("Value", drTreat["ti_loinc_2"].ToString());
                                writer.WriteElementString("ValueType", drTreat["ti_loinc_3"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_loinc_4"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", drTreat["ti_loinc_4"].ToString());
                                writer.WriteElementString("Value", drTreat["ti_loinc_5"].ToString());
                                writer.WriteElementString("ValueType", drTreat["ti_loinc_6"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_loinc_7"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", drTreat["ti_loinc_7"].ToString());
                                writer.WriteElementString("Value", drTreat["ti_loinc_8"].ToString());
                                writer.WriteElementString("ValueType", drTreat["ti_loinc_9"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_loinc_10"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", drTreat["ti_loinc_10"].ToString());
                                writer.WriteElementString("Value", drTreat["ti_loinc_11"].ToString());
                                writer.WriteElementString("ValueType", drTreat["ti_loinc_12"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_loinc_13"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", drTreat["ti_loinc_13"].ToString());
                                writer.WriteElementString("Value", drTreat["ti_loinc_14"].ToString());
                                writer.WriteElementString("ValueType", drTreat["ti_loinc_15"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            // LOINC CODES ENDS
                            if ((drTreat["tr_code"].ToString() == "9") || (drTreat["tr_code"].ToString() == "10") || (drTreat["tr_code"].ToString() == "11") || (drTreat["tr_code"].ToString() == "9.1") || (drTreat["tr_code"].ToString() == "10.1") || (drTreat["tr_code"].ToString() == "11.1"))
                            {
                                if (drTreat["ti_lab_8"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "BPS");
                                    writer.WriteElementString("Value", drTreat["ti_lab_8"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_9"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "BPD");
                                    writer.WriteElementString("Value", drTreat["ti_lab_9"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "82565")
                            {
                                if (drTreat["ti_lab_7"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "CR");
                                    writer.WriteElementString("Value", drTreat["ti_lab_7"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "82043")
                            {
                                if (drTreat["ti_lab_6"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "UA");
                                    writer.WriteElementString("Value", drTreat["ti_lab_6"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "84478")
                            {
                                if (drTreat["ti_lab_5"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "TRIG");
                                    writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "83721")
                            {
                                if (drTreat["ti_lab_4"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "LDL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "83718")
                            {
                                if (drTreat["ti_lab_3"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "HDL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "82465")
                            {
                                if (drTreat["ti_lab_2"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "CHOL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "80061")
                            {
                                if (drTreat["ti_image_7"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "NONHDL");
                                    writer.WriteElementString("Value", drTreat["ti_image_7"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "80061")
                            {
                                if (drTreat["ti_lab_2"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "CHOL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_3"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "HDL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_4"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "LDL");
                                    writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }

                                if (drTreat["ti_lab_5"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "TRIG");
                                    writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }

                            }
                            if (drTreat["tr_code"].ToString() == "83036")
                            {
                                if (drTreat["ti_lab_1"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "A1c");
                                    writer.WriteElementString("Value", drTreat["ti_lab_1"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (diag__codes.Contains("E66.9") == true)
                            {
                                if (drTreat["ti_lab_10"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "BMI");
                                    writer.WriteElementString("Value", drTreat["ti_lab_10"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                            {
                                if (drTreat["ti_lab_11"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "Albumin");
                                    writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                            {
                                if (drTreat["ti_lab_11"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "Albumin");
                                    writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_12"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "ALP");
                                    writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_13"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "ALT");
                                    writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_lab_14"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "AST");
                                    writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_8"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "TotalBilirubin");
                                    writer.WriteElementString("Value", drTreat["ti_image_8"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_9"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "DirectBilirubin");
                                    writer.WriteElementString("Value", drTreat["ti_image_9"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                                if (drTreat["ti_image_10"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "TotalProtein");
                                    writer.WriteElementString("Value", drTreat["ti_image_10"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                            {
                                if (drTreat["ti_lab_12"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "ALP");
                                    writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84460"))
                            {
                                if (drTreat["ti_lab_13"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "ALT");
                                    writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84450"))
                            {
                                if (drTreat["ti_lab_14"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "AST");
                                    writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                            {
                                if (drTreat["ti_lab_15"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "FBS");
                                    writer.WriteElementString("Value", drTreat["ti_lab_15"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                            {
                                if (drTreat["ti_lab_16"].ToString() != "")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Result");
                                    writer.WriteElementString("Code", "RBS");
                                    writer.WriteElementString("Value", drTreat["ti_lab_16"].ToString());
                                    writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                    // End Observation element
                                    writer.WriteEndElement();
                                }
                            }
                            if (drTreat["ti_lab_17"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Result");
                                writer.WriteElementString("Code", "FCR");
                                writer.WriteElementString("Value", drTreat["ti_lab_17"].ToString());
                                writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                // End Observation element
                                writer.WriteEndElement();
                            }

                            // NEW CODES ENDS

                            if (drTreat["tr_code"].ToString() == "17999")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "Activity Description");
                                writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                writer.WriteElementString("ValueType", "Text");
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["tr_code"].ToString() == "0232T")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "Activity Description");
                                writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                writer.WriteElementString("ValueType", "Text");
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["pt_notes"].ToString() != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "Description");
                                writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["pt_teeth"].ToString() != "")
                            {
                                if (drTreat["pt_teeth"].ToString() != "NA")
                                {
                                    string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                    for (int j = 0; j < pt__teeth.Length; j++)
                                    {
                                        //MessageBox.Show(words[j]);
                                        if (pt__teeth[j].Trim() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Universal Dental");
                                            writer.WriteElementString("Code", pt__teeth[j].Trim());
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                }
                            }
                            if (claim_no != "")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "CLAIM-FORM-NUMBER");
                                writer.WriteElementString("Value", claim_no);
                                writer.WriteElementString("ValueType", "CLAIM-FORM-NUMBER");
                                // End Observation element
                                writer.WriteEndElement();
                            }

                            if ((drTreat["pt_notes"].ToString() != "") && (ic_name.Contains("MADALLAH") == true))
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", "CLAIM-FORM-NUMBER");
                                writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                writer.WriteElementString("ValueType", "CLAIM-FORM-NUMBER");
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_1"].ToString() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");
                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_1"].ToString());
                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_2"].ToString() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");
                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_2"].ToString());
                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();

                            }
                            if (drTreat["ti_image_3"].ToString() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");
                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_3"].ToString());
                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_4"].ToString() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");
                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_4"].ToString());
                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_5"].ToString() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");
                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_5"].ToString());
                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            DataTable dt_lab = new DataTable();
                            dt_lab = BusinessLogicLayer.EClaims.EClaims.GetLabResultsAppointmentID(int.Parse(drTreat["ptId"].ToString()));
                            foreach (DataRow dr_lab in dt_lab.Rows)
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "LOINC");
                                writer.WriteElementString("Code", dr_lab["cll_code"].ToString());
                                writer.WriteElementString("Value", drTreat["cll_result"].ToString());
                                writer.WriteElementString("ValueType", dr_lab["cll_units"].ToString());
                                // End Observation element
                                writer.WriteEndElement();
                            }
                            // End Activity element
                            writer.WriteEndElement();
                        }
                        // End Claim element
                        writer.WriteEndElement();
                    }
                    // End Claim Submission element
                    writer.WriteEndElement();
                    // End Document
                    writer.WriteEndDocument();
                    // string val= stringWriter.ToString();
                    writer.Flush();
                    writer.Close();
                    byte[] fileContent = null;
                    string fileName = Path.Combine(filename);
                    System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                    long byteLength = new System.IO.FileInfo(fileName).Length;
                    fileContent = binaryReader.ReadBytes((Int32)byteLength);
                    fs.Close();
                    fs.Dispose();
                    binaryReader.Close();
                    return new FileContentResult(fileContent, "application/xml");

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
        public ActionResult GenerateHAADFullXmlDirect(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    DateTime TransactionDate = DateTime.Now;
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                    dt = ds.Tables[0];
                    //dt = dt_Inv;
                    DataTable dt_signs = ds.Tables[0];
                    string ins_clinic_code = "";
                    string ic_name = "";
                    string filename = Server.MapPath("~/submissions/GeneratedXmls/HAAD/Direct/Sub_" + dt.Rows[0]["set_permit_no"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".xml").Replace(" ", ""); // Specify the output filename

                    StringWriter stringWriter = new StringWriter();
                    XmlTextWriter writer = new XmlTextWriter(stringWriter);
                    writer.Formatting = System.Xml.Formatting.Indented;
                    writer.WriteStartDocument();
                    // Start Claim.Submission element
                    if (BusinessLogicLayer.EClaims.EClaims.Check_Already_Submitted(s_ic_id, DateTime.Parse(s_date_from.ToString("MM/dd/yyyy")), DateTime.Parse(s_date_to.ToString("MM/dd/yyyy"))) == false)
                    {
                        if (dt_signs.Rows.Count > 0)
                        {
                            string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                            DataRow dr = dt.Rows[0];
                            writer.WriteStartElement("Claim.Submission");
                            writer.WriteAttributeString("xmlns:tns", "http://www.haad.ae/DataDictionary/CommonTypes");
                            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                            writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "http://www.haad.ae/DataDictionary/CommonTypes/DataDictionary.xsd");

                            writer.WriteStartElement("Header");
                            // Write Header elements
                            writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                            writer.WriteElementString("ReceiverID", ins_code);
                            writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                            writer.WriteElementString("RecordCount", no_of_claims.ToString());
                            writer.WriteElementString("DispositionFlag", s_flag);
                            // End Header element
                            writer.WriteEndElement();
                            int x = 0;
                            foreach (DataRow row in dt.Rows)
                            {
                                x = x + 1;
                                float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                                float inv_net_cash = float.Parse(row["inv_net"].ToString());
                                float inv_vat = float.Parse(row["inv_vat"].ToString());
                                //float inv_net = float.Parse(row["inv_net"].ToString());
                                float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                                float inv_copay = float.Parse(row["inv_copay"].ToString());
                                float inv_share = float.Parse(row["inv_share"].ToString());
                                float pat_share = 0;
                                if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                                {
                                    pat_share = inv_tded + inv_copay + inv_share;
                                }
                                else
                                {
                                    pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                                }
                                float inv_total = inv_net + pat_share;
                                string ins_no = row["inv_pi_insno"].ToString();
                                string claim_no = row["inv_claimno"].ToString();
                                string policy_no = row["inv_pi_polocyno"].ToString();
                                string inv_no = row["inv_no"].ToString();
                                string pat_emirateid = row["pat_emirateid"].ToString();
                                ins_clinic_code = row["inv_ic_payercode"].ToString();

                                ic_name = row["inv_insurance_name"].ToString();
                                DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                                DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                                int d_ay = app__fdate.Day;
                                string d__ay = "";
                                if (d_ay < 10)
                                {
                                    d__ay = "0" + d_ay.ToString();
                                }
                                else
                                {
                                    d__ay = d_ay.ToString();
                                }

                                int m_onth = app__fdate.Month;
                                string m__onth = "";
                                if (m_onth < 10)
                                {
                                    m__onth = "0" + m_onth.ToString();
                                }
                                else
                                {
                                    m__onth = m_onth.ToString();
                                }
                                writer.WriteStartElement("Claim");
                                writer.WriteElementString("ID", inv_no);
                                writer.WriteElementString("MemberID", ins_no);
                                writer.WriteElementString("PayerID", ins_clinic_code);
                                writer.WriteElementString("ProviderID", dr["set_permit_no"].ToString());
                                if (claim_no != "")
                                {
                                    writer.WriteElementString("ClaimNo", claim_no);
                                    if (policy_no != "")
                                    {
                                        writer.WriteElementString("InsurancePolicyNo", policy_no);
                                    }
                                }
                                if (row["pat_emirateid"].ToString() == " ")
                                {
                                    writer.WriteElementString("EmiratesIDNumber", "999-9999-9999999-9");
                                }
                                else
                                {
                                    writer.WriteElementString("EmiratesIDNumber", pat_emirateid);
                                }
                                writer.WriteElementString("Gross", inv_total.ToString("0.00"));
                                writer.WriteElementString("PatientShare", pat_share.ToString("0.00"));
                                writer.WriteElementString("Net", inv_net.ToString("0.00"));

                                writer.WriteStartElement("Encounter");
                                writer.WriteElementString("FacilityID", dr["set_permit_no"].ToString());
                                writer.WriteElementString("Type", "1");
                                writer.WriteElementString("PatientID", row["pat_code"].ToString());
                                if (row["app_eligibility"].ToString() != "0")
                                {
                                    writer.WriteElementString("EligibilityIDPayer", row["app_eligibility"].ToString());
                                }
                                writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                                writer.WriteElementString("End", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ttime"].ToString());
                                writer.WriteElementString("StartType", "1");
                                // End Encounter element
                                writer.WriteEndElement();

                                //Diagnosis Generation Starts Here.....
                                DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(dr["appId"].ToString()), 0);
                                int diag_count = 0;
                                string diag__codes = "";
                                foreach (DataRow drDiag in dtDiag.Rows)
                                {
                                    diag_count = diag_count + 1;
                                    writer.WriteStartElement("Diagnosis");
                                    if (drDiag["pad_type"].ToString() == "Primary")
                                    {
                                        writer.WriteElementString("Type", "Principal");
                                    }
                                    else if (drDiag["pad_type"].ToString() == "Secondary")
                                    {
                                        writer.WriteElementString("Type", "Secondary");
                                    }
                                    else
                                    {
                                        writer.WriteElementString("Type", "ReasonForVisit");
                                    }
                                    diag__codes = diag__codes + "," + drDiag["diag_code"].ToString();
                                    writer.WriteElementString("Code", drDiag["Diag_Code"].ToString());
                                    if (drDiag["pad_year"].ToString() != "0")
                                    {
                                        writer.WriteStartElement("DxInfo");
                                        writer.WriteElementString("Type", "Year of Onset");
                                        writer.WriteElementString("Code", drDiag["pad_year"].ToString());
                                        writer.WriteEndElement();
                                    }
                                    writer.WriteEndElement();
                                }
                                //Diagnosis Generation Ends Here.....                           


                                DataTable dtTreat = new DataTable();
                                dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                                int y = 0;
                                // int z = 0;
                                foreach (DataRow drTreat in dtTreat.Rows)
                                {


                                    float pt_net = float.Parse(drTreat["pt_net"].ToString());
                                    float pt_vat = float.Parse(drTreat["pt_vat"].ToString());
                                    DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString());
                                    y = y + 1;
                                    string act_no = drTreat["ptId"].ToString();
                                    int ActDetails = BusinessLogicLayer.EMR.PatientTreatments.InsertActivityDetails(int.Parse(drTreat["ptId"].ToString()), int.Parse(dr["appId"].ToString()), "Claims", act_no, PageControl.getLoggedinId(), pt_net, "Claims");

                                    writer.WriteStartElement("Activity");
                                    writer.WriteElementString("ID", act_no);
                                    writer.WriteElementString("Start", DateTime.Parse(row["app_fdate"].ToString()).ToString("dd/MM/yyyy") + " " + row["app_doc_ftime"].ToString());
                                    writer.WriteElementString("Type", drTreat["tr_itype"].ToString());
                                    writer.WriteElementString("Code", drTreat["tr_code"].ToString());
                                    writer.WriteElementString("Quantity", drTreat["pt_qty"].ToString());
                                    writer.WriteElementString("Net", float.Parse(pt_net.ToString("0.00")).ToString());
                                    writer.WriteElementString("Clinician", drTreat["emp_license"].ToString());
                                    if (drTreat["pt_auth_code"].ToString() != "")
                                    {
                                        if (drTreat["pt_auth_code"].ToString() != "Not Required")
                                        {
                                            writer.WriteElementString("PriorAuthorizationID", drTreat["pt_auth_code"].ToString());
                                        }
                                    }
                                    if (drTreat["ic_name"].ToString() == "'Cash'")
                                    {
                                        writer.WriteElementString("VAT", pt_vat.ToString("0.00"));
                                        if (pt_vat > 0)
                                        {
                                            writer.WriteElementString("VATPercent", "5");
                                        }
                                        else
                                        {
                                            writer.WriteElementString("VATPercent", "0");
                                        }
                                    }

                                    DataTable dtTreat2 = new DataTable();
                                    dtTreat2 = BusinessLogicLayer.EClaims.EClaims.GetPrescriptions(int.Parse(dr["appId"].ToString()));
                                    foreach (DataRow dtpresc in dtTreat2.Rows)
                                    {
                                        if (dtpresc["pre_eRxRefNo"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "ERX");
                                            writer.WriteElementString("Code", dtpresc["pre_eRxRefNo"].ToString());
                                            writer.WriteElementString("Value", dtpresc["preId"].ToString());
                                            writer.WriteElementString("ValueType", "Reference");
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "InvoiceNumber");
                                    writer.WriteElementString("Value", row["inv_no"].ToString());
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();

                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Text");
                                    writer.WriteElementString("Code", "InvoiceDate");
                                    writer.WriteElementString("Value", DateTime.Parse(row["inv_date"].ToString()).ToString("dd-MM-yyyy"));
                                    writer.WriteElementString("ValueType", "Text");
                                    // End Observation element
                                    writer.WriteEndElement();

                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Financial");
                                    writer.WriteElementString("Code", "ActivityGross");
                                    writer.WriteElementString("Value", (float.Parse(drTreat["pt_total"].ToString()) - float.Parse(drTreat["pt_disc"].ToString())).ToString("0.00"));
                                    writer.WriteElementString("ValueType", "Float");
                                    // End Observation element
                                    writer.WriteEndElement();

                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Financial");
                                    writer.WriteElementString("Code", "PSDeductible");
                                    writer.WriteElementString("Value", (float.Parse(drTreat["pt_ded"].ToString()) + float.Parse(drTreat["pt_dded"].ToString()) + float.Parse(drTreat["pt_rded"].ToString()) + float.Parse(drTreat["pt_mded"].ToString()) + float.Parse(drTreat["pt_lded"].ToString())).ToString("0.00"));
                                    writer.WriteElementString("ValueType", "Float");
                                    // End Observation element
                                    writer.WriteEndElement();


                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Financial");
                                    writer.WriteElementString("Code", "PSCoPayment");
                                    writer.WriteElementString("Value", (float.Parse(drTreat["pt_copay"].ToString()) + float.Parse(drTreat["pt_dcopay"].ToString())).ToString("0.00"));
                                    writer.WriteElementString("ValueType", "Float");
                                    // End Observation element
                                    writer.WriteEndElement();

                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Financial");
                                    writer.WriteElementString("Code", "PSOutOfPocket");
                                    writer.WriteElementString("Value", "0.00");
                                    writer.WriteElementString("ValueType", "Float");
                                    // End Observation element
                                    writer.WriteEndElement();
                                    // LOINC CODES STARTS
                                    if (drTreat["ti_loinc_1"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", drTreat["ti_loinc_1"].ToString());
                                        writer.WriteElementString("Value", drTreat["ti_loinc_2"].ToString());
                                        writer.WriteElementString("ValueType", drTreat["ti_loinc_3"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_loinc_4"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", drTreat["ti_loinc_4"].ToString());
                                        writer.WriteElementString("Value", drTreat["ti_loinc_5"].ToString());
                                        writer.WriteElementString("ValueType", drTreat["ti_loinc_6"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_loinc_7"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", drTreat["ti_loinc_7"].ToString());
                                        writer.WriteElementString("Value", drTreat["ti_loinc_8"].ToString());
                                        writer.WriteElementString("ValueType", drTreat["ti_loinc_9"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_loinc_10"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", drTreat["ti_loinc_10"].ToString());
                                        writer.WriteElementString("Value", drTreat["ti_loinc_11"].ToString());
                                        writer.WriteElementString("ValueType", drTreat["ti_loinc_12"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_loinc_13"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", drTreat["ti_loinc_13"].ToString());
                                        writer.WriteElementString("Value", drTreat["ti_loinc_14"].ToString());
                                        writer.WriteElementString("ValueType", drTreat["ti_loinc_15"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    // LOINC CODES ENDS
                                    if ((drTreat["tr_code"].ToString() == "9") || (drTreat["tr_code"].ToString() == "10") || (drTreat["tr_code"].ToString() == "11") || (drTreat["tr_code"].ToString() == "9.1") || (drTreat["tr_code"].ToString() == "10.1") || (drTreat["tr_code"].ToString() == "11.1"))
                                    {
                                        if (drTreat["ti_lab_8"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "BPS");
                                            writer.WriteElementString("Value", drTreat["ti_lab_8"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_9"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "BPD");
                                            writer.WriteElementString("Value", drTreat["ti_lab_9"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "82565")
                                    {
                                        if (drTreat["ti_lab_7"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "CR");
                                            writer.WriteElementString("Value", drTreat["ti_lab_7"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "82043")
                                    {
                                        if (drTreat["ti_lab_6"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "UA");
                                            writer.WriteElementString("Value", drTreat["ti_lab_6"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "84478")
                                    {
                                        if (drTreat["ti_lab_5"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "TRIG");
                                            writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "83721")
                                    {
                                        if (drTreat["ti_lab_4"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "LDL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "83718")
                                    {
                                        if (drTreat["ti_lab_3"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "HDL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "82465")
                                    {
                                        if (drTreat["ti_lab_2"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "CHOL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "80061")
                                    {
                                        if (drTreat["ti_image_7"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "NONHDL");
                                            writer.WriteElementString("Value", drTreat["ti_image_7"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["tr_code"].ToString() == "80061")
                                    {
                                        if (drTreat["ti_lab_2"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "CHOL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_2"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_3"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "HDL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_3"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_4"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "LDL");
                                            writer.WriteElementString("Value", drTreat["ti_lab_4"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }

                                        if (drTreat["ti_lab_5"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "TRIG");
                                            writer.WriteElementString("Value", drTreat["ti_lab_5"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }

                                    }
                                    if (drTreat["tr_code"].ToString() == "83036")
                                    {
                                        if (drTreat["ti_lab_1"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "A1c");
                                            writer.WriteElementString("Value", drTreat["ti_lab_1"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }

                                    if (diag__codes.Contains("E66.9") == true)
                                    {
                                        if (drTreat["ti_lab_10"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "BMI");
                                            writer.WriteElementString("Value", drTreat["ti_lab_10"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                                    {
                                        if (drTreat["ti_lab_11"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "Albumin");
                                            writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                                    {
                                        if (drTreat["ti_lab_11"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "Albumin");
                                            writer.WriteElementString("Value", drTreat["ti_lab_11"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_12"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "ALP");
                                            writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_13"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "ALT");
                                            writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_lab_14"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "AST");
                                            writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_image_8"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "TotalBilirubin");
                                            writer.WriteElementString("Value", drTreat["ti_image_8"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_image_9"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "DirectBilirubin");
                                            writer.WriteElementString("Value", drTreat["ti_image_9"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                        if (drTreat["ti_image_10"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "TotalProtein");
                                            writer.WriteElementString("Value", drTreat["ti_image_10"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                                    {
                                        if (drTreat["ti_lab_12"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "ALP");
                                            writer.WriteElementString("Value", drTreat["ti_lab_12"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84460"))
                                    {
                                        if (drTreat["ti_lab_13"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "ALT");
                                            writer.WriteElementString("Value", drTreat["ti_lab_13"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "84450"))
                                    {
                                        if (drTreat["ti_lab_14"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "AST");
                                            writer.WriteElementString("Value", drTreat["ti_lab_14"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                    {
                                        if (drTreat["ti_lab_15"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "FBS");
                                            writer.WriteElementString("Value", drTreat["ti_lab_15"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) && (drTreat["tr_code"].ToString() == "82947"))
                                    {
                                        if (drTreat["ti_lab_16"].ToString() != "")
                                        {
                                            writer.WriteStartElement("Observation");
                                            writer.WriteElementString("Type", "Result");
                                            writer.WriteElementString("Code", "RBS");
                                            writer.WriteElementString("Value", drTreat["ti_lab_16"].ToString());
                                            writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                            // End Observation element
                                            writer.WriteEndElement();
                                        }
                                    }
                                    if (drTreat["ti_lab_17"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "FCR");
                                        writer.WriteElementString("Value", drTreat["ti_lab_17"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["tr_code"].ToString() == "17999")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Text");
                                        writer.WriteElementString("Code", "Activity Description");
                                        writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                        writer.WriteElementString("ValueType", "Text");
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["tr_code"].ToString() == "0232T")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Text");
                                        writer.WriteElementString("Code", "Activity Description");
                                        writer.WriteElementString("Value", drTreat["tr_name"].ToString().Replace("&", "and").Replace("'", ""));
                                        writer.WriteElementString("ValueType", "Text");
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    // NEW CODES ENDS
                                    if (drTreat["pt_notes"].ToString() != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Result");
                                        writer.WriteElementString("Code", "Description");
                                        writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                        writer.WriteElementString("ValueType", app_date.ToString("dd/MM/yyyy"));
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["pt_teeth"].ToString() != "")
                                    {
                                        if (drTreat["pt_teeth"].ToString() != "NA")
                                        {
                                            string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                            for (int j = 0; j < pt__teeth.Length; j++)
                                            {
                                                //MessageBox.Show(words[j]);
                                                if (pt__teeth[j].Trim() != "")
                                                {
                                                    writer.WriteStartElement("Observation");
                                                    writer.WriteElementString("Type", "Universal Dental");
                                                    writer.WriteElementString("Code", pt__teeth[j].Trim());
                                                    // End Observation element
                                                    writer.WriteEndElement();
                                                }
                                            }
                                        }
                                    }

                                    if (claim_no != "")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "Text");
                                        writer.WriteElementString("Code", "CLAIM-FORM-NUMBER");
                                        writer.WriteElementString("Value", drTreat["pt_notes"].ToString());
                                        writer.WriteElementString("ValueType", "CLAIM-FORM-NUMBER");
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }

                                    if (drTreat["ti_image_1"].ToString() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "File");
                                        writer.WriteElementString("Code", "PDF");
                                        string path = "";
                                        path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                        string file_path = Path.Combine(path, drTreat["ti_image_1"].ToString());
                                        byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                        string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                        writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                        writer.WriteElementString("ValueType", "PDF File");
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_2"].ToString() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "File");
                                        writer.WriteElementString("Code", "PDF");
                                        string path = "";
                                        path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                        string file_path = Path.Combine(path, drTreat["ti_image_2"].ToString());
                                        byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                        string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                        writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                        writer.WriteElementString("ValueType", "PDF File");
                                        writer.WriteEndElement();

                                    }
                                    if (drTreat["ti_image_3"].ToString() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "File");
                                        writer.WriteElementString("Code", "PDF");
                                        string path = "";
                                        path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                        string file_path = Path.Combine(path, drTreat["ti_image_3"].ToString());
                                        byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                        string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                        writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                        writer.WriteElementString("ValueType", "PDF File");
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_4"].ToString() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "File");
                                        writer.WriteElementString("Code", "PDF");
                                        string path = "";
                                        path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                        string file_path = Path.Combine(path, drTreat["ti_image_4"].ToString());
                                        byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                        string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                        writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                        writer.WriteElementString("ValueType", "PDF File");
                                        writer.WriteEndElement();
                                    }
                                    if (drTreat["ti_image_5"].ToString() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "File");
                                        writer.WriteElementString("Code", "PDF");
                                        string path = "";
                                        path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                        string file_path = Path.Combine(path, drTreat["ti_image_5"].ToString());
                                        byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                        string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                        writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                        writer.WriteElementString("ValueType", "PDF File");
                                        writer.WriteEndElement();
                                    }
                                    DataTable dt_lab = new DataTable();
                                    dt_lab = BusinessLogicLayer.EClaims.EClaims.GetLabResultsAppointmentID(int.Parse(drTreat["ptId"].ToString()));
                                    foreach (DataRow dr_lab in dt_lab.Rows)
                                    {
                                        writer.WriteStartElement("Observation");
                                        writer.WriteElementString("Type", "LOINC");
                                        writer.WriteElementString("Code", dr_lab["cll_code"].ToString());
                                        writer.WriteElementString("Value", drTreat["cll_result"].ToString());
                                        writer.WriteElementString("ValueType", dr_lab["cll_units"].ToString());
                                        // End Observation element
                                        writer.WriteEndElement();
                                    }
                                    // End Activity element
                                    writer.WriteEndElement();
                                }
                                // End Claim element
                                writer.WriteEndElement();
                            }
                            // End Claim Submission element
                            writer.WriteEndElement();
                            // End Document
                            writer.WriteEndDocument();
                            // string val= stringWriter.ToString();
                            writer.Flush();
                            writer.Close();
                            string file_name = dr["set_permit_no"].ToString() + "_" + s_ic_id + "_" + s_date_from.ToString("ddMMyyyy") + "_" + s_date_to.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xml";

                            string eClaim_ErrorMessage = "";
                            byte[] eClaim_ErrorReport = new byte[99];

                            string eClaim_TransactionId = "";
                            ae.gov.doh.shafafiya.Webservices e_Claim = new ae.gov.doh.shafafiya.Webservices();
                            e_Claim.UploadTransaction(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), Encoding.UTF8.GetBytes(stringWriter.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"")), file_name, out eClaim_ErrorMessage, out eClaim_ErrorReport, out eClaim_TransactionId);

                            TempData["ErrorMessage"] = eClaim_ErrorMessage;
                            string atr = "";
                            if (eClaim_ErrorMessage.Contains("successful") == false)
                            {
                                if (eClaim_ErrorMessage.Contains("invalid") == false)
                                {
                                    if (eClaim_ErrorMessage.Contains("input") == false)
                                    {
                                        string fileName = "~/submissions/HAAD/Error/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls".Replace(" ", "");
                                        using (FileStream destFile = System.IO.File.Open(Server.MapPath(fileName), FileMode.Create))
                                        {
                                            destFile.Write(eClaim_ErrorReport, 0, eClaim_ErrorReport.Length);
                                        }

                                        string atr1 = "Error Msg: " + eClaim_ErrorMessage + " Error Report <a href='/submissions/HAAD/Error/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls' class='fs-25 text-primary font-weight-bold text-center'><i class='fa fa-file-archive-o text-white'></i ></a>";
                                        atr = HttpUtility.HtmlDecode(atr1);
                                    }
                                    else
                                    {
                                        atr = "Error Msg: " + eClaim_ErrorMessage;
                                    }
                                }
                                else
                                {
                                    atr = "Error Msg: " + eClaim_ErrorMessage;
                                }
                            }
                            else
                            {
                                int eclId = 0;
                                string xmlString = writer.ToString();
                                string FolderPath = Server.MapPath("~/submissions/GeneratedXmls/HAAD/Direct/Sub_" + file_name);
                                eclId = BusinessLogicLayer.EClaims.EClaims.eClaim_Insert(s_ic_id, s_date_from, s_date_to, file_name, xmlString, eClaim_ErrorMessage);
                                int uinv_id = 0;
                                if (s_flag == "PRODUCTION")
                                {
                                    uinv_id = BusinessLogicLayer.EClaims.EClaims.SP_UpdateInvoiceStatus(inv_ids);
                                }
                                String contents = writer.ToString();

                                // Get the length of the contents
                                int length = contents.Length;
                                Response.AppendHeader("Content-Disposition", "attachment; filename=" + file_name);
                                Response.AppendHeader("Content-Length", length.ToString());
                                Response.ContentType = "text/xml";
                                Response.Write(contents.ToString());
                                Response.End();
                            }
                            return Json(atr, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Please select Treatments" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Selected Insurance Company claims during selected period already submitted" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult GenerateSelectedJSONDownload(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();

                string ic_insurance_name = "";
                DateTime cliam__date = s_date_from;
                DateTime TransactionDate = DateTime.Now;
                Dictionary<string, string> errors = new Dictionary<string, string>();
                int madeby = PageControl.getLoggedinId();
                int val = 0;
                DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                dt = ds.Tables[0];
                DataTable dt_signs = ds.Tables[0];
                string ins_clinic_code = "";
                string ic_name = "";
                string filename = Server.MapPath("~/submissions/GeneratedXmls/Riyati/Manual/Sub_" + dt.Rows[0]["set_sat_ftime"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + ".json").Replace(" ", ""); // Specify the output filename
                string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                try
                {
                    int day = DateTime.Parse(DateTime.Now.ToShortDateString()).Day;
                    int month = DateTime.Parse(DateTime.Now.ToShortDateString()).Month;
                    string day_value = "";
                    string month_value = "";
                    if (day < 10)
                    {
                        day_value = "0" + day.ToString();
                    }
                    else
                    {
                        day_value = day.ToString();
                    }
                    if (month < 10)
                    {
                        month_value = "0" + month.ToString();
                    }
                    else
                    {
                        month_value = month.ToString();
                    }
                    string Tr__date = day_value + "/" + month_value + "/" + DateTime.Parse(DateTime.Now.ToShortDateString()).Year;


                    string emp__license = string.Empty;
                    string FacilityId = dt.Rows[0]["set_sat_ftime"].ToString();
                    string strUsername = ConfigurationManager.AppSettings["RiayatiPOUsername"].ToString();
                    string strPassword = ConfigurationManager.AppSettings["RiayatiPOPassword"].ToString();
                    string strApiUrl = ConfigurationManager.AppSettings["RiayatiAPIUrl"].ToString();
                    string strEmiratesId = string.Empty;

                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_Request submission_request = new BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_Request();
                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission submission = new BusinessEntities.EClaims.ClaimSubmissionRequest.Submission();

                    BusinessEntities.EClaims.ClaimSubmissionRequest.Header header = new BusinessEntities.EClaims.ClaimSubmissionRequest.Header();

                    ///Adding Header

                    header.SenderID = FacilityId;
                    if (ic_names == "'Cash'")
                    {
                        header.ReceiverID = "MOHAP";
                    }
                    else
                    {
                        header.ReceiverID = ins_code.Trim();
                    }
                    header.TransactionDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    header.RecordCount = no_of_claims.ToString().Trim();
                    header.DispositionFlag = s_flag;
                    header.PayerID = dt.Rows[0]["inv_ic_payercode"].ToString().Trim();

                    submission.Header = header;

                    int i = 0;
                    string invmIds = "";
                    List<BusinessEntities.EClaims.ClaimSubmissionRequest.Claim> ClaimMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Claim>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BusinessEntities.EClaims.ClaimSubmissionRequest.Claim claims = new BusinessEntities.EClaims.ClaimSubmissionRequest.Claim();

                        i = i + 1;
                        //float inv_total = float.Parse(row["inv_total"].ToString());
                        float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        float inv_net_cash = float.Parse(row["inv_net"].ToString().Trim());
                        float inv_vat = float.Parse(row["inv_vat"].ToString().Trim());
                        //float inv_net = float.Parse(row["inv_net"].ToString());
                        float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                        float inv_copay = float.Parse(row["inv_copay"].ToString().Trim());
                        float inv_share = float.Parse(row["inv_share"].ToString().Trim());
                        float pat_share = 0;

                        if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                        {
                            pat_share = inv_tded + inv_copay + inv_share;
                        }
                        else
                        {
                            pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        }

                        float inv_total = inv_net_cash + pat_share;

                        string ins_no = row["pi_insno"].ToString().Trim();
                        string claim_no = row["inv_claimno"].ToString().Trim();
                        string policy_no = row["inv_pi_polocyno"].ToString().Trim();
                        string inv_no = row["inv_no"].ToString().Trim();
                        ins_clinic_code = row["inv_ic_payercode"].ToString().Trim();

                        invmIds = invmIds + "," + row["invId"].ToString();

                        ic_insurance_name = row["ic_name"].ToString().Trim();
                        ic_name = row["inv_insurance_name"].ToString().Trim();
                        DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                        DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                        int d_ay = app__fdate.Day;
                        string d__ay = "";
                        if (d_ay < 10)
                        {
                            d__ay = "0" + d_ay.ToString();
                        }
                        else
                        {
                            d__ay = d_ay.ToString();
                        }

                        int m_onth = app__fdate.Month;
                        string m__onth = "";
                        if (m_onth < 10)
                        {
                            m__onth = "0" + m_onth.ToString();
                        }
                        else
                        {
                            m__onth = m_onth.ToString();
                        }

                        claims.ID = inv_no;
                        if (ins_clinic_code != "INS200")
                        {
                            claims.IDPayer = ins_clinic_code;
                        }
                        claims.Type = "Submission";

                        claims.MemberId = ins_no.Trim();
                        claims.ProviderID = FacilityId;

                        if (!string.IsNullOrEmpty(row["pat_emirateid"].ToString().Trim()) && (row["pat_emirateid"].ToString().Trim().Length == 15))
                        {

                            claims.NationalIDNumber = row["pat_emirateid"].ToString().Substring(0, 3) + "-" + row["pat_emirateid"].ToString().Substring(3, 4) + "-" + row["pat_emirateid"].ToString().Substring(7, 7) + "-" + row["pat_emirateid"].ToString().Substring(14);
                        }
                        else if (!string.IsNullOrEmpty(row["pat_emirateid"].ToString().Trim()) && (row["pat_emirateid"].ToString().Trim().Length == 18))
                        {

                            claims.NationalIDNumber = row["pat_emirateid"].ToString().Trim();
                        }
                        else
                        {
                            claims.NationalIDNumber = "999-9999-9999999-9";
                        }



                        claims.Gross = inv_total.ToString("0.00");
                        claims.PatientShare = pat_share.ToString("0.00");
                        claims.Net = inv_net.ToString("0.00");
                        claims.DateOfBirth = DateTime.Parse(row["pat_dob"].ToString()).ToString("dd/MM/yyyy HH:mm");
                        claims.Gender = row["pat_gender"].ToString().Trim();

                        BusinessEntities.EClaims.ClaimSubmissionRequest.Encounter encounter = new BusinessEntities.EClaims.ClaimSubmissionRequest.Encounter();
                        encounter.FacilityID = FacilityId;
                        encounter.Type = "1";
                        encounter.PatientID = row["pat_code"].ToString().Trim();
                        encounter.Start = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + row["app_doc_ftime"].ToString();
                        encounter.End = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + row["app_doc_ttime"].ToString();
                        encounter.StartType = "1";
                        encounter.EndType = "1";
                        //encounter.TransferSource =
                        //encounter.TransferDestination =
                        claims.Encounter = encounter;

                        List<BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis> DiagnosisMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis>();

                        DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(row["appId"].ToString()), 0);
                        string diag__codes = "";
                        foreach (DataRow drDiag in dtDiag.Rows)
                        {
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis diagnosis = new BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis();

                            if (drDiag["pad_type"].ToString() == "Primary")
                            {
                                diagnosis.Type = "Principal";
                            }
                            else
                            {
                                diagnosis.Type = "Secondary";
                            }
                            diag__codes = diag__codes + "," + drDiag["diag_code"].ToString().Trim();
                            diagnosis.Code = drDiag["diag_code"].ToString().Trim();

                            DiagnosisMain.Add(diagnosis);
                        }
                        claims.Diagnosis = DiagnosisMain;


                        //ACTIVITY

                        List<BusinessEntities.EClaims.ClaimSubmissionRequest.Activity> ActivityMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Activity>();
                        int y = 0;
                        DataTable dtTreat = new DataTable();
                        dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        foreach (DataRow drTreat in dtTreat.Rows)
                        {
                            float pt_net = float.Parse(drTreat["pt_net"].ToString().Trim());
                            float pt_vat = float.Parse(drTreat["pt_vat"].ToString().Trim());
                            DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString().Trim());
                            y = y + 1;
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Activity activity = new BusinessEntities.EClaims.ClaimSubmissionRequest.Activity();
                            activity.ID = drTreat["ptId"].ToString().Trim();
                            activity.Start = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + drTreat["app_doc_ftime"].ToString();
                            activity.Type = drTreat["tr_itype"].ToString().Trim();
                            activity.Code = drTreat["tr_code"].ToString().Trim();
                            activity.Location = "2";
                            activity.Quantity = drTreat["pt_qty"].ToString().Trim();
                            activity.Net = pt_net.ToString("0.00");

                            if (drTreat["emp_license"].ToString().Trim().Substring(0, 3).Equals("MOH"))
                            {
                                emp__license = drTreat["emp_license"].ToString().Substring(3, (drTreat["emp_license"].ToString().Length - 3));
                            }
                            else
                            {
                                emp__license = drTreat["emp_license"].ToString().Trim();
                            }

                            activity.Clinician = emp__license;
                            if (drTreat["tr_itype"].ToString().Trim() == "5")
                            {
                                activity.Duration = drTreat["pt_qty"].ToString().Trim();
                            }
                            if (drTreat["pt_auth_code"].ToString().Trim() != "")
                            {
                                if (drTreat["pt_auth_code"].ToString().Trim() != "Not Required")
                                {
                                    activity.PriorAuthorizationID = drTreat["pt_auth_code"].ToString().Trim();
                                }
                            }
                            List<BusinessEntities.EClaims.ClaimSubmissionRequest.Observation> ObservationMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Observation>();
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            DataTable dtTreat2 = new DataTable();
                            dtTreat2 = BusinessLogicLayer.EClaims.EClaims.GetPrescriptions(int.Parse(row["appId"].ToString()));
                            foreach (DataRow dtpresc in dtTreat2.Rows)
                            {
                                if (dtpresc["pre_eRxRefNo"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation1 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation1.Type = "ERX";
                                    observation1.Code = "eRxReferenceNo";
                                    observation1.Value = dtpresc["pre_eRxRefNo"].ToString().Trim();
                                    observation1.ValueType = "Reference";
                                    ObservationMain.Add(observation1);
                                }
                            }


                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation55 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            observation55.Type = "Text";
                            observation55.Code = "InvoiceNumber";
                            observation55.Value = row["inv_no"].ToString().Trim();
                            observation55.ValueType = "Text";
                            ObservationMain.Add(observation55);

                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation56 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            observation56.Type = "Text";
                            observation56.Code = "InvoiceDate";
                            observation56.Value = DateTime.Parse(row["inv_date"].ToString()).ToString("dd-MM-yyyy").Trim();
                            observation56.ValueType = "Date";
                            ObservationMain.Add(observation56);

                            if (drTreat["pt_teeth"].ToString().Trim() != "")
                            {
                                if (drTreat["pt_teeth"].ToString().Trim() != "NA")
                                {
                                    string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                    for (int j = 0; j < pt__teeth.Length; j++)
                                    {
                                        //MessageBox.Show(words[j]);
                                        if (pt__teeth[j].Trim() != "")
                                        {
                                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation91 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                            observation91.Type = "UniversalDental";
                                            observation91.Code = "UniversalNumberingSystemDental";
                                            observation91.Value = pt__teeth[j].Trim();
                                            observation91.ValueType = "ToothNumber";
                                            ObservationMain.Add(observation91);
                                        }
                                    }
                                }
                            }

                            if (drTreat["ti_image_1"].ToString().Trim() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno1"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation101 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation101.Type = "File";
                                    observation101.Code = "File";
                                    observation101.Value = drTreat["ti_img_refno1"].ToString().Trim();
                                    observation101.ValueType = "File";
                                    ObservationMain.Add(observation101);
                                }


                            }
                            if (drTreat["ti_image_2"].ToString().Trim() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation102 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation102.Type = "File";
                                    observation102.Code = "File";
                                    observation102.Value = drTreat["ti_img_refno2"].ToString().Trim();
                                    observation102.ValueType = "File";
                                    ObservationMain.Add(observation102);
                                }


                            }
                            if (drTreat["ti_image_3"].ToString().Trim() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation103 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation103.Type = "File";
                                    observation103.Code = "File";
                                    observation103.Value = drTreat["ti_img_refno3"].ToString().Trim();
                                    observation103.ValueType = "File";
                                    ObservationMain.Add(observation103);
                                }


                            }
                            if (drTreat["ti_image_4"].ToString().Trim() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation104 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation104.Type = "File";
                                    observation104.Code = "File";
                                    observation104.Value = drTreat["ti_img_refno4"].ToString().Trim();
                                    observation104.ValueType = "File";
                                    ObservationMain.Add(observation104);
                                }
                            }
                            if (drTreat["ti_image_5"].ToString().Trim() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation105 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation105.Type = "File";
                                    observation105.Code = "File";
                                    observation105.Value = drTreat["ti_img_refno5"].ToString().Trim();
                                    observation105.ValueType = "File";
                                    ObservationMain.Add(observation105);
                                }


                            }

                            if (drTreat["pt_notes"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation107 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation107.Type = "Text";
                                observation107.Code = "Description";
                                observation107.Value = drTreat["pt_notes"].ToString().Trim();
                                observation107.ValueType = "Other";
                                ObservationMain.Add(observation107);
                            }


                            if (!string.IsNullOrEmpty(drTreat["pt_offauth"].ToString().Trim()))
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observationOff = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observationOff.Type = "OfflineAuthorization";
                                observationOff.Code = "OfflineAuthorization";
                                observationOff.Value = drTreat["pt_offauth"].ToString().Trim();
                                observationOff.ValueType = "OfflineAuthorization";
                                ObservationMain.Add(observationOff);

                            }
                            if (drTreat["ti_loinc_1"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation57 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation57.Type = "LOINC";
                                observation57.Code = "LOINC"; ;
                                observation57.Value = drTreat["ti_loinc_1"].ToString().Trim();// drTreat["ti_loinc_2"].ToString();
                                observation57.ValueType = "LOINCcode";// drTreat["ti_loinc_3"].ToString();
                                ObservationMain.Add(observation57);
                            }

                            if (drTreat["ti_loinc_4"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation58 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation58.Type = "LOINC";
                                observation58.Code = "LOINC";
                                observation58.Value = drTreat["ti_loinc_4"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation58.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation58);

                            }

                            if (drTreat["ti_loinc_7"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation59 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation59.Type = "LOINC";
                                observation59.Code = "LOINC";
                                observation59.Value = drTreat["ti_loinc_7"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation59.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation59);


                            }

                            if (drTreat["ti_loinc_10"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation60 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation60.Type = "LOINC";
                                observation60.Code = "LOINC";
                                observation60.Value = drTreat["ti_loinc_10"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation60.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation60);

                            }

                            if (drTreat["ti_loinc_13"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation61 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation61.Type = "LOINC";
                                observation61.Code = "LOINC";
                                observation61.Value = drTreat["ti_loinc_13"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation61.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation61);

                            }

                            // LOINC CODES ENDS

                            if ((drTreat["tr_code"].ToString().Trim() == "9") || (drTreat["tr_code"].ToString().Trim() == "10") || (drTreat["tr_code"].ToString().Trim() == "11") || (drTreat["tr_code"].ToString().Trim() == "9.1") || (drTreat["tr_code"].ToString().Trim() == "10.1") || (drTreat["tr_code"].ToString().Trim() == "11.1"))
                            {
                                if (drTreat["ti_lab_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation2 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation2.Type = "Text";
                                    observation2.Code = "Description";
                                    observation2.Value = "BPS– (Result =" + drTreat["ti_lab_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation2.ValueType = "Other";
                                    ObservationMain.Add(observation2);
                                }
                                if (drTreat["ti_lab_9"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation3 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();

                                    observation3.Type = "Text";
                                    observation3.Code = "Description";
                                    observation3.Value = "BPD– (Result =" + drTreat["ti_lab_9"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation3.ValueType = "Other";
                                    ObservationMain.Add(observation3);
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "82565")
                            {
                                if (drTreat["ti_lab_7"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation4 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation4.Type = "Text";
                                    observation4.Code = "Description";
                                    observation4.Value = "CR– (Result =" + drTreat["ti_lab_7"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation4.ValueType = "Other";
                                    ObservationMain.Add(observation4);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "82043")
                            {
                                if (drTreat["ti_lab_6"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation5 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation5.Type = "Text";
                                    observation5.Code = "Description";
                                    observation5.Value = "UA– (Result =" + drTreat["ti_lab_6"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation5.ValueType = "Other";
                                    ObservationMain.Add(observation5);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "84478")
                            {
                                if (drTreat["ti_lab_5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation6 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation6.Type = "Text";
                                    observation6.Code = "Description";
                                    observation6.Value = "TRIG– (Result =" + drTreat["ti_lab_5"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation6.ValueType = "Other";
                                    ObservationMain.Add(observation6);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "83721")
                            {
                                if (drTreat["ti_lab_4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation7 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation7.Type = "Text";
                                    observation7.Code = "Description";
                                    observation7.Value = "LDL– (Result =" + drTreat["ti_lab_4"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation7.ValueType = "Other";
                                    ObservationMain.Add(observation7);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "83718")
                            {
                                if (drTreat["ti_lab_3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation8 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation8.Type = "Text";
                                    observation8.Code = "Description";
                                    observation8.Value = "HDL– (Result =" + drTreat["ti_lab_3"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation8.ValueType = "Other";
                                    ObservationMain.Add(observation8);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "82465")
                            {
                                if (drTreat["ti_lab_2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation9 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation9.Type = "Text";
                                    observation9.Code = "Description";
                                    observation9.Value = "CHOL– (Result =" + drTreat["ti_lab_2"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation9.ValueType = "Other";
                                    ObservationMain.Add(observation9);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "80061")
                            {
                                if (drTreat["ti_lab_2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation31 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation31.Type = "Text";
                                    observation31.Code = "Description";
                                    observation31.Value = "CHOL– (Result =" + drTreat["ti_lab_2"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation31.ValueType = "Other";
                                    ObservationMain.Add(observation31);
                                }
                                if (drTreat["ti_lab_3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation10 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation10.Type = "Text";
                                    observation10.Code = "Description";
                                    observation10.Value = "HDL– (Result =" + drTreat["ti_lab_3"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation10.ValueType = "Other";
                                    ObservationMain.Add(observation10);
                                }
                                if (drTreat["ti_lab_4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation11 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation11.Type = "Text";
                                    observation11.Code = "Description";
                                    observation11.Value = "LDL– (Result =" + drTreat["ti_lab_4"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation11.ValueType = "Other";
                                    ObservationMain.Add(observation11);
                                }

                                if (drTreat["ti_lab_5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation12 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation12.Type = "Text";
                                    observation12.Code = "Description";
                                    observation12.Value = "TRIG– (Result =" + drTreat["ti_lab_5"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation12.ValueType = "Other";
                                    ObservationMain.Add(observation12);

                                }
                                if (drTreat["ti_image_7"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation30 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation30.Type = "Text";
                                    observation30.Code = "Description";
                                    observation30.Value = "NONHDL– (Result =" + drTreat["ti_image_7"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation30.ValueType = "Other";
                                    ObservationMain.Add(observation30);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "83036")
                            {
                                if (drTreat["ti_lab_1"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation13 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation13.Type = "Text";
                                    observation13.Code = "Description";
                                    observation13.Value = "A1c– (Result =" + drTreat["ti_lab_1"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation13.ValueType = "Other";
                                    ObservationMain.Add(observation13);
                                }
                            }

                            if (diag__codes.Contains("E66.9") == true)
                            {
                                if (drTreat["ti_lab_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation14 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation14.Type = "Text";
                                    observation14.Code = "Description";
                                    observation14.Value = "BMI– (Result =" + drTreat["ti_lab_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation14.ValueType = "Other";
                                    ObservationMain.Add(observation14);
                                }
                            }
                            if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation15 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation15.Type = "Text";
                                    observation15.Code = "Description";
                                    observation15.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation15.ValueType = "Other";
                                    ObservationMain.Add(observation15);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                            {
                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation16 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation16.Type = "Text";
                                    observation16.Code = "Description";
                                    observation16.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation16.ValueType = "Other";
                                    ObservationMain.Add(observation16);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation17 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation17.Type = "Text";
                                    observation17.Code = "Description";
                                    observation17.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation17.ValueType = "Other";
                                    ObservationMain.Add(observation17);
                                }
                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation18 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation18.Type = "Text";
                                    observation18.Code = "Description";
                                    observation18.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation18.ValueType = "Other";
                                    ObservationMain.Add(observation18);

                                }
                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation19 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation19.Type = "Text";
                                    observation19.Code = "Description";
                                    observation19.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation19.ValueType = "Other";
                                    ObservationMain.Add(observation19);
                                }
                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation20 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation20.Type = "Text";
                                    observation20.Code = "Description";
                                    observation20.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation20.ValueType = "Other";
                                    ObservationMain.Add(observation20);
                                }
                                if (drTreat["ti_image_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation32 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation32.Type = "Text";
                                    observation32.Code = "Description";
                                    observation32.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation32.ValueType = "Other";
                                    ObservationMain.Add(observation32);
                                }
                                if (drTreat["ti_image_9"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation33 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation33.Type = "Text";
                                    observation33.Code = "Description";
                                    observation33.Value = "DirectBilirubin– (Result =" + drTreat["ti_image_9"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation33.ValueType = "Other";
                                    ObservationMain.Add(observation33);
                                }
                                if (drTreat["ti_image_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation34 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation34.Type = "Text";
                                    observation34.Code = "Description";
                                    observation34.Value = "TotalProtein– (Result =" + drTreat["ti_image_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation34.ValueType = "Other";
                                    ObservationMain.Add(observation34);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString().Trim() == "84460"))
                            {
                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation21 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation21.Type = "Text";
                                    observation21.Code = "Description";
                                    observation21.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation21.ValueType = "Other";
                                    ObservationMain.Add(observation21);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString().Trim() == "84450"))
                            {
                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation22 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation22.Type = "Text";
                                    observation22.Code = "Description";
                                    observation22.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation22.ValueType = "Other";
                                    ObservationMain.Add(observation22);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82947")) //((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) &&
                            {
                                if (drTreat["ti_lab_15"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation23 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation23.Type = "Text";
                                    observation23.Code = "Description";
                                    observation23.Value = "FBS– (Result =" + drTreat["ti_lab_15"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation23.ValueType = "Other";
                                    ObservationMain.Add(observation23);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82947"))
                            {
                                if (drTreat["ti_lab_16"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation24 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation24.Type = "Text";
                                    observation24.Code = "Description";
                                    observation24.Value = "RBS– (Result =" + drTreat["ti_lab_16"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation24.ValueType = "Other";
                                    ObservationMain.Add(observation24);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82950"))
                            {
                                if (drTreat["ti_lab_16"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation25 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation25.Type = "Text";
                                    observation25.Code = "Description";
                                    observation25.Value = "PPBS– (Result =" + drTreat["ti_lab_16"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation25.ValueType = "Other";
                                    ObservationMain.Add(observation25);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "80076")
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation26 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation26.Type = "Text";
                                    observation26.Code = "Description";
                                    observation26.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation26.ValueType = "Other";
                                    ObservationMain.Add(observation26);
                                }

                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation27 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation27.Type = "Text";
                                    observation27.Code = "Description";
                                    observation27.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation27.ValueType = "Other";
                                    ObservationMain.Add(observation27);
                                }

                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation28 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation28.Type = "Text";
                                    observation28.Code = "Description";
                                    observation28.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation28.ValueType = "Other";
                                    ObservationMain.Add(observation28);
                                }

                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation29 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation29.Type = "Text";
                                    observation29.Code = "Description";
                                    observation29.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation29.ValueType = "Other";
                                    ObservationMain.Add(observation29);
                                }

                                if (drTreat["ti_image_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation35 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation35.Type = "Text";
                                    observation35.Code = "Description";
                                    observation35.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation35.ValueType = "Other";
                                    ObservationMain.Add(observation35);

                                }

                                if (drTreat["ti_image_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation36 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation36.Type = "Text";
                                    observation36.Code = "Description";
                                    observation36.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation36.ValueType = "Other";
                                    ObservationMain.Add(observation36);
                                }
                            }


                            activity.Observation = ObservationMain;
                            ActivityMain.Add(activity);
                        }
                        claims.Activity = ActivityMain;

                        ClaimMain.Add(claims);
                    }
                    submission.Claim = ClaimMain;
                    submission_request.Submission = submission;
                    string myDeserializedClass = JsonConvert.SerializeObject(submission_request);
                    Trace.TraceWarning("Json::" + myDeserializedClass);
                    var empclaims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_name = empclaims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                    string file_name = "EMC_Sub_" + emp_name + "_" + s_date_from.ToString("ddMMyyyyhhsstt") + "_" + ic_insurance_name + ".json";


                    byte[] fileBytes = Encoding.UTF8.GetBytes(myDeserializedClass);
                    return File(fileBytes, "application/json", file_name);
                }
                catch (WebException ex)
                {
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());

                    // Read the content.
                    string responseFromServer = sr.ReadToEnd();

                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_response result1 = JsonConvert.DeserializeObject<BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_response>(responseFromServer);
                    if (result1.StatusCode == "400")
                    {
                        //lblErrorMessage.Text = result1.UserMessage;
                        int count = 1;

                        foreach (var err in result1.Error)
                        {
                            // string ErrMsg = " " + count + ". In " + err.Reference + "," + err.AdditionalReferenceObjectName + "," + err.ErrorText + ".";
                            //    lblErrorMessage.Text += ErrMsg;
                            string ErrMsg = string.Empty;

                            ErrMsg = "<p style=\"font-size:14px\">" + count;

                            if (!string.IsNullOrEmpty(err.Reference))
                            {
                                ErrMsg += " &nbsp;<b style=\"color:red;\"> Reference:</b>" + err.Reference + ".";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReference))
                            {
                                ErrMsg += "<b style=\"color:red;\">AdditionalReference:</b>" + err.AdditionalReference + ".";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReferenceObjectName))
                            {
                                ErrMsg += "<b style=\"color:red;\">AdditionalReferenceObjectName:</b>" + err.AdditionalReferenceObjectName + ".";
                            }
                            if (!string.IsNullOrEmpty(err.ErrorText))
                            {
                                ErrMsg += "<b style=\"color:red;\">ErrorText:</b>" + err.ErrorText + ".";
                            }
                            if (!string.IsNullOrEmpty(err.ObjectName))
                            {
                                ErrMsg += "<b style=\"color:red;\">ObjectName:</b>" + err.ObjectName + ".";
                            }
                            ErrMsg += "</p>";
                            //lblError.InnerHtml += ErrMsg;
                            count = count + 1;

                            return Json(new { isSuccess = false, message = ErrMsg }, JsonRequestBehavior.AllowGet);
                        }
                        return Json(new { isSuccess = false, message = result1.UserMessage }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = result1.UserMessage }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public async Task<ActionResult> GenerateSelectedJSONMOHDirect(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();

                string ic_insurance_name = "";
                DateTime cliam__date = s_date_from;
                DateTime TransactionDate = DateTime.Now;
                Dictionary<string, string> errors = new Dictionary<string, string>();
                int madeby = PageControl.getLoggedinId();
                int val = 0;
                DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                dt = ds.Tables[0];
                DataTable dt_signs = ds.Tables[0];
                string ins_clinic_code = "";
                string ic_name = "";
                string filename = Server.MapPath("~/submissions/GeneratedXmls/Riyati/Direct/Sub_" + dt.Rows[0]["set_sat_ftime"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + ".json").Replace(" ", ""); // Specify the output filename
                string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                try
                {
                    int day = DateTime.Parse(DateTime.Now.ToShortDateString()).Day;
                    int month = DateTime.Parse(DateTime.Now.ToShortDateString()).Month;
                    string day_value = "";
                    string month_value = "";
                    if (day < 10)
                    {
                        day_value = "0" + day.ToString();
                    }
                    else
                    {
                        day_value = day.ToString();
                    }
                    if (month < 10)
                    {
                        month_value = "0" + month.ToString();
                    }
                    else
                    {
                        month_value = month.ToString();
                    }
                    string Tr__date = day_value + "/" + month_value + "/" + DateTime.Parse(DateTime.Now.ToShortDateString()).Year;


                    string emp__license = string.Empty;
                    string FacilityId = dt.Rows[0]["set_sat_ftime"].ToString();
                    string strUsername = ConfigurationManager.AppSettings["RiayatiPOUsername"].ToString();
                    string strPassword = ConfigurationManager.AppSettings["RiayatiPOPassword"].ToString();
                    string strApiUrl = ConfigurationManager.AppSettings["RiayatiAPIUrl"].ToString();
                    string strEmiratesId = string.Empty;

                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_Request submission_request = new BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_Request();
                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission submission = new BusinessEntities.EClaims.ClaimSubmissionRequest.Submission();
                    BusinessEntities.EClaims.ClaimSubmissionRequest.Header header = new BusinessEntities.EClaims.ClaimSubmissionRequest.Header();

                    ///Adding Header

                    header.SenderID = FacilityId;
                    if (ic_names == "'Cash'")
                    {
                        header.ReceiverID = "MOHAP";
                    }
                    else
                    {
                        header.ReceiverID = ins_code.Trim();
                    }
                    header.TransactionDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    header.RecordCount = no_of_claims.ToString().Trim();
                    header.DispositionFlag = s_flag;
                    header.PayerID = dt.Rows[0]["inv_ic_payercode"].ToString().Trim();

                    submission.Header = header;

                    int i = 0;
                    string invmIds = "";
                    List<BusinessEntities.EClaims.ClaimSubmissionRequest.Claim> ClaimMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Claim>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BusinessEntities.EClaims.ClaimSubmissionRequest.Claim claims = new BusinessEntities.EClaims.ClaimSubmissionRequest.Claim();

                        i = i + 1;
                        //float inv_total = float.Parse(row["inv_total"].ToString());
                        float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        float inv_net_cash = float.Parse(row["inv_net"].ToString().Trim());
                        float inv_vat = float.Parse(row["inv_vat"].ToString().Trim());
                        //float inv_net = float.Parse(row["inv_net"].ToString());
                        float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                        float inv_copay = float.Parse(row["inv_copay"].ToString().Trim());
                        float inv_share = float.Parse(row["inv_share"].ToString().Trim());
                        float pat_share = 0;

                        if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                        {
                            pat_share = inv_tded + inv_copay + inv_share;
                        }
                        else
                        {
                            pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        }

                        float inv_total = inv_net_cash + pat_share;

                        string ins_no = row["pi_insno"].ToString().Trim();
                        string claim_no = row["inv_claimno"].ToString().Trim();
                        string policy_no = row["inv_pi_polocyno"].ToString().Trim();
                        string inv_no = row["inv_no"].ToString().Trim();
                        ins_clinic_code = row["inv_ic_payercode"].ToString().Trim();

                        invmIds = invmIds + "," + row["invId"].ToString();

                        ic_insurance_name = row["ic_name"].ToString().Trim();
                        ic_name = row["inv_insurance_name"].ToString().Trim();
                        DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                        DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                        int d_ay = app__fdate.Day;
                        string d__ay = "";
                        if (d_ay < 10)
                        {
                            d__ay = "0" + d_ay.ToString();
                        }
                        else
                        {
                            d__ay = d_ay.ToString();
                        }

                        int m_onth = app__fdate.Month;
                        string m__onth = "";
                        if (m_onth < 10)
                        {
                            m__onth = "0" + m_onth.ToString();
                        }
                        else
                        {
                            m__onth = m_onth.ToString();
                        }

                        claims.ID = inv_no;
                        if (ins_clinic_code != "INS200")
                        {
                            claims.IDPayer = ins_clinic_code;
                        }
                        claims.Type = "Submission";

                        claims.MemberId = ins_no.Trim();
                        claims.ProviderID = FacilityId;

                        if (!string.IsNullOrEmpty(row["pat_emirateid"].ToString().Trim()) && (row["pat_emirateid"].ToString().Trim().Length == 15))
                        {

                            claims.NationalIDNumber = row["pat_emirateid"].ToString().Substring(0, 3) + "-" + row["pat_emirateid"].ToString().Substring(3, 4) + "-" + row["pat_emirateid"].ToString().Substring(7, 7) + "-" + row["pat_emirateid"].ToString().Substring(14);
                        }
                        else if (!string.IsNullOrEmpty(row["pat_emirateid"].ToString().Trim()) && (row["pat_emirateid"].ToString().Trim().Length == 18))
                        {

                            claims.NationalIDNumber = row["pat_emirateid"].ToString().Trim();
                        }
                        else
                        {
                            claims.NationalIDNumber = "999-9999-9999999-9";
                        }



                        claims.Gross = inv_total.ToString("0.00");
                        claims.PatientShare = pat_share.ToString("0.00");
                        claims.Net = inv_net.ToString("0.00");
                        claims.DateOfBirth = DateTime.Parse(row["pat_dob"].ToString()).ToString("dd/MM/yyyy HH:mm");
                        claims.Gender = row["pat_gender"].ToString().Trim();

                        BusinessEntities.EClaims.ClaimSubmissionRequest.Encounter encounter = new BusinessEntities.EClaims.ClaimSubmissionRequest.Encounter();
                        encounter.FacilityID = FacilityId;
                        encounter.Type = "1";
                        encounter.PatientID = row["pat_code"].ToString().Trim();
                        encounter.Start = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + row["app_doc_ftime"].ToString();
                        encounter.End = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + row["app_doc_ttime"].ToString();
                        encounter.StartType = "1";
                        encounter.EndType = "1";
                        //encounter.TransferSource =
                        //encounter.TransferDestination =
                        claims.Encounter = encounter;

                        List<BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis> DiagnosisMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis>();

                        DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(row["appId"].ToString()), 0);
                        string diag__codes = "";
                        foreach (DataRow drDiag in dtDiag.Rows)
                        {
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis diagnosis = new BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis();

                            if (drDiag["pad_type"].ToString() == "Primary")
                            {
                                diagnosis.Type = "Principal";
                            }
                            else
                            {
                                diagnosis.Type = "Secondary";
                            }
                            diag__codes = diag__codes + "," + drDiag["diag_code"].ToString().Trim();
                            diagnosis.Code = drDiag["diag_code"].ToString().Trim();

                            DiagnosisMain.Add(diagnosis);
                        }
                        claims.Diagnosis = DiagnosisMain;


                        //ACTIVITY

                        List<BusinessEntities.EClaims.ClaimSubmissionRequest.Activity> ActivityMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Activity>();
                        int y = 0;
                        DataTable dtTreat = new DataTable();
                        dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        foreach (DataRow drTreat in dtTreat.Rows)
                        {
                            float pt_net = float.Parse(drTreat["pt_net"].ToString().Trim());
                            float pt_vat = float.Parse(drTreat["pt_vat"].ToString().Trim());
                            DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString().Trim());
                            y = y + 1;
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Activity activity = new BusinessEntities.EClaims.ClaimSubmissionRequest.Activity();
                            activity.ID = drTreat["ptId"].ToString().Trim();
                            activity.Start = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + drTreat["app_doc_ftime"].ToString();
                            activity.Type = drTreat["tr_itype"].ToString().Trim();
                            activity.Code = drTreat["tr_code"].ToString().Trim();
                            activity.Location = "2";
                            activity.Quantity = drTreat["pt_qty"].ToString().Trim();
                            activity.Net = pt_net.ToString("0.00");

                            if (drTreat["emp_license"].ToString().Trim().Substring(0, 3).Equals("MOH"))
                            {
                                emp__license = drTreat["emp_license"].ToString().Substring(3, (drTreat["emp_license"].ToString().Length - 3));
                            }
                            else
                            {
                                emp__license = drTreat["emp_license"].ToString().Trim();
                            }

                            activity.Clinician = emp__license;
                            if (drTreat["tr_itype"].ToString().Trim() == "5")
                            {
                                activity.Duration = drTreat["pt_qty"].ToString().Trim();
                            }
                            if (drTreat["pt_auth_code"].ToString().Trim() != "")
                            {
                                if (drTreat["pt_auth_code"].ToString().Trim() != "Not Required")
                                {
                                    activity.PriorAuthorizationID = drTreat["pt_auth_code"].ToString().Trim();
                                }
                            }
                            List<BusinessEntities.EClaims.ClaimSubmissionRequest.Observation> ObservationMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Observation>();
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            DataTable dtTreat2 = new DataTable();
                            dtTreat2 = BusinessLogicLayer.EClaims.EClaims.GetPrescriptions(int.Parse(row["appId"].ToString()));
                            foreach (DataRow dtpresc in dtTreat2.Rows)
                            {
                                if (dtpresc["pre_eRxRefNo"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation1 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation1.Type = "ERX";
                                    observation1.Code = "eRxReferenceNo";
                                    observation1.Value = dtpresc["pre_eRxRefNo"].ToString().Trim();
                                    observation1.ValueType = "Reference";
                                    ObservationMain.Add(observation1);
                                }
                            }


                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation55 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            observation55.Type = "Text";
                            observation55.Code = "InvoiceNumber";
                            observation55.Value = row["inv_no"].ToString().Trim();
                            observation55.ValueType = "Text";
                            ObservationMain.Add(observation55);

                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation56 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            observation56.Type = "Text";
                            observation56.Code = "InvoiceDate";
                            observation56.Value = DateTime.Parse(row["inv_date"].ToString()).ToString("dd-MM-yyyy").Trim();
                            observation56.ValueType = "Date";
                            ObservationMain.Add(observation56);

                            if (drTreat["pt_teeth"].ToString().Trim() != "")
                            {
                                if (drTreat["pt_teeth"].ToString().Trim() != "NA")
                                {
                                    string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                    for (int j = 0; j < pt__teeth.Length; j++)
                                    {
                                        //MessageBox.Show(words[j]);
                                        if (pt__teeth[j].Trim() != "")
                                        {
                                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation91 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                            observation91.Type = "UniversalDental";
                                            observation91.Code = "UniversalNumberingSystemDental";
                                            observation91.Value = pt__teeth[j].Trim();
                                            observation91.ValueType = "ToothNumber";
                                            ObservationMain.Add(observation91);
                                        }
                                    }
                                }
                            }

                            if (drTreat["ti_image_1"].ToString().Trim() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno1"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation101 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation101.Type = "File";
                                    observation101.Code = "File";
                                    observation101.Value = drTreat["ti_img_refno1"].ToString().Trim();
                                    observation101.ValueType = "File";
                                    ObservationMain.Add(observation101);
                                }
                            }
                            if (drTreat["ti_image_2"].ToString().Trim() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation102 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation102.Type = "File";
                                    observation102.Code = "File";
                                    observation102.Value = drTreat["ti_img_refno2"].ToString().Trim();
                                    observation102.ValueType = "File";
                                    ObservationMain.Add(observation102);
                                }


                            }
                            if (drTreat["ti_image_3"].ToString().Trim() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation103 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation103.Type = "File";
                                    observation103.Code = "File";
                                    observation103.Value = drTreat["ti_img_refno3"].ToString().Trim();
                                    observation103.ValueType = "File";
                                    ObservationMain.Add(observation103);
                                }


                            }
                            if (drTreat["ti_image_4"].ToString().Trim() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation104 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation104.Type = "File";
                                    observation104.Code = "File";
                                    observation104.Value = drTreat["ti_img_refno4"].ToString().Trim();
                                    observation104.ValueType = "File";
                                    ObservationMain.Add(observation104);
                                }
                            }
                            if (drTreat["ti_image_5"].ToString().Trim() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation105 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation105.Type = "File";
                                    observation105.Code = "File";
                                    observation105.Value = drTreat["ti_img_refno5"].ToString().Trim();
                                    observation105.ValueType = "File";
                                    ObservationMain.Add(observation105);
                                }


                            }

                            if (drTreat["pt_notes"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation107 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation107.Type = "Text";
                                observation107.Code = "Description";
                                observation107.Value = drTreat["pt_notes"].ToString().Trim();
                                observation107.ValueType = "Other";
                                ObservationMain.Add(observation107);
                            }


                            if (!string.IsNullOrEmpty(drTreat["pt_offauth"].ToString().Trim()))
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observationOff = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observationOff.Type = "OfflineAuthorization";
                                observationOff.Code = "OfflineAuthorization";
                                observationOff.Value = drTreat["pt_offauth"].ToString().Trim();
                                observationOff.ValueType = "OfflineAuthorization";
                                ObservationMain.Add(observationOff);

                            }
                            if (drTreat["ti_loinc_1"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation57 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation57.Type = "LOINC";
                                observation57.Code = "LOINC"; ;
                                observation57.Value = drTreat["ti_loinc_1"].ToString().Trim();// drTreat["ti_loinc_2"].ToString();
                                observation57.ValueType = "LOINCcode";// drTreat["ti_loinc_3"].ToString();
                                ObservationMain.Add(observation57);
                            }

                            if (drTreat["ti_loinc_4"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation58 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation58.Type = "LOINC";
                                observation58.Code = "LOINC";
                                observation58.Value = drTreat["ti_loinc_4"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation58.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation58);

                            }

                            if (drTreat["ti_loinc_7"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation59 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation59.Type = "LOINC";
                                observation59.Code = "LOINC";
                                observation59.Value = drTreat["ti_loinc_7"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation59.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation59);


                            }

                            if (drTreat["ti_loinc_10"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation60 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation60.Type = "LOINC";
                                observation60.Code = "LOINC";
                                observation60.Value = drTreat["ti_loinc_10"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation60.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation60);

                            }

                            if (drTreat["ti_loinc_13"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation61 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation61.Type = "LOINC";
                                observation61.Code = "LOINC";
                                observation61.Value = drTreat["ti_loinc_13"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation61.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation61);

                            }

                            // LOINC CODES ENDS

                            if ((drTreat["tr_code"].ToString().Trim() == "9") || (drTreat["tr_code"].ToString().Trim() == "10") || (drTreat["tr_code"].ToString().Trim() == "11") || (drTreat["tr_code"].ToString().Trim() == "9.1") || (drTreat["tr_code"].ToString().Trim() == "10.1") || (drTreat["tr_code"].ToString().Trim() == "11.1"))
                            {
                                if (drTreat["ti_lab_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation2 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation2.Type = "Text";
                                    observation2.Code = "Description";
                                    observation2.Value = "BPS– (Result =" + drTreat["ti_lab_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation2.ValueType = "Other";
                                    ObservationMain.Add(observation2);
                                }
                                if (drTreat["ti_lab_9"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation3 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();

                                    observation3.Type = "Text";
                                    observation3.Code = "Description";
                                    observation3.Value = "BPD– (Result =" + drTreat["ti_lab_9"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation3.ValueType = "Other";
                                    ObservationMain.Add(observation3);
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "82565")
                            {
                                if (drTreat["ti_lab_7"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation4 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation4.Type = "Text";
                                    observation4.Code = "Description";
                                    observation4.Value = "CR– (Result =" + drTreat["ti_lab_7"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation4.ValueType = "Other";
                                    ObservationMain.Add(observation4);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "82043")
                            {
                                if (drTreat["ti_lab_6"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation5 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation5.Type = "Text";
                                    observation5.Code = "Description";
                                    observation5.Value = "UA– (Result =" + drTreat["ti_lab_6"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation5.ValueType = "Other";
                                    ObservationMain.Add(observation5);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "84478")
                            {
                                if (drTreat["ti_lab_5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation6 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation6.Type = "Text";
                                    observation6.Code = "Description";
                                    observation6.Value = "TRIG– (Result =" + drTreat["ti_lab_5"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation6.ValueType = "Other";
                                    ObservationMain.Add(observation6);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "83721")
                            {
                                if (drTreat["ti_lab_4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation7 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation7.Type = "Text";
                                    observation7.Code = "Description";
                                    observation7.Value = "LDL– (Result =" + drTreat["ti_lab_4"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation7.ValueType = "Other";
                                    ObservationMain.Add(observation7);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "83718")
                            {
                                if (drTreat["ti_lab_3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation8 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation8.Type = "Text";
                                    observation8.Code = "Description";
                                    observation8.Value = "HDL– (Result =" + drTreat["ti_lab_3"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation8.ValueType = "Other";
                                    ObservationMain.Add(observation8);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "82465")
                            {
                                if (drTreat["ti_lab_2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation9 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation9.Type = "Text";
                                    observation9.Code = "Description";
                                    observation9.Value = "CHOL– (Result =" + drTreat["ti_lab_2"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation9.ValueType = "Other";
                                    ObservationMain.Add(observation9);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "80061")
                            {
                                if (drTreat["ti_lab_2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation31 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation31.Type = "Text";
                                    observation31.Code = "Description";
                                    observation31.Value = "CHOL– (Result =" + drTreat["ti_lab_2"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation31.ValueType = "Other";
                                    ObservationMain.Add(observation31);
                                }
                                if (drTreat["ti_lab_3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation10 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation10.Type = "Text";
                                    observation10.Code = "Description";
                                    observation10.Value = "HDL– (Result =" + drTreat["ti_lab_3"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation10.ValueType = "Other";
                                    ObservationMain.Add(observation10);
                                }
                                if (drTreat["ti_lab_4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation11 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation11.Type = "Text";
                                    observation11.Code = "Description";
                                    observation11.Value = "LDL– (Result =" + drTreat["ti_lab_4"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation11.ValueType = "Other";
                                    ObservationMain.Add(observation11);
                                }

                                if (drTreat["ti_lab_5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation12 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation12.Type = "Text";
                                    observation12.Code = "Description";
                                    observation12.Value = "TRIG– (Result =" + drTreat["ti_lab_5"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation12.ValueType = "Other";
                                    ObservationMain.Add(observation12);

                                }
                                if (drTreat["ti_image_7"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation30 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation30.Type = "Text";
                                    observation30.Code = "Description";
                                    observation30.Value = "NONHDL– (Result =" + drTreat["ti_image_7"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation30.ValueType = "Other";
                                    ObservationMain.Add(observation30);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "83036")
                            {
                                if (drTreat["ti_lab_1"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation13 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation13.Type = "Text";
                                    observation13.Code = "Description";
                                    observation13.Value = "A1c– (Result =" + drTreat["ti_lab_1"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation13.ValueType = "Other";
                                    ObservationMain.Add(observation13);
                                }
                            }

                            if (diag__codes.Contains("E66.9") == true)
                            {
                                if (drTreat["ti_lab_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation14 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation14.Type = "Text";
                                    observation14.Code = "Description";
                                    observation14.Value = "BMI– (Result =" + drTreat["ti_lab_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation14.ValueType = "Other";
                                    ObservationMain.Add(observation14);
                                }
                            }
                            if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation15 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation15.Type = "Text";
                                    observation15.Code = "Description";
                                    observation15.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation15.ValueType = "Other";
                                    ObservationMain.Add(observation15);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                            {
                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation16 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation16.Type = "Text";
                                    observation16.Code = "Description";
                                    observation16.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation16.ValueType = "Other";
                                    ObservationMain.Add(observation16);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation17 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation17.Type = "Text";
                                    observation17.Code = "Description";
                                    observation17.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation17.ValueType = "Other";
                                    ObservationMain.Add(observation17);
                                }
                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation18 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation18.Type = "Text";
                                    observation18.Code = "Description";
                                    observation18.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation18.ValueType = "Other";
                                    ObservationMain.Add(observation18);

                                }
                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation19 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation19.Type = "Text";
                                    observation19.Code = "Description";
                                    observation19.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation19.ValueType = "Other";
                                    ObservationMain.Add(observation19);
                                }
                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation20 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation20.Type = "Text";
                                    observation20.Code = "Description";
                                    observation20.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation20.ValueType = "Other";
                                    ObservationMain.Add(observation20);
                                }
                                if (drTreat["ti_image_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation32 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation32.Type = "Text";
                                    observation32.Code = "Description";
                                    observation32.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation32.ValueType = "Other";
                                    ObservationMain.Add(observation32);
                                }
                                if (drTreat["ti_image_9"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation33 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation33.Type = "Text";
                                    observation33.Code = "Description";
                                    observation33.Value = "DirectBilirubin– (Result =" + drTreat["ti_image_9"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation33.ValueType = "Other";
                                    ObservationMain.Add(observation33);
                                }
                                if (drTreat["ti_image_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation34 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation34.Type = "Text";
                                    observation34.Code = "Description";
                                    observation34.Value = "TotalProtein– (Result =" + drTreat["ti_image_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation34.ValueType = "Other";
                                    ObservationMain.Add(observation34);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString().Trim() == "84460"))
                            {
                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation21 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation21.Type = "Text";
                                    observation21.Code = "Description";
                                    observation21.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation21.ValueType = "Other";
                                    ObservationMain.Add(observation21);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString().Trim() == "84450"))
                            {
                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation22 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation22.Type = "Text";
                                    observation22.Code = "Description";
                                    observation22.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation22.ValueType = "Other";
                                    ObservationMain.Add(observation22);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82947")) //((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) &&
                            {
                                if (drTreat["ti_lab_15"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation23 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation23.Type = "Text";
                                    observation23.Code = "Description";
                                    observation23.Value = "FBS– (Result =" + drTreat["ti_lab_15"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation23.ValueType = "Other";
                                    ObservationMain.Add(observation23);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82947"))
                            {
                                if (drTreat["ti_lab_16"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation24 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation24.Type = "Text";
                                    observation24.Code = "Description";
                                    observation24.Value = "RBS– (Result =" + drTreat["ti_lab_16"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation24.ValueType = "Other";
                                    ObservationMain.Add(observation24);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82950"))
                            {
                                if (drTreat["ti_lab_16"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation25 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation25.Type = "Text";
                                    observation25.Code = "Description";
                                    observation25.Value = "PPBS– (Result =" + drTreat["ti_lab_16"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation25.ValueType = "Other";
                                    ObservationMain.Add(observation25);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "80076")
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation26 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation26.Type = "Text";
                                    observation26.Code = "Description";
                                    observation26.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation26.ValueType = "Other";
                                    ObservationMain.Add(observation26);
                                }

                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation27 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation27.Type = "Text";
                                    observation27.Code = "Description";
                                    observation27.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation27.ValueType = "Other";
                                    ObservationMain.Add(observation27);
                                }

                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation28 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation28.Type = "Text";
                                    observation28.Code = "Description";
                                    observation28.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation28.ValueType = "Other";
                                    ObservationMain.Add(observation28);
                                }

                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation29 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation29.Type = "Text";
                                    observation29.Code = "Description";
                                    observation29.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation29.ValueType = "Other";
                                    ObservationMain.Add(observation29);
                                }

                                if (drTreat["ti_image_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation35 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation35.Type = "Text";
                                    observation35.Code = "Description";
                                    observation35.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation35.ValueType = "Other";
                                    ObservationMain.Add(observation35);

                                }

                                if (drTreat["ti_image_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation36 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation36.Type = "Text";
                                    observation36.Code = "Description";
                                    observation36.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation36.ValueType = "Other";
                                    ObservationMain.Add(observation36);
                                }
                            }


                            activity.Observation = ObservationMain;
                            ActivityMain.Add(activity);
                        }
                        claims.Activity = ActivityMain;

                        ClaimMain.Add(claims);
                    }
                    submission.Claim = ClaimMain;
                    submission_request.Submission = submission;

                    string myDeserializedClass = JsonConvert.SerializeObject(submission_request);


                    var empclaims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_name = empclaims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                    string file_name = "EMC_Sub_" + emp_name + "_" + s_date_from.ToString("ddMMyyyyhhsstt") + "_" + ic_insurance_name + ".json";


                    string atr = "";


                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    var options = new RestClientOptions(strApiUrl)
                    {
                        MaxTimeout = -1,
                    };

                    var client = new RestClient(options);
                    var request = new RestRequest("Claim/PostSubmission", Method.Post);

                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("username", strUsername);
                    request.AddHeader("password", strPassword);
                    request.AddParameter("application/json", myDeserializedClass, ParameterType.RequestBody);

                    RestResponse response = await client.ExecuteAsync(request);

                    ClaimSubmissionRequest.Submission_response result = JsonConvert.DeserializeObject<ClaimSubmissionRequest.Submission_response>(response.Content);
                    string rpath = Server.MapPath("~/submissions/GeneratedXmls/Riyati/Direct/Response/");

                    if (!Directory.Exists(rpath))
                    {
                        Directory.CreateDirectory(rpath);
                    }

                    System.IO.File.WriteAllText(Path.Combine(rpath, filename), response.Content.ToString());

                    bool isSubmitted = false;
                    string mesg = result.Message;

                    if (result.StatusCode == "201")
                    {
                        if (s_flag == "PRODUCTION")
                        {
                            int eclId = 0;
                            int uinv_id = 0;

                            string FolderPath = Server.MapPath("~/submissions/GeneratedXmls/Riyati/Direct/Sub_" + file_name);
                            eclId = BusinessLogicLayer.EClaims.EClaims.eClaim_Insert(s_ic_id, s_date_from, s_date_to, file_name, FolderPath, result.UserMessage);
                            if (eclId > 0)
                            {
                                if (s_flag == "PRODUCTION")
                                {
                                    uinv_id = BusinessLogicLayer.EClaims.EClaims.SP_UpdateInvoiceStatus(inv_ids);
                                }
                                isSubmitted = true;

                                mesg = "Selected Treatment(s) submitted for eAuthorization Successfully!";
                            }
                            else
                            {
                                return Json(new { isSuccess = false, message = result.Message }, JsonRequestBehavior.AllowGet);
                                //mesg = "Error while Creating eAuthorization for Treatment(s)!";
                            }
                        }
                        else
                        {
                            isSubmitted = true;

                            mesg = "Selected Treatment(s) submitted for eAuthorization Successfully in " + s_flag + " Mode!";
                        }

                        return Json(new { isSuccess = isSubmitted, message = mesg, response = result }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        int count = 1;
                        string ErrMsg = string.Empty;
                        foreach (var err in result.Error)
                        {
                            string ErrMsg1 = " " + count + "." + err.ErrorText + ".";
                            mesg += ErrMsg1;
                            count = count + 1;
                        }
                        foreach (var err in result.Error)
                        {
                            // string ErrMsg = " " + count + ". In " + err.Reference + "," + err.AdditionalReferenceObjectName + "," + err.ErrorText + ".";
                            //    lblErrorMessage.Text += ErrMsg;


                            ErrMsg = "<p style=\"font-size:14px\">" + count;

                            if (!string.IsNullOrEmpty(err.Reference))
                            {
                                ErrMsg += " &nbsp;<b style=\"color:red;\"> Reference:</b>" + err.Reference + ".";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReference))
                            {
                                ErrMsg += "<b style=\"color:red;\">AdditionalReference:</b>" + err.AdditionalReference + ".";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReferenceObjectName))
                            {
                                ErrMsg += "<b style=\"color:red;\">AdditionalReferenceObjectName:</b>" + err.AdditionalReferenceObjectName + ".";
                            }
                            if (!string.IsNullOrEmpty(err.ErrorText))
                            {
                                ErrMsg += "<b style=\"color:red;\">ErrorText:</b>" + err.ErrorText + ".";
                            }
                            if (!string.IsNullOrEmpty(err.ObjectName))
                            {
                                ErrMsg += "<b style=\"color:red;\">ObjectName:</b>" + err.ObjectName + ".";
                            }
                            ErrMsg += "</p>";
                            //lblError.InnerHtml += ErrMsg;
                            count = count + 1;
                        }
                        return Json(new { isSuccess = isSubmitted, message = mesg, response = ErrMsg }, JsonRequestBehavior.AllowGet);
                    }


                    Response.AppendHeader("'Content-Disposition'", "'attachment; filename='" + file_name + "'");

                    Response.AppendHeader("Content-Length", myDeserializedClass.Length.ToString());
                    Response.ContentType = "text/xml";
                    Response.Write(myDeserializedClass.ToString());
                    Response.End();
                    return Json(new { isSuccess = true, message = atr }, JsonRequestBehavior.AllowGet);
                    //byte[] fileBytes = Encoding.UTF8.GetBytes(myDeserializedClass);
                    // return File(fileBytes, "application/json", file_name);
                }
                catch (WebException ex)
                {
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());

                    // Read the content.
                    string responseFromServer = sr.ReadToEnd();

                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_response result1 = JsonConvert.DeserializeObject<BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_response>(responseFromServer);
                    if (result1.StatusCode == "400")
                    {
                        int count = 1;
                        foreach (var err in result1.Error)
                        {
                            // string ErrMsg = " " + count + ". In " + err.Reference + "," + err.AdditionalReferenceObjectName + "," + err.ErrorText + ".";
                            //    lblErrorMessage.Text += ErrMsg;
                            string ErrMsg = string.Empty;

                            ErrMsg = "<p style=\"font-size:14px\">" + count;

                            if (!string.IsNullOrEmpty(err.Reference))
                            {
                                ErrMsg += " &nbsp;<b style=\"color:red;\"> Reference:</b>" + err.Reference + ".";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReference))
                            {
                                ErrMsg += "<b style=\"color:red;\">AdditionalReference:</b>" + err.AdditionalReference + ".";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReferenceObjectName))
                            {
                                ErrMsg += "<b style=\"color:red;\">AdditionalReferenceObjectName:</b>" + err.AdditionalReferenceObjectName + ".";
                            }
                            if (!string.IsNullOrEmpty(err.ErrorText))
                            {
                                ErrMsg += "<b style=\"color:red;\">ErrorText:</b>" + err.ErrorText + ".";
                            }
                            if (!string.IsNullOrEmpty(err.ObjectName))
                            {
                                ErrMsg += "<b style=\"color:red;\">ObjectName:</b>" + err.ObjectName + ".";
                            }
                            ErrMsg += "</p>";
                            //lblError.InnerHtml += ErrMsg;
                            count = count + 1;

                            return Json(new { isSuccess = false, message = ErrMsg }, JsonRequestBehavior.AllowGet);
                        }
                        return Json(new { isSuccess = false, message = result1.UserMessage }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = result1.UserMessage }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GenerateHAADPersonRegisterManual(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    DateTime TransactionDate = DateTime.Now;
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                    dt = ds.Tables[0];
                    DataTable dt_signs = ds.Tables[0];
                    string file_name = Server.MapPath("~/submissions/GeneratedXmls/HAAD/Person_Register/Manual/Person_Register-" + dt.Rows[0]["set_permit_no"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + ".xml").Replace(" ", ""); // Specify the output filename

                    //StringWriter stringWriter = new StringWriter();
                    XmlTextWriter writer = new XmlTextWriter(file_name, System.Text.Encoding.UTF8);
                    //XmlTextWriter writer = new XmlTextWriter(System.Text.Encoding.UTF8);
                    writer.Formatting = System.Xml.Formatting.Indented;

                    // Start Claim.Submission element


                    if (dt_signs.Rows.Count > 0)
                    {
                        writer.WriteStartDocument();
                        string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                        DataRow dr = dt.Rows[0];
                        writer.WriteStartElement("Person.Register");
                        writer.WriteAttributeString("xmlns:tns", "http://www.haad.ae/DataDictionary/CommonTypes");
                        writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                        writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "http://www.haad.ae/DataDictionary/CommonTypes/DataDictionary.xsd");
                        writer.WriteStartElement("Header");
                        // Write Header elements
                        writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                        writer.WriteElementString("ReceiverID", "HAAD");
                        writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        writer.WriteElementString("RecordCount", no_of_claims.ToString());
                        writer.WriteElementString("DispositionFlag", s_flag);
                        // End Header element
                        writer.WriteEndElement();
                        string patIds = "";
                        int x = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            x = x + 1;
                            string unified_no = row["pat_emirateid"].ToString().Replace("-", "");
                            string pat_name = row["pat_name"].ToString();
                            string pat_lname = row["pat_lname"].ToString();
                            string pat_mob = row["pat_mob"].ToString();

                            DateTime pat__dob = DateTime.Parse(row["pat_dob"].ToString());
                            string pat_dob = pat__dob.ToString("dd/MM/yyyy");

                            string pat_gender = row["pat_gender"].ToString();
                            string pat_nationality = row["nationality"].ToString();
                            string pat_city = row["pat_city"].ToString();
                            string pat_country_res_name = row["country"].ToString();
                            // string pat_emirates_res_name = row["pat_emirates_res"].ToString();
                            // string pat_passport_no = row["pat_passport_no"].ToString();
                            string emiratesId = row["pat_emirateid"].ToString();
                            string pat_code = row["pat_code"].ToString();

                            patIds = patIds + "," + row["patId"].ToString();



                            writer.WriteStartElement("Person");
                            if ((unified_no != "") && (unified_no != "0"))
                            {
                                writer.WriteElementString("UnifiedNumber", unified_no);
                            }
                            writer.WriteElementString("FirstName", pat_name);
                            writer.WriteElementString("FirstNameEn", pat_name);
                            writer.WriteElementString("LastNameEn", pat_lname);
                            writer.WriteElementString("ContactNumber", pat_mob);
                            writer.WriteElementString("BirthDate", pat_dob);

                            if (pat_gender == "Male")
                            {
                                writer.WriteElementString("Gender", "1");
                            }
                            else if (pat_gender == "Female")
                            {
                                writer.WriteElementString("Gender", "0");
                            }
                            else
                            {
                                writer.WriteElementString("Gender", "9");
                            }
                            writer.WriteElementString("Nationality", pat_nationality);
                            writer.WriteElementString("City", pat_city);
                            if (pat_country_res_name != "")
                            {
                                writer.WriteElementString("CountryOfResidence", pat_country_res_name);
                            }
                            if (pat_country_res_name == "United Arab Emirates")
                            {
                                writer.WriteElementString("EmirateOfResidence", "1");
                            }

                            if ((emiratesId != "") && (emiratesId != "0"))
                            {
                                writer.WriteElementString("EmiratesIDNumber", emiratesId);
                            }
                            writer.WriteStartElement("Member");
                            writer.WriteElementString("ID", dr["set_permit_no"].ToString() + "#" + pat_code);
                            writer.WriteEndElement();
                            writer.WriteEndElement();


                        }
                        // End Person.Register element
                        writer.WriteEndElement();
                        // End Document
                        writer.WriteEndDocument();
                        // string val= stringWriter.ToString();
                        writer.Flush();
                        writer.Close();
                        byte[] fileContent = null;
                        string fileName = Path.Combine(file_name);
                        System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(fileName).Length;
                        fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();
                        return new FileContentResult(fileContent, "application/xml");

                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Please select Treatments" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult GenerateHAADPersonRegisterDirect(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    DateTime TransactionDate = DateTime.Now;
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                    dt = ds.Tables[0];
                    DataTable dt_signs = ds.Tables[0];
                    string file_name = Server.MapPath("~/submissions/GeneratedXmls/HAAD/Person_Register/Manual/Person_Register-" + dt.Rows[0]["set_permit_no"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + ".xml").Replace(" ", ""); // Specify the output filename

                    //StringWriter stringWriter = new StringWriter();
                    XmlTextWriter writer = new XmlTextWriter(file_name, System.Text.Encoding.UTF8);
                    //XmlTextWriter writer = new XmlTextWriter(System.Text.Encoding.UTF8);
                    writer.Formatting = System.Xml.Formatting.Indented;

                    // Start Claim.Submission element


                    if (dt_signs.Rows.Count > 0)
                    {
                        writer.WriteStartDocument();
                        string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                        DataRow dr = dt.Rows[0];
                        writer.WriteStartElement("Person.Register");
                        writer.WriteAttributeString("xmlns:tns", "http://www.haad.ae/DataDictionary/CommonTypes");
                        writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                        writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "http://www.haad.ae/DataDictionary/CommonTypes/DataDictionary.xsd");
                        writer.WriteStartElement("Header");
                        // Write Header elements
                        writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                        writer.WriteElementString("ReceiverID", "HAAD");
                        writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        writer.WriteElementString("RecordCount", no_of_claims.ToString());
                        writer.WriteElementString("DispositionFlag", s_flag);
                        // End Header element
                        writer.WriteEndElement();
                        string patIds = "";
                        int x = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            x = x + 1;
                            string unified_no = row["pat_emirateid"].ToString().Replace("-", "");
                            string pat_name = row["pat_name"].ToString();
                            string pat_lname = row["pat_lname"].ToString();
                            string pat_mob = row["pat_mob"].ToString();

                            DateTime pat__dob = DateTime.Parse(row["pat_dob"].ToString());
                            string pat_dob = pat__dob.ToString("dd/MM/yyyy");

                            string pat_gender = row["pat_gender"].ToString();
                            string pat_nationality = row["nationality"].ToString();
                            string pat_city = row["pat_city"].ToString();
                            string pat_country_res_name = row["country"].ToString();
                            // string pat_emirates_res_name = row["pat_emirates_res"].ToString();
                            // string pat_passport_no = row["pat_passport_no"].ToString();
                            string emiratesId = row["pat_emirateid"].ToString();
                            string pat_code = row["pat_code"].ToString();

                            patIds = patIds + "," + row["patId"].ToString();



                            writer.WriteStartElement("Person");
                            if ((unified_no != "") && (unified_no != "0"))
                            {
                                writer.WriteElementString("UnifiedNumber", unified_no);
                            }
                            writer.WriteElementString("FirstName", pat_name);
                            writer.WriteElementString("FirstNameEn", pat_name);
                            writer.WriteElementString("LastNameEn", pat_lname);
                            writer.WriteElementString("ContactNumber", pat_mob);
                            writer.WriteElementString("BirthDate", pat_dob);

                            if (pat_gender == "Male")
                            {
                                writer.WriteElementString("Gender", "1");
                            }
                            else if (pat_gender == "Female")
                            {
                                writer.WriteElementString("Gender", "0");
                            }
                            else
                            {
                                writer.WriteElementString("Gender", "9");
                            }
                            writer.WriteElementString("Nationality", pat_nationality);
                            writer.WriteElementString("City", pat_city);
                            if (pat_country_res_name != "")
                            {
                                writer.WriteElementString("CountryOfResidence", pat_country_res_name);
                            }
                            if (pat_country_res_name == "United Arab Emirates")
                            {
                                writer.WriteElementString("EmirateOfResidence", "1");
                            }

                            if ((emiratesId != "") && (emiratesId != "0"))
                            {
                                writer.WriteElementString("EmiratesIDNumber", emiratesId);
                            }
                            writer.WriteStartElement("Member");
                            writer.WriteElementString("ID", dr["set_permit_no"].ToString() + "#" + pat_code);
                            writer.WriteEndElement();
                            writer.WriteEndElement();


                        }
                        // End Person.Register element
                        writer.WriteEndElement();
                        // End Document
                        writer.WriteEndDocument();
                        // string val= stringWriter.ToString();
                        writer.Flush();
                        writer.Close();
                        string filename = "Person_Register" + "-" + dr["set_permit_no"].ToString() + ".xml".Replace(" ", "");
                        string eClaim_ErrorMessage = "";
                        byte[] eClaim_ErrorReport = new byte[99];
                        string eClaim_TransactionId = "";
                        ae.gov.doh.shafafiya.Webservices e_Claim = new ae.gov.doh.shafafiya.Webservices();
                        e_Claim.UploadTransaction(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), Encoding.UTF8.GetBytes(writer.ToString()), file_name, out eClaim_ErrorMessage, out eClaim_ErrorReport, out eClaim_TransactionId);

                        TempData["ErrorMessage"] = eClaim_ErrorMessage;
                        string atr = "";
                        if (eClaim_ErrorMessage.Contains("successful") == false)
                        {
                            if (eClaim_ErrorMessage.Contains("invalid") == false)
                            {
                                if (eClaim_ErrorMessage.Contains("input") == false)
                                {
                                    string fileName = "~/submissions/HAAD/Person_Register/Error/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls".Replace(" ", "");
                                    using (FileStream destFile = System.IO.File.Open(Server.MapPath(fileName), FileMode.Create))
                                    {
                                        destFile.Write(eClaim_ErrorReport, 0, eClaim_ErrorReport.Length);
                                    }

                                    string atr1 = "Error Msg: " + eClaim_ErrorMessage + " Error Report <a href='/submissions/HAAD/Person_Register/Error/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls' class='fs-25 text-primary font-weight-bold text-center'><i class='fa fa-file-archive-o text-white'></i ></a>";
                                    atr = HttpUtility.HtmlDecode(atr1);
                                }
                                else
                                {
                                    atr = "Error Msg: " + eClaim_ErrorMessage;
                                }
                            }
                            else
                            {
                                atr = "Error Msg: " + eClaim_ErrorMessage;
                            }
                        }
                        else
                        {
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                            Response.AppendHeader("Content-Length", writer.ToString().Length.ToString());
                            Response.ContentType = "text/xml";
                            Response.Write(writer.ToString());
                            Response.End();
                        }
                        return Json(atr, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Please select Treatments" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult GenerateRiyatiFullJSONDownload(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();

                string ic_insurance_name = "";
                DateTime cliam__date = s_date_from;
                DateTime TransactionDate = DateTime.Now;
                Dictionary<string, string> errors = new Dictionary<string, string>();
                int madeby = PageControl.getLoggedinId();
                int val = 0;
                DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                dt = ds.Tables[0];
                DataTable dt_signs = ds.Tables[0];
                string ins_clinic_code = "";
                string ic_name = "";
                string filename = Server.MapPath("~/submissions/GeneratedXmls/Riyati/Manual/Sub_" + dt.Rows[0]["set_sat_ftime"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + ".xml").Replace(" ", ""); // Specify the output filename
                string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                try
                {
                    int day = DateTime.Parse(DateTime.Now.ToString()).Day;
                    int month = DateTime.Parse(DateTime.Now.ToString()).Month;
                    int hour = DateTime.Now.Hour;
                    int minute = DateTime.Now.Minute;
                    int second = DateTime.Now.Second;
                    string day_value = "";
                    string month_value = "";
                    string hour_value = "";
                    string minute_value = "";
                    string second_value = "";
                    if (day < 10)
                    {
                        day_value = "0" + day.ToString();
                    }
                    else
                    {
                        day_value = day.ToString();
                    }

                    if (month < 10)
                    {
                        month_value = "0" + month.ToString();
                    }
                    else
                    {
                        month_value = month.ToString();
                    }

                    if (hour < 10)
                    {
                        hour_value = "0" + hour.ToString();
                    }
                    else
                    {
                        hour_value = hour.ToString();
                    }

                    if (minute < 10)
                    {
                        minute_value = "0" + minute.ToString();
                    }
                    else
                    {
                        minute_value = minute.ToString();
                    }

                    if (second < 10)
                    {
                        second_value = "0" + second.ToString();
                    }
                    else
                    {
                        second_value = second.ToString();
                    }

                    string Tr__date = day_value + "/" + month_value + "/" + DateTime.Now.Year + " " + hour_value + ":" + minute_value;


                    string emp__license = string.Empty;
                    string FacilityId = dt.Rows[0]["set_sat_ftime"].ToString();
                    string strUsername = ConfigurationManager.AppSettings["RiayatiPOUsername"].ToString();
                    string strPassword = ConfigurationManager.AppSettings["RiayatiPOPassword"].ToString();
                    string strApiUrl = ConfigurationManager.AppSettings["RiayatiAPIUrl"].ToString();
                    string strEmiratesId = string.Empty;

                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_Request submission_request = new BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_Request();
                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission submission = new BusinessEntities.EClaims.ClaimSubmissionRequest.Submission();

                    BusinessEntities.EClaims.ClaimSubmissionRequest.Header header = new BusinessEntities.EClaims.ClaimSubmissionRequest.Header();

                    ///Adding Header

                    header.SenderID = FacilityId;
                    if (ic_names == "'Cash'")
                    {
                        header.ReceiverID = "MOHAP";
                    }
                    else
                    {
                        header.ReceiverID = ins_code.Trim();
                    }
                    header.TransactionDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    header.RecordCount = no_of_claims.ToString().Trim();
                    header.DispositionFlag = s_flag;
                    header.PayerID = dt.Rows[0]["inv_ic_payercode"].ToString().Trim();

                    submission.Header = header;

                    int i = 0;
                    string invmIds = "";
                    List<BusinessEntities.EClaims.ClaimSubmissionRequest.Claim> ClaimMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Claim>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BusinessEntities.EClaims.ClaimSubmissionRequest.Claim claims = new BusinessEntities.EClaims.ClaimSubmissionRequest.Claim();

                        i = i + 1;
                        //float inv_total = float.Parse(row["inv_total"].ToString());
                        float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        float inv_net_cash = float.Parse(row["inv_net"].ToString().Trim());
                        float inv_vat = float.Parse(row["inv_vat"].ToString().Trim());
                        //float inv_net = float.Parse(row["inv_net"].ToString());
                        float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                        float inv_copay = float.Parse(row["inv_copay"].ToString().Trim());
                        float inv_share = float.Parse(row["inv_share"].ToString().Trim());
                        float pat_share = 0;

                        if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                        {
                            pat_share = inv_tded + inv_copay + inv_share;
                        }
                        else
                        {
                            pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        }

                        float inv_total = inv_net_cash + pat_share;

                        string ins_no = row["pi_insno"].ToString().Trim();
                        string claim_no = row["inv_claimno"].ToString().Trim();
                        string policy_no = row["inv_pi_polocyno"].ToString().Trim();
                        string inv_no = row["inv_no"].ToString().Trim();
                        ins_clinic_code = row["inv_ic_payercode"].ToString().Trim();

                        invmIds = invmIds + "," + row["invId"].ToString();

                        ic_insurance_name = row["ic_name"].ToString().Trim();
                        ic_name = row["inv_insurance_name"].ToString().Trim();
                        DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                        DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                        int d_ay = app__fdate.Day;
                        string d__ay = "";
                        if (d_ay < 10)
                        {
                            d__ay = "0" + d_ay.ToString();
                        }
                        else
                        {
                            d__ay = d_ay.ToString();
                        }

                        int m_onth = app__fdate.Month;
                        string m__onth = "";
                        if (m_onth < 10)
                        {
                            m__onth = "0" + m_onth.ToString();
                        }
                        else
                        {
                            m__onth = m_onth.ToString();
                        }

                        claims.ID = inv_no;
                        if (ins_clinic_code != "INS200")
                        {
                            claims.IDPayer = ins_clinic_code;
                        }
                        claims.Type = "Submission";

                        claims.MemberId = ins_no.Trim();
                        claims.ProviderID = FacilityId;

                        if (!string.IsNullOrEmpty(row["pat_emirateid"].ToString().Trim()) && (row["pat_emirateid"].ToString().Trim().Length == 15))
                        {

                            claims.NationalIDNumber = row["pat_emirateid"].ToString().Substring(0, 3) + "-" + row["pat_emirateid"].ToString().Substring(3, 4) + "-" + row["pat_emirateid"].ToString().Substring(7, 7) + "-" + row["pat_emirateid"].ToString().Substring(14);
                        }
                        else if (!string.IsNullOrEmpty(row["pat_emirateid"].ToString().Trim()) && (row["pat_emirateid"].ToString().Trim().Length == 18))
                        {

                            claims.NationalIDNumber = row["pat_emirateid"].ToString().Trim();
                        }
                        else
                        {
                            claims.NationalIDNumber = "999-9999-9999999-9";
                        }



                        claims.Gross = inv_total.ToString("0.00");
                        claims.PatientShare = pat_share.ToString("0.00");
                        claims.Net = inv_net.ToString("0.00");
                        claims.DateOfBirth = DateTime.Parse(row["pat_dob"].ToString()).ToString("dd/MM/yyyy HH:mm");
                        claims.Gender = row["pat_gender"].ToString().Trim();

                        BusinessEntities.EClaims.ClaimSubmissionRequest.Encounter encounter = new BusinessEntities.EClaims.ClaimSubmissionRequest.Encounter();
                        encounter.FacilityID = FacilityId;
                        encounter.Type = "1";
                        encounter.PatientID = row["pat_code"].ToString().Trim();
                        encounter.Start = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + row["app_doc_ftime"].ToString();
                        encounter.End = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + row["app_doc_ttime"].ToString();
                        encounter.StartType = "1";
                        encounter.EndType = "1";
                        //encounter.TransferSource =
                        //encounter.TransferDestination =
                        claims.Encounter = encounter;

                        List<BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis> DiagnosisMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis>();

                        DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(row["appId"].ToString()), 0);
                        string diag__codes = "";
                        foreach (DataRow drDiag in dtDiag.Rows)
                        {
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis diagnosis = new BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis();

                            if (drDiag["pad_type"].ToString() == "Primary")
                            {
                                diagnosis.Type = "Principal";
                            }
                            else
                            {
                                diagnosis.Type = "Secondary";
                            }
                            diag__codes = diag__codes + "," + drDiag["diag_code"].ToString().Trim();
                            diagnosis.Code = drDiag["diag_code"].ToString().Trim();

                            DiagnosisMain.Add(diagnosis);
                        }
                        claims.Diagnosis = DiagnosisMain;


                        //ACTIVITY

                        List<BusinessEntities.EClaims.ClaimSubmissionRequest.Activity> ActivityMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Activity>();
                        int y = 0;
                        DataTable dtTreat = new DataTable();
                        dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        foreach (DataRow drTreat in dtTreat.Rows)
                        {
                            float pt_net = float.Parse(drTreat["pt_net"].ToString().Trim());
                            float pt_vat = float.Parse(drTreat["pt_vat"].ToString().Trim());
                            DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString().Trim());
                            y = y + 1;
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Activity activity = new BusinessEntities.EClaims.ClaimSubmissionRequest.Activity();
                            activity.ID = drTreat["ptId"].ToString().Trim();
                            activity.Start = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + drTreat["app_doc_ftime"].ToString();
                            activity.Type = drTreat["tr_itype"].ToString().Trim();
                            activity.Code = drTreat["tr_code"].ToString().Trim();
                            activity.Location = "2";
                            activity.Quantity = drTreat["pt_qty"].ToString().Trim();
                            activity.Net = pt_net.ToString("0.00");

                            if (drTreat["emp_license"].ToString().Trim().Substring(0, 3).Equals("MOH"))
                            {
                                emp__license = drTreat["emp_license"].ToString().Substring(3, (drTreat["emp_license"].ToString().Length - 3));
                            }
                            else
                            {
                                emp__license = drTreat["emp_license"].ToString().Trim();
                            }

                            activity.Clinician = emp__license;
                            if (drTreat["tr_itype"].ToString().Trim() == "5")
                            {
                                activity.Duration = drTreat["pt_qty"].ToString().Trim();
                            }
                            if (drTreat["pt_auth_code"].ToString().Trim() != "")
                            {
                                if (drTreat["pt_auth_code"].ToString().Trim() != "Not Required")
                                {
                                    activity.PriorAuthorizationID = drTreat["pt_auth_code"].ToString().Trim();
                                }
                            }
                            List<BusinessEntities.EClaims.ClaimSubmissionRequest.Observation> ObservationMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Observation>();
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            DataTable dtTreat2 = new DataTable();
                            dtTreat2 = BusinessLogicLayer.EClaims.EClaims.GetPrescriptions(int.Parse(row["appId"].ToString()));
                            foreach (DataRow dtpresc in dtTreat2.Rows)
                            {
                                if (dtpresc["pre_eRxRefNo"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation1 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation1.Type = "ERX";
                                    observation1.Code = "eRxReferenceNo";
                                    observation1.Value = dtpresc["pre_eRxRefNo"].ToString().Trim();
                                    observation1.ValueType = "Reference";
                                    ObservationMain.Add(observation1);
                                }
                            }


                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation55 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            observation55.Type = "Text";
                            observation55.Code = "InvoiceNumber";
                            observation55.Value = row["inv_no"].ToString().Trim();
                            observation55.ValueType = "Text";
                            ObservationMain.Add(observation55);

                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation56 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            observation56.Type = "Text";
                            observation56.Code = "InvoiceDate";
                            observation56.Value = DateTime.Parse(row["inv_date"].ToString()).ToString("dd-MM-yyyy").Trim();
                            observation56.ValueType = "Date";
                            ObservationMain.Add(observation56);

                            if (drTreat["pt_teeth"].ToString().Trim() != "")
                            {
                                if (drTreat["pt_teeth"].ToString().Trim() != "NA")
                                {
                                    string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                    for (int j = 0; j < pt__teeth.Length; j++)
                                    {
                                        //MessageBox.Show(words[j]);
                                        if (pt__teeth[j].Trim() != "")
                                        {
                                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation91 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                            observation91.Type = "UniversalDental";
                                            observation91.Code = "UniversalNumberingSystemDental";
                                            observation91.Value = pt__teeth[j].Trim();
                                            observation91.ValueType = "ToothNumber";
                                            ObservationMain.Add(observation91);
                                        }
                                    }
                                }
                            }

                            if (drTreat["ti_image_1"].ToString().Trim() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno1"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation101 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation101.Type = "File";
                                    observation101.Code = "File";
                                    observation101.Value = drTreat["ti_img_refno1"].ToString().Trim();
                                    observation101.ValueType = "File";
                                    ObservationMain.Add(observation101);
                                }


                            }
                            if (drTreat["ti_image_2"].ToString().Trim() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation102 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation102.Type = "File";
                                    observation102.Code = "File";
                                    observation102.Value = drTreat["ti_img_refno2"].ToString().Trim();
                                    observation102.ValueType = "File";
                                    ObservationMain.Add(observation102);
                                }


                            }
                            if (drTreat["ti_image_3"].ToString().Trim() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation103 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation103.Type = "File";
                                    observation103.Code = "File";
                                    observation103.Value = drTreat["ti_img_refno3"].ToString().Trim();
                                    observation103.ValueType = "File";
                                    ObservationMain.Add(observation103);
                                }


                            }
                            if (drTreat["ti_image_4"].ToString().Trim() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation104 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation104.Type = "File";
                                    observation104.Code = "File";
                                    observation104.Value = drTreat["ti_img_refno4"].ToString().Trim();
                                    observation104.ValueType = "File";
                                    ObservationMain.Add(observation104);
                                }
                            }
                            if (drTreat["ti_image_5"].ToString().Trim() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation105 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation105.Type = "File";
                                    observation105.Code = "File";
                                    observation105.Value = drTreat["ti_img_refno5"].ToString().Trim();
                                    observation105.ValueType = "File";
                                    ObservationMain.Add(observation105);
                                }


                            }

                            if (drTreat["pt_notes"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation107 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation107.Type = "Text";
                                observation107.Code = "Description";
                                observation107.Value = drTreat["pt_notes"].ToString().Trim();
                                observation107.ValueType = "Other";
                                ObservationMain.Add(observation107);
                            }


                            if (!string.IsNullOrEmpty(drTreat["pt_offauth"].ToString().Trim()))
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observationOff = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observationOff.Type = "OfflineAuthorization";
                                observationOff.Code = "OfflineAuthorization";
                                observationOff.Value = drTreat["pt_offauth"].ToString().Trim();
                                observationOff.ValueType = "OfflineAuthorization";
                                ObservationMain.Add(observationOff);

                            }
                            if (drTreat["ti_loinc_1"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation57 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation57.Type = "LOINC";
                                observation57.Code = "LOINC"; ;
                                observation57.Value = drTreat["ti_loinc_1"].ToString().Trim();// drTreat["ti_loinc_2"].ToString();
                                observation57.ValueType = "LOINCcode";// drTreat["ti_loinc_3"].ToString();
                                ObservationMain.Add(observation57);
                            }

                            if (drTreat["ti_loinc_4"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation58 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation58.Type = "LOINC";
                                observation58.Code = "LOINC";
                                observation58.Value = drTreat["ti_loinc_4"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation58.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation58);

                            }

                            if (drTreat["ti_loinc_7"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation59 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation59.Type = "LOINC";
                                observation59.Code = "LOINC";
                                observation59.Value = drTreat["ti_loinc_7"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation59.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation59);


                            }

                            if (drTreat["ti_loinc_10"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation60 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation60.Type = "LOINC";
                                observation60.Code = "LOINC";
                                observation60.Value = drTreat["ti_loinc_10"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation60.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation60);

                            }

                            if (drTreat["ti_loinc_13"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation61 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation61.Type = "LOINC";
                                observation61.Code = "LOINC";
                                observation61.Value = drTreat["ti_loinc_13"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation61.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation61);

                            }

                            // LOINC CODES ENDS

                            if ((drTreat["tr_code"].ToString().Trim() == "9") || (drTreat["tr_code"].ToString().Trim() == "10") || (drTreat["tr_code"].ToString().Trim() == "11") || (drTreat["tr_code"].ToString().Trim() == "9.1") || (drTreat["tr_code"].ToString().Trim() == "10.1") || (drTreat["tr_code"].ToString().Trim() == "11.1"))
                            {
                                if (drTreat["ti_lab_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation2 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation2.Type = "Text";
                                    observation2.Code = "Description";
                                    observation2.Value = "BPS– (Result =" + drTreat["ti_lab_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation2.ValueType = "Other";
                                    ObservationMain.Add(observation2);
                                }
                                if (drTreat["ti_lab_9"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation3 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();

                                    observation3.Type = "Text";
                                    observation3.Code = "Description";
                                    observation3.Value = "BPD– (Result =" + drTreat["ti_lab_9"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation3.ValueType = "Other";
                                    ObservationMain.Add(observation3);
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "82565")
                            {
                                if (drTreat["ti_lab_7"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation4 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation4.Type = "Text";
                                    observation4.Code = "Description";
                                    observation4.Value = "CR– (Result =" + drTreat["ti_lab_7"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation4.ValueType = "Other";
                                    ObservationMain.Add(observation4);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "82043")
                            {
                                if (drTreat["ti_lab_6"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation5 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation5.Type = "Text";
                                    observation5.Code = "Description";
                                    observation5.Value = "UA– (Result =" + drTreat["ti_lab_6"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation5.ValueType = "Other";
                                    ObservationMain.Add(observation5);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "84478")
                            {
                                if (drTreat["ti_lab_5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation6 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation6.Type = "Text";
                                    observation6.Code = "Description";
                                    observation6.Value = "TRIG– (Result =" + drTreat["ti_lab_5"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation6.ValueType = "Other";
                                    ObservationMain.Add(observation6);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "83721")
                            {
                                if (drTreat["ti_lab_4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation7 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation7.Type = "Text";
                                    observation7.Code = "Description";
                                    observation7.Value = "LDL– (Result =" + drTreat["ti_lab_4"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation7.ValueType = "Other";
                                    ObservationMain.Add(observation7);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "83718")
                            {
                                if (drTreat["ti_lab_3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation8 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation8.Type = "Text";
                                    observation8.Code = "Description";
                                    observation8.Value = "HDL– (Result =" + drTreat["ti_lab_3"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation8.ValueType = "Other";
                                    ObservationMain.Add(observation8);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "82465")
                            {
                                if (drTreat["ti_lab_2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation9 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation9.Type = "Text";
                                    observation9.Code = "Description";
                                    observation9.Value = "CHOL– (Result =" + drTreat["ti_lab_2"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation9.ValueType = "Other";
                                    ObservationMain.Add(observation9);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "80061")
                            {
                                if (drTreat["ti_lab_2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation31 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation31.Type = "Text";
                                    observation31.Code = "Description";
                                    observation31.Value = "CHOL– (Result =" + drTreat["ti_lab_2"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation31.ValueType = "Other";
                                    ObservationMain.Add(observation31);
                                }
                                if (drTreat["ti_lab_3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation10 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation10.Type = "Text";
                                    observation10.Code = "Description";
                                    observation10.Value = "HDL– (Result =" + drTreat["ti_lab_3"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation10.ValueType = "Other";
                                    ObservationMain.Add(observation10);
                                }
                                if (drTreat["ti_lab_4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation11 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation11.Type = "Text";
                                    observation11.Code = "Description";
                                    observation11.Value = "LDL– (Result =" + drTreat["ti_lab_4"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation11.ValueType = "Other";
                                    ObservationMain.Add(observation11);
                                }

                                if (drTreat["ti_lab_5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation12 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation12.Type = "Text";
                                    observation12.Code = "Description";
                                    observation12.Value = "TRIG– (Result =" + drTreat["ti_lab_5"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation12.ValueType = "Other";
                                    ObservationMain.Add(observation12);

                                }
                                if (drTreat["ti_image_7"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation30 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation30.Type = "Text";
                                    observation30.Code = "Description";
                                    observation30.Value = "NONHDL– (Result =" + drTreat["ti_image_7"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation30.ValueType = "Other";
                                    ObservationMain.Add(observation30);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "83036")
                            {
                                if (drTreat["ti_lab_1"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation13 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation13.Type = "Text";
                                    observation13.Code = "Description";
                                    observation13.Value = "A1c– (Result =" + drTreat["ti_lab_1"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation13.ValueType = "Other";
                                    ObservationMain.Add(observation13);
                                }
                            }

                            if (diag__codes.Contains("E66.9") == true)
                            {
                                if (drTreat["ti_lab_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation14 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation14.Type = "Text";
                                    observation14.Code = "Description";
                                    observation14.Value = "BMI– (Result =" + drTreat["ti_lab_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation14.ValueType = "Other";
                                    ObservationMain.Add(observation14);
                                }
                            }
                            if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation15 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation15.Type = "Text";
                                    observation15.Code = "Description";
                                    observation15.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation15.ValueType = "Other";
                                    ObservationMain.Add(observation15);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                            {
                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation16 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation16.Type = "Text";
                                    observation16.Code = "Description";
                                    observation16.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation16.ValueType = "Other";
                                    ObservationMain.Add(observation16);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation17 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation17.Type = "Text";
                                    observation17.Code = "Description";
                                    observation17.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation17.ValueType = "Other";
                                    ObservationMain.Add(observation17);
                                }
                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation18 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation18.Type = "Text";
                                    observation18.Code = "Description";
                                    observation18.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation18.ValueType = "Other";
                                    ObservationMain.Add(observation18);

                                }
                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation19 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation19.Type = "Text";
                                    observation19.Code = "Description";
                                    observation19.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation19.ValueType = "Other";
                                    ObservationMain.Add(observation19);
                                }
                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation20 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation20.Type = "Text";
                                    observation20.Code = "Description";
                                    observation20.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation20.ValueType = "Other";
                                    ObservationMain.Add(observation20);
                                }
                                if (drTreat["ti_image_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation32 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation32.Type = "Text";
                                    observation32.Code = "Description";
                                    observation32.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation32.ValueType = "Other";
                                    ObservationMain.Add(observation32);
                                }
                                if (drTreat["ti_image_9"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation33 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation33.Type = "Text";
                                    observation33.Code = "Description";
                                    observation33.Value = "DirectBilirubin– (Result =" + drTreat["ti_image_9"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation33.ValueType = "Other";
                                    ObservationMain.Add(observation33);
                                }
                                if (drTreat["ti_image_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation34 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation34.Type = "Text";
                                    observation34.Code = "Description";
                                    observation34.Value = "TotalProtein– (Result =" + drTreat["ti_image_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation34.ValueType = "Other";
                                    ObservationMain.Add(observation34);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString().Trim() == "84460"))
                            {
                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation21 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation21.Type = "Text";
                                    observation21.Code = "Description";
                                    observation21.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation21.ValueType = "Other";
                                    ObservationMain.Add(observation21);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString().Trim() == "84450"))
                            {
                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation22 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation22.Type = "Text";
                                    observation22.Code = "Description";
                                    observation22.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation22.ValueType = "Other";
                                    ObservationMain.Add(observation22);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82947")) //((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) &&
                            {
                                if (drTreat["ti_lab_15"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation23 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation23.Type = "Text";
                                    observation23.Code = "Description";
                                    observation23.Value = "FBS– (Result =" + drTreat["ti_lab_15"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation23.ValueType = "Other";
                                    ObservationMain.Add(observation23);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82947"))
                            {
                                if (drTreat["ti_lab_16"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation24 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation24.Type = "Text";
                                    observation24.Code = "Description";
                                    observation24.Value = "RBS– (Result =" + drTreat["ti_lab_16"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation24.ValueType = "Other";
                                    ObservationMain.Add(observation24);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82950"))
                            {
                                if (drTreat["ti_lab_16"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation25 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation25.Type = "Text";
                                    observation25.Code = "Description";
                                    observation25.Value = "PPBS– (Result =" + drTreat["ti_lab_16"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation25.ValueType = "Other";
                                    ObservationMain.Add(observation25);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "80076")
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation26 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation26.Type = "Text";
                                    observation26.Code = "Description";
                                    observation26.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation26.ValueType = "Other";
                                    ObservationMain.Add(observation26);
                                }

                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation27 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation27.Type = "Text";
                                    observation27.Code = "Description";
                                    observation27.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation27.ValueType = "Other";
                                    ObservationMain.Add(observation27);
                                }

                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation28 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation28.Type = "Text";
                                    observation28.Code = "Description";
                                    observation28.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation28.ValueType = "Other";
                                    ObservationMain.Add(observation28);
                                }

                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation29 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation29.Type = "Text";
                                    observation29.Code = "Description";
                                    observation29.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation29.ValueType = "Other";
                                    ObservationMain.Add(observation29);
                                }

                                if (drTreat["ti_image_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation35 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation35.Type = "Text";
                                    observation35.Code = "Description";
                                    observation35.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation35.ValueType = "Other";
                                    ObservationMain.Add(observation35);

                                }

                                if (drTreat["ti_image_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation36 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation36.Type = "Text";
                                    observation36.Code = "Description";
                                    observation36.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation36.ValueType = "Other";
                                    ObservationMain.Add(observation36);
                                }
                            }


                            activity.Observation = ObservationMain;
                            ActivityMain.Add(activity);
                        }
                        claims.Activity = ActivityMain;

                        ClaimMain.Add(claims);
                    }
                    submission.Claim = ClaimMain;
                    submission_request.Submission = submission;
                    string myDeserializedClass = JsonConvert.SerializeObject(submission_request);
                    Trace.TraceWarning("Json::" + myDeserializedClass);
                    var empclaims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_name = empclaims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                    string file_name = "EMC_Sub_" + emp_name + "_" + s_date_from.ToString("ddMMyyyyhhsstt") + "_" + ic_insurance_name + ".json";


                    byte[] fileBytes = Encoding.UTF8.GetBytes(myDeserializedClass);
                    return File(fileBytes, "application/json", file_name);
                }
                catch (WebException ex)
                {
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());

                    // Read the content.
                    string responseFromServer = sr.ReadToEnd();

                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_response result1 = JsonConvert.DeserializeObject<BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_response>(responseFromServer);
                    if (result1.StatusCode == "400")
                    {
                        //lblErrorMessage.Text = result1.UserMessage;
                        int count = 1;

                        foreach (var err in result1.Error)
                        {
                            // string ErrMsg = " " + count + ". In " + err.Reference + "," + err.AdditionalReferenceObjectName + "," + err.ErrorText + ".";
                            //    lblErrorMessage.Text += ErrMsg;
                            string ErrMsg = string.Empty;

                            ErrMsg = "<p style=\"font-size:14px\">" + count;

                            if (!string.IsNullOrEmpty(err.Reference))
                            {
                                ErrMsg += " &nbsp;<b style=\"color:red;\"> Reference:</b>" + err.Reference + ".";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReference))
                            {
                                ErrMsg += "<b style=\"color:red;\">AdditionalReference:</b>" + err.AdditionalReference + ".";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReferenceObjectName))
                            {
                                ErrMsg += "<b style=\"color:red;\">AdditionalReferenceObjectName:</b>" + err.AdditionalReferenceObjectName + ".";
                            }
                            if (!string.IsNullOrEmpty(err.ErrorText))
                            {
                                ErrMsg += "<b style=\"color:red;\">ErrorText:</b>" + err.ErrorText + ".";
                            }
                            if (!string.IsNullOrEmpty(err.ObjectName))
                            {
                                ErrMsg += "<b style=\"color:red;\">ObjectName:</b>" + err.ObjectName + ".";
                            }
                            ErrMsg += "</p>";
                            //lblError.InnerHtml += ErrMsg;
                            count = count + 1;

                            return Json(new { isSuccess = false, message = ErrMsg }, JsonRequestBehavior.AllowGet);
                        }
                        return Json(new { isSuccess = false, message = result1.UserMessage }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = result1.UserMessage }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public async Task<ActionResult> GenerateFullJSONDirect(string inv_ids, string s_flag, int no_of_claims, string s_ic_id, string ic_names, DateTime s_date_from, DateTime s_date_to)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = new DataTable();

                string ic_insurance_name = "";
                DateTime cliam__date = s_date_from;
                DateTime TransactionDate = DateTime.Now;
                Dictionary<string, string> errors = new Dictionary<string, string>();
                int madeby = PageControl.getLoggedinId();
                DataSet ds = BusinessLogicLayer.EClaims.EClaims.GetInvoiceDetailsForSubmission(inv_ids, s_flag);
                dt = ds.Tables[0];
                DataTable dt_signs = ds.Tables[0];
                string ins_clinic_code = "";
                string ic_name = "";
                string filename = Server.MapPath("~/submissions/GeneratedXmls/Riyati/Direct/Sub_" + dt.Rows[0]["set_sat_ftime"].ToString() + " - " + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + " - " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + ".xml").Replace(" ", ""); // Specify the output filename
                string ins_code = BusinessLogicLayer.EClaims.EClaims.SP_GetIcCode(s_ic_id);
                try
                {
                    int day = DateTime.Parse(DateTime.Now.ToShortDateString()).Day;
                    int month = DateTime.Parse(DateTime.Now.ToShortDateString()).Month;
                    string day_value = "";
                    string month_value = "";
                    if (day < 10)
                    {
                        day_value = "0" + day.ToString();
                    }
                    else
                    {
                        day_value = day.ToString();
                    }
                    if (month < 10)
                    {
                        month_value = "0" + month.ToString();
                    }
                    else
                    {
                        month_value = month.ToString();
                    }
                    string Tr__date = day_value + "/" + month_value + "/" + DateTime.Parse(DateTime.Now.ToShortDateString()).Year;


                    string emp__license = string.Empty;
                    string FacilityId = dt.Rows[0]["set_sat_ftime"].ToString();
                    string strUsername = ConfigurationManager.AppSettings["RiayatiPOUsername"].ToString();
                    string strPassword = ConfigurationManager.AppSettings["RiayatiPOPassword"].ToString();
                    string strApiUrl = ConfigurationManager.AppSettings["RiayatiAPIUrl"].ToString();
                    string strEmiratesId = string.Empty;

                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_Request submission_request = new BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_Request();
                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission submission = new BusinessEntities.EClaims.ClaimSubmissionRequest.Submission();
                    BusinessEntities.EClaims.ClaimSubmissionRequest.Header header = new BusinessEntities.EClaims.ClaimSubmissionRequest.Header();

                    ///Adding Header

                    header.SenderID = FacilityId;
                    if (ic_names == "'Cash'")
                    {
                        header.ReceiverID = "MOHAP";
                    }
                    else
                    {
                        header.ReceiverID = ins_code.Trim();
                    }
                    header.TransactionDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    header.RecordCount = no_of_claims.ToString().Trim();
                    header.DispositionFlag = s_flag;
                    header.PayerID = dt.Rows[0]["inv_ic_payercode"].ToString().Trim();

                    submission.Header = header;

                    int i = 0;
                    string invmIds = "";
                    List<BusinessEntities.EClaims.ClaimSubmissionRequest.Claim> ClaimMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Claim>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BusinessEntities.EClaims.ClaimSubmissionRequest.Claim claims = new BusinessEntities.EClaims.ClaimSubmissionRequest.Claim();

                        i = i + 1;
                        //float inv_total = float.Parse(row["inv_total"].ToString());
                        float inv_net = BusinessLogicLayer.EClaims.EClaims.GetInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        float inv_net_cash = float.Parse(row["inv_net"].ToString().Trim());
                        float inv_vat = float.Parse(row["inv_vat"].ToString().Trim());
                        //float inv_net = float.Parse(row["inv_net"].ToString());
                        float inv_tded = float.Parse(row["inv_tded"].ToString()) + float.Parse(row["inv_dded"].ToString()) + float.Parse(row["inv_lded"].ToString()) + float.Parse(row["inv_rded"].ToString()) + float.Parse(row["inv_mded"].ToString());
                        float inv_copay = float.Parse(row["inv_copay"].ToString().Trim());
                        float inv_share = float.Parse(row["inv_share"].ToString().Trim());
                        float pat_share = 0;

                        if (int.Parse(row["icId"].ToString()) == int.Parse(row["ic_topup"].ToString()))
                        {
                            pat_share = inv_tded + inv_copay + inv_share;
                        }
                        else
                        {
                            pat_share = BusinessLogicLayer.EClaims.EClaims.GetTopupInvoiceNet(int.Parse(row["appId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        }

                        float inv_total = inv_net_cash + pat_share;

                        string ins_no = row["pi_insno"].ToString().Trim();
                        string claim_no = row["inv_claimno"].ToString().Trim();
                        string policy_no = row["inv_pi_polocyno"].ToString().Trim();
                        string inv_no = row["inv_no"].ToString().Trim();
                        ins_clinic_code = row["inv_ic_payercode"].ToString().Trim();

                        invmIds = invmIds + "," + row["invId"].ToString();

                        ic_insurance_name = row["ic_name"].ToString().Trim();
                        ic_name = row["inv_insurance_name"].ToString().Trim();
                        DateTime inv__date = DateTime.Parse(row["inv_date"].ToString());
                        DateTime app__fdate = DateTime.Parse(row["app_fdate"].ToString());

                        int d_ay = app__fdate.Day;
                        string d__ay = "";
                        if (d_ay < 10)
                        {
                            d__ay = "0" + d_ay.ToString();
                        }
                        else
                        {
                            d__ay = d_ay.ToString();
                        }

                        int m_onth = app__fdate.Month;
                        string m__onth = "";
                        if (m_onth < 10)
                        {
                            m__onth = "0" + m_onth.ToString();
                        }
                        else
                        {
                            m__onth = m_onth.ToString();
                        }

                        claims.ID = inv_no;
                        if (ins_clinic_code != "INS200")
                        {
                            claims.IDPayer = ins_clinic_code;
                        }
                        claims.Type = "Submission";

                        claims.MemberId = ins_no.Trim();
                        claims.ProviderID = FacilityId;

                        if (!string.IsNullOrEmpty(row["pat_emirateid"].ToString().Trim()) && (row["pat_emirateid"].ToString().Trim().Length == 15))
                        {

                            claims.NationalIDNumber = row["pat_emirateid"].ToString().Substring(0, 3) + "-" + row["pat_emirateid"].ToString().Substring(3, 4) + "-" + row["pat_emirateid"].ToString().Substring(7, 7) + "-" + row["pat_emirateid"].ToString().Substring(14);
                        }
                        else if (!string.IsNullOrEmpty(row["pat_emirateid"].ToString().Trim()) && (row["pat_emirateid"].ToString().Trim().Length == 18))
                        {

                            claims.NationalIDNumber = row["pat_emirateid"].ToString().Trim();
                        }
                        else
                        {
                            claims.NationalIDNumber = "999-9999-9999999-9";
                        }



                        claims.Gross = inv_total.ToString("0.00");
                        claims.PatientShare = pat_share.ToString("0.00");
                        claims.Net = inv_net.ToString("0.00");
                        claims.DateOfBirth = DateTime.Parse(row["pat_dob"].ToString()).ToString("dd/MM/yyyy HH:mm");
                        claims.Gender = row["pat_gender"].ToString().Trim();

                        BusinessEntities.EClaims.ClaimSubmissionRequest.Encounter encounter = new BusinessEntities.EClaims.ClaimSubmissionRequest.Encounter();
                        encounter.FacilityID = FacilityId;
                        encounter.Type = "1";
                        encounter.PatientID = row["pat_code"].ToString().Trim();
                        encounter.Start = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + row["app_doc_ftime"].ToString();
                        encounter.End = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + row["app_doc_ttime"].ToString();
                        encounter.StartType = "1";
                        encounter.EndType = "1";
                        //encounter.TransferSource =
                        //encounter.TransferDestination =
                        claims.Encounter = encounter;

                        List<BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis> DiagnosisMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis>();

                        DataTable dtDiag = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosisPR(int.Parse(row["appId"].ToString()), 0);
                        string diag__codes = "";
                        foreach (DataRow drDiag in dtDiag.Rows)
                        {
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis diagnosis = new BusinessEntities.EClaims.ClaimSubmissionRequest.Diagnosis();

                            if (drDiag["pad_type"].ToString() == "Primary")
                            {
                                diagnosis.Type = "Principal";
                            }
                            else
                            {
                                diagnosis.Type = "Secondary";
                            }
                            diag__codes = diag__codes + "," + drDiag["diag_code"].ToString().Trim();
                            diagnosis.Code = drDiag["diag_code"].ToString().Trim();

                            DiagnosisMain.Add(diagnosis);
                        }
                        claims.Diagnosis = DiagnosisMain;


                        //ACTIVITY

                        List<BusinessEntities.EClaims.ClaimSubmissionRequest.Activity> ActivityMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Activity>();
                        int y = 0;
                        DataTable dtTreat = new DataTable();
                        dtTreat = BusinessLogicLayer.EClaims.EClaims.Get_TreatmentsByAppointmentID(int.Parse(row["appId"].ToString()), int.Parse(row["invId"].ToString()), int.Parse(row["inv_insurance"].ToString()));
                        foreach (DataRow drTreat in dtTreat.Rows)
                        {
                            float pt_net = float.Parse(drTreat["pt_net"].ToString().Trim());
                            float pt_vat = float.Parse(drTreat["pt_vat"].ToString().Trim());
                            DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString().Trim());
                            y = y + 1;
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Activity activity = new BusinessEntities.EClaims.ClaimSubmissionRequest.Activity();
                            activity.ID = drTreat["ptId"].ToString().Trim();
                            activity.Start = d__ay + "/" + m__onth + "/" + app__fdate.Year + " " + drTreat["app_doc_ftime"].ToString();
                            activity.Type = drTreat["tr_itype"].ToString().Trim();
                            activity.Code = drTreat["tr_code"].ToString().Trim();
                            activity.Location = "2";
                            activity.Quantity = drTreat["pt_qty"].ToString().Trim();
                            activity.Net = pt_net.ToString("0.00");

                            if (drTreat["emp_license"].ToString().Trim().Substring(0, 3).Equals("MOH"))
                            {
                                emp__license = drTreat["emp_license"].ToString().Substring(3, (drTreat["emp_license"].ToString().Length - 3));
                            }
                            else
                            {
                                emp__license = drTreat["emp_license"].ToString().Trim();
                            }

                            activity.Clinician = emp__license;
                            if (drTreat["tr_itype"].ToString().Trim() == "5")
                            {
                                activity.Duration = drTreat["pt_qty"].ToString().Trim();
                            }
                            if (drTreat["pt_auth_code"].ToString().Trim() != "")
                            {
                                if (drTreat["pt_auth_code"].ToString().Trim() != "Not Required")
                                {
                                    activity.PriorAuthorizationID = drTreat["pt_auth_code"].ToString().Trim();
                                }
                            }
                            List<BusinessEntities.EClaims.ClaimSubmissionRequest.Observation> ObservationMain = new List<BusinessEntities.EClaims.ClaimSubmissionRequest.Observation>();
                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            DataTable dtTreat2 = new DataTable();
                            dtTreat2 = BusinessLogicLayer.EClaims.EClaims.GetPrescriptions(int.Parse(row["appId"].ToString()));
                            foreach (DataRow dtpresc in dtTreat2.Rows)
                            {
                                if (dtpresc["pre_eRxRefNo"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation1 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation1.Type = "ERX";
                                    observation1.Code = "eRxReferenceNo";
                                    observation1.Value = dtpresc["pre_eRxRefNo"].ToString().Trim();
                                    observation1.ValueType = "Reference";
                                    ObservationMain.Add(observation1);
                                }
                            }


                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation55 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            observation55.Type = "Text";
                            observation55.Code = "InvoiceNumber";
                            observation55.Value = row["inv_no"].ToString().Trim();
                            observation55.ValueType = "Text";
                            ObservationMain.Add(observation55);

                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation56 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                            observation56.Type = "Text";
                            observation56.Code = "InvoiceDate";
                            observation56.Value = DateTime.Parse(row["inv_date"].ToString()).ToString("dd-MM-yyyy").Trim();
                            observation56.ValueType = "Date";
                            ObservationMain.Add(observation56);

                            if (drTreat["pt_teeth"].ToString().Trim() != "")
                            {
                                if (drTreat["pt_teeth"].ToString().Trim() != "NA")
                                {
                                    string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');

                                    for (int j = 0; j < pt__teeth.Length; j++)
                                    {
                                        //MessageBox.Show(words[j]);
                                        if (pt__teeth[j].Trim() != "")
                                        {
                                            BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation91 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                            observation91.Type = "UniversalDental";
                                            observation91.Code = "UniversalNumberingSystemDental";
                                            observation91.Value = pt__teeth[j].Trim();
                                            observation91.ValueType = "ToothNumber";
                                            ObservationMain.Add(observation91);
                                        }
                                    }
                                }
                            }

                            if (drTreat["ti_image_1"].ToString().Trim() != "" && drTreat["ti_image_1_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno1"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation101 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation101.Type = "File";
                                    observation101.Code = "File";
                                    observation101.Value = drTreat["ti_img_refno1"].ToString().Trim();
                                    observation101.ValueType = "File";
                                    ObservationMain.Add(observation101);
                                }


                            }
                            if (drTreat["ti_image_2"].ToString().Trim() != "" && drTreat["ti_image_2_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation102 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation102.Type = "File";
                                    observation102.Code = "File";
                                    observation102.Value = drTreat["ti_img_refno2"].ToString().Trim();
                                    observation102.ValueType = "File";
                                    ObservationMain.Add(observation102);
                                }


                            }
                            if (drTreat["ti_image_3"].ToString().Trim() != "" && drTreat["ti_image_3_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation103 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation103.Type = "File";
                                    observation103.Code = "File";
                                    observation103.Value = drTreat["ti_img_refno3"].ToString().Trim();
                                    observation103.ValueType = "File";
                                    ObservationMain.Add(observation103);
                                }


                            }
                            if (drTreat["ti_image_4"].ToString().Trim() != "" && drTreat["ti_image_4_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation104 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation104.Type = "File";
                                    observation104.Code = "File";
                                    observation104.Value = drTreat["ti_img_refno4"].ToString().Trim();
                                    observation104.ValueType = "File";
                                    ObservationMain.Add(observation104);
                                }
                            }
                            if (drTreat["ti_image_5"].ToString().Trim() != "" && drTreat["ti_image_5_type"].ToString() == "Claims")
                            {
                                if (drTreat["ti_img_refno5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation105 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation105.Type = "File";
                                    observation105.Code = "File";
                                    observation105.Value = drTreat["ti_img_refno5"].ToString().Trim();
                                    observation105.ValueType = "File";
                                    ObservationMain.Add(observation105);
                                }


                            }

                            if (drTreat["pt_notes"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation107 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation107.Type = "Text";
                                observation107.Code = "Description";
                                observation107.Value = drTreat["pt_notes"].ToString().Trim();
                                observation107.ValueType = "Other";
                                ObservationMain.Add(observation107);
                            }


                            if (!string.IsNullOrEmpty(drTreat["pt_offauth"].ToString().Trim()))
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observationOff = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observationOff.Type = "OfflineAuthorization";
                                observationOff.Code = "OfflineAuthorization";
                                observationOff.Value = drTreat["pt_offauth"].ToString().Trim();
                                observationOff.ValueType = "OfflineAuthorization";
                                ObservationMain.Add(observationOff);

                            }
                            if (drTreat["ti_loinc_1"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation57 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation57.Type = "LOINC";
                                observation57.Code = "LOINC"; ;
                                observation57.Value = drTreat["ti_loinc_1"].ToString().Trim();// drTreat["ti_loinc_2"].ToString();
                                observation57.ValueType = "LOINCcode";// drTreat["ti_loinc_3"].ToString();
                                ObservationMain.Add(observation57);
                            }

                            if (drTreat["ti_loinc_4"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation58 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation58.Type = "LOINC";
                                observation58.Code = "LOINC";
                                observation58.Value = drTreat["ti_loinc_4"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation58.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation58);

                            }

                            if (drTreat["ti_loinc_7"].ToString().Trim() != "")
                            {
                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation59 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation59.Type = "LOINC";
                                observation59.Code = "LOINC";
                                observation59.Value = drTreat["ti_loinc_7"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation59.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation59);


                            }

                            if (drTreat["ti_loinc_10"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation60 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation60.Type = "LOINC";
                                observation60.Code = "LOINC";
                                observation60.Value = drTreat["ti_loinc_10"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation60.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation60);

                            }

                            if (drTreat["ti_loinc_13"].ToString().Trim() != "")
                            {

                                BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation61 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                observation61.Type = "LOINC";
                                observation61.Code = "LOINC";
                                observation61.Value = drTreat["ti_loinc_13"].ToString().Trim();// drTreat["ti_loinc_5"].ToString();
                                observation61.ValueType = "LOINCcode";// drTreat["ti_loinc_6"].ToString();
                                ObservationMain.Add(observation61);

                            }

                            // LOINC CODES ENDS

                            if ((drTreat["tr_code"].ToString().Trim() == "9") || (drTreat["tr_code"].ToString().Trim() == "10") || (drTreat["tr_code"].ToString().Trim() == "11") || (drTreat["tr_code"].ToString().Trim() == "9.1") || (drTreat["tr_code"].ToString().Trim() == "10.1") || (drTreat["tr_code"].ToString().Trim() == "11.1"))
                            {
                                if (drTreat["ti_lab_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation2 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation2.Type = "Text";
                                    observation2.Code = "Description";
                                    observation2.Value = "BPS– (Result =" + drTreat["ti_lab_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation2.ValueType = "Other";
                                    ObservationMain.Add(observation2);
                                }
                                if (drTreat["ti_lab_9"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation3 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();

                                    observation3.Type = "Text";
                                    observation3.Code = "Description";
                                    observation3.Value = "BPD– (Result =" + drTreat["ti_lab_9"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation3.ValueType = "Other";
                                    ObservationMain.Add(observation3);
                                }
                            }
                            if (drTreat["tr_code"].ToString() == "82565")
                            {
                                if (drTreat["ti_lab_7"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation4 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation4.Type = "Text";
                                    observation4.Code = "Description";
                                    observation4.Value = "CR– (Result =" + drTreat["ti_lab_7"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation4.ValueType = "Other";
                                    ObservationMain.Add(observation4);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "82043")
                            {
                                if (drTreat["ti_lab_6"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation5 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation5.Type = "Text";
                                    observation5.Code = "Description";
                                    observation5.Value = "UA– (Result =" + drTreat["ti_lab_6"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation5.ValueType = "Other";
                                    ObservationMain.Add(observation5);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "84478")
                            {
                                if (drTreat["ti_lab_5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation6 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation6.Type = "Text";
                                    observation6.Code = "Description";
                                    observation6.Value = "TRIG– (Result =" + drTreat["ti_lab_5"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation6.ValueType = "Other";
                                    ObservationMain.Add(observation6);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "83721")
                            {
                                if (drTreat["ti_lab_4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation7 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation7.Type = "Text";
                                    observation7.Code = "Description";
                                    observation7.Value = "LDL– (Result =" + drTreat["ti_lab_4"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation7.ValueType = "Other";
                                    ObservationMain.Add(observation7);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "83718")
                            {
                                if (drTreat["ti_lab_3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation8 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation8.Type = "Text";
                                    observation8.Code = "Description";
                                    observation8.Value = "HDL– (Result =" + drTreat["ti_lab_3"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation8.ValueType = "Other";
                                    ObservationMain.Add(observation8);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "82465")
                            {
                                if (drTreat["ti_lab_2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation9 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation9.Type = "Text";
                                    observation9.Code = "Description";
                                    observation9.Value = "CHOL– (Result =" + drTreat["ti_lab_2"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation9.ValueType = "Other";
                                    ObservationMain.Add(observation9);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "80061")
                            {
                                if (drTreat["ti_lab_2"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation31 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation31.Type = "Text";
                                    observation31.Code = "Description";
                                    observation31.Value = "CHOL– (Result =" + drTreat["ti_lab_2"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation31.ValueType = "Other";
                                    ObservationMain.Add(observation31);
                                }
                                if (drTreat["ti_lab_3"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation10 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation10.Type = "Text";
                                    observation10.Code = "Description";
                                    observation10.Value = "HDL– (Result =" + drTreat["ti_lab_3"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation10.ValueType = "Other";
                                    ObservationMain.Add(observation10);
                                }
                                if (drTreat["ti_lab_4"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation11 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation11.Type = "Text";
                                    observation11.Code = "Description";
                                    observation11.Value = "LDL– (Result =" + drTreat["ti_lab_4"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation11.ValueType = "Other";
                                    ObservationMain.Add(observation11);
                                }

                                if (drTreat["ti_lab_5"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation12 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation12.Type = "Text";
                                    observation12.Code = "Description";
                                    observation12.Value = "TRIG– (Result =" + drTreat["ti_lab_5"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation12.ValueType = "Other";
                                    ObservationMain.Add(observation12);

                                }
                                if (drTreat["ti_image_7"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation30 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation30.Type = "Text";
                                    observation30.Code = "Description";
                                    observation30.Value = "NONHDL– (Result =" + drTreat["ti_image_7"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation30.ValueType = "Other";
                                    ObservationMain.Add(observation30);
                                }
                            }
                            if (drTreat["tr_code"].ToString().Trim() == "83036")
                            {
                                if (drTreat["ti_lab_1"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation13 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation13.Type = "Text";
                                    observation13.Code = "Description";
                                    observation13.Value = "A1c– (Result =" + drTreat["ti_lab_1"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation13.ValueType = "Other";
                                    ObservationMain.Add(observation13);
                                }
                            }

                            if (diag__codes.Contains("E66.9") == true)
                            {
                                if (drTreat["ti_lab_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation14 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation14.Type = "Text";
                                    observation14.Code = "Description";
                                    observation14.Value = "BMI– (Result =" + drTreat["ti_lab_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation14.ValueType = "Other";
                                    ObservationMain.Add(observation14);
                                }
                            }
                            if ((diag__codes.Contains("R77.0") == true) && (drTreat["tr_code"].ToString() == "82040"))
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation15 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation15.Type = "Text";
                                    observation15.Code = "Description";
                                    observation15.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation15.ValueType = "Other";
                                    ObservationMain.Add(observation15);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && ((drTreat["tr_code"].ToString() == "84075") || (drTreat["tr_code"].ToString() == "84078") || (drTreat["tr_code"].ToString() == "84080")))
                            {
                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation16 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation16.Type = "Text";
                                    observation16.Code = "Description";
                                    observation16.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation16.ValueType = "Other";
                                    ObservationMain.Add(observation16);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString() == "80076"))
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation17 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation17.Type = "Text";
                                    observation17.Code = "Description";
                                    observation17.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation17.ValueType = "Other";
                                    ObservationMain.Add(observation17);
                                }
                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation18 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation18.Type = "Text";
                                    observation18.Code = "Description";
                                    observation18.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation18.ValueType = "Other";
                                    ObservationMain.Add(observation18);

                                }
                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation19 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation19.Type = "Text";
                                    observation19.Code = "Description";
                                    observation19.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation19.ValueType = "Other";
                                    ObservationMain.Add(observation19);
                                }
                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation20 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation20.Type = "Text";
                                    observation20.Code = "Description";
                                    observation20.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation20.ValueType = "Other";
                                    ObservationMain.Add(observation20);
                                }
                                if (drTreat["ti_image_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation32 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation32.Type = "Text";
                                    observation32.Code = "Description";
                                    observation32.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation32.ValueType = "Other";
                                    ObservationMain.Add(observation32);
                                }
                                if (drTreat["ti_image_9"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation33 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation33.Type = "Text";
                                    observation33.Code = "Description";
                                    observation33.Value = "DirectBilirubin– (Result =" + drTreat["ti_image_9"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation33.ValueType = "Other";
                                    ObservationMain.Add(observation33);
                                }
                                if (drTreat["ti_image_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation34 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation34.Type = "Text";
                                    observation34.Code = "Description";
                                    observation34.Value = "TotalProtein– (Result =" + drTreat["ti_image_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation34.ValueType = "Other";
                                    ObservationMain.Add(observation34);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString().Trim() == "84460"))
                            {
                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation21 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation21.Type = "Text";
                                    observation21.Code = "Description";
                                    observation21.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation21.ValueType = "Other";
                                    ObservationMain.Add(observation21);
                                }
                            }
                            if ((diag__codes.Contains("R94.5") == true) && (drTreat["tr_code"].ToString().Trim() == "84450"))
                            {
                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation22 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation22.Type = "Text";
                                    observation22.Code = "Description";
                                    observation22.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation22.ValueType = "Other";
                                    ObservationMain.Add(observation22);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82947")) //((diag__codes.Contains("E08") == true) || (diag__codes.Contains("E09") == true) || (diag__codes.Contains("E10") == true) || (diag__codes.Contains("E11") == true) || (diag__codes.Contains("E13") == true)) &&
                            {
                                if (drTreat["ti_lab_15"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation23 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation23.Type = "Text";
                                    observation23.Code = "Description";
                                    observation23.Value = "FBS– (Result =" + drTreat["ti_lab_15"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation23.ValueType = "Other";
                                    ObservationMain.Add(observation23);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82947"))
                            {
                                if (drTreat["ti_lab_16"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation24 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation24.Type = "Text";
                                    observation24.Code = "Description";
                                    observation24.Value = "RBS– (Result =" + drTreat["ti_lab_16"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation24.ValueType = "Other";
                                    ObservationMain.Add(observation24);
                                }
                            }
                            if ((drTreat["tr_code"].ToString().Trim() == "82950"))
                            {
                                if (drTreat["ti_lab_16"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation25 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation25.Type = "Text";
                                    observation25.Code = "Description";
                                    observation25.Value = "PPBS– (Result =" + drTreat["ti_lab_16"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation25.ValueType = "Other";
                                    ObservationMain.Add(observation25);
                                }
                            }

                            if (drTreat["tr_code"].ToString().Trim() == "80076")
                            {
                                if (drTreat["ti_lab_11"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation26 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation26.Type = "Text";
                                    observation26.Code = "Description";
                                    observation26.Value = "Albumin– (Result =" + drTreat["ti_lab_11"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation26.ValueType = "Other";
                                    ObservationMain.Add(observation26);
                                }

                                if (drTreat["ti_lab_12"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation27 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation27.Type = "Text";
                                    observation27.Code = "Description";
                                    observation27.Value = "ALP– (Result =" + drTreat["ti_lab_12"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation27.ValueType = "Other";
                                    ObservationMain.Add(observation27);
                                }

                                if (drTreat["ti_lab_13"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation28 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation28.Type = "Text";
                                    observation28.Code = "Description";
                                    observation28.Value = "ALT– (Result =" + drTreat["ti_lab_13"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation28.ValueType = "Other";
                                    ObservationMain.Add(observation28);
                                }

                                if (drTreat["ti_lab_14"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation29 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation29.Type = "Text";
                                    observation29.Code = "Description";
                                    observation29.Value = "AST– (Result =" + drTreat["ti_lab_14"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation29.ValueType = "Other";
                                    ObservationMain.Add(observation29);
                                }

                                if (drTreat["ti_image_8"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation35 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation35.Type = "Text";
                                    observation35.Code = "Description";
                                    observation35.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_8"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation35.ValueType = "Other";
                                    ObservationMain.Add(observation35);

                                }

                                if (drTreat["ti_image_10"].ToString().Trim() != "")
                                {
                                    BusinessEntities.EClaims.ClaimSubmissionRequest.Observation observation36 = new BusinessEntities.EClaims.ClaimSubmissionRequest.Observation();
                                    observation36.Type = "Text";
                                    observation36.Code = "Description";
                                    observation36.Value = "TotalBilirubin– (Result =" + drTreat["ti_image_10"].ToString().Trim() + ") –" + app_date.ToString("dd/MM/yyyy");
                                    observation36.ValueType = "Other";
                                    ObservationMain.Add(observation36);
                                }
                            }


                            activity.Observation = ObservationMain;
                            ActivityMain.Add(activity);
                        }
                        claims.Activity = ActivityMain;

                        ClaimMain.Add(claims);
                    }
                    submission.Claim = ClaimMain;
                    submission_request.Submission = submission;

                    string myDeserializedClass = JsonConvert.SerializeObject(submission_request);


                    var empclaims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_name = empclaims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                    string file_name = "EMC_Sub_" + emp_name + "_" + s_date_from.ToString("ddMMyyyyhhsstt") + "_" + ic_insurance_name + ".json";


                    string atr = "";


                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    var options = new RestClientOptions(strApiUrl)
                    {
                        MaxTimeout = -1,
                    };

                    var client = new RestClient(options);
                    var request = new RestRequest("Claim/PostSubmission", Method.Post);

                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("username", strUsername);
                    request.AddHeader("password", strPassword);
                    request.AddParameter("application/json", myDeserializedClass, ParameterType.RequestBody);

                    RestResponse response = await client.ExecuteAsync(request);

                    ClaimSubmissionRequest.Submission_response result = JsonConvert.DeserializeObject<ClaimSubmissionRequest.Submission_response>(response.Content);
                    string rpath = Server.MapPath("~/submissions/GeneratedXmls/Riyati/Direct/Response/");

                    if (!Directory.Exists(rpath))
                    {
                        Directory.CreateDirectory(rpath);
                    }

                    System.IO.File.WriteAllText(Path.Combine(rpath, filename), response.Content.ToString());

                    bool isSubmitted = false;
                    string mesg = result.Message;

                    if (result.StatusCode == "201")
                    {
                        if (s_flag == "PRODUCTION")
                        {
                            int eclId = 0;
                            int uinv_id = 0;

                            string FolderPath = Server.MapPath("~/submissions/GeneratedXmls/Riyati/Direct/Sub_" + file_name);
                            eclId = BusinessLogicLayer.EClaims.EClaims.eClaim_Insert(s_ic_id, s_date_from, s_date_to, file_name, FolderPath, result.UserMessage);
                            if (eclId > 0)
                            {
                                if (s_flag == "PRODUCTION")
                                {
                                    uinv_id = BusinessLogicLayer.EClaims.EClaims.SP_UpdateInvoiceStatus(inv_ids);
                                }
                                isSubmitted = true;

                                mesg = "Selected Treatment(s) submitted for eAuthorization Successfully!";
                            }
                            else
                            {
                                return Json(new { isSuccess = false, message = result.Message }, JsonRequestBehavior.AllowGet);
                                //mesg = "Error while Creating eAuthorization for Treatment(s)!";
                            }
                        }
                        else
                        {
                            isSubmitted = true;

                            mesg = "Selected Treatment(s) submitted for eAuthorization Successfully in " + s_flag + " Mode!";
                        }

                        return Json(new { isSuccess = isSubmitted, message = mesg, response = result }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        int count = 0;
                        string ErrMsg = "<div class=\"container\">";
                        foreach (var err in result.Error)
                        {
                            string ErrMsg1 = " " + count + "." + err.ErrorText + ".";
                            mesg += ErrMsg1;
                            count = count + 1;
                        }
                        ErrMsg += "<p class=\"lead\">" + count + " Claims having below validation errors</p>";

                        foreach (var err in result.Error)
                        {
                            ErrMsg += "<div class=\"alert alert-danger\" role=\"alert\">";
                            if (!string.IsNullOrEmpty(err.Reference))
                            {
                                ErrMsg += "<strong>Reference:</strong> " + err.Reference + "<br>";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReference))
                            {
                                ErrMsg += "<strong>Additional Reference:</strong> " + err.AdditionalReference + "<br>";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReferenceObjectName))
                            {
                                ErrMsg += "<strong>Additional Reference Object Name:</strong> " + err.AdditionalReferenceObjectName + "<br>";
                            }
                            if (!string.IsNullOrEmpty(err.ErrorText))
                            {
                                ErrMsg += "<strong>Error Text:</strong> " + err.ErrorText + "<br>";
                            }
                            if (!string.IsNullOrEmpty(err.ObjectName))
                            {
                                ErrMsg += "<strong>Object Name:</strong> " + err.ObjectName + "<br>";
                            }
                            ErrMsg += "</div><br>";
                            count = count + 1;
                        }
                        ErrMsg += "</div>";
                        return Json(new { isSuccess = isSubmitted, message = mesg, response = ErrMsg }, JsonRequestBehavior.AllowGet);
                    }



                    Response.AppendHeader("'Content-Disposition'", "'attachment; filename='" + file_name + "'");

                    Response.AppendHeader("Content-Length", myDeserializedClass.Length.ToString());
                    Response.ContentType = "text/xml";
                    Response.Write(myDeserializedClass.ToString());
                    Response.End();
                    return Json(new { isSuccess = true, message = atr }, JsonRequestBehavior.AllowGet);
                }
                catch (WebException ex)
                {
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());

                    // Read the content.
                    string responseFromServer = sr.ReadToEnd();

                    BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_response result1 = JsonConvert.DeserializeObject<BusinessEntities.EClaims.ClaimSubmissionRequest.Submission_response>(responseFromServer);
                    if (result1.StatusCode == "400")
                    {
                        //lblErrorMessage.Text = result1.UserMessage;
                        int count = 1;
                        string ErrMsg = string.Empty;

                        ErrMsg = "<p style=\"font-size:14px\">" + count;
                        foreach (var err in result1.Error)
                        {
                            if (!string.IsNullOrEmpty(err.Reference))
                            {
                                ErrMsg += " &nbsp;<b style=\"color:red;\"> Reference:</b>" + err.Reference + ".";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReference))
                            {
                                ErrMsg += "<b style=\"color:red;\">AdditionalReference:</b>" + err.AdditionalReference + ".";
                            }
                            if (!string.IsNullOrEmpty(err.AdditionalReferenceObjectName))
                            {
                                ErrMsg += "<b style=\"color:red;\">AdditionalReferenceObjectName:</b>" + err.AdditionalReferenceObjectName + ".";
                            }
                            if (!string.IsNullOrEmpty(err.ErrorText))
                            {
                                ErrMsg += "<b style=\"color:red;\">ErrorText:</b>" + err.ErrorText + ".";
                            }
                            if (!string.IsNullOrEmpty(err.ObjectName))
                            {
                                ErrMsg += "<b style=\"color:red;\">ObjectName:</b>" + err.ObjectName + ".";
                            }
                            ErrMsg += "</p>";
                            //lblError.InnerHtml += ErrMsg;
                            count = count + 1;

                            return Json(new { isSuccess = false, message = ErrMsg }, JsonRequestBehavior.AllowGet);
                        }
                        return Json(new { isSuccess = false, message = result1.UserMessage }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = result1.UserMessage }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult UpdateInvoiceeestatus(string inv_ids, string inv_estatus)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int invId = 0;
                    int pt_madeby = PageControl.getLoggedinId();
                    invId = BusinessLogicLayer.EClaims.EClaims.UpdateInvoiceeestatus(inv_ids, inv_estatus);

                    if (invId > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee updated inv_estatus to {inv_estatus} for the id= {inv_ids}"
                        });

                        return Json(new { isSuccess = true, invId = inv_ids, message = "invId. " + inv_ids + " is updated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in Updating status " }, JsonRequestBehavior.AllowGet);
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