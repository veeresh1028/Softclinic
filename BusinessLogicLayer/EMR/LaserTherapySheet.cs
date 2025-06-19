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
    public class LaserTherapySheet
    {
        #region  Laser Therapy Sheet (Page Load)
        public static List<BusinessEntities.EMR.LaserTherapySheet> GetAllLaserTherapySheet(int? appId, int? ltsId)
        {
            List<BusinessEntities.EMR.LaserTherapySheet> sclist = new List<BusinessEntities.EMR.LaserTherapySheet>();
            DataTable dt = DataAccessLayer.EMR.LaserTherapySheet.GetAllLaserTherapySheet(appId, ltsId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.LaserTherapySheet
                {
                    ltsId = Convert.ToInt32(dr["ltsId"]),
                    lts_appId = Convert.ToInt32(dr["lts_appId"]),
                    lts_session = dr["lts_session"].ToString(),
                    lts_bodypart = dr["lts_bodypart"].ToString(),
                    lts_skintype = dr["lts_skintype"].ToString(),
                    lts_flu_alex = dr["lts_flu_alex"].ToString(),
                    lts_flu_nd = dr["lts_flu_nd"].ToString(),
                    lts_remarks = dr["lts_remarks"].ToString(),
                    lts_offer = dr["lts_offer"].ToString(),
                    lts_date = Convert.ToDateTime(Convert.ToDateTime(dr["lts_date"].ToString()).ToString("dd/MM/yyyy")),
                    lts_date_created = Convert.ToDateTime(dr["lts_date_created"].ToString()),
                    lts_status = dr["lts_status"].ToString(),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.EMR.LaserTherapySheet> GetAllPreLaserTherapySheet(int appId, int patId)
        {
            List<BusinessEntities.EMR.LaserTherapySheet> sclist = new List<BusinessEntities.EMR.LaserTherapySheet>();
            DataTable dt = DataAccessLayer.EMR.LaserTherapySheet.GetAllPreLaserTherapySheet(appId, patId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.LaserTherapySheet
                {
                    ltsId = Convert.ToInt32(dr["ltsId"]),
                    lts_appId = Convert.ToInt32(dr["lts_appId"]),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),

                });
            }
            return sclist;
        }
        #endregion  Laser Therapy Sheet (Page Load)
        #region  Laser Therapy Sheet CRUD Operations
        public static bool InsertUpdateLaserTherapySheet(BusinessEntities.EMR.LaserTherapySheet data)
        {
            data.lts_session = string.IsNullOrEmpty(data.lts_session) ? string.Empty : data.lts_session;
            data.lts_bodypart = string.IsNullOrEmpty(data.lts_bodypart) ? string.Empty : data.lts_bodypart;
            data.lts_skintype = string.IsNullOrEmpty(data.lts_skintype) ? string.Empty : data.lts_skintype;
            data.lts_flu_alex = string.IsNullOrEmpty(data.lts_flu_alex) ? string.Empty : data.lts_flu_alex;
            data.lts_flu_nd = string.IsNullOrEmpty(data.lts_flu_nd) ? string.Empty : data.lts_flu_nd;
            data.lts_session = string.IsNullOrEmpty(data.lts_session) ? string.Empty : data.lts_session;
            data.lts_remarks = string.IsNullOrEmpty(data.lts_remarks) ? string.Empty : data.lts_remarks;
            data.lts_offer = string.IsNullOrEmpty(data.lts_offer) ? string.Empty : data.lts_offer;
            DateTime? lts_date_ = data.lts_date; // Assuming data.calts_d1 is of type DateTime?            
            if (data.lts_date != DateTime.Parse("1/1/0001 12:00:00 AM"))
            {
                data.lts_date = lts_date_.HasValue ? lts_date_.Value : DateTime.Parse("01/01/1950");
            }
            else
            {
                data.lts_date = DateTime.Parse("01/01/1950");
            }

            return DataAccessLayer.EMR.LaserTherapySheet.InsertUpdateLaserTherapySheet(data);
        }

        public static int DeleteLaserTherapySheet(int ltsId, int cme_madeby)
        {
            return DataAccessLayer.EMR.LaserTherapySheet.DeleteLaserTherapySheet(ltsId, cme_madeby);
        }

        public static string HtmlLaserTherapySheet(int appId, EMRInfo emr, int setId)
        {
            BusinessEntities.EMR.LaserTherapySheet pdf = BusinessLogicLayer.EMR.LaserTherapySheet.GetAllLaserTherapySheet(appId, 0).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "LaserTherapySheet").FirstOrDefault();
            BusinessEntities.Common.eSignature wsign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "witness", "LaserTherapySheet").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "headelts_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footelts_images", hf.footer.ToString());

            StringBuilder sb = new StringBuilder();

           

            sb.Append("<html>");
            sb.Append("    <head><title> <u>Laser Therapy Form</u></title></head>");
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
            sb.Append("            <h1>Laser Therapy Form</h1>");
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
            sb.Append("      <td colspan='3'>RCMC/05/F.18.</td>");
            sb.Append("  </tr>");
            sb.Append("  <tr>");
            sb.Append("      <td style='width:30%;'>Date.</td>");
            sb.Append("      <td style='width:2%;'>:</td>");
            sb.Append("      <td style='width:68%;'>" + pdf.lts_date + "</td>");
            sb.Append("  </tr>");
            sb.Append("  <tr>");
            sb.Append("      <td style='width:30%;'>File No.</td>");
            sb.Append("      <td style='width:2%;'>:</td>");
            sb.Append("      <td style='width:68%;'>" + emr.pat_code + "</td>");
            sb.Append("  </tr>");
            sb.Append("  <tr>");
            sb.Append("      <td style='width:30%;'>SESSION</td>");
            sb.Append("      <td style='width:2%;'>:</td>");
            sb.Append("      <td style='width:68%;'>" + pdf.lts_session + "</td>");
            sb.Append("  </tr>");
            sb.Append("  <tr>");
            sb.Append("      <td style='width:30%;'>BODY PART(S)</td>");
            sb.Append("      <td style='width:2%;'>:</td>");
            sb.Append("      <td style='width:68%;'>" + pdf.lts_bodypart + "</td>");
            sb.Append("  </tr>");
            sb.Append("  <tr>");
            sb.Append("      <td style='width:30%;'>SKIN TYPE</td>");
            sb.Append("      <td style='width:2%;'>:</td>");
            sb.Append("      <td style='width:68%;'>" + pdf.lts_skintype + "</td>");
            sb.Append("  </tr>");
            sb.Append("  <tr>");
            sb.Append("      <td style='width:30%;'>FLUENCE Alex</td>");
            sb.Append("      <td style='width:2%;'>:</td>");
            sb.Append("      <td style='width:68%;'>" + pdf.lts_flu_alex + "</td>");
            sb.Append("  </tr>");
            sb.Append("  <tr>");
            sb.Append("      <td style='width:30%;'>FLUENCE ND:Yag</td>");
            sb.Append("      <td style='width:2%;'>:</td>");
            sb.Append("      <td style='width:68%;'>" + pdf.lts_flu_nd + "</td>");
            sb.Append("  </tr>");
            sb.Append("  <tr>");
            sb.Append("      <td style='width:30%;'>REMARKS</td>");
            sb.Append("      <td style='width:2%;'>:</td>");
            sb.Append("      <td style='width:68%;'>" + pdf.lts_remarks + "</td>");
            sb.Append("  </tr>");
            sb.Append("  <tr>");
            sb.Append("      <td style='width:30%;'>OFFERS(Promo/Package)</td>");
            sb.Append("      <td style='width:2%;'>:</td>");
            sb.Append("      <td style='width:68%;'>" + pdf.lts_offer + "</td>");
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
