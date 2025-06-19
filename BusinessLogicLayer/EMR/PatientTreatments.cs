using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace BusinessLogicLayer.EMR
{
    public class PatientTreatments
    {
        #region Patient Treatments        
        public static List<BusinessEntities.EMR.PatientTreatments> GetAllPatientTreatments(int? appId, int? ptId, string pt_type)
        {
            List<BusinessEntities.EMR.PatientTreatments> sclist = new List<BusinessEntities.EMR.PatientTreatments>();

            DataTable dt = DataAccessLayer.EMR.PatientTreatments.GetAllPatientTreatments(appId, ptId, pt_type);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.PatientTreatments
                {
                    ptId = Convert.ToInt32(dr["ptId"]),
                    pt_appId = Convert.ToInt32(dr["pt_appId"]),
                    tr_code = dr["tr_code"].ToString(),
                    pt_invno = dr["pt_invno"].ToString(),
                    tr_name = dr["tr_name"].ToString(),
                    pt_teeth = dr["pt_teeth"].ToString(),
                    tr_norm_range = dr["tr_norm_range"].ToString(),
                    pt_sur = dr["pt_sur"].ToString(),
                    tr_name_type = dr["tr_name_type"].ToString(),
                    pt_qty = Convert.ToInt32(dr["pt_qty"].ToString()),
                    pt_status = dr["pt_status"].ToString(),
                    pt_date_received = Convert.ToDateTime(dr["pt_date_received"].ToString()),
                    pt_date_collected = Convert.ToDateTime(dr["pt_date_collected"].ToString()),
                    pt_uprice = Convert.ToDecimal(dr["pt_uprice"].ToString()),
                    pt_total = Convert.ToDecimal(dr["pt_total"].ToString()),
                    pt_disc = Convert.ToDecimal(dr["pt_disc"].ToString()),
                    pt_net = Convert.ToDecimal(dr["pt_net"].ToString()),
                    pt_ded = Convert.ToDecimal(dr["pt_ded"].ToString()),
                    pt_copay = Convert.ToDecimal(dr["pt_copay"].ToString()),
                    pt_dcopay = Convert.ToDecimal(dr["pt_dcopay"].ToString()),
                    pt_dded = Convert.ToDecimal(dr["pt_dded"].ToString()),
                    pt_lded = Convert.ToDecimal(dr["pt_lded"].ToString()),
                    pt_rded = Convert.ToDecimal(dr["pt_rded"].ToString()),
                    pt_mded = Convert.ToDecimal(dr["pt_mded"].ToString()),
                    pt_ceiling = Convert.ToDecimal(dr["pt_ceiling"].ToString()),
                    pat__share = Convert.ToDecimal(dr["pat__share"].ToString()),
                    pt_vat = Convert.ToDecimal(dr["pt_vat"].ToString()),
                    pt_net_vat = Convert.ToDecimal(dr["pt_net_vat"].ToString()),
                    pt_lab_status = dr["pt_lab_status"].ToString(),
                    pt_tdn_notes = dr["pt_tdn_notes"].ToString(),
                    pt_coupon = dr["pt_coupon"].ToString(),
                    pt_tr_dent_option = dr["pt_tr_dent_option"].ToString(),
                    pt_coupon_disc = Convert.ToDecimal(dr["pt_coupon_disc"].ToString()),
                    pt_ses = Convert.ToInt32(dr["pt_ses"]),
                    pt_pack_exp_date = Convert.ToDateTime(dr["pt_pack_exp_date"].ToString()),
                    pt_auth_code = dr["pt_auth_code"].ToString(),
                    pt_auth_adate = Convert.ToDateTime(dr["pt_auth_adate"].ToString()),
                    pt_auth_edate = Convert.ToDateTime(dr["pt_auth_edate"].ToString()),
                    pt_auth_batch = dr["pt_auth_batch"].ToString(),
                    pt_notes = dr["pt_notes"].ToString(),
                    pt_tr_code = dr["pt_tr_code"].ToString(),
                    pt_type = dr["pt_type"].ToString(),
                    ip_name = dr["ip_name"].ToString(),
                    tr_type = dr["tr_type"].ToString(),
                    pt_treatment = Convert.ToInt32(dr["pt_treatment"]),
                    isAllocated = Convert.ToInt32(dr["isAllocated"])
                });

            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.PatientTreatments> GetAllPatientTreatmentsPlan(int? appId, int? ptId, string pt_type)
        {
            List<BusinessEntities.EMR.PatientTreatments> sclist = new List<BusinessEntities.EMR.PatientTreatments>();
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.GetAllPatientTreatmentsPlan(appId, ptId, pt_type);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.PatientTreatments
                {
                    ptId = Convert.ToInt32(dr["ptId"]),
                    pt_appId = Convert.ToInt32(dr["pt_appId"]),
                    tr_code = dr["tr_code"].ToString(),
                    tr_name = dr["tr_name"].ToString(),
                    pt_teeth = dr["pt_teeth"].ToString(),
                    tr_norm_range = dr["tr_norm_range"].ToString(),
                    pt_sur = dr["pt_sur"].ToString(),
                    tr_name_type = dr["tr_name_type"].ToString(),
                    pt_qty = Convert.ToInt32(dr["pt_qty"].ToString()),
                    pt_status = dr["pt_status"].ToString(),
                    pt_date_received = Convert.ToDateTime(dr["pt_date_received"].ToString()),
                    pt_date_collected = Convert.ToDateTime(dr["pt_date_collected"].ToString()),
                    pt_uprice = Convert.ToDecimal(dr["pt_uprice"].ToString()),
                    pt_total = Convert.ToDecimal(dr["pt_total"].ToString()),
                    pt_disc = Convert.ToDecimal(dr["pt_disc"].ToString()),
                    pt_net = Convert.ToDecimal(dr["pt_net"].ToString()),
                    pt_ded = Convert.ToDecimal(dr["pt_ded"].ToString()),
                    pt_copay = Convert.ToDecimal(dr["pt_copay"].ToString()),
                    pt_dcopay = Convert.ToDecimal(dr["pt_dcopay"].ToString()),
                    pt_dded = Convert.ToDecimal(dr["pt_dded"].ToString()),
                    pt_lded = Convert.ToDecimal(dr["pt_lded"].ToString()),
                    pt_rded = Convert.ToDecimal(dr["pt_rded"].ToString()),
                    pt_mded = Convert.ToDecimal(dr["pt_mded"].ToString()),
                    pt_ceiling = Convert.ToDecimal(dr["pt_ceiling"].ToString()),
                    pat__share = Convert.ToDecimal(dr["pat__share"].ToString()),
                    pt_vat = Convert.ToDecimal(dr["pt_vat"].ToString()),
                    pt_net_vat = Convert.ToDecimal(dr["pt_net_vat"].ToString()),
                    pt_lab_status = dr["pt_lab_status"].ToString(),
                    pt_tdn_notes = dr["pt_tdn_notes"].ToString(),
                    pt_coupon = dr["pt_coupon"].ToString(),
                    pt_coupon_disc = Convert.ToDecimal(dr["pt_coupon_disc"].ToString()),
                    pt_ses = Convert.ToInt32(dr["pt_ses"]),
                    pt_pack_exp_date = Convert.ToDateTime(dr["pt_pack_exp_date"].ToString()),
                    pt_notes = dr["pt_notes"].ToString(),
                    ip_name = dr["ip_name"].ToString(),
                    tr_type = dr["tr_type"].ToString(),
                    pt_treatment = Convert.ToInt32(dr["pt_treatment"])
                });

            }
            return sclist;
        }
        public static List<BusinessEntities.EMR.PatientTreatments> GetPatientTreatments(int? appId)
        {
            List<BusinessEntities.EMR.PatientTreatments> sclist = new List<BusinessEntities.EMR.PatientTreatments>();
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.GetPatientTreatments(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.PatientTreatments
                {
                    ptId = Convert.ToInt32(dr["ptId"]),
                    pt_appId = Convert.ToInt32(dr["pt_appId"]),
                    tr_code = dr["tr_code"].ToString(),
                    tr_name = dr["tr_name"].ToString(),
                    tr_name_type = dr["tr_name_type"].ToString(),
                    pt_qty = Convert.ToInt32(dr["pt_qty"].ToString()),
                    pt_status = dr["pt_status"].ToString(),
                    pt_date_received = Convert.ToDateTime(dr["pt_date_received"].ToString()),
                    pt_date_collected = Convert.ToDateTime(dr["pt_date_collected"].ToString()),
                    pt_uprice = Convert.ToDecimal(dr["pt_uprice"].ToString()),
                    pt_total = Convert.ToDecimal(dr["pt_total"].ToString()),
                    pt_disc = Convert.ToDecimal(dr["pt_disc"].ToString()),
                    pt_net = Convert.ToDecimal(dr["pt_net"].ToString()),
                    pt_ded = Convert.ToDecimal(dr["pt_ded"].ToString()),
                    pt_copay = Convert.ToDecimal(dr["pt_copay"].ToString()),
                    pt_dcopay = Convert.ToDecimal(dr["pt_dcopay"].ToString()),
                    pt_dded = Convert.ToDecimal(dr["pt_dded"].ToString()),
                    pt_lded = Convert.ToDecimal(dr["pt_lded"].ToString()),
                    pt_rded = Convert.ToDecimal(dr["pt_rded"].ToString()),
                    pt_mded = Convert.ToDecimal(dr["pt_mded"].ToString()),
                    pt_ceiling = Convert.ToDecimal(dr["pt_ceiling"].ToString()),
                    pat__share = Convert.ToDecimal(dr["pat__share"].ToString()),
                    pt_vat = Convert.ToDecimal(dr["pt_vat"].ToString()),
                    pt_net_vat = Convert.ToDecimal(dr["pt_net_vat"].ToString()),
                    pt_lab_status = dr["pt_lab_status"].ToString(),
                    pt_tdn_notes = dr["pt_tdn_notes"].ToString(),
                    pt_coupon = dr["pt_coupon"].ToString(),
                    pt_coupon_disc = Convert.ToDecimal(dr["pt_coupon_disc"].ToString()),
                    pt_ses = Convert.ToInt32(dr["pt_ses"]),
                    pt_pack_exp_date = Convert.ToDateTime(dr["pt_pack_exp_date"].ToString()),
                    pt_notes = dr["pt_notes"].ToString(),
                    ip_name = dr["ip_name"].ToString(),
                    tr_type = dr["tr_type"].ToString(),

                });

            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.PatientTreatments> GetAllPrePatientTreatments(int appId, int patId, string pt_type)
        {
            List<BusinessEntities.EMR.PatientTreatments> sclist = new List<BusinessEntities.EMR.PatientTreatments>();
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.GetAllPrePatientTreatments(appId, patId, pt_type);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.PatientTreatments
                {
                    ptId = Convert.ToInt32(dr["ptId"]),
                    pt_appId = Convert.ToInt32(dr["pt_appId"]),
                    tr_code = dr["tr_code"].ToString(),
                    tr_name = dr["tr_name"].ToString(),
                    tr_name_type = dr["tr_name_type"].ToString(),
                    pt_qty = Convert.ToInt32(dr["pt_qty"].ToString()),
                    pt_status = dr["pt_status"].ToString(),
                    pt_uprice = Convert.ToDecimal(dr["pt_uprice"].ToString()),
                    pt_total = Convert.ToDecimal(dr["pt_total"].ToString()),
                    pt_disc = Convert.ToDecimal(dr["pt_disc"].ToString()),
                    pt_net = Convert.ToDecimal(dr["pt_net"].ToString()),
                    pt_vat = Convert.ToDecimal(dr["pt_vat"].ToString()),
                    pt_net_vat = Convert.ToDecimal(dr["pt_net_vat"].ToString()),
                    pt_lab_status = dr["pt_lab_status"].ToString(),
                    pt_tdn_notes = dr["pt_tdn_notes"].ToString(),
                    pt_ses = Convert.ToInt32(dr["pt_ses"]),
                    pt_pack_exp_date = string.IsNullOrEmpty(dr["pt_pack_exp_date"].ToString()) ? Convert.ToDateTime("1900-01-01 00:00:00.000") : Convert.ToDateTime(dr["pt_pack_exp_date"].ToString()),
                    doctor_name = dr["doctor_name"].ToString(),
                    ip_name = dr["ip_name"].ToString(),
                    pt_teeth = dr["pt_teeth"].ToString(),
                    pt_sur = dr["pt_sur"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),
                    pat__share = Convert.ToDecimal(dr["pat__share"].ToString())
                });
            }
            return sclist;
        }

        public static int InsertPatientTreatments(BusinessEntities.EMR.Cash_Treatments data, int madeby, out int ptId)
        {
            return DataAccessLayer.EMR.PatientTreatments.InsertPatientTreatments(data, madeby, out ptId);
        }

        public static int UpdatePatientTreatments(BusinessEntities.EMR.Cash_PatientTreat inv, int madeby, out int ptId)
        {
            return DataAccessLayer.EMR.PatientTreatments.UpdatePatientTreatments(inv, madeby, out ptId);
        }

       
        public static List<CommonDDL> GetInvNosList(int appId,string type)
        {
            List<CommonDDL> branchlist = new List<CommonDDL>();

            DataTable dt = DataAccessLayer.EMR.PatientTreatments.GetInvNosList(appId, type);

            foreach (DataRow dr in dt.Rows)
            {
                branchlist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["id"]),
                    text = dr["text"].ToString()
                });
            }
            return branchlist;
        }
        public static BusinessEntities.EMR.PatientTreatments Get_InvoiceInfo(int appId)
        {
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);

            BusinessEntities.EMR.PatientTreatments qc = new BusinessEntities.EMR.PatientTreatments();
            PatientTreatments info = new PatientTreatments();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                qc.appId = int.Parse(appId.ToString());
                qc.invId = int.Parse(dr["invId"].ToString());
                qc.inv_no = dr["inv_no"].ToString();
                qc.inv_date = DateTime.Parse(dr["inv_date"].ToString());
                qc.patId = int.Parse(dr["patId"].ToString());
                qc.pat_code = dr["pat_code"].ToString();
                qc.pat_name = dr["pat_name"].ToString();
                qc.pat_emirateid = dr["pat_emirateid"].ToString();
                qc.id_card_edate = DateTime.Parse(dr["id_card_edate"].ToString());
                qc.emp_name = dr["emp_name"].ToString();
                qc.emp_license = dr["emp_license"].ToString();
                qc.emp_dept_name = dr["emp_dept_name"].ToString();
            }

            return qc;
        }
        public static BusinessEntities.EMR.PatientTreatments Get_InvoiceInfoByInvId(int invId,int appId)
        {
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.Get_InvoiceInfoByInvId(invId, appId);

            BusinessEntities.EMR.PatientTreatments qc = new BusinessEntities.EMR.PatientTreatments();
            PatientTreatments info = new PatientTreatments();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                qc.appId = int.Parse(appId.ToString());
                qc.invId = int.Parse(dr["invId"].ToString());
                qc.inv_no = dr["inv_no"].ToString();
                qc.inv_date = DateTime.Parse(dr["inv_date"].ToString());
                qc.patId = int.Parse(dr["patId"].ToString());
                qc.pat_code = dr["pat_code"].ToString();
                qc.pat_name = dr["pat_name"].ToString();
                qc.pat_emirateid = dr["pat_emirateid"].ToString();
                qc.id_card_edate = DateTime.Parse(dr["id_card_edate"].ToString());
                qc.emp_name = dr["emp_name"].ToString();
                qc.emp_license = dr["emp_license"].ToString();
                qc.emp_dept_name = dr["emp_dept_name"].ToString();
            }

            return qc;
        }

        public static int GenerateInvoice(BusinessEntities.Invoice.InvoiceNew data, out string inv_no, int? multi_bill=0)
        {
            return DataAccessLayer.EMR.PatientTreatments.GenerateInvoice(data, out inv_no, multi_bill);
        }

        public static int CreatePackage(int ptId, int madeby)
        {
            return DataAccessLayer.EMR.PatientTreatments.CreatePackage(ptId, madeby);
        }

        public static int UpdatePatientTreatmentStatus(int ptId, string pt_status, string pt_notes)
        {
            return DataAccessLayer.EMR.PatientTreatments.UpdatePatientTreatmentStatus(ptId, pt_status, pt_notes);

        }

        public static int UpdateApproval(int ptId, string pt_auth_code, DateTime pt_auth_adate, DateTime pt_auth_edate)
        {
            return DataAccessLayer.EMR.PatientTreatments.UpdateApproval(ptId, pt_auth_code, pt_auth_adate, pt_auth_edate);
        }

        public static int InsertActivityDetails(int ptId, int appId, string pt_resub_type, string act_no, int madeby, float pt_net, string act_xml_type)
        {
            return DataAccessLayer.EMR.PatientTreatments.InsertActivityDetails(ptId, appId, pt_resub_type, act_no, madeby, pt_net, act_xml_type);
        }

        public static string HtmlQuotation(string ptId)
        {
            try
            {
                BusinessEntities.EMR.TreatmentPrint print = Quotation(ptId);

                StringBuilder sb = new StringBuilder();
                sb.Append("<html>");
                sb.Append("    <head><title>ClinicSoft 9.0 - Quotation (Treatments / Procedures)</title></head>");
                sb.Append("    <body style='font-family: Verdana, Geneva, Tahoma, sans-serif;'>");

                sb.Append("    <table style='width:100%; font-size: 12px; '>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: center;' colspan='6'>");
                sb.Append($"    <img src='{print.pt_header.set_header_image}' alt='Header Image'/>");
                sb.Append("        </td>");
                sb.Append("    </tr>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: center;'  colspan='6'>");
                sb.Append("            <h1>QUOTATION (Treatments / Procedures)</h1>");
                sb.Append("        </td>");
                sb.Append("    </tr>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: left;'>Reg TRN No</td>");
                sb.Append("        <td style='text-align: center;'>:</td>");
                sb.Append("        <td style='text-align: left;' colspan='4'>" + print.pt_header.set_vat_regno + "</td>");
                sb.Append("    </tr>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: left;'>Facility Name </td>");
                sb.Append("        <td style='text-align: center;'>:</td>");
                sb.Append("        <td style='text-align: left;'  colspan='4'>" + print.pt_header.set_company + "</td>");
                sb.Append("    </tr>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: left;'>Address </td>");
                sb.Append("        <td style='text-align: center;'>:</td>");
                sb.Append("        <td style='text-align: left;'  colspan='4'>" + print.pt_header.set_address + " <br/> " + print.pt_header.set_tel + "/" + print.pt_header.set_mob + "</td>");
                sb.Append("    </tr>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: left;' colspan='6'>");
                sb.Append("            <hr/>");
                sb.Append("        </td>");
                sb.Append("    </tr>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: left;'>Doctor</td>");
                sb.Append("        <td style='text-align: center;'>:</td>");
                sb.Append("        <td style='text-align: left;'>" + print.pt_header.emp_name + "(DHA # -" + print.pt_header.emp_license + ") </td>");
                sb.Append("        <td style='text-align: left;'>Department </td>");
                sb.Append("        <td style='text-align: center;'>:</td>");
                sb.Append("        <td style='text-align: left;'>" + print.pt_header.emp_dept_name + "</td>");
                sb.Append("    </tr>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: left;'>Patient Name</td>");
                sb.Append("        <td style='text-align: center;'>:</td>");
                sb.Append("        <td style='text-align: left;'>" + print.pt_header.pat_name + "</td>");
                sb.Append("        <td style='text-align: left;'>MRN/File No. </td>");
                sb.Append("        <td style='text-align: center;'>:</td>");
                sb.Append("        <td style='text-align: left;'>" + print.pt_header.pat_code + "</td>");
                sb.Append("    </tr>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: left;'>Age / Gender</td>");
                sb.Append("        <td style='text-align: center;'>:</td>");
                sb.Append("        <td style='text-align: left;'>" + print.pt_header.pat_age + "/" + print.pt_header.pat_gender + "</td>");
                sb.Append("        <td style='text-align: left;'>Type</td>");
                sb.Append("        <td style='text-align: center;'>:</td>");
                sb.Append("        <td style='text-align: left;'>" + print.pt_header.pt_type + "</td>");
                sb.Append("    </tr>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: left;'>Visit Date </td>");
                sb.Append("        <td style='text-align: center;'>:</td>");
                sb.Append("        <td style='text-align: left;'>" + print.pt_header.app_fdate + "</td>");
                sb.Append("        <td style='text-align: left;'>Made By</td>");
                sb.Append("        <td style='text-align: center;'>:</td>");
                sb.Append("        <td style='text-align: left;'>" + print.pt_header.madeby_name + "</td>");
                sb.Append("    </tr>");
                sb.Append("</table>");

                sb.Append("<table style='width:100%; font-size: 12px; border-collapse: collapse; margin-top:10px;'>");
                sb.Append("    <thead>");
                sb.Append("        <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("            <th style='width:5%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>#</th>");
                sb.Append("            <th style='width:40%; text-align: left; border: 1px solid #cdcdcd; padding: 10px;'>Treatment/Procedure</th>");
                sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Qty</th>");
                sb.Append("            <th style='width:10%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Unit Price </th>");
                sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Gross </th>");
                sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Discount</th>");
                sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Net</th>");
                sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>VAT</th>");
                sb.Append("            <th style='width:10%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>NET + VAT</th>");
                sb.Append("        </tr>");
                sb.Append("    </thead>");
                sb.Append("    <tbody>");

                int count = 0;

                foreach (BusinessEntities.EMR.TreatmentBody i in print.pt_body)
                {
                    count++;

                    sb.Append("        <tr style='border: 1px solid #cdcdcd; '>");
                    sb.Append("            <td style='text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>" + count.ToString("D2") + "</td>");
                    sb.Append("            <td style='border: 1px solid #cdcdcd; padding: 10px;'>");
                    sb.Append("                <strong>" + i.pt_tr_code + "</strong>");
                    sb.Append("                <br/>");
                    sb.Append("                <p>" + i.pt_tr_name + "</p>");
                    sb.Append("            </td>");
                    sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_qty + "</td>");
                    sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_uprice + "</td>");
                    sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_total + "</td>");
                    sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_disc + "</td>");
                    sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_net + "</td>");
                    sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_vat + "</td>");
                    sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_netvat + "</td>");
                    sb.Append("        </tr>");

                }

                sb.Append("    </tbody>");

                sb.Append("<tfoot>");
                sb.Append("        <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("            <td style='text-align: center; border: 1px solid #cdcdcd; padding: 10px;'></td>");
                sb.Append("            <td style='border: 1px solid #cdcdcd; padding: 10px;'>");
                sb.Append("            </td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_qty)) + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_uprice)) + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_total)) + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_disc)) + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_net)) + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_vat)) + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_netvat)) + "</td>");
                sb.Append("        </tr>");
                sb.Append("</tfoot>");

                sb.Append("</table>");

                sb.Append("<table style='width:100%; font-size: 12px; margin-top:10px;'>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: center;'>");
                sb.Append("            <p>Kindly note that this automated and uniquely dated invoice is payable on this visit before leaving the Center deposit will be automatically deducted upon settlement.</p>");
                sb.Append("        </td>");
                sb.Append("    </tr>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: left;'>");
                sb.Append("            Patient Signature");
                sb.Append("        </td>");
                sb.Append("    </tr>");
                sb.Append("    <tr>");
                sb.Append("        <td style='text-align: center;'>");
                sb.Append($"    <img src='{print.pt_header.set_footer_image}' alt='Footer Image'/>");
                //sb.Append("            <img src='" + print.pt_header.set_footer_image + "'/>");
                sb.Append("        </td>");
                sb.Append("    </tr>");
                sb.Append("</table>");

                sb.Append("    </body>");
                sb.Append("</html>");

                String htmlString = sb.ToString();

                return htmlString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static BusinessEntities.EMR.TreatmentPrint Quotation(string ptId)
        {
            DataSet ds = DataAccessLayer.EMR.PatientTreatments.PrintTreatments(ptId);

            TreatmentHeader header = new TreatmentHeader();
            TreatmentFooter footer = new TreatmentFooter();
            List<TreatmentBody> body = new List<TreatmentBody>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    header.set_vat_regno = dr["set_vat_regno"].ToString();
                    header.set_company = dr["set_company"].ToString();
                    header.set_address = dr["set_address"].ToString();
                    header.set_tel = dr["set_tel"].ToString();
                    header.set_mob = dr["set_mob"].ToString();
                    header.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", dr["set_header_image"].ToString());
                    header.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", dr["set_footer_image"].ToString());

                    header.pt_date_created = DateTime.Parse(dr["pt_date_created"].ToString()).ToString("HH:mm:ss");
                    header.emp_name = dr["emp_name"].ToString();
                    header.emp_license = dr["emp_license"].ToString();
                    header.emp_dept_name = dr["emp_dept_name"].ToString();
                    header.pat_name = dr["pat_name"].ToString();
                    header.pat_code = dr["pat_code"].ToString();
                    header.pt_type = dr["pt_type"].ToString();
                    header.pat_gender = dr["pat_gender"].ToString();
                    header.pt_date_created = dr["pt_date_created"].ToString();
                    header.madeby_name = dr["madeby_name"].ToString();

                    DateTime dateTimeToday = DateTime.Now;
                    DateTime birthDate = DateTime.Parse(dr["pat_dob"].ToString());

                    TimeSpan difference = dateTimeToday.Subtract(birthDate);
                    var firstDay = new DateTime(1, 1, 1);
                    int totalYears = (firstDay + difference).Year - 1;
                    int totalMonths = (totalYears * 12) + (firstDay + difference).Month - 1;
                    int runningMonths = totalMonths - (totalYears * 12);
                    int runningDays = (dateTimeToday - birthDate.AddMonths((totalYears * 12) + runningMonths)).Days;

                    header.pat_age = $"{totalYears}Y - {runningMonths}M - {runningDays}D";

                    header.app_fdate = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd-MMM-yyyy") + " " + dr["app_doc_ftime"].ToString() + " - " + dr["app_doc_ttime"].ToString();
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        TreatmentBody i = new TreatmentBody();
                        i.pt_tr_code = dr["pt_tr_code"].ToString();
                        i.pt_tr_name = dr["pt_tr_name"].ToString();
                        i.pt_uprice = decimal.Parse(dr["pt_uprice"].ToString()).ToString("N2");
                        i.pt_qty = decimal.Parse(dr["pt_qty"].ToString()).ToString("N2");
                        i.pt_total = decimal.Parse(dr["pt_total"].ToString()).ToString("N2");
                        i.pt_disc = decimal.Parse(dr["pt_disc"].ToString()).ToString("N2");
                        i.pt_vat = decimal.Parse(dr["pt_vat"].ToString()).ToString("N2");
                        i.pt_net = decimal.Parse(dr["pt_net"].ToString()).ToString("N2");
                        i.pt_netvat = (decimal.Parse(i.pt_net) + decimal.Parse(i.pt_vat)).ToString("N2");
                        body.Add(i);
                    }
                }
            }

            TreatmentPrint print = new TreatmentPrint();
            print.pt_header = header;
            print.pt_body = body;
            print.pt_footer = footer;

            return print;
        }
        #endregion

        #region Insurance Treatments CRUD Operations
        public static List<CommonDDL> GetInsuranceTreatments(string query, string appId)
        {
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.GetInsuranceTreatments(query, appId);

            List<CommonDDL> list = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                string req = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL info = new CommonDDL();
                    info.id = int.Parse(dr["trId"].ToString());
                    req = dr["tr_dent_option"].ToString();

                    if (req == "Required")
                    {
                        req = "[<b class='text-warning'>Prior Auth Req</b>]";
                    }
                    else
                    {
                        req = string.Empty;
                    }

                    info.text = "<span class='text-primary me-2'>" + dr["tr_code"].ToString() + " - </span> " +
                                "<span class='text-info me-2'>" + dr["tr_name"].ToString() + " - </span> " +
                                "<span class='text-danger'> AED " + decimal.Parse(dr["tr_price"].ToString()).ToString("N2") + "</span> " + req + "";

                    list.Add(info);
                }
            }

            return list;
        }

        public static int InsertInsurancePatientTreatments(Cash_Treatments data, int madeby)
        {
            int val = 0;
            int count = 0;
            bool is_allowed = false;

            List<BusinessEntities.EMR.Cash_PatientTreat> list = data.treatment_items;

            foreach (BusinessEntities.EMR.Cash_PatientTreat i in list)
            {
                if (i.isAllowed == 1)
                {
                    is_allowed = true;
                }
                else
                {
                    is_allowed = false;
                    val = -5;
                }

                if (is_allowed)
                {
                    BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();

                    treatment.pt_appId = int.Parse(i.pt_appId.ToString());
                    treatment.pt_treatment = i.ptId;
                    treatment.pt_qty = decimal.Parse(i.pt_qty.ToString());
                    treatment.pt_notes = string.IsNullOrEmpty(i.pt_notes) ? string.Empty : i.pt_notes.ToString();
                    treatment.pt_comments = string.IsNullOrEmpty(i.pt_comments) ? string.Empty : i.pt_comments.ToString();
                    treatment.pt_type = string.IsNullOrEmpty(i.pt_type) ? string.Empty : i.pt_type.ToString();
                    treatment.pt_teeth = string.IsNullOrEmpty(i.pt_teeth) ? string.Empty : i.pt_teeth.ToString();
                    treatment.pt_sur = string.IsNullOrEmpty(i.pt_sur) ? string.Empty : i.pt_sur.ToString();
                    treatment.pt_auth_code = string.Empty;
                    treatment.pt_ses = int.Parse(i.pt_ses.ToString());
                    treatment.pt_treat_type = 0;
                    treatment.pt_uprice = i.pt_uprice;
                    treatment.pt_total = i.pt_total;
                    treatment.pt_disc = i.pt_disc_value;
                    treatment.pt_net = i.pt_netvat;
                    treatment.pt_vat = i.pt_vat;
                    treatment.pt_barcode = string.IsNullOrEmpty(i.pt_disc_type.ToString()) ? "0" : (i.pt_disc_type.ToString() == "Fixed" ? "1" : "0");
                    treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                    treatment.pt_auth_edate = DateTime.Parse("01/01/2100");
                    treatment.pt_share = 0;
                    treatment.pt_ceiling = 0;
                    treatment.pt_vat_type = i.pt_vat_type;
                    treatment.pt_pdisc = i.pt_disc;
                    treatment.pt_coupon = string.IsNullOrEmpty(i.pt_coupon_value) ? string.Empty : i.pt_coupon_value.ToString();
                    treatment.pt_coupon_disc = i.pt_coupon_disc;

                    val = DataAccessLayer.EMR.PatientTreatments.CreateInsurancePatientTreatments(treatment, madeby);

                    if (val > 0)
                    {
                        count++;
                    }
                }
            }

            return val;
        }

        public static int UpdateInsurancePatientTreatments(BusinessEntities.Patient.Treatments.PatientTreatment treatment, int madeby)
        {
            int val = 0;
            bool is_allowed = false;

            if (treatment.isAllowed == 1)
            {
                is_allowed = true;
            }
            else
            {
                is_allowed = false;
                val = -5;
            }

            if (is_allowed)
            {
                treatment.pt_pdisc = treatment.pt_disc;

                val = DataAccessLayer.EMR.PatientTreatments.UpdateInsuranceTreatments(treatment, madeby);
            }

            return val;
        }

        public static float calc_bal_edit(int appId, int ptId)
        {
            float pi_ided_limit_bal = 0;
            DataTable dt2 = DataAccessLayer.EMR.PatientTreatments.calc_bal_edit(appId, ptId, "Lab");

            if (dt2.Rows.Count > 0)
            {
                pi_ided_limit_bal = float.Parse(dt2.Rows[0]["pi_ided_limit"].ToString()) - float.Parse(dt2.Rows[0]["pt_lded"].ToString());

                if (float.Parse(dt2.Rows[0]["pi_ided_limit"].ToString()) > 0 && pi_ided_limit_bal > 0)
                {
                    return pi_ided_limit_bal;
                }
                else if (float.Parse(dt2.Rows[0]["pi_ided_limit"].ToString()) > 0 && pi_ided_limit_bal == 0)
                {
                    return -1;
                }
                else if (float.Parse(dt2.Rows[0]["pi_ided_limit"].ToString()) == 0)
                {
                    return 0;
                }
                else if (float.Parse(dt2.Rows[0]["pi_ided_limit"].ToString()) > 0 && pi_ided_limit_bal < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                pi_ided_limit_bal = 0;
                return pi_ided_limit_bal;
            }
        }

        public static float calc_bal2(int appId)
        {
            float pi_copay_limit_bal = 0;

            DataTable dt3 = DataAccessLayer.EMR.PatientTreatments.calc_bal_edit(appId, 0, "Co.Pay");

            if (dt3.Rows.Count > 0)
            {
                pi_copay_limit_bal = float.Parse(dt3.Rows[0]["pi_copay_limit"].ToString()) - float.Parse(dt3.Rows[0]["pt_copay"].ToString());

                if (float.Parse(dt3.Rows[0]["pi_copay_limit"].ToString()) > 0 && pi_copay_limit_bal > 0)
                {
                    return pi_copay_limit_bal;
                }
                else if (float.Parse(dt3.Rows[0]["pi_copay_limit"].ToString()) > 0 && pi_copay_limit_bal == 0)
                {
                    return -1;
                }
                else if (float.Parse(dt3.Rows[0]["pi_copay_limit"].ToString()) == 0)
                {
                    return 0;
                }
                else if (float.Parse(dt3.Rows[0]["pi_copay_limit"].ToString()) > 0 && pi_copay_limit_bal < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                pi_copay_limit_bal = 0;

                return pi_copay_limit_bal;
            }
        }

        public static float calc_bal1(int appId)
        {
            float pi_rded_limit_bal = 0;
            DataTable dt3 = DataAccessLayer.EMR.PatientTreatments.calc_bal_edit(appId, 0, "Radiology");

            if (dt3.Rows.Count > 0)
            {
                pi_rded_limit_bal = float.Parse(dt3.Rows[0]["pi_rded_limit"].ToString()) - float.Parse(dt3.Rows[0]["pt_rded"].ToString());

                if (float.Parse(dt3.Rows[0]["pi_rded_limit"].ToString()) > 0 && pi_rded_limit_bal > 0)
                {
                    return pi_rded_limit_bal;
                }
                else if (float.Parse(dt3.Rows[0]["pi_rded_limit"].ToString()) > 0 && pi_rded_limit_bal == 0)
                {
                    return -1;
                }
                else if (float.Parse(dt3.Rows[0]["pi_rded_limit"].ToString()) == 0)
                {
                    return 0;
                }
                else if (float.Parse(dt3.Rows[0]["pi_rded_limit"].ToString()) > 0 && pi_rded_limit_bal < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                pi_rded_limit_bal = 0;
                return pi_rded_limit_bal;
            }
        }
        #endregion

        #region Dental Insurance Treatments CRUD Operations
        public static List<CommonDDL> GetTeeth(string query)
        {
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.GetTeeth(query);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static decimal GetPatientShare(int appId, int ptId, decimal qty, decimal uprice, decimal disc, out decimal pt_net, out int allowed_limit)
        {
            return DataAccessLayer.EMR.PatientTreatments.GetPatientShare(appId, ptId, qty, uprice, disc, out pt_net, out allowed_limit);
        }

        public static decimal GetPatientShareEdit(int appId, int ptId, decimal qty, decimal uprice, decimal disc, int id, decimal new_share, out decimal pt_net, out int allowed_limit)
        {
            return DataAccessLayer.EMR.PatientTreatments.GetPatientShareEdit(appId, ptId, qty, uprice, disc, id, new_share, out pt_net, out allowed_limit);
        }

        public static int InsertDentInsPatientTreatments(Cash_Treatments data, int madeby)
        {
            int val = 0;
            int count = 0;
            bool is_allowed = false;

            List<BusinessEntities.EMR.Cash_PatientTreat> list = data.treatment_items;

            foreach (BusinessEntities.EMR.Cash_PatientTreat i in list)
            {
                if (i.isAllowed == 1)
                {
                    is_allowed = true;
                }
                else
                {
                    is_allowed = false;
                    val = -5;
                }

                if (is_allowed)
                {
                    BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();

                    treatment.pt_appId = int.Parse(i.pt_appId.ToString());
                    treatment.pt_treatment = i.ptId;
                    treatment.pt_qty = decimal.Parse(i.pt_qty.ToString());
                    treatment.pt_notes = string.IsNullOrEmpty(i.pt_notes) ? string.Empty : i.pt_notes.ToString();
                    treatment.pt_comments = string.IsNullOrEmpty(i.pt_comments) ? string.Empty : i.pt_comments.ToString();
                    treatment.pt_type = string.IsNullOrEmpty(i.pt_type) ? string.Empty : i.pt_type.ToString();
                    treatment.pt_teeth = string.IsNullOrEmpty(i.pt_teeth) ? string.Empty : i.pt_teeth.ToString();
                    treatment.pt_sur = string.IsNullOrEmpty(i.pt_sur) ? string.Empty : i.pt_sur.ToString();
                    treatment.pt_auth_code = string.Empty;
                    treatment.pt_ses = int.Parse(i.pt_ses.ToString());
                    treatment.pt_treat_type = 0;
                    treatment.pt_uprice = i.pt_uprice;
                    treatment.pt_total = i.pt_total;
                    treatment.pt_disc = i.pt_disc_value;
                    treatment.pt_net = i.pt_netvat;
                    treatment.pt_vat = i.pt_vat;
                    treatment.pt_barcode = string.IsNullOrEmpty(i.pt_disc_type.ToString()) ? "0" : (i.pt_disc_type.ToString() == "Fixed" ? "1" : "0");
                    treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                    treatment.pt_auth_edate = DateTime.Parse("01/01/2100");
                    treatment.pt_share = 0;
                    treatment.pt_ceiling = 0;
                    treatment.pt_vat_type = i.pt_vat_type;
                    treatment.pt_pdisc = i.pt_disc;
                    treatment.pt_coupon = string.IsNullOrEmpty(i.pt_coupon_value) ? string.Empty : i.pt_coupon_value.ToString();
                    treatment.pt_coupon_disc = i.pt_coupon_disc;

                    val = DataAccessLayer.EMR.PatientTreatments.CreateDentalInsurancePatientTreatments(treatment, madeby);

                    if (val > 0)
                    {
                        count++;
                    }
                }
            }

            return val;
        }

        public static int UpdateDentInsPatientTreatment(BusinessEntities.Patient.Treatments.PatientTreatment treatment, int madeby)
        {
            int val = 0;
            bool is_allowed = false;

            if (treatment.isAllowed == 1)
            {
                is_allowed = true;
            }
            else
            {
                is_allowed = false;
                val = -5;
            }

            if (is_allowed)
            {
                treatment.pt_pdisc = treatment.pt_disc;
                treatment.pt_notes = string.IsNullOrEmpty(treatment.pt_notes) ? string.Empty : treatment.pt_notes;

                val = DataAccessLayer.EMR.PatientTreatments.UpdateDentInsPatientTreatment(treatment, madeby);
            }

            return val;
        }

        public static DataTable DentInsTreatBulkSummary(Cash_Treatments data)
        {
            int val = 0;
            bool is_allowed = false;

            List<Cash_PatientTreat> list = data.treatment_items;

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("pt_appId", typeof(int));
                dt.Columns.Add("pt_treatment", typeof(int));
                dt.Columns.Add("pt_qty", typeof(int));
                dt.Columns.Add("pt_notes", typeof(string));
                dt.Columns.Add("pt_type", typeof(string));
                dt.Columns.Add("pt_teeth", typeof(string));
                dt.Columns.Add("pt_sur", typeof(string));
                dt.Columns.Add("pt_auth_code", typeof(string));
                dt.Columns.Add("pt_ses", typeof(int));
                dt.Columns.Add("pt_treat_type", typeof(int));
                dt.Columns.Add("pt_uprice", typeof(decimal));
                dt.Columns.Add("pt_total", typeof(decimal));
                dt.Columns.Add("pt_disc", typeof(decimal));
                dt.Columns.Add("pt_ded", typeof(decimal));
                dt.Columns.Add("pt_copay", typeof(decimal));
                dt.Columns.Add("pt_net", typeof(decimal));
                dt.Columns.Add("pt_vat", typeof(decimal));
                dt.Columns.Add("pt_dcopay", typeof(decimal));
                dt.Columns.Add("pt_barcode", typeof(string));
                dt.Columns.Add("pt_auth_adate", typeof(DateTime));
                dt.Columns.Add("pt_auth_edate", typeof(DateTime));
                dt.Columns.Add("pt_share", typeof(decimal));
                dt.Columns.Add("pt_insurance", typeof(int));
                dt.Columns.Add("pt_dded", typeof(decimal));
                dt.Columns.Add("pt_lded", typeof(decimal));
                dt.Columns.Add("pt_rded", typeof(decimal));
                dt.Columns.Add("pt_mded", typeof(decimal));
                dt.Columns.Add("pt_ceiling", typeof(decimal));
                dt.Columns.Add("pt_vat_type", typeof(string));
                dt.Columns.Add("pt_pdisc", typeof(decimal));
                dt.Columns.Add("pt_coupon", typeof(string));
                dt.Columns.Add("pt_coupon_disc", typeof(decimal));

                foreach (Cash_PatientTreat i in list)
                {
                    string[] values = i.pt_teeth.Split(',');

                    foreach (string teeth in values)
                    {
                        int appId = int.Parse(i.pt_appId.ToString());
                        DataTable dti = DataAccessLayer.EMR.PatientTreatments.GetInsuranceDeduction(appId);
                        float PT__NET = 0;
                        float Totalvalue = GET_TOTAL(appId);
                        PT__NET = Totalvalue + (float)i.pt_net;

                        if (PT__NET <= (float)dti.Rows[0]["is_allowed_limit"])
                        {
                            is_allowed = true;
                        }
                        else
                        {
                            is_allowed = false;
                            val = -5;
                        }

                        float ic_discount = (float)(dti.Rows[0]["ic_discount"]);
                        float ic_credit = (float)(dti.Rows[0]["ic_credit"]);
                        float pt__ded = 0;

                        float pt__dded = 0;
                        float pt__lded = 0;
                        float pt__rded = 0;
                        float pt__mded = 0;

                        float pt__copay = 0;
                        float pt__dcopay = 0;
                        float pt__net = 0;
                        float tr__disc = 0;
                        float pt__uprice = 0;
                        float pt__total = 0;
                        float pt__disc = 0;

                        tr__disc = (float)i.pt_disc;
                        string tr__type = DataAccessLayer.EMR.PatientTreatments.Treat_Type(i.ptId);

                        pt__total = (float)i.pt_uprice * pt__uprice;
                        pt__disc = 0;

                        pt__disc = tr__disc;

                        if ((pt__total - pt__disc) <= pt__ded)
                        {
                            pt__ded = (pt__total - pt__disc);
                        }

                        if ((tr__type == "Dental Consultation") && (pt__uprice > 0))
                        {
                            if (dti.Rows[0]["pi_dded"].ToString() != "0")
                            {
                                if (dti.Rows[0]["pi_dded_type"].ToString() == "Fixed")
                                {
                                    pt__dded = (float)dti.Rows[0]["pi_dded"];
                                }
                                else
                                {
                                    pt__dded = (pt__total - pt__disc) * (float)dti.Rows[0]["pi_dded"] / 100;
                                }
                            }
                        }

                        if ((pt__total - pt__disc) <= pt__dded)
                        {
                            pt__dded = (pt__total - pt__disc);
                        }

                        if ((tr__type == "Dental Co.Pay") && (pt__uprice > 0))
                        {
                            if (dti.Rows[0]["pi_dcopay"].ToString() != "0")
                            {
                                if (dti.Rows[0]["pi_dcopay_type"].ToString() == "Fixed")
                                {
                                    pt__dcopay = (float)dti.Rows[0]["pi_dcopay"];
                                }
                                else
                                {
                                    pt__dcopay = ((pt__total - pt__disc) * (float)dti.Rows[0]["pi_dcopay"]) / 100;
                                }
                            }
                            else if (dti.Rows[0]["pi_hdcopay"].ToString() != "0")
                            {
                                if (dti.Rows[0]["pi_hdcopay_type"].ToString() == "Fixed")
                                {
                                    pt__dcopay = (float)dti.Rows[0]["pi_hdcopay"];
                                }
                                else
                                {
                                    pt__dcopay = ((pt__total - pt__disc) * (float)dti.Rows[0]["pi_hdcopay"]) / 100;
                                }
                            }
                        }

                        if ((pt__total - pt__disc) <= pt__dcopay)
                        {
                            pt__dcopay = (pt__total - pt__disc);
                        }

                        if (((float)dti.Rows[0]["pi_dcopay_limit"] > 0) && ((float)dti.Rows[0]["pi_dcopay_limit"] < pt__dcopay))
                        {
                            pt__dcopay = (float)dti.Rows[0]["pi_dcopay_limit"];
                        }

                        if (int.Parse(dti.Rows[0]["icId"].ToString()) == int.Parse(dti.Rows[0]["ic_topup"].ToString()))
                        {
                            pt__net = pt__total - pt__disc - pt__ded - pt__dded - pt__lded - pt__rded - pt__mded - pt__copay - pt__dcopay;
                        }
                        else
                        {
                            pt__net = (pt__total - pt__disc - pt__ded - pt__dded - pt__lded - pt__rded - pt__mded - pt__copay - pt__dcopay) * float.Parse(dti.Rows[0]["ic_share"].ToString()) / 100;
                        }

                        if (is_allowed)
                        {
                            DataRow dr = dt.NewRow();
                            dr["pt_appId"] = int.Parse(i.pt_appId.ToString());
                            dr["pt_treatment"] = i.ptId;
                            dr["pt_qty"] = int.Parse(i.pt_qty.ToString());
                            dr["pt_notes"] = i.pt_notes;
                            dr["pt_type"] = i.pt_type;
                            dr["pt_teeth"] = teeth;
                            dr["pt_sur"] = i.pt_sur;
                            dr["pt_auth_code"] = i.pt_auth_code;
                            dr["pt_ses"] = int.Parse(i.pt_ses.ToString());
                            dr["pt_treat_type"] = 3;
                            dr["pt_uprice"] = float.Parse(i.pt_uprice.ToString());
                            dr["pt_total"] = float.Parse(i.pt_total.ToString());
                            dr["pt_disc"] = float.Parse(i.pt_disc_value.ToString());

                            dr["pt_ded"] = 0;
                            dr["pt_copay"] = 0;
                            dr["pt_net"] = pt__net;
                            dr["pt_vat"] = i.pt_vat;
                            dr["pt_dcopay"] = pt__dcopay;
                            dr["pt_barcode"] = string.IsNullOrEmpty(i.pt_disc_type.ToString()) ? "0" : (i.pt_disc_type.ToString() == "Fixed" ? "1" : "0");
                            dr["pt_auth_adate"] = DateTime.Parse("01/01/1900");
                            dr["pt_auth_edate"] = DateTime.Parse("01/01/2100");
                            dr["pt_share"] = 0;
                            dr["pt_insurance"] = 1;
                            dr["pt_dded"] = pt__dded;
                            dr["pt_lded"] = 0;
                            dr["pt_rded"] = 0;
                            dr["pt_mded"] = 0;
                            dr["pt_ceiling"] = 0;
                            dr["pt_vat_type"] = i.pt_vat_type;
                            dr["pt_pdisc"] = pt__disc;
                            dr["pt_coupon"] = string.IsNullOrEmpty(i.pt_coupon_value) ? "" : i.pt_coupon_value.ToString();
                            dr["pt_coupon_disc"] = i.pt_coupon_disc;
                            dt.Rows.Add(dr);
                        }
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static float GET_TOTAL(int appId)
        {
            DataTable dt3 = DataAccessLayer.EMR.PatientTreatments.GET_PTTOTAL(appId);

            if (dt3.Rows.Count > 0)
            {
                return float.Parse(dt3.Rows[0]["TOTAL"].ToString());
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Miscellaneous Functions
        public static int UpdateStatusToPriorRequest(int ptId, int inv_appId)
        {
            return DataAccessLayer.EMR.PatientTreatments.UpdateStatusToPriorRequest(ptId, inv_appId);
        }

        public static int CopyInsuranceTreatment(int pt_appId, int ptId, string type)
        {
            return DataAccessLayer.EMR.PatientTreatments.CopyInsuranceTreatment(pt_appId, ptId, type);
        }

        public static int MoveInsuranceTreatment(int pt_appId, int ptId, string type)
        {
            return DataAccessLayer.EMR.PatientTreatments.MoveInsuranceTreatment(pt_appId, ptId, type);
        }

        public static int GenerateInsuranceInvoice(BusinessEntities.EMR.TreatmentBulkInvoice inv, out string inv_no, int? multi_bill = 0)
        {
            int invId = 0;
            inv_no = string.Empty;
            bool flag = false;

            DataSet ds = DataAccessLayer.EMR.PatientTreatments.GetInsuranceInvoiceDetails(inv);

            BusinessEntities.Invoice.QuickCash qc = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfo(inv.inv_appId);

            TreatmentInsuranceDetails insdetails = new TreatmentInsuranceDetails();
            TreatmentInvoiceDetails invdetails = new TreatmentInvoiceDetails();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    insdetails.ic_name = dr["ic_name"].ToString();
                    insdetails.pt_insurance = int.Parse(dr["pt_insurance"].ToString());
                    insdetails.pt_auth_adate = DateTime.Parse(dr["pt_auth_adate"].ToString());
                    insdetails.app_fdate = DateTime.Parse(dr["app_fdate"].ToString());

                    //if (insdetails.pt_auth_adate.Year > 1900 && insdetails.pt_auth_adate.Year != 2100)
                    //{
                    //    insdetails.app_fdate = insdetails.pt_auth_adate;
                    //}

                    insdetails.pt_total = decimal.Parse(dr["pt_total"].ToString());
                    insdetails.pt_disc = decimal.Parse(dr["pt_disc"].ToString());
                    insdetails.pt_ded = decimal.Parse(dr["pt_ded"].ToString());
                    insdetails.pt_dded = decimal.Parse(dr["pt_dded"].ToString());
                    insdetails.pt_lded = decimal.Parse(dr["pt_lded"].ToString());
                    insdetails.pt_rded = decimal.Parse(dr["pt_rded"].ToString());
                    insdetails.pt_mded = decimal.Parse(dr["pt_mded"].ToString());
                    insdetails.pt_copay = decimal.Parse(dr["pt_copay"].ToString());
                    insdetails.pt_dcopay = decimal.Parse(dr["pt_dcopay"].ToString());
                    insdetails.pt_share = decimal.Parse(dr["pt_share"].ToString());
                    insdetails.pt_net = decimal.Parse(dr["pt_net"].ToString());
                    insdetails.pt_pded = decimal.Parse(dr["pt_pded"].ToString());
                    insdetails.pt_sded = decimal.Parse(dr["pt_sded"].ToString());

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow dr1 = ds.Tables[1].Rows[0];

                        invdetails.inv_no = dr1["inv_no"].ToString();
                        invdetails.inv_total = decimal.Parse(dr1["inv_total"].ToString()) + insdetails.pt_total;
                        invdetails.inv_tded = decimal.Parse(dr1["inv_tded"].ToString()) + insdetails.pt_ded;
                        invdetails.inv_dded = decimal.Parse(dr1["inv_dded"].ToString()) + insdetails.pt_dded;
                        invdetails.inv_lded = decimal.Parse(dr1["inv_lded"].ToString()) + insdetails.pt_lded;
                        invdetails.inv_rded = decimal.Parse(dr1["inv_rded"].ToString()) + insdetails.pt_rded;
                        invdetails.inv_mded = decimal.Parse(dr1["inv_mded"].ToString()) + insdetails.pt_mded;
                        invdetails.inv_pded = decimal.Parse(dr1["inv_pded"].ToString()) + insdetails.pt_pded;
                        invdetails.inv_sded = decimal.Parse(dr1["inv_sded"].ToString()) + insdetails.pt_sded;
                        invdetails.inv_copay = decimal.Parse(dr1["inv_copay"].ToString()) + insdetails.pt_copay;
                        invdetails.inv_dcopay = decimal.Parse(dr1["inv_dcopay"].ToString()) + insdetails.pt_dcopay;
                        invdetails.inv_share = decimal.Parse(dr1["inv_share"].ToString()) + insdetails.pt_share;
                        invdetails.inv_net = decimal.Parse(dr1["inv_net"].ToString()) + insdetails.pt_net;
                        invdetails.inv_disc = decimal.Parse(dr1["inv_disc"].ToString()) + insdetails.pt_disc;
                    }
                    else
                    {
                        invdetails.inv_no = qc.qc_invoice_info.inv_no;
                        invdetails.inv_total = insdetails.pt_total;
                        invdetails.inv_tded = insdetails.pt_ded;
                        invdetails.inv_dded = insdetails.pt_dded;
                        invdetails.inv_lded = insdetails.pt_lded;
                        invdetails.inv_rded = insdetails.pt_rded;
                        invdetails.inv_mded = insdetails.pt_mded;
                        invdetails.inv_pded = insdetails.pt_pded;
                        invdetails.inv_sded = insdetails.pt_sded;
                        invdetails.inv_copay = insdetails.pt_copay;
                        invdetails.inv_dcopay = insdetails.pt_dcopay;
                        invdetails.inv_share = insdetails.pt_share;
                        invdetails.inv_net = insdetails.pt_net;
                        invdetails.inv_disc = insdetails.pt_disc;
                    }

                    flag = true;
                }
                else
                {
                    invId = -2;
                    flag = false;
                }

                if (flag)
                {
                    BusinessEntities.Invoice.InvoiceNew _inv = new BusinessEntities.Invoice.InvoiceNew();
                    _inv.invId = 0;
                    _inv.inv_appId = inv.inv_appId;
                    _inv.invId = inv.invId;
                    _inv.inv_no = invdetails.inv_no;
                    _inv.inv_date = insdetails.app_fdate;
                    _inv.inv_total = invdetails.inv_total;
                    _inv.inv_tdisc = 0;
                    _inv.inv_tdisc_type = "Fixed";
                    _inv.inv_net = invdetails.inv_net;
                    _inv.inv_disc = invdetails.inv_disc;
                    _inv.inv_tded = invdetails.inv_tded;
                    _inv.inv_lded = invdetails.inv_lded;
                    _inv.inv_rded = invdetails.inv_rded;
                    _inv.inv_mded = invdetails.inv_mded;
                    _inv.inv_sded = invdetails.inv_sded;
                    _inv.inv_dded = invdetails.inv_dded;
                    _inv.inv_pded = invdetails.inv_pded;
                    _inv.inv_copay = invdetails.inv_copay;
                    _inv.inv_dcopay = invdetails.inv_dcopay;
                    _inv.inv_share = invdetails.inv_share;
                    _inv.inv_notes = string.Empty;
                    _inv.inv_madeby = inv.inv_madeby;
                    _inv.inv_ic_name = insdetails.ic_name;
                    _inv.inv_type = "Insurance";
                    _inv.inv_insurance = insdetails.pt_insurance;
                    _inv.pat_name = inv.pat_name;
                    _inv.pat_code = inv.pat_code;

                    invId = DataAccessLayer.EMR.PatientTreatments.GenerateInsuranceInvoice(_inv, out inv_no, inv.ptIds,multi_bill);
                }
            }

            return invId;
        }

        public static string HtmlInsuranceQuotation(string ptIds)
        {
            BusinessEntities.EMR.TreatmentPrint print = InsuranceQuotation(ptIds);

            StringBuilder sb = new StringBuilder();

            sb.Append("<html>");
            sb.Append("    <head><title>ClinicSoft 9.0 - Quotation (Treatments / Procedures)</title></head>");
            sb.Append("    <body style='font-family: Verdana, Geneva, Tahoma, sans-serif;'>");

            sb.Append("    <table style='width:100%; font-size: 12px; '>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;' colspan='6'>");
            sb.Append($"    <img src='{print.pt_header.set_header_image}' alt='Header Image'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'  colspan='6'>");
            sb.Append("            <h1>QUOTATION (Treatments / Procedures)</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Reg TRN No</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;' colspan='4'>" + print.pt_header.set_vat_regno + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Facility Name </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'  colspan='4'>" + print.pt_header.set_company + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Address </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'  colspan='4'>" + print.pt_header.set_address + " <br/> " + print.pt_header.set_tel + "/" + print.pt_header.set_mob + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;' colspan='6'>");
            sb.Append("            <hr/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Doctor</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.emp_name + "(DHA # -" + print.pt_header.emp_license + ") </td>");
            sb.Append("        <td style='text-align: left;'>Department </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.emp_dept_name + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Patient Name</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.pat_name + "</td>");
            sb.Append("        <td style='text-align: left;'>MRN/File No. </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.pat_code + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Age / Gender</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.pat_age + "/" + print.pt_header.pat_gender + "</td>");
            sb.Append("        <td style='text-align: left;'>Type</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.pt_type + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Visit Date </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.app_fdate + "</td>");
            sb.Append("        <td style='text-align: left;'>Made By</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.madeby_name + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<table style='width:100%; font-size: 12px; border-collapse: collapse; margin-top:10px;'>");
            sb.Append("    <thead>");
            sb.Append("        <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("            <th style='width:5%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>#</th>");
            sb.Append("            <th style='width:40%; text-align: left; border: 1px solid #cdcdcd; padding: 10px;'>Treatment/Procedure</th>");
            sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Qty</th>");
            sb.Append("            <th style='width:10%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Unit Price </th>");
            sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Gross </th>");
            sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Discount</th>");
            sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>NET</th>");
            sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>VAT</th>");
            sb.Append("            <th style='width:10%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>NET + VAT</th>");
            sb.Append("        </tr>");
            sb.Append("    </thead>");
            sb.Append("    <tbody>");

            int count = 0;

            foreach (BusinessEntities.EMR.TreatmentBody i in print.pt_body)
            {
                count++;

                sb.Append("        <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("            <td style='text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>" + count.ToString("D2") + "</td>");
                sb.Append("            <td style='border: 1px solid #cdcdcd; padding: 10px;'>");
                sb.Append("                <strong>" + i.pt_tr_code + "</strong>");
                sb.Append("                <br/>");
                sb.Append("                <p>" + i.pt_tr_name + "</p>");
                sb.Append("            </td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_qty + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_uprice + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_total + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_disc + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_net + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_vat + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pt_netvat + "</td>");
                sb.Append("        </tr>");
            }

            sb.Append("    </tbody>");

            sb.Append("<tfoot>");
            sb.Append("        <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("            <td style='text-align: center; border: 1px solid #cdcdcd; padding: 10px;'></td>");
            sb.Append("            <td style='border: 1px solid #cdcdcd; padding: 10px;'>");
            sb.Append("            </td>");
            sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_qty)) + "</td>");
            sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_uprice)) + "</td>");
            sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_total)) + "</td>");
            sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_disc)) + "</td>");
            sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_net)) + "</td>");
            sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_vat)) + "</td>");
            sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.pt_body.Sum(item => decimal.Parse(item.pt_netvat)) + "</td>");
            sb.Append("        </tr>");
            sb.Append("</tfoot>");

            sb.Append("</table>");

            sb.Append("<table style='width:100%; font-size: 12px; margin-top:10px;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'>");
            sb.Append("            <p>Kindly note that this automated and uniquely dated invoice is payable on this visit before leaving the Center deposit will be automatically deducted upon settlement.</p>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;font-weight:bold'>");
            sb.Append("            Patient Signature");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'>");
            sb.Append($"    <img src='{print.pt_header.set_footer_image}' alt='Footer Image'/>");
            //sb.Append("            <img src='" + print.pt_header.set_footer_image + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }

        public static BusinessEntities.EMR.TreatmentPrint InsuranceQuotation(string ptIds)
        {
            DataSet ds = DataAccessLayer.EMR.PatientTreatments.PrintInsuranceQuotation(ptIds);

            TreatmentHeader header = new TreatmentHeader();
            TreatmentFooter footer = new TreatmentFooter();
            List<TreatmentBody> body = new List<TreatmentBody>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    header.set_vat_regno = dr["set_vat_regno"].ToString();
                    header.set_company = dr["set_company"].ToString();
                    header.set_address = dr["set_address"].ToString();
                    header.set_tel = dr["set_tel"].ToString();
                    header.set_mob = dr["set_mob"].ToString();
                    header.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", dr["set_header_image"].ToString());
                    header.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", dr["set_footer_image"].ToString());

                    header.pt_date_created = DateTime.Parse(dr["pt_date_created"].ToString()).ToString("HH:mm:ss");
                    header.emp_name = dr["emp_name"].ToString();
                    header.emp_license = dr["emp_license"].ToString();
                    header.emp_dept_name = dr["emp_dept_name"].ToString();
                    header.pat_name = dr["pat_name"].ToString();
                    header.pat_code = dr["pat_code"].ToString();
                    header.pt_type = dr["pt_type"].ToString();
                    header.pat_gender = dr["pat_gender"].ToString();
                    header.pt_date_created = dr["pt_date_created"].ToString();
                    header.madeby_name = dr["madeby_name"].ToString();

                    DateTime dateTimeToday = DateTime.Now;
                    DateTime birthDate = DateTime.Parse(dr["pat_dob"].ToString());

                    TimeSpan difference = dateTimeToday.Subtract(birthDate);
                    var firstDay = new DateTime(1, 1, 1);
                    int totalYears = (firstDay + difference).Year - 1;
                    int totalMonths = (totalYears * 12) + (firstDay + difference).Month - 1;
                    int runningMonths = totalMonths - (totalYears * 12);
                    int runningDays = (dateTimeToday - birthDate.AddMonths((totalYears * 12) + runningMonths)).Days;

                    header.pat_age = $"{totalYears}Y - {runningMonths}M - {runningDays}D";

                    header.app_fdate = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd-MMM-yyyy") + " " + dr["app_doc_ftime"].ToString() + " - " + dr["app_doc_ttime"].ToString();
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        TreatmentBody i = new TreatmentBody();
                        i.pt_tr_code = dr["pt_tr_code"].ToString();
                        i.pt_tr_name = dr["pt_tr_name"].ToString();
                        i.pt_uprice = decimal.Parse(dr["pt_uprice"].ToString()).ToString("N2");
                        i.pt_qty = decimal.Parse(dr["pt_qty"].ToString()).ToString("N2");
                        i.pt_total = decimal.Parse(dr["pt_total"].ToString()).ToString("N2");
                        i.pt_disc = decimal.Parse(dr["pt_disc"].ToString()).ToString("N2");
                        i.pt_vat = decimal.Parse(dr["pt_vat"].ToString()).ToString("N2");
                        i.pt_net = decimal.Parse(dr["pt_net"].ToString()).ToString("N2");
                        i.pt_netvat = (decimal.Parse(i.pt_net) + decimal.Parse(i.pt_vat)).ToString("N2");
                        body.Add(i);
                    }
                }
            }

            TreatmentPrint print = new TreatmentPrint();
            print.pt_header = header;
            print.pt_body = body;
            print.pt_footer = footer;

            return print;
        }
        #endregion

        #region EAUTH Prior Requests
        public static int UpdateResubTypeComments(string ptIds, string pt_resub_type, string pt_resub_notes)
        {
            return DataAccessLayer.EMR.PatientTreatments.UpdateResubTypeComments(ptIds, pt_resub_type, pt_resub_notes);

        }

        public static DataSet GetPatientTreatmentsPriorRequestDirect(int appId, string ptIds)
        {
            return DataAccessLayer.EMR.PatientTreatments.GetPatientTreatmentsPriorRequestDirect(appId, ptIds);
        }

        public static DataSet GetPatientTreatmentsPriorRequestCancel(int appId, string ptIds)
        {
            return DataAccessLayer.EMR.PatientTreatments.GetPatientTreatmentsPriorRequestCancel(appId, ptIds);
        }

        public static int EAUTH_Prior_Requests_insert(DateTime epr_date, string epr_ID, string epr_sender, string epr_receiver, string epr_filename, string epr_file, string epr_ErrorMessage, int epr_appId, int madeby)
        {
            return DataAccessLayer.EMR.PatientTreatments.EAUTH_Prior_Requests_insert(epr_date, epr_ID, epr_sender, epr_receiver, epr_filename, epr_file, epr_ErrorMessage, epr_appId, madeby);
        }

        public static int UpdatePatientTreatmentPRStatus(int ptId, string pt_status)
        {
            return DataAccessLayer.EMR.PatientTreatments.UpdatePatientTreatmentPRStatus(ptId, pt_status);

        }

        public static int UpdateBatch(int ptId, int pt_appId)
        {
            return DataAccessLayer.EMR.PatientTreatments.UpdateBatch(ptId, pt_appId);

        }

        public static int ClearBatch(int ptId, int pt_appId)
        {
            return DataAccessLayer.EMR.PatientTreatments.ClearBatch(ptId, pt_appId);

        }
        #endregion

        #region Packages
        public static List<PackageOrder> GetPatientPackageOrders(int patId = 0)
        {
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.GetPatientPackageOrders(patId);

            List<PackageOrder> data = new List<PackageOrder>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackageOrder _data = new PackageOrder();
                    _data.poId = int.Parse(dr["poId"].ToString());
                    _data.po_package = dr["po_package"].ToString();
                    _data.po_refno = dr["po_refno"].ToString();
                    _data.po_details = dr["po_details"].ToString();
                    _data.po_package_name = dr["po_package_name"].ToString();
                    _data.po_pkg_price = decimal.Parse(dr["po_pkg_price"].ToString());
                    _data.total_cash = decimal.Parse(dr["total"].ToString());
                    _data.total_recieved = decimal.Parse(dr["total_recieved"].ToString());
                    _data.pkg_advance = decimal.Parse(dr["pkg_advance"].ToString());
                    _data.pkg_total_allocated = decimal.Parse(dr["pkg_total_allocated"].ToString());
                    _data.pkg_adv_bal = decimal.Parse(dr["pkg_adv_bal"].ToString());
                    _data.pkg_balance = decimal.Parse(dr["pkg_balance"].ToString());
                    _data.po_notes = dr["po_notes"].ToString();
                    _data.po_status = dr["po_status"].ToString();
                    _data.po_date = DateTime.Parse(dr["po_date"].ToString()).ToString("dd-MM-yyyy");
                    _data.po_exp_date = DateTime.Parse(dr["po_exp_date"].ToString()).ToString("dd-MM-yyyy");
                    data.Add(_data);
                }
            }
            return data;
        }

        public static BusinessEntities.EMR.Cash_PackService PatientPackageOrder(int poId, int appId, int patId)
        {
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.PatientPackageOrder(poId, appId, patId);
            BusinessEntities.EMR.Cash_PackService qc = new BusinessEntities.EMR.Cash_PackService();
            PatientTreatments info = new PatientTreatments();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                qc.poId = int.Parse(poId.ToString());
                qc.appId = int.Parse(appId.ToString());
                qc.patId = int.Parse(patId.ToString()); ;
                qc.po_patient = int.Parse(patId.ToString());
                qc.po_packagename = dr["po_packagename"].ToString();
                qc.po_packageprice = decimal.Parse(dr["po_packageprice"].ToString());
            }
            return qc;
        }

        public static List<BusinessEntities.EMR.Cash_PackService> GetPatientPackageServices(int poId, int appId, int patId)
        {
            List<BusinessEntities.EMR.Cash_PackService> sclist = new List<BusinessEntities.EMR.Cash_PackService>();
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.GetPatientPackageServices(poId, appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.Cash_PackService
                {
                    posId = Convert.ToInt32(dr["posId"]),
                    pos_refno = dr["pos_refno"].ToString(),
                    pos_date = Convert.ToDateTime(dr["pos_date"].ToString()),
                    pos_patient = Convert.ToInt32(dr["pos_poId"].ToString()),
                    pos_poId = Convert.ToInt32(dr["pos_poId"].ToString()),
                    pos_psId = Convert.ToInt32(dr["pos_psId"].ToString()),
                    pos_pkgId = Convert.ToInt32(dr["pos_pkgId"].ToString()),
                    pos_pkg_name = dr["pos_pkg_name"].ToString(),
                    pos_pkg_price = Convert.ToDecimal(dr["pos_pkg_price"].ToString()),
                    pos_services = Convert.ToInt32(dr["pos_services"].ToString()),
                    pos_qty = Convert.ToInt32(dr["pos_qty"].ToString()),
                    pos_usedqty = Convert.ToInt32(dr["pos_usedqty"].ToString()),
                    pos_balqty = Convert.ToInt32(dr["pos_balqty"].ToString()),
                    pos_ps_oriPrice = Convert.ToDecimal(dr["pos_ps_oriPrice"].ToString()),
                    pos_ps_disPrice = Convert.ToDecimal(dr["pos_ps_disPrice"].ToString()),
                    pos_ps_unitPrice = Convert.ToDecimal(dr["pos_ps_unitPrice"].ToString()),
                    pos_notes = dr["pos_notes"].ToString(),
                    pos_branch = Convert.ToInt32(dr["pos_branch"].ToString()),
                    pos_exp_date = Convert.ToDateTime(dr["pos_exp_date"].ToString()),
                    pos_ps_services_code = dr["pos_ps_services_code"].ToString(),
                    pos_ps_services_name = dr["pos_ps_services_name"].ToString(),
                    pos_ps_services_price = Convert.ToDecimal(dr["pos_ps_services_price"].ToString()),
                    pos_status = dr["pos_status"].ToString(),
                    pos_madeby = Convert.ToInt32(dr["pos_madeby"].ToString()),
                    pos_date_created = Convert.ToDateTime(dr["pos_date_created"].ToString()),
                    pos_date_modified = Convert.ToDateTime(dr["pos_date_modified"].ToString())

                });

            }
            return sclist;
        }

        public static int GenerateTreatmentsandInvoice(BusinessEntities.EMR.PT_treatments data, int madeby, out string inv_no)
        {
            return DataAccessLayer.EMR.PatientTreatments.GenerateTreatmentsandInvoice(data, madeby, out inv_no);
        }

        public static int GenerateTreatments(BusinessEntities.EMR.PT_treatments data, int madeby)
        {
            return DataAccessLayer.EMR.PatientTreatments.GenerateTreatments(data, madeby);
        }
        #endregion

        public static int GetInvoiceId(int invId)
        {
            return DataAccessLayer.EMR.PatientTreatments.GetInvoiceId(invId);
        }

        public static List<BusinessEntities.EMR.PatientTreatments> GetRadiologyTreatments(int? appId, string type)
        {
            List<BusinessEntities.EMR.PatientTreatments> sclist = new List<BusinessEntities.EMR.PatientTreatments>();
            DataTable dt = DataAccessLayer.EMR.PatientTreatments.GetRadiologyTreatments(appId, type);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.PatientTreatments
                {
                    ptId = Convert.ToInt32(dr["ptId"]),
                    pt_appId = Convert.ToInt32(dr["pt_appId"]),
                    tr_code = dr["tr_code"].ToString(),
                    tr_name = dr["tr_name"].ToString(),
                    tr_name_type = dr["tr_name_type"].ToString(),
                    pt_qty = Convert.ToInt32(dr["pt_qty"].ToString()),
                    pt_status = dr["pt_status"].ToString(),
                    pt_date_received = Convert.ToDateTime(dr["pt_date_received"].ToString()),
                    pt_date_collected = Convert.ToDateTime(dr["pt_date_collected"].ToString()),
                    pt_uprice = Convert.ToDecimal(dr["pt_uprice"].ToString()),
                    pt_total = Convert.ToDecimal(dr["pt_total"].ToString()),
                    pt_disc = Convert.ToDecimal(dr["pt_disc"].ToString()),
                    pt_net = Convert.ToDecimal(dr["pt_net"].ToString()),
                    pt_ded = Convert.ToDecimal(dr["pt_ded"].ToString()),
                    pt_copay = Convert.ToDecimal(dr["pt_copay"].ToString()),
                    pt_dcopay = Convert.ToDecimal(dr["pt_dcopay"].ToString()),
                    pt_dded = Convert.ToDecimal(dr["pt_dded"].ToString()),
                    pt_lded = Convert.ToDecimal(dr["pt_lded"].ToString()),
                    pt_rded = Convert.ToDecimal(dr["pt_rded"].ToString()),
                    pt_mded = Convert.ToDecimal(dr["pt_mded"].ToString()),
                    pt_ceiling = Convert.ToDecimal(dr["pt_ceiling"].ToString()),
                    pat__share = Convert.ToDecimal(dr["pat__share"].ToString()),
                    pt_vat = Convert.ToDecimal(dr["pt_vat"].ToString()),
                    pt_net_vat = Convert.ToDecimal(dr["pt_net_vat"].ToString()),
                    pt_lab_status = dr["pt_lab_status"].ToString(),
                    pt_tdn_notes = dr["pt_tdn_notes"].ToString(),
                    pt_coupon = dr["pt_coupon"].ToString(),
                    pt_coupon_disc = Convert.ToDecimal(dr["pt_coupon_disc"].ToString()),
                    pt_ses = Convert.ToInt32(dr["pt_ses"]),
                    pt_pack_exp_date = Convert.ToDateTime(dr["pt_pack_exp_date"].ToString()),
                    pt_notes = dr["pt_notes"].ToString(),
                    ip_name = dr["ip_name"].ToString(),
                    tr_type = dr["tr_type"].ToString(),
                    pt_treatment = Convert.ToInt32(dr["pt_treatment"])
                });

            }
            return sclist;
        }
    }
}