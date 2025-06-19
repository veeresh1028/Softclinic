using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web.UI;
using System.Data.SqlClient;
using BusinessEntities.EMR;
using System.Configuration;
using System.IO;
using BusinessEntities.Appointment.AuditLogs;

namespace BusinessLogicLayer.EMR
{
    public class Prescription
    {
        #region Prescription (Page Load)
        public static List<BusinessEntities.EMR.Prescription> GetAllPrescription(int? appId, int? preId, string pre_med_type)
        {
            List<BusinessEntities.EMR.Prescription> list = new List<BusinessEntities.EMR.Prescription>();

            DataTable dt = DataAccessLayer.EMR.Prescription.GetAllPrescription(appId, preId, pre_med_type);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BusinessEntities.EMR.Prescription
                    {
                        preId = Convert.ToInt32(dr["preId"]),
                        pre_appId = Convert.ToInt32(dr["pre_appId"]),

                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        item_brand = dr["item_brand"].ToString(),
                        item_dosage = dr["item_dosage"].ToString(),
                        item_strength = dr["item_strength"].ToString(),
                        pre_temp3 = dr["pre_temp3"].ToString(),
                        pre_temp4 = dr["pre_temp4"].ToString(),
                        pre_temp5 = dr["pre_temp5"].ToString(),
                        pre_duration = dr["pre_duration"].ToString(),
                        pre_qty_type = dr["pre_qty_type"].ToString(),
                        ra_code_desc = dr["ra_code_desc"].ToString(),
                        pre_instr = dr["pre_instr"].ToString(),
                        pre_status = dr["pre_status"].ToString(),


                        pre_medicine = Convert.ToInt32(dr["pre_medicine"]),
                        pre_temp6 = dr["pre_temp6"].ToString(),
                        pre_type = dr["pre_type"].ToString(),
                        pre_temp1 = dr["pre_temp1"].ToString(),
                        pre_eRxRefNo = dr["pre_eRxRefNo"].ToString(),
                        pre_qty = Convert.ToInt32(dr["pre_qty"]),

                    });
                }
            }

            return list;
        }

        public static List<BusinessEntities.EMR.Prescription> GetAllPrescriptionPrint(int? appId)
        {
            List<BusinessEntities.EMR.Prescription> list = new List<BusinessEntities.EMR.Prescription>();

            DataTable dt = DataAccessLayer.EMR.Prescription.GetAllPrescriptionPrint(appId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BusinessEntities.EMR.Prescription
                    {
                        preId = Convert.ToInt32(dr["preId"]),
                        pre_appId = Convert.ToInt32(dr["pre_appId"]),

                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        item_brand = dr["item_brand"].ToString(),
                        item_dosage = dr["item_dosage"].ToString(),
                        item_strength = dr["item_strength"].ToString(),
                        pre_temp3 = dr["pre_temp3"].ToString(),
                        pre_temp4 = dr["pre_temp4"].ToString(),
                        pre_temp5 = dr["pre_temp5"].ToString(),
                        pre_duration = dr["pre_duration"].ToString(),
                        pre_qty_type = dr["pre_qty_type"].ToString(),
                        ra_code_desc = dr["ra_code_desc"].ToString(),
                        pre_instr = dr["pre_instr"].ToString(),
                        pre_status = dr["pre_status"].ToString(),

                        pre_medicine = Convert.ToInt32(dr["pre_medicine"]),
                        pre_temp6 = dr["pre_temp6"].ToString(),
                        pre_type = dr["pre_type"].ToString(),
                        pre_temp1 = dr["pre_temp1"].ToString(),
                        pre_eRxRefNo = dr["pre_eRxRefNo"].ToString(),
                        pre_qty = Convert.ToInt32(dr["pre_qty"])
                    });
                }
            }

            return list;
        }

        public static List<BusinessEntities.EMR.Prescription> GetPrePrescription(int appId, int patId, string pre_med_type)
        {
            List<BusinessEntities.EMR.Prescription> list = new List<BusinessEntities.EMR.Prescription>();

            DataTable dt = DataAccessLayer.EMR.Prescription.GetPrePrescription(appId, patId, pre_med_type);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BusinessEntities.EMR.Prescription
                    {
                        preId = Convert.ToInt32(dr["preId"]),
                        pre_appId = Convert.ToInt32(dr["pre_appId"]),
                        item_name = dr["item_name"].ToString(),
                        item_code = dr["item_code"].ToString(),
                        item_brand = dr["item_brand"].ToString(),
                        item_dosage = dr["item_dosage"].ToString(),
                        item_strength = dr["item_strength"].ToString(),
                        pre_temp3 = dr["pre_temp3"].ToString(),
                        pre_temp4 = dr["pre_temp4"].ToString(),
                        pre_temp5 = dr["pre_temp5"].ToString(),
                        pre_duration = dr["pre_duration"].ToString(),
                        pre_qty_type = dr["pre_qty_type"].ToString(),
                        ra_code_desc = dr["ra_code_desc"].ToString(),
                        pre_instr = dr["pre_instr"].ToString(),
                        pre_status = dr["pre_status"].ToString(),
                        doctor_name = dr["doctor_name"].ToString(),
                        app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString())
                    });
                }
            }

            return list;
        }

        public static List<CommonDDL> GetPrescriptionType(string query, int type)
        {
            DataTable dt = DataAccessLayer.EMR.Prescription.GetPrescriptionType(query, type);

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

        public static List<CommonDDL> GetMedicine(string query, int type, string plan, int pre_doctor)
        {
            DataTable dt = DataAccessLayer.EMR.Prescription.GetMedicine(query, type, plan, pre_doctor);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["item_code"].ToString() + " | (" + dr["item_name"].ToString() + ") | " + dr["item_dosage"].ToString() + " - " + dr["item_brand"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static List<GetByName> GetRouteOfAdmin(string query, string flag)
        {
            DataTable dt = DataAccessLayer.EMR.Prescription.GetRouteOfAdmin(query, flag);

            List<GetByName> data = new List<GetByName>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    GetByName _data = new GetByName();
                    _data.id = dr["id"].ToString();
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
        #endregion

        #region Prescription CRUD Operations
        public static int InsertPrescription(BusinessEntities.EMR.Prescription data)
        {
            data.pre_type = string.IsNullOrEmpty(data.pre_type) ? string.Empty : data.pre_type;
            data.pre_qtype = string.IsNullOrEmpty(data.pre_qtype) ? string.Empty : data.pre_qtype;
            data.pre_duration = string.IsNullOrEmpty(data.pre_duration) ? string.Empty : data.pre_duration;
            data.pre_temp1 = string.IsNullOrEmpty(data.pre_temp1) ? string.Empty : data.pre_temp1;
            data.pre_temp2 = string.IsNullOrEmpty(data.pre_temp2) ? string.Empty : data.pre_temp2;
            data.pre_temp3 = string.IsNullOrEmpty(data.pre_temp3) ? string.Empty : data.pre_temp3;
            data.pre_temp6 = string.IsNullOrEmpty(data.pre_temp6) ? string.Empty : data.pre_temp6;

            return DataAccessLayer.EMR.Prescription.InsertPrescription(data);
        }

        public static int UpdatePrescription(BusinessEntities.EMR.Prescription data)
        {
            return DataAccessLayer.EMR.Prescription.UpdatePrescription(data);
        }

        public static int DeletePrescription(int preId, int pre_madeby)
        {
            return DataAccessLayer.EMR.Prescription.DeletePrescription(preId, pre_madeby);
        }

        public static string HtmlPrescription(string preId, int pre_appId)
        {
            BusinessEntities.EMR.PrescriptionPrint print = PrintPrescription(preId, pre_appId);

            StringBuilder sb = new StringBuilder();

            sb.Append("<html>");
            sb.Append("    <head><title>ClinicSoft 9.0 - Prescription</title></head>");
            sb.Append("    <body style='font-family: Verdana, Geneva, Tahoma, sans-serif;'>");

            sb.Append("    <table style='width:100%; font-size: 14px; '>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;' colspan='6'>");
            sb.Append("            <img src='" + print.pt_header.set_header_image + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;' colspan='6'>");
            sb.Append("            <h1>Prescription</h1>");
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
            sb.Append("        <td style='text-align: left;' colspan='4'>" + print.pt_header.set_company + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr'>");
            sb.Append("        <td style='text-align: left;'>Address </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;' colspan='4'> <br/>" + print.pt_header.set_address + " <br/> " + print.pt_header.set_tel + "/" + print.pt_header.set_mob + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;' colspan='6'>");
            sb.Append("            <hr/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Doctor</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.emp_name + " (DHA # -" + print.pt_header.emp_license + ") </td>");
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
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.type + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Visit Date </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.app_fdate + "</td>");
            sb.Append("        <td style='text-align: left;'>Made By</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>" + print.pt_header.madeby_name + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Principal Diagnosis</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;' colspan='4'>" + print.pt_header.PrimaryD + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Secondary Diagnosis</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;' colspan='4'>" + print.pt_header.SecD + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<table style='width:100%; font-size: 14px; border-collapse: collapse; margin-top:10px;'>");
            sb.Append("    <thead>");
            sb.Append("        <tr style='border: 1px solid #cdcdcd;'>");
            sb.Append("            <th style='width:5%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'></th>");
            sb.Append("            <th style='width:15%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Generic</th>");
            sb.Append("            <th style='width:15%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Brand</th>");
            sb.Append("            <th style='width:15%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>ERX Ref.</th>");
            sb.Append("            <th style='width:20%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Dosage</th>");
            sb.Append("            <th style='width:10%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Strength</th>");
            sb.Append("            <th style='width:20%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Instructions</th>");
            sb.Append("            <th style='width:10%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Quantity</th>");
            sb.Append("            <th style='width:20%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Route of Admin</th>");
            sb.Append("        </tr>");
            sb.Append("    </thead>");
            sb.Append("    <tbody>");

            int count = 0;

            foreach (BusinessEntities.EMR.PrescriptionBody i in print.pt_body)
            {
                count++;

                sb.Append("        <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("            <td style='text-align: center; border: 1px solid #cdcdcd; padding: 5px;'>" + count.ToString("D2") + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 15px;'>" + i.item_name + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 15px;'>" + i.item_brand + "</td>");
                sb.Append("            <td style='text-align: center;border: 1px solid #cdcdcd; padding: 15px;'>" + i.item_erx_ref + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 20px;'>" + i.item_dosage + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + i.item_strength + "</td>");
                sb.Append("            <td style='text-align: left;border: 1px solid #cdcdcd; padding: 20px;'>" + i.pre_instr + "</td>");
                sb.Append("            <td style='text-align: center;border: 1px solid #cdcdcd; padding: 10px;'>" + i.pre_qty_type + "</td>");
                sb.Append("            <td style='text-align: left;border: 1px solid #cdcdcd; padding: 20px;'>" + i.ra_code_desc + "</td>");
                sb.Append("        </tr>");
            }

            sb.Append("    </tbody>");
            sb.Append("</table>");

            sb.Append("<table style='width:100%; font-size: 14px;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'>");
            sb.Append("            <img src='" + print.pt_header.id_card_front + "' width='400px' Height='300px'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<div style='width:100%; font-size: 14px; margin-bottom:0px;bottom:0px;'>");

            // Footer with CSS positioning
            sb.Append("    <div style='position: fixed; bottom: 0; width: 100%; margin-top: 10px;'>");
            sb.Append("<table style='width:100%; font-size: 14px;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;' colspan='4'>");
            sb.Append("            <p>P.S.: Kindly note that this is automated For Pharmacy.</p><br/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left; width:20%;'>Doctor Name </td>");
            sb.Append("        <td style='text-align: left; width:20%;'>License Number </td>");
            sb.Append("        <td style='text-align: left; width:30%;'>Date </td>");
            sb.Append("        <td style='text-align: left; width:30%;'>Signature & Stamp </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left; width:20%;'>" + print.pt_header.emp_name + "</td>");
            sb.Append("        <td style='text-align: left; width:20%;'>" + print.pt_header.emp_license + " </td>");
            sb.Append("        <td style='text-align: left; width:30%;'> " + print.pt_header.app_fdate + "</td>");
            sb.Append("        <td style='text-align: left; width:30%;'><img src='" + print.pt_header.emp_sign + "' width='80px' Height='60px'/></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;' colspan='4'>");
            sb.Append("            <img src='" + print.pt_header.set_footer_image + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    </div>");
            sb.Append("</div>");

            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }

        public static BusinessEntities.EMR.PrescriptionPrint PrintPrescription(string preId, int pre_appId)
        {
            DataSet ds = DataAccessLayer.EMR.Prescription.PrintPrescription(preId, pre_appId);
            DataSet ds1 = DataAccessLayer.EMR.Prescription.PrintPrescriptionPD(pre_appId);

            PrescriptionHeader header = new PrescriptionHeader();
            PrescriptionFooter footer = new PrescriptionFooter();
            List<PrescriptionBody> body = new List<PrescriptionBody>();

            if (ds1.Tables.Count > 0)
            {
                DataRow dr1 = ds1.Tables[0].Rows[0];
                header.PrimaryD = dr1["PrimaryDiagnosis"].ToString();
                header.SecD = dr1["SecondaryDiagnosis"].ToString();
            }

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
                    header.emp_sign = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "EMPLOYEE_SIGNS", string.IsNullOrEmpty(dr["emp_sign"].ToString()) ? "signature_bg.jpg" : dr["emp_sign"].ToString());
                    header.id_card_front = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "patient_images", string.IsNullOrEmpty(dr["id_card_front"].ToString()) ? "signature_bg.jpg" : dr["id_card_front"].ToString());

                    header.emp_name = dr["emp_name"].ToString();
                    header.emp_license = dr["emp_license"].ToString();
                    header.emp_dept_name = dr["emp_dept_name"].ToString();
                    header.pat_name = dr["pat_name"].ToString();
                    header.pat_code = dr["pat_code"].ToString();
                    header.type = dr["app_ic_name"].ToString();
                    header.pat_gender = dr["pat_gender"].ToString();
                    header.app_fdate = dr["app_fdate"].ToString();
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
                        PrescriptionBody i = new PrescriptionBody();
                        i.item_name = dr["item_name"].ToString();
                        i.item_brand = dr["item_brand"].ToString();
                        i.item_dosage = dr["item_dosage"].ToString();
                        i.item_strength = dr["item_strength"].ToString();
                        i.item_erx_ref = (string.IsNullOrEmpty(dr["pre_eRxRefNo"].ToString())) ? "-" : dr["pre_eRxRefNo"].ToString();
                        i.pre_instr = dr["pre_instr"].ToString();
                        i.pre_qty_type = dr["pre_qty_type"].ToString();
                        i.ra_code_desc = dr["ra_code_desc"].ToString();
                        body.Add(i);
                    }
                }
            }

            PrescriptionPrint print = new PrescriptionPrint();
            print.pt_header = header;
            print.pt_body = body;
            print.pt_footer = footer;

            return print;
        }
        #endregion

        #region Prescription Favourites (Page Load)
        public static List<BusinessEntities.EMR.PrescriptionFavourites> GetAllPrescriptionFavourites(int? empId, int? prefId)
        {
            List<BusinessEntities.EMR.PrescriptionFavourites> sclist = new List<BusinessEntities.EMR.PrescriptionFavourites>();

            try
            {
                DataTable dt = DataAccessLayer.EMR.Prescription.GetAllPrescriptionFavourites(empId, prefId);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        sclist.Add(new BusinessEntities.EMR.PrescriptionFavourites
                        {
                            prefId = Convert.ToInt32(dr["prefId"]),
                            pref_empId = Convert.ToInt32(dr["pref_empId"]),
                            item_name = dr["item_name"].ToString(),
                            item_code = dr["item_code"].ToString(),
                            item_brand = dr["item_brand"].ToString(),
                            item_dosage = dr["item_dosage"].ToString(),
                            item_strength = dr["item_strength"].ToString(),
                            pref_temp3 = dr["pref_temp3"].ToString(),
                            pref_temp4 = dr["pref_temp4"].ToString(),
                            pref_temp5 = dr["pref_temp5"].ToString(),
                            pref_duration = dr["pref_duration"].ToString(),
                            pref_qty_type = dr["pref_qty_type"].ToString(),
                            ra_code_desc = dr["ra_code_desc"].ToString(),
                            pref_instr = dr["pref_instr"].ToString(),
                            pref_status = dr["pref_status"].ToString(),

                            pref_medicine = Convert.ToInt32(dr["pref_medicine"]),
                            pref_temp6 = dr["pref_temp6"].ToString(),
                            pref_type = dr["pref_type"].ToString(),
                            pref_temp1 = dr["pref_temp1"].ToString(),
                            pref_qty = Convert.ToInt32(dr["pref_qty"]),
                            pref_oc_code = dr["pref_oc_code"].ToString(),
                            pref_oc_type = dr["pref_oc_type"].ToString(),
                            pref_qtype = dr["pref_qtype"].ToString(),
                            pref_ra_code = dr["pref_ra_code"].ToString(),
                            pref_ra_type = dr["pref_ra_type"].ToString(),
                            pref_temp2 = dr["pref_temp2"].ToString()
                        });
                    }
                }

                return sclist;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Prescription Favourites CRUD Operations
        public static int InsertUpdatePrescriptionFavourites(BusinessEntities.EMR.PrescriptionFavourites data)
        {
            data.pref_qtype = string.IsNullOrEmpty(data.pref_qtype) ? string.Empty : data.pref_qtype;

            return DataAccessLayer.EMR.Prescription.InsertUpdatePrescriptionFavourites(data);
        }

        public static int DeletePrescriptionFavourites(int prefId, int pref_madeby)
        {
            return DataAccessLayer.EMR.Prescription.DeletePrescriptionFavourites(prefId, pref_madeby);
        }
        #endregion

        #region Prescription Controlled (Page Load)
        public static List<CommonDDL> GetDrugMedicine(string query)
        {
            DataTable dt = DataAccessLayer.EMR.Prescription.GetDrugMedicine(query);
            List<CommonDDL> data = new List<CommonDDL>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["item_code"].ToString() + " | " + dr["item_brand"].ToString() + " | (" + dr["item_name"].ToString() + ") | " + dr["item_dosage"].ToString();
                    data.Add(_data);
                }
            }
            return data;

        }

        public static List<BusinessEntities.EMR.ControlledDrug> GetControlledDrugPrescription(int? appId)
        {
            List<BusinessEntities.EMR.ControlledDrug> sclist = new List<BusinessEntities.EMR.ControlledDrug>();
            DataTable dt = DataAccessLayer.EMR.Prescription.GetControlledDrugPrescription(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.ControlledDrug
                {
                    precId = Convert.ToInt32(dr["precId"]),
                    prec_appId = Convert.ToInt32(dr["prec_appId"]),

                    item_name = dr["item_name"].ToString(),
                    item_code = dr["item_code"].ToString(),
                    item_brand = dr["item_brand"].ToString(),
                    item_dosage = dr["item_dosage"].ToString(),
                    item_strength = dr["item_strength"].ToString(),
                    prec_temp3 = dr["prec_temp3"].ToString(),
                    prec_temp4 = dr["prec_temp4"].ToString(),
                    prec_temp5 = dr["prec_temp5"].ToString(),
                    prec_duration = dr["prec_duration"].ToString(),
                    prec_qty_type = dr["prec_qty_type"].ToString(),
                    ra_code_desc = dr["ra_code_desc"].ToString(),
                    prec_instr = dr["prec_instr"].ToString(),
                    prec_status = dr["prec_status"].ToString(),


                    prec_medicine = Convert.ToInt32(dr["prec_medicine"]),
                    prec_temp6 = dr["prec_temp6"].ToString(),
                    prec_oj_type = dr["prec_oj_type"].ToString(),
                    prec_oj_code = dr["prec_oj_code"].ToString(),
                    prec_type = dr["prec_type"].ToString(),
                    prec_temp1 = dr["prec_temp1"].ToString(),
                    prec_qty = Convert.ToInt32(dr["prec_qty"]),

                });
            }
            return sclist;
        }
        #endregion

        #region Prescription Controlled CRUD Operations
        public static ControlDrugRequest GetRequestString(DataTable dtAppInfo, ControlledDrug data)
        {
            DataRow dr = dtAppInfo.Rows[0];
            ControlDrugRequest request = new ControlDrugRequest();


            if (dtAppInfo.Rows.Count > 0)
            {
                Subject subject = new Subject();
                subject.reference = "Patient?identifier=" + dtAppInfo.Rows[0]["pat_emirateid"].ToString().Replace("-", "");
                subject.display = dtAppInfo.Rows[0]["pat_fullname"].ToString();

                Agent agent = new Agent();
                agent.reference = "Practitioner?identifier=" + dtAppInfo.Rows[0]["emp_license"].ToString();
                agent.display = dtAppInfo.Rows[0]["emp_name"].ToString();

                OnBehalfOf onBehalfOf = new OnBehalfOf();
                onBehalfOf.reference = "Organization?identifier=" + dtAppInfo.Rows[0]["set_permit_no"].ToString();
                onBehalfOf.display = dtAppInfo.Rows[0]["set_company"].ToString();

                Requester requester = new Requester();
                requester.agent = agent;
                requester.onBehalfOf = onBehalfOf;

                DataTable dtDiag = DataAccessLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(data.prec_appId, 0);

                if (dtDiag.Rows.Count > 0)
                {
                    List<Coding> lis_primary_coding = new List<Coding>();
                    List<Coding> lis_secondary_coding = new List<Coding>();

                    foreach (DataRow drDiag in dtDiag.Rows)
                    {
                        if (drDiag["pad_type"].ToString().Equals("Primary"))
                        {
                            Coding coding = new Coding();
                            coding.code = drDiag["diag_code"].ToString();
                            coding.system = "http://hl7.org/fhir/sid/icd-10";
                            lis_primary_coding.Add(coding);

                            Coding coding2 = new Coding();
                            coding2.code = "principal";
                            coding2.system = "http://hl7.org/fhir/ex-diagnosistype";
                            lis_primary_coding.Add(coding2);
                        }
                        else
                        {
                            Coding coding = new Coding();
                            coding.code = drDiag["diag_code"].ToString();
                            coding.system = "http://hl7.org/fhir/sid/icd-10";
                            lis_secondary_coding.Add(coding);

                            Coding coding2 = new Coding();
                            coding2.code = "differential";
                            coding2.system = "http://hl7.org/fhir/ex-diagnosistype";
                            lis_secondary_coding.Add(coding2);
                        }
                    }

                    List<ReasonCode> list_reasonCode = new List<ReasonCode>();

                    if (lis_primary_coding.Count > 0)
                    {
                        ReasonCode reasonCode = new ReasonCode();
                        reasonCode.coding = lis_primary_coding;
                        list_reasonCode.Add(reasonCode);
                    }

                    if (lis_secondary_coding.Count > 0)
                    {
                        ReasonCode reasonCode = new ReasonCode();
                        reasonCode.coding = lis_secondary_coding;
                        list_reasonCode.Add(reasonCode);
                    }

                    ValidityPeriod validityPeriod = new ValidityPeriod();
                    validityPeriod.start = DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss.ff") + "+04:00";
                    validityPeriod.end = DateTime.Now.AddDays(int.Parse(data.prec_duration)).ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss.ff") + "+04:00";

                    ExpectedSupplyDuration expectedSupplyDuration = new ExpectedSupplyDuration();
                    expectedSupplyDuration.unit = "days";
                    expectedSupplyDuration.value = int.Parse(data.prec_duration);

                    DispenseRequest dispenseRequest = new DispenseRequest();
                    dispenseRequest.validityPeriod = validityPeriod;
                    dispenseRequest.expectedSupplyDuration = expectedSupplyDuration;
                    dispenseRequest.numberOfRepeatsAllowed = 1;

                    Route route = new Route();
                    route.text = data.prec_temp6;

                    DoseQuantity doseQuantity = new DoseQuantity();
                    doseQuantity.unit = data.prec_type;
                    doseQuantity.value = int.Parse(data.prec_temp3);

                    Timing timing = new Timing();
                    Repeat repeat = new Repeat();
                    repeat.frequency = int.Parse(data.prec_temp4);
                    repeat.period = int.Parse(data.prec_duration);

                    //units=> s = second; min =minute; h = hour; d = day; wk = week; mo = month; a = year.
                    switch (data.prec_temp5)
                    {
                        case "Day": repeat.periodUnit = "d"; break;
                        case "Week": repeat.periodUnit = "wk"; break;
                        case "Hour": repeat.periodUnit = "h"; break;
                        case "Month": repeat.periodUnit = "mo"; break;
                        case "Year": repeat.periodUnit = "a"; break;
                        default: repeat.periodUnit = "d"; break;
                    }



                    timing.repeat = repeat;

                    List<DosageInstruction> list_dosageInstruction = new List<DosageInstruction>();

                    DosageInstruction dosageInstruction = new DosageInstruction();
                    dosageInstruction.patientInstruction = data.prec_instr;
                    dosageInstruction.route = route;
                    dosageInstruction.doseQuantity = doseQuantity;
                    dosageInstruction.timing = timing;
                    list_dosageInstruction.Add(dosageInstruction);

                    MedicationReference medicationReference = new MedicationReference();
                    medicationReference.reference = "Medication?code=" + DataAccessLayer.EMR.Prescription.GetDrugCode(data.prec_medicine);

                    List<SupportingInformation> list_supportingInformation = new List<SupportingInformation>();
                    SupportingInformation supportingInformation = new SupportingInformation();
                    supportingInformation.reference = "Media/8645";
                    list_supportingInformation.Add(supportingInformation);

                    request.resourceType = "MedicationRequest";
                    request.intent = "order";
                    request.status = "active";
                    request.subject = subject;
                    request.authoredOn = DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss.ff") + "+04:00";
                    request.requester = requester;
                    request.reasonCode = list_reasonCode;
                    request.dispenseRequest = dispenseRequest;
                    request.dosageInstruction = list_dosageInstruction;
                    request.medicationReference = medicationReference;
                    request.supportingInformation = list_supportingInformation;

                    return request;
                }
                else
                {
                    return request;
                }
            }
            else
            {

                return request;
            }
        }

        public static ERX_Request GenerateMOHerx(DataTable dt, DataTable dt_signs, string preIds, int madeby)
        {
            DataRow dr = dt.Rows[0];
            ERX_Request erx = new ERX_Request();
            ErxRequest erx1 = new ErxRequest();
            string FacilityId = ConfigurationManager.AppSettings["FacilityId"].ToString().Trim();
            Header header = new Header();
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;
            string day_value = string.Empty;
            string month_value = string.Empty;
            string hour_value = string.Empty;
            string minute_value = string.Empty;
            string second_value = string.Empty;
            string emp__license = string.Empty;
            string Route_of_Admin = string.Empty;

            if (day < 10)
            {
                day_value = "0" + day.ToString().Trim();
            }
            else
            {
                day_value = day.ToString().Trim();
            }
            if (month < 10)
            {
                month_value = "0" + month.ToString().Trim();
            }
            else
            {
                month_value = month.ToString().Trim();
            }

            if (hour < 10)
            {
                hour_value = "0" + hour.ToString().Trim();
            }
            else
            {
                hour_value = hour.ToString().Trim();
            }

            if (minute < 10)
            {
                minute_value = "0" + minute.ToString().Trim();
            }
            else
            {
                minute_value = minute.ToString().Trim();
            }

            if (second < 10)
            {
                second_value = "0" + second.ToString().Trim();
            }
            else
            {
                second_value = second.ToString().Trim();
            }
            string Tr__date2 = DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + month_value + day_value + hour_value + minute_value + second_value;
            string Tr__date = day_value + "/" + month_value + "/" + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + " " + hour_value + ":" + minute_value;

            DateTime pat__dob = DateTime.Parse(dt.Rows[0]["pat_dob"].ToString());
            string start_date = day_value + "/" + month_value + "/" + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + " " + hour_value + ":" + minute_value;

            header.SenderID = FacilityId;

            if (dt.Rows[0]["ic_name"].ToString() == "Cash")
            {
                header.ReceiverID = "MOH";
            }
            else
            {
                header.ReceiverID = dt.Rows[0]["ic_code"].ToString().Trim();
            }

            header.TransactionDate = Tr__date;
            header.RecordCount = "1";
            header.DispositionFlag = "PRODUCTION";

            if (dt.Rows[0]["ic_name"].ToString() == "Cash")
            {
                header.PayerID = "SelfPay";
            }
            else
            {
                header.PayerID = dt.Rows[0]["ip_code"].ToString().Trim();
            }

            erx1.Header = header;

            Prescriptionerx prescription = new Prescriptionerx();

            Patienterx patient = new Patienterx();
            patient.MemberID = dt.Rows[0]["pi_insno"].ToString();

            if (!string.IsNullOrEmpty(dt.Rows[0]["pat_emirateid"].ToString().Trim()) && (dt.Rows[0]["pat_emirateid"].ToString().Trim().Length == 15))
            {
                patient.NationalIDNumber = dt.Rows[0]["pat_emirateid"].ToString().Substring(0, 3) + "-" + dt.Rows[0]["pat_emirateid"].ToString().Substring(3, 4) + "-" + dt.Rows[0]["pat_emirateid"].ToString().Substring(7, 7) + "-" + dt.Rows[0]["pat_emirateid"].ToString().Substring(14);
            }
            else if (!string.IsNullOrEmpty(dt.Rows[0]["pat_emirateid"].ToString().Trim()) && (dt.Rows[0]["pat_emirateid"].ToString().Trim().Length == 18))
            {
                patient.NationalIDNumber = dt.Rows[0]["pat_emirateid"].ToString().Trim();
            }
            else
            {
                patient.NationalIDNumber = "999-9999-9999999-9";
            }

            patient.DateOfBirth = pat__dob.ToString("dd/MM/yyyy HH:mm");
            patient.FullName = dt.Rows[0]["pat_name"].ToString().Trim();
            patient.Gender = dt.Rows[0]["pat_gender"].ToString().Trim();
            patient.ContactNumber = dt.Rows[0]["pat_mob"].ToString().Trim();
            patient.Weight = dt_signs.Rows[0]["sign_weight"].ToString().Trim();
            patient.Email = dt.Rows[0]["pat_email"].ToString().Trim();

            Encounter encounter = new Encounter();
            encounter.FacilityID = FacilityId;
            encounter.Type = "1";

            DataTable dtDiag = DataAccessLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(int.Parse(dr["appId"].ToString()), 0);

            List<Diagnosis> DiagnosisMain = new List<Diagnosis>();

            foreach (DataRow drDiag in dtDiag.Rows)
            {
                Diagnosis diagnosis = new Diagnosis();
                if (drDiag["pad_type"].ToString() == "Primary")
                {
                    diagnosis.Type = "Principal";
                }
                else
                {
                    diagnosis.Type = "Secondary";
                }
                diagnosis.Code = drDiag["diag_code"].ToString().Trim();

                DiagnosisMain.Add(diagnosis);
            }

            List<Activity> ActivityMain = new List<Activity>();

            DataTable pre = DataAccessLayer.EMR.EMR_Patient.eRX(int.Parse(dt.Rows[0]["appId"].ToString()), preIds);

            foreach (DataRow drPre in pre.Rows)
            {
                Activity activity = new Activity();
                activity.ID = drPre["preId"].ToString().Trim();
                activity.Type = "5";
                activity.Code = drPre["item_code"].ToString().Trim();
                activity.Quantity = drPre["pre_qty"].ToString().Trim();
                activity.Duration = drPre["pre_duration"].ToString().Trim();
                activity.UnitId = "1";
                activity.Refills = "1";

                string tempValue = pre.Rows[0]["pre_temp6"].ToString().Trim();

                if (tempValue.Length >= 3 && tempValue.Substring(0, 3).Equals("ROA"))
                {
                    Route_of_Admin = tempValue.Substring(3);
                }

                //if (pre.Rows[0]["pre_temp6"].ToString().Trim().Substring(0, 3).Equals("ROA"))
                //{
                //    Route_of_Admin = pre.Rows[0]["pre_temp6"].ToString().Substring(3, (pre.Rows[0]["pre_temp6"].ToString().Length - 3));
                //}

                activity.RoutOfAdmin = Route_of_Admin;
                activity.Instructions = drPre["pre_instr"].ToString().Trim();
                activity.Start = start_date;

                Frequency frequency = new Frequency();
                frequency.UnitPerFrequency = drPre["pre_temp3"].ToString().Trim();
                frequency.FrequencyValue = drPre["pre_temp4"].ToString().Trim();
                frequency.FrequencyType = drPre["pre_temp5"].ToString().Trim();
                activity.Frequency = frequency;

                List<Observation> ObservationMain = new List<Observation>();
                Observation observation = new Observation();
                observation.Type = "ERX";
                observation.Code = "10910-8";
                observation.Value = "Test";
                observation.ValueType = "Test";
                ObservationMain.Add(observation);
                ActivityMain.Add(activity);
            }

            prescription.ID = dr["set_permit_no"].ToString() + "-" + dt.Rows[0]["ic_code"].ToString() + "-" + Tr__date2 + "";
            prescription.Type = "eRxRequest";
            prescription.ReferenceNumber = 0;

            string empTemp = dt.Rows[0]["emp_license"].ToString().Trim();

            if (empTemp.Length >= 3 && empTemp.Substring(0, 3).Equals("MOH"))
            {
                emp__license = dt.Rows[0]["emp_license"].ToString().Substring(3, (dt.Rows[0]["emp_license"].ToString().Length - 3));
            }
            else
            {
                emp__license = dt.Rows[0]["emp_license"].ToString().Trim();
            }

            //if (dt.Rows[0]["emp_license"].ToString().Trim().Substring(0, 3).Equals("MOH"))
            //{
            //    emp__license = dt.Rows[0]["emp_license"].ToString().Substring(3, (dt.Rows[0]["emp_license"].ToString().Length - 3));
            //}
            //else
            //{
            //    emp__license = dt.Rows[0]["emp_license"].ToString().Trim();
            //}

            prescription.Clinician = emp__license;
            prescription.Patient = patient;
            prescription.Encounter = encounter;
            prescription.Diagnosis = DiagnosisMain;
            prescription.Activity = ActivityMain;

            erx1.Header = header;
            erx1.Prescription = prescription;
            erx.ErxRequest = erx1;

            return erx;
        }

        public static int InsertControlledDrugs(BusinessEntities.EMR.ControlledDrug data)
        {
            return DataAccessLayer.EMR.Prescription.InsertControlledDrugs(data);
        }
        #endregion

        #region General Prescription (Page Load)
        public static List<BusinessEntities.EMR.GeneralPrescription> GetAllGeneralPrescription(int? appId, int? gpreId)
        {
            List<BusinessEntities.EMR.GeneralPrescription> prescriptions = new List<BusinessEntities.EMR.GeneralPrescription>();

            DataTable dt = DataAccessLayer.EMR.Prescription.GetAllGeneralPrescription(appId, gpreId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    prescriptions.Add(new BusinessEntities.EMR.GeneralPrescription
                    {
                        gpreId = Convert.ToInt32(dr["gpreId"]),
                        gpre_appId = Convert.ToInt32(dr["gpre_appId"]),
                        gpre_desc = dr["gpre_desc"].ToString(),
                        gpre_status = dr["gpre_status"].ToString()
                    });
                }
            }

            return prescriptions;
        }

        public static List<BusinessEntities.EMR.GeneralPrescription> GetPrevGeneralPrescription(int appId, int patId)
        {
            List<BusinessEntities.EMR.GeneralPrescription> prescriptions = new List<BusinessEntities.EMR.GeneralPrescription>();

            DataTable dt = DataAccessLayer.EMR.Prescription.GetPrevGeneralPrescription(appId, patId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    prescriptions.Add(new BusinessEntities.EMR.GeneralPrescription
                    {
                        gpreId = Convert.ToInt32(dr["gpreId"]),
                        gpre_appId = Convert.ToInt32(dr["gpre_appId"]),
                        gpre_desc = dr["gpre_desc"].ToString(),
                        gpre_status = dr["gpre_status"].ToString(),
                        doctor_name = dr["doctor_name"].ToString(),
                        app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString())
                    });
                }
            }

            return prescriptions;
        }
        #endregion

        #region General Prescription CRUD Operations
        public static int InsertGeneralPrescription(BusinessEntities.EMR.GeneralPrescription data)
        {
            return DataAccessLayer.EMR.Prescription.InsertGeneralPrescription(data);
        }

        public static int UpdateGeneralPrescription(BusinessEntities.EMR.GeneralPrescription data)
        {
            return DataAccessLayer.EMR.Prescription.UpdateGeneralPrescription(data);
        }

        public static int DeleteGeneralPrescription(int gpreId, int gpre_madeby)
        {
            return DataAccessLayer.EMR.Prescription.DeleteGeneralPrescription(gpreId, gpre_madeby);
        }
        #endregion

        #region Prescription Insurance (eRX)
        public static int Generate_eRX(int appId, string file_name, string eRx_ReferenceNo, string eRx_ErrorMessage, string preIds, int madeby, string Tr__date2)
        {
            return DataAccessLayer.EMR.Prescription.Generate_eRX(appId, file_name, eRx_ReferenceNo, eRx_ErrorMessage, preIds, madeby, Tr__date2);
        }

        public static int Generate_Cancel_eRX(int appId, string file_name, string eRx_ReferenceNo, string eRx_ErrorMessage, string preIds, int madeby, string Tr__date2)
        {
            return DataAccessLayer.EMR.Prescription.Generate_Cancel_eRX(appId, file_name, eRx_ReferenceNo, eRx_ErrorMessage, preIds, madeby, Tr__date2);
        }

        public static string GenerateTemplate(DataTable dt, DataTable dt_signs, string preIds, int madeby)
        {
            DataRow dr = dt.Rows[0];

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.AppendLine("<eRx.Request xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            sb.AppendLine("<Header>");
            sb.AppendLine("<SenderID>" + dr["set_permit_no"].ToString() + "</SenderID>");

            if (dr["ic_name"].ToString() == "Cash")
            {
                sb.AppendLine("<ReceiverID>DHA</ReceiverID>");
            }
            else
            {
                sb.AppendLine("<ReceiverID>" + dr["ic_code"].ToString() + "</ReceiverID>");
            }

            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;
            string day_value = string.Empty;
            string month_value = string.Empty;
            string hour_value = string.Empty;
            string minute_value = string.Empty;
            string second_value = string.Empty;

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

            string Tr__date = day_value + "/" + month_value + "/" + DateTime.Parse(dr["app_fdate"].ToString()).Year + " " + hour_value + ":" + minute_value;
            string Tr__date2 = DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + month_value + day_value + hour_value + minute_value + second_value;

            sb.AppendLine("<TransactionDate>" + Tr__date + "</TransactionDate>");
            sb.AppendLine("<RecordCount>1</RecordCount>");
            sb.AppendLine("<DispositionFlag>PRODUCTION</DispositionFlag>");
            sb.AppendLine("</Header>");

            // Doctor license details
            sb.AppendLine("<Prescription>");
            sb.AppendLine("<ID>" + dr["set_permit_no"].ToString() + "-" + dr["ic_code"].ToString() + "-" + Tr__date2 + "</ID>");
            sb.AppendLine("<Type>eRxRequest</Type>");

            if (dr["ic_name"].ToString() == "Cash")
            {
                sb.AppendLine("<PayerID>SelfPay</PayerID>");
            }
            else
            {
                sb.AppendLine("<PayerID>" + dr["app_ip_code"].ToString() + "</PayerID>");
            }

            sb.AppendLine("<Clinician>" + dr["emp_license"].ToString() + "</Clinician>");

            // Patient Details
            sb.AppendLine("<Patient>");

            if (dr["ic_name"].ToString() == "Cash")
            {
                sb.AppendLine("<MemberID>" + dr["set_permit_no"].ToString() + "</MemberID>");
            }
            else
            {
                sb.AppendLine("<MemberID>" + dr["pi_insno"].ToString() + "</MemberID>");
            }

            sb.AppendLine("<EmiratesIDNumber>" + dr["pat_emirateid"].ToString() + "</EmiratesIDNumber>");
            DateTime pat__dob = DateTime.Parse(dr["pat_dob"].ToString());
            sb.AppendLine("<DateOfBirth>" + pat__dob.ToString("dd/MM/yyyy") + "</DateOfBirth>");
            sb.AppendLine("<Weight>" + (float.Parse(dt_signs.Rows[0]["sign_weight"].ToString()) * 1000) + "</Weight>");
            sb.AppendLine("</Patient>");

            // Clinic license details
            sb.AppendLine("<Encounter>");
            sb.AppendLine("<FacilityID>" + dr["set_permit_no"].ToString() + "</FacilityID>");
            sb.AppendLine("<Type>1</Type>");
            sb.AppendLine("</Encounter>");

            DataTable dtDiag = DataAccessLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(int.Parse(dr["appId"].ToString()), 0);
            int diag_count = 0;

            foreach (DataRow drDiag in dtDiag.Rows)
            {
                diag_count = diag_count + 1;
                sb.AppendLine("<Diagnosis>");

                if (drDiag["pad_type"].ToString() == "Primary")
                {
                    sb.AppendLine("<Type>Principal</Type>");
                }
                else
                {
                    sb.AppendLine("<Type>Secondary</Type>");
                }

                sb.AppendLine("<Code>" + drDiag["diag_code"].ToString() + "</Code>");
                sb.AppendLine("</Diagnosis>");
            }
            string start_date = day_value + "/" + month_value + "/" + DateTime.Parse(dr["app_fdate"].ToString()).Year + " " + hour_value + ":" + minute_value;

            DataTable dtPre = DataAccessLayer.EMR.Prescription.Geterx_Prescription(preIds);

            foreach (DataRow drPre in dtPre.Rows)
            {
                sb.AppendLine("<Activity>");
                sb.AppendLine("<ID>" + drPre["preId"].ToString() + "</ID>");
                sb.AppendLine("<Start>" + start_date + "</Start>");
                sb.AppendLine("<Type>5</Type>");
                sb.AppendLine("<Code>" + drPre["item_code"].ToString() + "</Code>");
                sb.AppendLine("<Quantity>" + drPre["pre_qty"].ToString() + "</Quantity>");
                sb.AppendLine("<Duration>" + drPre["pre_duration"].ToString() + "</Duration>");
                sb.AppendLine("<Refills>" + drPre["pre_temp2"].ToString() + "</Refills>");
                sb.AppendLine("<RoutOfAdmin>" + drPre["pre_temp6"].ToString() + "</RoutOfAdmin>");
                sb.AppendLine("<Instructions>" + drPre["pre_instr"].ToString() + "</Instructions>");
                sb.AppendLine("<Frequency>");
                sb.AppendLine("<UnitPerFrequency>" + drPre["pre_temp3"].ToString() + "</UnitPerFrequency>");
                sb.AppendLine("<FrequencyValue>" + drPre["pre_temp4"].ToString() + "</FrequencyValue>");
                sb.AppendLine("<FrequencyType>" + drPre["pre_temp5"].ToString() + "</FrequencyType>");
                sb.AppendLine("</Frequency>");
                sb.AppendLine("</Activity>");
            }

            sb.AppendLine("</Prescription>");
            sb.AppendLine("</eRx.Request>");
            sb = sb.Replace("'", "\"");

            return sb.ToString();
        }
        #endregion

        #region erX Cancellation (DHA / MOH)
        public static string GenerateERXCancellationTemplate(DataTable dt, DataTable dt_signs, string preIds, int madeby)
        {
            DataRow dr = dt.Rows[0];

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.AppendLine("<eRx.Request xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            sb.AppendLine("<Header>");
            sb.AppendLine("<SenderID>" + dr["set_permit_no"].ToString() + "</SenderID>");

            if (dr["ic_name"].ToString() == "Cash")
            {
                sb.AppendLine("<ReceiverID>DHA</ReceiverID>");
            }
            else
            {
                sb.AppendLine("<ReceiverID>" + dr["ic_code"].ToString() + "</ReceiverID>");
            }

            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;
            string day_value = string.Empty;
            string month_value = string.Empty;
            string hour_value = string.Empty;
            string minute_value = string.Empty;
            string second_value = string.Empty;

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

            string Tr__date = day_value + "/" + month_value + "/" + DateTime.Parse(dr["app_fdate"].ToString()).Year + " " + hour_value + ":" + minute_value;
            string Tr__date2 = DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + month_value + day_value + hour_value + minute_value + second_value;

            sb.AppendLine("<TransactionDate>" + Tr__date + "</TransactionDate>");
            sb.AppendLine("<RecordCount>1</RecordCount>");
            sb.AppendLine("<DispositionFlag>PRODUCTION</DispositionFlag>");
            sb.AppendLine("</Header>");

            // Doctor license details
            sb.AppendLine("<Prescription>");
            sb.AppendLine("<ID>" + dr["set_permit_no"].ToString() + "-" + dr["ic_code"].ToString() + "-" + dt.Rows[0]["pre_qtype"].ToString() + "</ID>");
            sb.AppendLine("<Type>eRxCancellation</Type>");

            if (dr["ic_name"].ToString() == "Cash")
            {
                sb.AppendLine("<PayerID>SelfPay</PayerID>");
            }
            else
            {
                sb.AppendLine("<PayerID>" + dr["app_ip_code"].ToString() + "</PayerID>");
            }

            sb.AppendLine("<Clinician>" + dr["emp_license"].ToString() + "</Clinician>");


            sb.AppendLine("</Prescription>");
            sb.AppendLine("</eRx.Request>");
            sb = sb.Replace("'", "\"");

            return sb.ToString();
        }

        public static ERX_Request GenerateMOHERXCancellation(DataTable dt, DataTable dt_signs, string preIds, int madeby)
        {
            DataRow dr = dt.Rows[0];
            ERX_Request erx = new ERX_Request();
            ErxRequest erx1 = new ErxRequest();
            string FacilityId = ConfigurationManager.AppSettings["FacilityId"].ToString().Trim();
            Header header = new Header();
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;
            string day_value = string.Empty;
            string month_value = string.Empty;
            string hour_value = string.Empty;
            string minute_value = string.Empty;
            string second_value = string.Empty;
            string emp__license = string.Empty;
            string Route_of_Admin = string.Empty;

            if (day < 10)
            {
                day_value = "0" + day.ToString().Trim();
            }
            else
            {
                day_value = day.ToString().Trim();
            }
            if (month < 10)
            {
                month_value = "0" + month.ToString().Trim();
            }
            else
            {
                month_value = month.ToString().Trim();
            }

            if (hour < 10)
            {
                hour_value = "0" + hour.ToString().Trim();
            }
            else
            {
                hour_value = hour.ToString().Trim();
            }

            if (minute < 10)
            {
                minute_value = "0" + minute.ToString().Trim();
            }
            else
            {
                minute_value = minute.ToString().Trim();
            }

            if (second < 10)
            {
                second_value = "0" + second.ToString().Trim();
            }
            else
            {
                second_value = second.ToString().Trim();
            }
            string Tr__date2 = DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + month_value + day_value + hour_value + minute_value + second_value;
            string Tr__date = day_value + "/" + month_value + "/" + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + " " + hour_value + ":" + minute_value;

            DateTime pat__dob = DateTime.Parse(dt.Rows[0]["pat_dob"].ToString());
            string start_date = day_value + "/" + month_value + "/" + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + " " + hour_value + ":" + minute_value;

            header.SenderID = FacilityId;

            if (dt.Rows[0]["ic_name"].ToString() == "Cash")
            {
                header.ReceiverID = "MOH";
            }
            else
            {
                header.ReceiverID = dt.Rows[0]["ic_code"].ToString().Trim();
            }

            header.TransactionDate = Tr__date;
            header.RecordCount = "1";
            header.DispositionFlag = "PRODUCTION";

            if (dt.Rows[0]["ic_name"].ToString() == "Cash")
            {
                header.PayerID = "SelfPay";
            }
            else
            {
                header.PayerID = dt.Rows[0]["ip_code"].ToString().Trim();
            }

            erx1.Header = header;

            Prescriptionerx prescription = new Prescriptionerx();

            prescription.ID = dr["set_permit_no"].ToString() + "-" + dt.Rows[0]["ic_code"].ToString() + "-" + dt.Rows[0]["pre_qtype"].ToString() + "";
            prescription.Type = "eRxCancellation";
            prescription.ReferenceNumber = 0;

            string empTemp = dt.Rows[0]["emp_license"].ToString().Trim();

            if (empTemp.Length >= 3 && empTemp.Substring(0, 3).Equals("MOH"))
            {
                emp__license = dt.Rows[0]["emp_license"].ToString().Substring(3, (dt.Rows[0]["emp_license"].ToString().Length - 3));
            }
            else
            {
                emp__license = dt.Rows[0]["emp_license"].ToString().Trim();
            }

            prescription.Clinician = emp__license;
            erx1.Header = header;
            erx1.Prescription = prescription;
            erx.ErxRequest = erx1;

            return erx;
        }
        #endregion

        #region ERX Submissions
        public static List<BusinessEntities.EMR.erxSubmissions> GeterxSubmissions(int appId)
        {
            List<BusinessEntities.EMR.erxSubmissions> list = new List<BusinessEntities.EMR.erxSubmissions>();

            DataTable dt = DataAccessLayer.EMR.Prescription.GeterxSubmissions(appId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BusinessEntities.EMR.erxSubmissions
                    {
                        erxId = Convert.ToInt32(dr["erxId"]),
                        erx_appId = Convert.ToInt32(dr["erx_appId"]),

                        erx_filename = dr["erx_filename"].ToString(),
                        erx_ErrorMessage = dr["erx_ErrorMessage"].ToString(),
                        erx_ErrorReport = dr["erx_ErrorReport"].ToString(),
                        erx_status = dr["erx_status"].ToString(),
                        erx_madeby = dr["erx_madeby"].ToString(),

                        erx_ReferenceNo = Convert.ToInt32(dr["erx_ReferenceNo"]),
                        erx_date = Convert.ToDateTime(dr["erx_date"].ToString())
                    });
                }
            }

            return list;
        }
        #endregion

        public static DataSet GetPatientEMRInfoPresc(int? appId, string preIds)
        {
            return DataAccessLayer.EMR.Prescription.GetPatientEMRInfoPresc(appId, preIds);
        }
    }
}