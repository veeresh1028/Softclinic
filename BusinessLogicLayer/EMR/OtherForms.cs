using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EMR
{
    public class OtherForms
    {
        #region  Monthly Evaluation (Page Load)
        public static List<BusinessEntities.EMR.Referal> GetAllReferal(int? appId, int? rId)
        {
            List<BusinessEntities.EMR.Referal> sclist = new List<BusinessEntities.EMR.Referal>();
            DataTable dt = DataAccessLayer.EMR.OtherForms.GetAllReferal(appId, rId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.Referal
                {
                    rId = Convert.ToInt32(dr["rId"]),
                    r_appId = Convert.ToInt32(dr["r_appId"]),
                    r_to = dr["r_to"].ToString(),
                    r_mrno = dr["r_mrno"].ToString(),
                    r_type = dr["r_type"].ToString(),
                    r_reason = dr["r_reason"].ToString(),
                    r_history = dr["r_history"].ToString(),
                    r_phy = dr["r_phy"].ToString(),
                    r_inv = dr["r_inv"].ToString(),
                    r_pro = dr["r_pro"].ToString(),
                    r_rec = dr["r_rec"].ToString(),
                    r_med = dr["r_med"].ToString(),
                    r_date = Convert.ToDateTime(dr["r_date"].ToString()),
                    r_date_created = Convert.ToDateTime(dr["r_date_created"].ToString()),
                    r_status = dr["r_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.Referal> GetAllPreReferal(int appId, int patId)
        {
            List<BusinessEntities.EMR.Referal> sclist = new List<BusinessEntities.EMR.Referal>();
            DataTable dt = DataAccessLayer.EMR.OtherForms.GetAllPreReferal(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.Referal
                {
                    rId = Convert.ToInt32(dr["rId"]),
                    r_appId = Convert.ToInt32(dr["r_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Monthly Evaluation (Page Load)
        #region  Monthly Evaluation CRUD Operations
        public static bool InsertUpdateReferal(BusinessEntities.EMR.Referal data)
        {
            data.r_pro = string.IsNullOrEmpty(data.r_pro) ? string.Empty : data.r_pro;
            data.r_to = string.IsNullOrEmpty(data.r_to) ? string.Empty : data.r_to;
            data.r_mrno = string.IsNullOrEmpty(data.r_mrno) ? string.Empty : data.r_mrno;
            data.r_type = string.IsNullOrEmpty(data.r_type) ? string.Empty : data.r_type;
            data.r_reason = string.IsNullOrEmpty(data.r_reason) ? string.Empty : data.r_reason;
            data.r_pro = string.IsNullOrEmpty(data.r_pro) ? string.Empty : data.r_pro;
            data.r_history = string.IsNullOrEmpty(data.r_history) ? string.Empty : data.r_history;
            data.r_phy = string.IsNullOrEmpty(data.r_phy) ? string.Empty : data.r_phy;
            data.r_inv = string.IsNullOrEmpty(data.r_inv) ? string.Empty : data.r_inv;
            data.r_rec = string.IsNullOrEmpty(data.r_rec) ? string.Empty : data.r_rec;
            data.r_med = string.IsNullOrEmpty(data.r_med) ? string.Empty : data.r_med;
            DateTime? r_date_ = data.r_date; // Assuming data.car_d1 is of type DateTime?            
            if (data.r_date != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.r_date = r_date_.HasValue ? r_date_.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.r_date = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMR.OtherForms.InsertUpdateReferal(data);
        }

        public static int DeleteReferal(int rId, int cme_madeby)
        {
            return DataAccessLayer.EMR.OtherForms.DeleteReferal(rId, cme_madeby);
        }

        public static string HtmlReferal(int appId, EMRInfo emr, int setId)
        {
            BusinessEntities.EMR.Referal pdf = BusinessLogicLayer.EMR.OtherForms.GetAllReferal(appId,0).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "Referal").FirstOrDefault();
            BusinessEntities.Common.eSignature wsign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "witness", "Referal").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", hf.footer.ToString());

            StringBuilder sb = new StringBuilder();

            string pdfr1 = pdf.r_type;
            string radioHtml1 = "<input type='radio'  class='custom-control-input' name='r_type' value='Emergency' id='1'> <span class='custom-control-label'>Emergency</span>";
            string radioHtml2 = "<input type='radio' class='custom-control-input' name='r_type' value='Urgent' id='2'> <span class='custom-control-label'>Urgent</span>";
            string radioHtml3 = "<input type='radio' class='custom-control-input' name='r_type' value='Routine' id='2'> <span class='custom-control-label'>Routine</span>";

            if (pdfr1 == "Emergency")
            {
                radioHtml1 = radioHtml1.Replace("<input type='radio'", "<input type='radio' checked");
            }
            else if (pdfr1 == "Urgent")
            {
                radioHtml2 = radioHtml2.Replace("<input type='radio'", "<input type='radio' checked");
            }
            else if (pdfr1 == "Routine")
            {
                radioHtml3 = radioHtml3.Replace("<input type='radio'", "<input type='radio' checked");
            }

            sb.Append("<html>");
            sb.Append("    <head><title> <u>Refferal Form</u></title></head>");
            sb.Append("    <body style='font-family: Verdana, Geneva, Tahoma, sans-serif;'>");

            sb.Append("    <table style='width:100%; border: none;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'>");
            sb.Append("            <img src='" + header + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    </table>");

            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'  colspan='9'>");
            sb.Append("            <h1>Refferal Form</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Patient Name</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000' colspan='4'>" + emr.pat_name + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Emirates ID</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_emirateid + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>File No</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_code + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>DOB</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_dob + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Nationality</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_nationality + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Gender</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_gender + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Doctor's Name</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.doc_name + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Date</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.app_fdate + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<div style='width:100%; text-align:justify; font-size: 12px; margin-top: 50px;margin-bottom: 50px;'>");

            sb.Append("<table style='width:100%; font-size:12px; border:0 solid #000000'>");
            sb.Append("  <tr>");
            sb.Append("     <td>");
            sb.Append("         <table style='width:100%; font-size:12px; border:0 solid #000000'>");
            sb.Append("             <tr>");
            sb.Append("                 <td style='width:20%;'>Date</td>");
            sb.Append("                 <td style='width:5%;'>:</td>");
            sb.Append("                 <td style='width:25%;'>" + pdf.r_date.ToString("dd/MM/yyyy") + "</td>");
            sb.Append("                 <td style='width:20%;'>Referred to</td>");
            sb.Append("                 <td style='width:5%;'>:</td>");
            sb.Append("                 <td style='width:25%;'>" + pdf.r_to + "</td>");
            sb.Append("             </tr>");
            sb.Append("         </table>");
            sb.Append("     </td>");
            sb.Append("  </tr>");
            sb.Append("  <tr>");
            sb.Append("     <td>");
            sb.Append("         <table style='width:100%; font-size:12px; border:0 solid #000000'>");
            sb.Append("             <tr>");
            sb.Append("                 <td style='width:20%;'>Patient's Medical Record #</td>");
            sb.Append("                 <td style='width:5%;'>:</td>");
            sb.Append("                 <td style='width:25%;'>" + pdf.r_mrno + "</td>");
            sb.Append("                 <td style='width:20%;'>Type</td>");
            sb.Append("                 <td style='width:5%;'>:</td>");
            sb.Append("                 <td style='width:8%;'>" + radioHtml1 + "</td>");
            sb.Append("                 <td style='width:8%;'>" + radioHtml2 + "</td>");
            sb.Append("                 <td style='width:9%;'>" + radioHtml3 + "</td>");
            sb.Append("             </tr>");
            sb.Append("         </table>");
            sb.Append("     </td>");
            sb.Append("  </tr>");            
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>Kindly find the attached medical documents to the form.</td>");
            sb.Append("  </tr>");                        
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>Reason for Referral.</td>");
            sb.Append("  </tr>");                       
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>"+pdf.r_reason + "</td>");
            sb.Append("  </tr>");                        
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>Summary of Presentation.</td>");
            sb.Append("  </tr>");                         
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>History.</td>");
            sb.Append("  </tr>");                       
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>"+pdf.r_history + "</td>");
            sb.Append("  </tr>");                                   
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>Physical Examination.</td>");
            sb.Append("  </tr>");                       
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>"+pdf.r_phy + "</td>");
            sb.Append("  </tr>");                                  
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>Investigations.</td>");
            sb.Append("  </tr>");                       
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>"+pdf.r_inv + "</td>");
            sb.Append("  </tr>");                                  
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>Provisional Diagnosis.</td>");
            sb.Append("  </tr>");                       
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>"+pdf.r_pro + "</td>");
            sb.Append("  </tr>");                                 
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>Recommendations</td>");
            sb.Append("  </tr>");                       
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>"+pdf.r_rec + "</td>");
            sb.Append("  </tr>");                                 
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>Medications:(Patient need to bring all medications to the appointment)</td>");
            sb.Append("  </tr>");                       
            sb.Append("  <tr>");
            sb.Append("      <td style='width:100%;'>"+pdf.r_med + "</td>");
            sb.Append("  </tr>");

            sb.Append("</table>");
            
            sb.Append("</div>");

            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:1px solid #000000; width: 33%;'>");
            sb.Append("            Doctor Name");
            sb.Append("        </td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:1px solid #000000; width: 34%;'>");
            sb.Append("            Licence");
            sb.Append("        </td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:1px solid #000000; width: 33%;'>");
            sb.Append("            Signature/Stamp");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;padding: 10px;border-right:1px solid #000000'>");
            sb.Append("            <img src='" + emr.doc_name + "' style='height: 100px; width: 100px;'/>");
            sb.Append("        </td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border-right:1px solid #000000'>");
            sb.Append("            <img src='" + emr.emp_license + "' style='height: 100px; width: 100px;'/>");
            sb.Append("        </td>");
            sb.Append("        <td style='text-align: center;padding: 10px;'>");
            sb.Append("            <img src='" + emr.doc_sign + "' style='height: 100px; width: 100px;'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");            
            sb.Append("</table>");

            sb.Append("    <table style='width:100%; border: none;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'>");
            sb.Append("            <img src='" + footer + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    </table>");
            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }

        #endregion  
    }
}
