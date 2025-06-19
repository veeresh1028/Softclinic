using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessLogicLayer.InsuranceForms
{
    public class InsuranceFormPDF
    {

        public static string HtmlAdnicMemberConsent(int appId, EMRInfo emr, int setId)
        {

            BusinessEntities.InsuranceForms.AdnicMemberConsent pdf = BusinessLogicLayer.InsuranceForms.AdnicMemberConsent.GetAdnicMemberConsentData(appId).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "AdnicMemberConsent").FirstOrDefault();
            BusinessEntities.Common.eSignature wsign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "witness", "AdnicMemberConsent").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", hf.footer.ToString());


            StringBuilder sb = new StringBuilder();

            sb.Append("<html>");
            sb.Append("    <head>");
            sb.Append(" <title>إقرار بالموافقة على الإفصاح عن معلومات طبية<br>MEMBER CONSENT FOR RELEASE OF MEDICAL INFORMATION</title>");
            sb.Append(" <meta charset='utf-8'>  ");
            sb.Append(" </head>  ");
            sb.Append("    <body ='font-family: Vstyleerdana, Geneva, Tahoma, sans-serif;'>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; border: none;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'>");
            sb.Append("            <img src='" + header + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    </table>");
            //sb.Append("    <br/>");
            //sb.Append("    <table style='width:100%; border: none;'>");
            //sb.Append("    <tr>");
            //sb.Append("        <td style='text-align: center;'>");
            //sb.Append("            <img src='" + adnic.jpg + "'/>");
            //sb.Append("        </td>");
            //sb.Append("    </tr>");
            //sb.Append("    </table>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000' colspan='4'>");
            sb.Append("            <h1 style='font-family: Arial, sans-serif;'>إقرار بالموافقة على الإفصاح عن معلومات طبية<br>MEMBER CONSENT FOR RELEASE OF MEDICAL INFORMATION</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:none solid #000000'>Group Member Name</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:none solid #000000' colspan='4'>" + emr.pat_name + "</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: right;padding: 10px;border:none solid #000000'>اسم العضو الرئيسي</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:none solid #000000'>Patient Name</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:none solid #000000' colspan='4'>" + emr.pat_name + "</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: right;padding: 10px;border:none solid #000000'>اسم المريض</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:none solid #000000'>Patient’s Membership No</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:none solid #000000' colspan='4'>" + pdf.mcaf_pat_memno + "</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: right;padding: 10px;border:none solid #000000'>رقم عضوية المريض</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:none solid #000000'>Relationship</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:none solid #000000' colspan='4'>" + pdf.mcaf_relationship + "</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: right;padding: 10px;border:none solid #000000'>درجة القرابة</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:none solid #000000'>Patient File No</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:none solid #000000' colspan='4'>" + emr.pat_code + "</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: right;padding: 10px;border:none solid #000000'>رقم ملف المريض</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:none solid #000000'>Patient Mobile No</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:none solid #000000' colspan='4'>" + emr.pat_mob + "</td>");
            sb.Append("        <td style='text-align: center;border:none solid #000000'>:</td>");
            sb.Append("        <td style='text-align: right;padding: 10px;border:none solid #000000'>هاتف المريض</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("<p><b>I hereby authorize,<br />occupational</b> " + emr.emp_license + "</p> ");
            sb.Append("<p>To provide all the needed medical information related to me or my Spouse/Child to Abu Dhabi National Insurance Company allowing their Doctors and Medical Claims Officers to have access to my medical records and to obtain the required copies of the medical reports and investigations.</p> ");
            sb.Append("<p>Abu Dhabi National Insurance Company to access this information to evaluate my medical condition and treatment received.</p> ");
            sb.Append("<p>Abu Dhabi National Insurance Company to refer my case for second opinion consultation and review the best treatment plan possible subject to my policy benefits.</p> ");
            sb.Append("<p>Abu Dhabi National Insurance Company guarantees complete confidentiality of the information received.</p> ");
            sb.Append("<p>I understand this consent is valid for the duration of my Policy Period with Abu Dhabi National Insurance Company at any healthcare provider, including but not limited to Hospitals, medical centers, clinics, laboratories, diagnostic centers and pharmacies.</p> ");
            sb.Append("    <br/>");
            sb.Append("    <p><b>Patient Signature:</b></p>");
            sb.Append("            <img src='" + psign.psb_sign.Replace(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px; width: 100px;'/>");
            sb.Append("    </td>");
            sb.Append("    <td style='text-align: right;padding: 10px;border:none solid #000000'>");
            sb.Append("<p><b>أقر أنا الموقع أدناه،<br />occupational</b> " + emr.emp_license + "</p> ");
            sb.Append("<p>عطــاء المعلومــات الطبيــة الخاصة بــي أو بالــزوج / الزوجة أو بالأبناء لشــركة أبوظبــي الوطنية للتأمين وأن أســمح لأطباء و مســؤولي التعويضــات الطبيــة التابعيــن للشــركة بالاطــاع علــى الملف الطبي و الحصــول على صور من التقاريــر الطبية و الفحوصات التشخيصية الازمة.</p> ");
            sb.Append("<p>و إننــي علــى علم بأن شــركة أبوظبــي الوطنية للتأمين ســوف تطلــع علــى هذه المعلومــات من أجــل تقييم الحالــة الطبية و العاج الطبي الذي تلقيته.</p> ");
            sb.Append("<p>مراجعه شــركة أبوظبي الوطنية للتأمين لحالتي لأخذ رأي طبي ثانــي أو مراجعه التقاريــر الطبية الخاصه بي مــع طبيب ثاني من أجــل الوصول إلى افضــل عاج ممكن وفقــا للتغطيه التأمينيه الخاصه بي.</p> ");
            sb.Append("<p>و تؤكــد شــركة أبوظبــي الوطنيــة للتأميــن التعامــل مــع هذه المعلومات بسرية تامة.</p> ");
            sb.Append("<p>إن هــذا الإقــرار صالــح خــال فتــرة وثيقــة التأميــن الخاصة بي مــع شــركة أبوظبــي الوطنيــة للتأميــن و معمول بهــا لدى أي مــزود خدمــات ،بما في ذلك علي ســبيل الذكــر و ليس الحصر ، المستشــفيات، المراكز والعيادات الطبية ، المختبرات ، مراكز التشخيص والصيدليات.</p> ");
            sb.Append("    <br/>");
            sb.Append("    <p><b>توقيع المريض :</b></p>");
            sb.Append("            <img src='" + psign.psb_sign.Replace(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px; width: 100px;'/>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }

        public static string HtmlAdnicShifa(int appId, EMRInfo emr, int setId)
        {

            BusinessEntities.InsuranceForms.AdnicShifa pdf = BusinessLogicLayer.InsuranceForms.AdnicShifa.GetAdnicShifaData(appId).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "AdnicShifa").FirstOrDefault();
            BusinessEntities.Common.eSignature wsign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "witness", "AdnicShifa").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", hf.footer.ToString());


            StringBuilder sb = new StringBuilder();

            string pdfAds1 = pdf.ads_oth_above;
            string radioHtml1 = "<input type='radio'  class='custom-control-input' name='ads_oth_above' value='No' id='1'>";
            string radioHtml2 = "<input type='radio' class='custom-control-input' name='ads_oth_above' value='Yes' id='2'>";

            if (pdfAds1 == "No")
            {
                radioHtml1 = radioHtml1.Replace("<input type='radio'", "<input type='radio' checked");
            }
            else if (pdfAds1 == "Yes")
            {
                radioHtml2 = radioHtml2.Replace("<input type='radio'", "<input type='radio' checked");
            }

            string pdfAds2 = pdf.ads_oth_claim;
            string radioHtml3 = "<input type='radio'  class='custom-control-input' name='ads_oth_claim' value='No' id='3'>";
            string radioHtml4 = "<input type='radio' class='custom-control-input' name='ads_oth_claim' value='Yes' id='4'>";

            if (pdfAds2 == "No")
            {
                radioHtml3 = radioHtml3.Replace("<input type='radio'", "<input type='radio' checked");
            }
            else if (pdfAds2 == "Yes")
            {
                radioHtml4 = radioHtml4.Replace("<input type='radio'", "<input type='radio' checked");
            }

            sb.Append("<html>");
            sb.Append("    <head><title>REIMBURSEMENT MEDICAL CLAIM FORM</title></head>");
            sb.Append("    <body style='font-family: Verdana, Geneva, Tahoma, sans-serif;'>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; border: none;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'>");
            sb.Append("            <img src='" + header + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    </table>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'  colspan='9'>");
            sb.Append("            <h1>REIMBURSEMENT MEDICAL CLAIM FORM</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: right;border:1px solid #000000'  colspan='9'>");
            sb.Append("          <p><b>Voucher No :</b>" + pdf.ads_voucher + "</p>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;border:1px solid #000000'  colspan='9'>");
            sb.Append("          <p></p>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'  colspan='9'>");
            sb.Append("          <p><b>Please read the instructions & guidelines on overleaf before filling the form</p>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:none solid #000000;border-collapse: collapse; colspan='9''>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>1. Patient Details</b></p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <br/>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Patient's Name:</b></p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p>" + emr.pat_name + "</p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Patient Health Card No:</b></p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p>" + emr.pi_polocyno + "</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Group Member's Name:</b></p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p>" + pdf.ads_group_mem + "</p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Type of Plan:</b></p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p>" + emr.ic_name + "</p>");
            sb.Append("    </td>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Employer's Name:</b></p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p>" + emr.doc_name + "</p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Telephone No:</b></p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p>" + emr.pat_mob + "</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Email ID:</b></p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p>" + emr.pat_email + "</p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Address:</b></p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p>" + emr.pat_address + "</p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Date of Birth:</b></p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p>" + emr.pat_dob + "</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <br/>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>2. Reason for not using listed helathcare facilities(Kindly indicate)</b></p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:none solid #000000;border-collapse: collapse; colspan='9''>");
            sb.Append("    <tr>");
            sb.Append("    <td>Emergency</td>");
            sb.Append("    <td>Elective</td>");
            sb.Append("    <td>Service Not Available</td>");
            sb.Append("    <td>On vacation/business trip outside UAE</td>");
            sb.Append("    </tr>");
            sb.Append("    </table>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Other(s) please specify</b></p>");
            sb.Append("    </td>");
            sb.Append("    <td>");
            sb.Append("    <p>" + pdf.ads_reason_other + "</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <br/>");
            sb.Append("    <tr>");
            sb.Append("    <td style='colspan='9''>");
            sb.Append("    <p><b>3. Medical Information(To be filled by treating doctor for all outpatient for cases like hospitalization procedures surgeries-detailed medical report is required)</b></p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Condition Requiring treatment</b>" + pdf.ads_condition + "</p>");
            sb.Append("    </td>");
            sb.Append("    <td style='text-align: right;'>");
            sb.Append("    <p><b>Visit Date</b>" + pdf.ads_visit + "</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b></b>Onset and duration of illness:</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p>" + pdf.ads_onset + "</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Treatment Details</b></p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p>" + pdf.ads_treat_details + "</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='colspan='9''>");
            sb.Append("    <p><b>I declare that i have attended to this patient and that the particulars given are best of my knowledge true and correct.</b></p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Name & Signature of the Doctor:</b></p>");
            sb.Append("    </td>");
            sb.Append("    <td style='text-align: right;'>");
            sb.Append("    <p><b>Stamp :</b></p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;'>");
            sb.Append("            <img src='" + emr.doc_sign + "' style='height: 100px; width: 100px;'/>");
            sb.Append("        </td>");
            sb.Append("    <td style='text-align: center;'>");
            sb.Append("    <p><b>Date:</b>" + emr.app_fdate + "</p>");
            sb.Append("    </td>");
            sb.Append("        <td style='text-align: right;padding: 10px;'>");
            sb.Append("            <img src='" + emr.doc_sign + "' style='height: 100px; width: 100px;'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>4. Name & Address of the Hospital/Clinic</b></td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>Treatment Details</b></td>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>Treatment Details</b></td>");
            sb.Append("        <td>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse; colspan='9''>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:1px solid #000000'><b>CPT Code</b></td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:1px solid #000000'><b>Treatment</b></ td > ");
            sb.Append("        <td style = 'text-align: center;padding: 10px;border:1px solid #000000'><b>Type</b></ td > ");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'><b>Price</b></td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:1px solid #000000'><b>Auth. Code</b></td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:1px solid #000000'><b>Auth. Date</b></td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'><b>Exp. Date</b></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:1px solid #000000'></td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:1px solid #000000'></ td > ");
            sb.Append("        <td style ='text-align: center;padding: 10px;border:1px solid #000000'></ td > ");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'></td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:1px solid #000000'></td>");
            sb.Append("        <td style='text-align: center;padding: 10px;border:1px solid #000000'></td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'></td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='width:100%; border:1px solid #000000' colspan:'7'><b>Currency(If treatment availed outside UAE)</b></td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;>");
            sb.Append("    <tr>");
            sb.Append("    <td style='width:100%;><b>5.Bank Details</b></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>Bank Details(Compulsory):</b></td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000; width:50%;colspan-4'><b>" + pdf.ads_bank + "</b></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>Account Holder Name:</b></td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000; width:50%;' colspan:'4'><b>" + pdf.ads_bname + "</b></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>Bank Name:</b></td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000; width:50%;' colspan:'4'><b>" + pdf.ads_account + "</b></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>Bank Address:</b></td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000; width:50%;' colspan:'4'><b>" + pdf.ads_baddress + "</b></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>Currency:</b></td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>" + pdf.ads_bcurrency + "</b></td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>SWIFT Code:</b></td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>" + pdf.ads_bswiftcode + "</b></td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    <br/>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:none solid #000000;border-collapse: collapse;>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p>6.Other Information</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td><b>Is the above case work related</b></td>");
            sb.Append("    <td>" + radioHtml1 + "</td>");
            sb.Append("    <td>" + radioHtml2 + "</td>");
            sb.Append("    <td>" + pdf.ads_oth_above_det + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td><b>Is the claim covered by another insurance</b></td>");
            sb.Append("    <td>" + radioHtml3 + "</td>");
            sb.Append("    <td>" + radioHtml4 + "</td>");
            sb.Append("    <td>" + pdf.ads_oth_claim_det + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>7.Declaration</b></p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p>I, the undersigned hereby declared that the information above is true and complete and that reimbursement requested is for expense paid by me for the treatment of my medical condition.</p>");
            sb.Append("    <p>I agree to submit to ADNIC any requested document mandatory / deemed necessary to process my above claim . I hereby authorize ADNIC to approach ,and any doctor / Medical facility/ any Institution or any person who has any record / medical information about me or my family member to provide ADNIC with complete information including copies of the records when requested.</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:none solid #000000;border-collapse: collapse;>");
            sb.Append("    <tr>");
            sb.Append("    <td>" + pdf.ads_witnessname + "</td>");
            sb.Append("        <td>");
            sb.Append("            <img src='" + psign.psb_sign.Replace(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px; width: 100px;'/>");
            sb.Append("        </td>");
            sb.Append("    <td>" + emr.app_fdate + "</td>");
            sb.Append("    <td>" + pdf.ads_contact + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td><b>Name Relationship to the Card Holder</b></td>");
            sb.Append("    <td><b>Signature</b></td>");
            sb.Append("    <td><b>Date</b></td>");
            sb.Append("    <td><b>Contact No.</b></td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    <br/>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Instructions</b></p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p>1.This form needs to be completed by the insured member (Card holder), only if the provider is not submitting the claim on his behalf.</p>");
            sb.Append("    <p>2.Please read the form carefully and make sure to complete all pertinent information. ADNIC will not be able to process any incomplete Reimbursement Claim Form with lacking proper documentation.</p>");
            sb.Append("    <p>3.Use a separate form for each Member.</p>");
            sb.Append("    <p>4.All the documents including invoices and medical reports should be in either English or Arabic. Documents in other languages must be translated by an official public translator prior to submission.</p>");
            sb.Append("    <p>5.The following documents to be attached to your duly filled Reimbursement Claim Form.");
            sb.Append("    <ul>");
            sb.Append("    <li> Copy of Card.</li>");
            sb.Append("    <li> Original itemized bill/Invoices (dated) and receipts of payment.</li>");
            sb.Append("    <li> Original prescription for medication given by the treating doctor ( except for controlled drugs) . Validity of the prescription is limited to 60 days and for controlled drugs is limited to 3 days in line with HAAD</li>");
            sb.Append("    <li> Investigation requests/reports like laboratory tests, x-rays, etc.</li>");
            sb.Append("    </ul>");
            sb.Append("    </p>");
            sb.Append("    <p>Additional requirements to above:</p>");
            sb.Append("    <p>For Inpatient (Hospitalization Cases)</p>");
            sb.Append("    <p>• Medical Report/Discharge Summary stamped & signed by the treating Doctor.</p>");
            sb.Append("    <p>For treatment availed Outside the UAE");
            sb.Append("    <ul>");
            sb.Append("   <li> Copy of passport showing Exit & Re-entry to UAE or any other similar documents (E.g.: E-gate)</li>");
            sb.Append("   <li> Elective treatment is subject to ADNIC prior approval at all times.</li>");
            sb.Append("    <ul>");
            sb.Append("    </p>");
            sb.Append("    <p>6.Please retain copies of receipts and documents enclosed with your claim, as ADNIC will retain original documents.</p>");
            sb.Append("    <p>7.All claims s ubject to reimbursement availed within or outside UAE should be submitted within 120 days of incurred treatment.</p>");
            sb.Append("    <p>8. Please submit all the above required documents directly to MSH international - DIFC Liberty House Office No 304, Level - 3, P.O Box 506537, Dubai, United Arab Emirates</p>");
            sb.Append("    <p>If you need assistance in filling this form please call MSH Toll Free (UAE): 800674823|+971 4 365 1350</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <br/>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p><b>Instructions to complete the Form</b></p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td>");
            sb.Append("    <p>1.Please write your name & Card Number as mentioned in the Card</p>");
            sb.Append("    <p>2.Medical Information - Request your treating doctor to fill up brief medical information about your condition and treatment.</p>");
            sb.Append("    <p>3.Provider Name & Address - Kindly use more than one line if necessary to provide this information about each facility where  you were treated</p>");
            sb.Append("    <p>4.Bill No. - Please write the serial number/reference number printed on the bill/receipt/invoice for each service separately.</p>");
            sb.Append("    <p>5.Service Date - State date of treatment for each service against each bill.</p>");
            sb.Append("    <p>6.Description of Services -State type of service like Consultation/Pharmacy/Investigations/Physiotherapy/Dental/ Hospitalization.</p>");
            sb.Append("    <p>7.Amount - State the exact amount as appears on the invoices</p>");
            sb.Append("    <p>8.Total - Total amount of all the invoices submitted with this form for reimbursement from ADNIC</p>");
            sb.Append("    <p>9.Currency - Name of the currency in which actual payment was made.</p>");
            sb.Append("    <p>10.If treatment due to road traffic accident a police report is required to be submitted with this form.</p>");
            sb.Append("    <p>11.Declaration - Kindly write your name, signature, date, the contact number and relationship to the cardholder.</p>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("</table>");
            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }


        public static string HtmlAdnicClaim(int appId, EMRInfo emr, int setId)
        {

            BusinessEntities.InsuranceForms.AdnicClaim pdf = BusinessLogicLayer.InsuranceForms.AdnicClaim.GetAdnicClaimData(appId).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "AdnicClaim").FirstOrDefault();
            BusinessEntities.Common.eSignature wsign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "witness", "AdnicClaim").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", hf.footer.ToString());

            StringBuilder sb = new StringBuilder();

            string pdfAc1 = pdf.ac_rel;
            string radioHtml1 = "<input type='radio'  class='custom-control-input' name='ac_rel' value='Wife' id='1'>";
            string radioHtml2 = "<input type='radio' class='custom-control-input' name='ac_rel' value='Husband' id='2'>";
            string radioHtml3 = "<input type='radio' class='custom-control-input' name='ac_rel' value='Child' id='3'>";

            if (pdfAc1 == "Wife")
            {
                radioHtml1 = radioHtml1.Replace("<input type='radio'", "<input type='radio' checked");
            }
            else if (pdfAc1 == "Husband")
            {
                radioHtml2 = radioHtml2.Replace("<input type='radio'", "<input type='radio' checked");
            }
            else if (pdfAc1 == "Child")
            {
                radioHtml3 = radioHtml3.Replace("<input type='radio'", "<input type='radio' checked");
            }

            string pdfAc2 = pdf.ac_ins;
            string radioHtml4 = "<input type='radio'  class='custom-control-input' name='ac_ins' value='Yes' id='4'>";
            string radioHtml5 = "<input type='radio' class='custom-control-input' name='ac_ins' value='No' id='5'>";

            if (pdfAc2 == "No")
            {
                radioHtml4 = radioHtml4.Replace("<input type='radio'", "<input type='radio' checked");
            }
            else if (pdfAc2 == "Yes")
            {
                radioHtml5 = radioHtml5.Replace("<input type='radio'", "<input type='radio' checked");
            }

            string pdfAc3 = pdf.ac_acc;
            string radioHtml6 = "<input type='radio'  class='custom-control-input' name='ac_acc' value='Yes' id='6'>";
            string radioHtml7 = "<input type='radio' class='custom-control-input' name='ac_acc' value='No' id='7'>";

            if (pdfAc3 == "No")
            {
                radioHtml6 = radioHtml6.Replace("<input type='radio'", "<input type='radio' checked");
            }
            else if (pdfAc3 == "Yes")
            {
                radioHtml7 = radioHtml7.Replace("<input type='radio'", "<input type='radio' checked");
            }

            sb.Append("<html>");
            sb.Append("    <head><title>Adnic Claim Form</title></head>");
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
            sb.Append("            <h1>Adnic Claim Form</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            //sb.Append("        <td>");
            //sb.Append("            <img src='" + ~/ images / header_images / adnic.jpg + "' style='height: 100px; width: 100px;'/>");
            //sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<div style='width:100%; text-align:justify; font-size: 12px; margin-top: 50px;margin-bottom: 50px;'>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("<tr>");
            sb.Append("        <td style='text-align: center;padding: 10px;' >");
            sb.Append("<p></p> ");
            sb.Append("</td>");
            sb.Append("        <td style='text-align: center;padding: 10px;'>");
            sb.Append("<p>&nbsp;</p> ");
            sb.Append("</td>");
            sb.Append("        <td style='text-center: center;padding: 10px;'>");
            sb.Append("<p><b>ADNIC MEDICAL INSURANCE SCHEME</b></p> ");
            sb.Append("</td>");
            sb.Append("        <td style='text-align-right: center;padding: 10px;'>");
            sb.Append("<p><b>INSURANCE COPY</b></p> ");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("<tr>");
            sb.Append("        <td style='text-align: center;padding: 10px;'>");
            sb.Append("<p><b>CLAIM FORM - DIRECT BILLING</b></p> ");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("<tr>");
            sb.Append("        <td style='text-align: center;padding: 10px;' >");
            sb.Append("<p>--------------------------------------------------------------------------------</p> ");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;' colspan='9'>");
            sb.Append("<tr>");
            sb.Append("        <td valign='top'>");
            sb.Append("<p><b>PART 1</b></p> ");
            sb.Append("<p style=color:red>COMPLETE PART 1 OF THIS FORM.</p> ");
            sb.Append("<p style=color:red>Part 2 must be completed by the doctor / specialist giving details of treatment received.</p> ");
            sb.Append("<p style=color:red>Submit this form with original account(s) within 45 days of the expenditure beingin curred.</p> ");
            sb.Append("<p style=color:red>Your claim will not be considered if not submitted within the above Period.A NEW CLAIM FORM IS REQUIRED EACH TIME YOU SUBMIT ACCOUNTS.</p> ");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:none solid #000000;border-collapse: collapse;'>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<p>Patient's Membership No." + emr.pi_insno + "</p>");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<p>Voucher No.:" + pdf.ac_voucher + "</p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<p>Group Member's Name (Mr./Mrs./Miss):</p>");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<p>Employer's Name</p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<p>" + pdf.ac_groupname + "</p>");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<p>" + pdf.ac_employer + "</p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<p>Patient's Name (if not Group Member)</p>");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<p>Patient's date of birth</p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<p>" + emr.pat_name + "</p>");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<p>" + emr.pat_dob + "</p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<p>Patient's Contact No./Mobile <br/>(Mandatory)</p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<p>" + emr.pat_mob + "</p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:none solid #000000;border-collapse: collapse;'>");
            sb.Append("<tr>");
            sb.Append("<td>If Patient is not the Group Member, tick relationship</td>");
            sb.Append("    <td>" + radioHtml1 + "<span>Wife</span></td>");
            sb.Append("    <td>" + radioHtml2 + "<span>Husband</span></td>");
            sb.Append("    <td>" + radioHtml3 + "<span>Child</span></td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:none solid #000000;border-collapse: collapse;'>");
            sb.Append("<tr>");
            sb.Append("<td>For an in-patient stay in hospital</td>");
            sb.Append("<td>Admission Date</td>");
            sb.Append("<td>Discharge Date</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:none solid #000000;border-collapse: collapse;'>");
            sb.Append("<tr>");
            sb.Append("<td>Please enter date(s) of admission and discharge</td>");
            sb.Append("<td>" + emr.app_fdate + "</td>");
            sb.Append("<td>" + emr.app_fdate + "</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:none solid #000000;border-collapse: collapse;'>");
            sb.Append("<tr>");
            sb.Append("<td>Is the cost of this treatment also covered by any other insurer? (Mandatory)</td>");
            sb.Append("    <td>" + radioHtml3 + "<span>Yes</span></td>");
            sb.Append("    <td>" + radioHtml4 + "<span>No</span></td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("    <table style='width:100%; font-size: 12px; border:none solid #000000;border-collapse: collapse;'>");
            sb.Append("<tr>");
            sb.Append("<td>Was the treatment necessary as the result of an accident?</td>");
            sb.Append("    <td>" + radioHtml5 + "<span>Yes</span></td>");
            sb.Append("    <td>" + radioHtml6 + "<span>No</span></td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<tr>");
            sb.Append("<td></td><td>If the answer to either question is YES, please give full details.</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td></td><td>" + pdf.ac_acc_details + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td></td><td>I hereby claim for costs of treatment and declare that, to the best of my knowledge and belief, all information given in support of this claim is true and complete.</td>");
            sb.Append("</tr>");
            sb.Append("</br>");
            sb.Append("<tr>");
            sb.Append("<td></td><td><b>Member's Signature</b></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td></td>  <td>");
            sb.Append("            <img src='" + psign.psb_sign.Replace(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px;'/>");
            sb.Append("        </td>");
            sb.Append("<td><b>Date:</b>" + emr.app_fdate + "</b>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("</table>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("    <table style=' border:none solid #000000;border-collapse: collapse;'>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<p><b></b>PART 2</p>");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<p>Condition requiring treatment " + pdf.ac_cond + "</p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<p>To be completed by Doctor/Specialist who carried out the treatment</p>");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<p><b>Details of treatment / operation / on set of illness " + pdf.ac_set + "</b></p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<p>Please complete this form in BLOCK CAPITALS</p>");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<p>Name(s), qualification and address(es)/License No. of Doctor / Specialist / Provider License No." + emr.doc_name + "</p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("        <td style='text-align: center;padding: 10px;'>");
            sb.Append("            <img src='" + emr.doc_sign + "' style='height: 100px; width: 100px;'/>");
            sb.Append("        </td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<p><b>Date:" + emr.app_fdate + "</b></p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("<tr>");
            sb.Append("<td tyle='text-align-center>");
            sb.Append("<p><b>Sheikh Khalifa St. P.O.Box.839 - Abu Dhabi - Tel:6264000 - Telex: 223450 ADNIC EM - Telfax: 6268600 - E-mail:adnic@adnic.ae</b></p>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</div>");
            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }

        public static string HtmlAdnicDentalAuth(int appId, EMRInfo emr, int setId)
        {

            BusinessEntities.InsuranceForms.AdnicDentalAuth pdf = BusinessLogicLayer.InsuranceForms.AdnicDentalAuth.GetAdnicDentalAuthData(appId).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "AdnicDentalAuth").FirstOrDefault();
            BusinessEntities.Common.eSignature wsign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "witness", "AdnicDentalAuth").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", hf.footer.ToString());

            StringBuilder sb = new StringBuilder();

            sb.Append("<html>");
            sb.Append("    <head><title>Adnic Claim Form</title></head>");
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
            sb.Append("            <h1>ADNIC Dental Pre-Auth Form</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            //sb.Append("        <td>");
            //sb.Append("            <img src='" + ~/ images / header_images / adnic.jpg + "' style='height: 100px; width: 100px;'/>");
            //sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<div style='width:100%; text-align:justify; font-size: 12px; margin-top: 50px;margin-bottom: 50px;'>");
            sb.Append("<table style='width:100%; font-size: 12px; border:none solid #000000;border-collapse: collapse;'>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>Member’s name (as Written on Card) :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_name + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'></td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>ADNIC Card ID Number :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.ic_code + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>Patient’s Mobile No. (Mandatory) :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_mob + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>Providers Name / Code :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.ic_name + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>To Branch (Name) :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.set_company + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>Fax to be sent :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_fax + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>Date of Birth :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_dob + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("</table>");
            sb.Append("<br/>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: center;padding: 10px;border:1px solid #000000'><b>CHARTING SYSTEM</b></td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>EXAMINATION AND TREATMENT RECORD<br/>UNIVERSAL TOOTH NO. SYSTEM MANDATORY</b></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: center;padding: 10px;border:1px solid #000000'><img src=/></td>");
            sb.Append("    <td>");
            sb.Append("<table style='font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: center;padding: 10px;border:1px solid #000000'><b>Diagnosis or ICD9</b></td>");
            sb.Append("    <td style='text-align: center;padding: 10px;border:1px solid #000000'><b>Description of Service</b></td>");
            sb.Append("    <td style='text-align: center;padding: 10px;border:1px solid #000000'><b>Tooth No.</b></td>");
            sb.Append("    <td style='text-align: center;padding: 10px;border:1px solid #000000'><b>Canadian Code</b></td>");
            sb.Append("    <td style='text-align: center;padding: 10px;border:1px solid #000000'><b>Cost Estimate</b></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_diags1 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_ser1 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_tooth1 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_code1 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_cost1 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_diags2 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_ser2 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_tooth2 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_code2 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_cost2 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_diags3 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_ser3 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_tooth3 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_code3 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_cost3 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_diags4 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_ser4 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_tooth4 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_code4 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_cost4 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_diags5 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_ser5 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_tooth5 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_code5 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_cost5 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_diags6 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_ser6 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_tooth6 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_code6 + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_cost6 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: right;padding: 10px;border:1px solid #000000' colspan='4'><b>Total Amount:</b></td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_treat_tot + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("    </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<br/>");
            sb.Append("<table style='font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'><b> Document Attached In Number:</b></td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + pdf.ada_doc_no + "</td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>Service Date :" + emr.app_fdate + "</b></td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<br/>");
            sb.Append("<table style='font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>Doctor / Signature / Stamp:</b></td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>");
            sb.Append("            <img src='" + emr.doc_sign + "' style='height: 100px; width: 100px;'/>");
            sb.Append("        </td>");
            sb.Append("    <td style='text-align: left;padding: 10px;border:1px solid #000000'><b>Member Signature</b><br/>");
            sb.Append("            <img src='" + psign.psb_sign.Replace(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px;'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("</div>");
            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }

        //---------------------- Medical Expenses Claim Form----------------------------
        public static string HtmlMedicalExpensesForm(int appId, EMRInfo emr, int setId)
        {

            BusinessEntities.InsuranceForms.MedicalExpensesForm pdf = BusinessLogicLayer.InsuranceForms.MedicalExpensesForm.GetMedicalExpensesFormData(appId).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "MedicalExpensesForm").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", hf.footer.ToString());

            StringBuilder sb = new StringBuilder();
            BusinessEntities.EMR.PatientDiagnosis Diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(appId, 0).FirstOrDefault();

            BusinessEntities.EMRForms.Adnic sign_bp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_pulse = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_temp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_notes = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();

            BusinessEntities.EMR.PatientTreatments treatments = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(appId,0,"").FirstOrDefault();

            string pdfmef_radio = pdf.mef_radio;

            string radioHtml1 = "<input type='radio'  class='custom-control-input' name='mef_radio' value='mef_radio11' id='1'>";
            string radioHtml2 = "<input type='radio' class='custom-control-input' name='mef_radio' value='mef_radio12' id='2'>";
            string radioHtml3 = "<input type='radio' class='custom-control-input' name='mef_radio' value='mef_radio13' id='3'>";
            string radioHtml4 = "<input type='radio' class='custom-control-input' name='mef_radio' value='mef_radio14' id='4'>";


            if (pdfmef_radio == "1")
            {
                radioHtml1 = radioHtml1.Replace("<input type='radio'", "<input type='radio' checked");
            }
            else if (pdfmef_radio == "2")
            {
                radioHtml2 = radioHtml2.Replace("<input type='radio'", "<input type='radio' checked");
            }
            else if (pdfmef_radio == "3")
            {
                radioHtml3 = radioHtml3.Replace("<input type='radio'", "<input type='radio' checked");
            }
            else if (pdfmef_radio == "4")
            {
                radioHtml4 = radioHtml4.Replace("<input type='radio'", "<input type='radio' checked");
            }


            sb.Append("<html>");
            sb.Append("    <head><title>Medical Expenses Claim Form</title></head>");
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
            sb.Append("            <h1>Medical Expenses Claim Form</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Date</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.app_fdate + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Clinic Name</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.set_company + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Emirates ID</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_emirateid + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Card Holder's Name</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_name + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Age</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_age + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Gender</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_gender + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Mobile No</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_mob + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Ins Card No</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pi_insno + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Valid Upto</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pi_edate + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Company Name</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.ic_name + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Employee No</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.emp_license + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'> Nationality</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_nationality + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='width:50%;text-align: left;padding: 10px;'colspan='12'>" + emr.pi_image + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<div style='width:100%; text-align:justify; font-size: 12px; margin-top: 50px;margin-bottom: 50px;'>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;'><h5>Clinical Details</h5></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;'>Signs & Symptoms</td>");
            sb.Append("    </tr>");
            //sb.Append("    <tr>");
            //sb.Append("       <td style='text-align: left;padding: 10px;'>BP&nbsp;</h5></td>");
            //sb.Append("        <td style='text-align: center;'>:</td>");
            //sb.Append("        <td style='text-align: left;padding: 10px;'>" + sign_bp.sign_bp + "</td>");
            //sb.Append("    </tr>");
            //sb.Append("    <tr>");
            //sb.Append("        <td style='text-align: left;padding: 10px;'>Temp&nbsp;</td>");
            //sb.Append("        <td style='text-align: center;'>:</td>");
            //sb.Append("        <td style='text-align: left;padding: 10px;'>" + sign_temp.sign_temp + "</td>");
            //sb.Append("    </tr>");
            //sb.Append("    <tr>");
            //sb.Append("    <td style='text-align: left;padding: 10px;'> Pulse&nbsp;</td>");
            //sb.Append("        <td style='text-align: center;'>:</td>");
            //sb.Append("        <td style='text-align: left;padding: 10px;'>" + sign_pulse.sign_pulse + "</td>");
            //sb.Append("    </tr>");
            //sb.Append("    <tr>");
            //sb.Append("    <td style='text-align: left;padding: 10px;'> Notes&nbsp;</td>");
            //sb.Append("        <td style='text-align: center;'>:</td>");
            //sb.Append("        <td style='text-align: left;padding: 10px;'>" + sign_notes.sign_notes + "</td>");
            //sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;'>Date of Onset Illness&nbsp;</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;'>" + emr.app_fdate + "</td>");
            sb.Append("    </tr>");
            sb.Append("  <tr  style='text-align:justify'>");
            sb.Append("      <td>" + radioHtml1 + "Emergency </td>");
            sb.Append("      <td>" + radioHtml2 + "Work related</td>");
            sb.Append("      <td>" + radioHtml3 + "New visit</td>");
            sb.Append("      <td>" + radioHtml4 + "Follow up visit</td>");
            sb.Append("  </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;'> Diagnosis&nbsp;</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;'>" + Diagnosis.diag_name+ "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;'>Management plan (Services inside the clinic including injections and investigations)</td>");
            //sb.Append("        <td style='text-align: left;padding: 10px;'>" + treatments.treatments + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style='margin-bottom:0px;'>");
            sb.Append("        <td style='text-align: left;padding: 10px;'>");
            sb.Append("             <br/> " + emr.app_doctor_department);
            sb.Append("             <br/>Doctor Name");
            sb.Append("</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;'colspan='2'>");
            sb.Append("            <img src='" + emr.doc_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["InsuranceFormEndPoint"]) + "' style='height: 100px; width: 100px;'/>");
            sb.Append("             <br/>Signature & Stamp");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;'>Diagnostic Procedures referred outside</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px;'>" + pdf.mef_diag + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<p>I hereby authorize the physician, Hospital or pharmacy to file a claim for medical services on my behalf and I confirm that the above-mentioned examination/Investigation/therapy is given to me by the doctor. I hereby authorize any Clinic, Physician, Pharmacy or any other person who has provided medical services to me to furnish any and all information with regard to any medical history, medical condition, or medical services and copies of all medical and Clinic records.</p>");

            sb.Append("<table style='width:100%; font-size: 12px;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;'colspan='2'>");
            sb.Append("            <img src='" + psign.psb_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px; width: 100px;'/>");
            sb.Append("             <br/>Patient's Signature");
            sb.Append("             <br/> " + emr.app_fdate);
            sb.Append("             <br/><br/>Date");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<p>Pharmaceuticals (to be filled by treating doctor only)</p>");
            sb.Append("</div>");


            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }
        //Dubai Care claim Form Dental
        public static string HtmlDubaiCareClaimDental(int appId, EMRInfo emr, int setId)
        {

            BusinessEntities.InsuranceForms.DubaiCareClaimDental pdf = BusinessLogicLayer.InsuranceForms.DubaiCareClaimDental.GetDubaiCareClaimDentalData(appId).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "DubaiCareClaimDental").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", hf.footer.ToString());

            StringBuilder sb = new StringBuilder();
            BusinessEntities.EMR.PatientDiagnosis Diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(appId, 0).FirstOrDefault();

            BusinessEntities.EMRForms.Adnic sign_bp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_pulse = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_temp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_notes = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();

            BusinessEntities.EMR.PatientTreatments treatments = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(appId, 0, "").FirstOrDefault();

            sb.Append("<html>");
            sb.Append("    <head><title>Reimbursement Claim Form</title></head>");
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
            sb.Append("            <h1>Reimbursement Claim Form</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Claim No.</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pi_insno + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Authorization No.</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pi_polocyno + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Member Name/ Date of Birth</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_dob + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Membership No</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pi_insno + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Member Address/Tel</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_mob + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Expiry date of policy</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pi_edate + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<div style='width:100%; text-align:justify; font-size: 12px; margin-top: 0px;margin-bottom: 0px;'>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-bottom:1px solid #000000' colspan='2'><h5>Medical Section</h5></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style='border-bottom:1px solid #000000'>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-left:1px; width:50%'>Medical Practitioner's Name and Address/Tel.<br/><br/>" + emr.doc_name +"</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-left:1px; width:50%'>Medical condition:<br/><br/>" + pdf.dcd_1 +"</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style='border-left:1px;'>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:50%'>declare that I am the patient's medical practitioner, and that the particulars given are to the best of my knowledge true and correct.</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:50%'>Please Give the date on which your patient first consulted any doctor for this condition <br/><br/> "+ emr.app_fdate +"</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:50%'>Signature & Stamp</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:50%'></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='padding: 10px; width:50%'>");
            sb.Append("         <img src='" + emr.doc_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px; width: 100px;'/>");
            sb.Append("    </td>");
            sb.Append("    <td style='padding: 10px; width:50%'></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:50%'>Date</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:50%'></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:50%'>" + emr.app_fdate +"</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:50%'></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style='border-top:1px solid #000000'>");
            sb.Append("    <td text-align: left;padding: 10px border-top:1px border-bottom:1px solid #000000; colspan='2'>History of medical condition: <br/><br/>" + pdf.dcd_2 +"</ td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px border-top:1px border-bottom:1px solid #000000;' colspan='2'>Details of Physical findings <br/><br/>" + pdf.dcd_3 + "</ td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px border-top:1px border-bottom:1px solid #000000;' colspan='2'>Details of any investigations done with relevant dates.<br/><br/>" + pdf.dcd_4 + "</ td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px border-top:1px border-bottom:1px solid #000000;' colspan='2'>Details of treatments done with relevant dates.<br/><br/>" + pdf.dcd_5 + "</ td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px border-top:1px border-bottom:1px solid #000000;' colspan='2'>Total Amount<br/><br/>" + pdf.dcd_6 + "</ td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr style=''>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-left:1px; width:50%'>Patient's Declaration and Consent</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-left:1px; width:50%'>Signature : <img src='" + psign.psb_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px; width: 100px;'/></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style=''>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-left:1px; width:50%'>I confirm that I am the patient/ patient's parent or guardian and wish to claim benefits, and declare that all the particulars given above are to the best of my knowledge true and correct. I hereby consent to and authorize the medical practitioner involved in the patient's care to discuss treatment details and discharge arrangements with and to DubaiCare. I agree that a copy of this consent shall have the validity of the original.</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-left:1px; width:50%'>Date : " + emr.app_fdate + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-bottom:1px solid #000000' colspan='2'><h5>Please send this form to DubaiCare, P.O. Box 3027 Dubai – UAE Toll Free: 800 3 82467 ( Including original invoice with paid stamp, investigation and prescription) For any enquiry please call from 08.00 am to 17.00 pm (Sunday to Thursday)</h5></td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            

          
            sb.Append("</div>");


            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }

        //Neuron Form Dental
        public static string HtmlNeuronDentalForm(int appId, EMRInfo emr, int setId)
        {

            BusinessEntities.InsuranceForms.NeuronDentalForm pdf = BusinessLogicLayer.InsuranceForms.NeuronDentalForm.GetNeuronDentalFormData(appId).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "NeuronDentalForm").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", hf.footer.ToString());

            StringBuilder sb = new StringBuilder();
            BusinessEntities.EMR.PatientDiagnosis Diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(appId, 0).FirstOrDefault();

            BusinessEntities.EMRForms.Adnic sign_bp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_pulse = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_temp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_notes = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();

            BusinessEntities.EMR.PatientTreatments treatments = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(appId, 0, "").FirstOrDefault();

            sb.Append("<html>");
            sb.Append("    <head><title>Dental Claim Form - Provider Direct Billing</title></head>");
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
            sb.Append("            <h1>Dental Claim Form - Provider Direct Billing</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'rowspan='4'>Patient Name and Address</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'rowspan='4'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'rowspan='4'>" + emr.pat_name + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Member Neuron ID</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pi_insno + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Emirates ID</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_emirateid + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Date of Birth</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_dob + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Facility Name (In-Network Provider)</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.set_company + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Member Tel Number</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.set_tel + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Insurence Name</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.ic_name + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>Member Mobile</td>");
            sb.Append("        <td style='text-align: center;border:1px solid #000000'>:</td>");
            sb.Append("        <td style='text-align: left;padding: 10px;border:1px solid #000000'>" + emr.pat_mob + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<div style='width:100%; text-align:justify; font-size: 12px; margin-top: 0px;margin-bottom: 0px;'>");
            sb.Append("<p style='font-weight-semibold'>Section B -Medical Section</p>");
            sb.Append("<p>( to be fully completed by treating dentist - involved tooth numbers must be marked on chart also )</p>");
            
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:30%; border:1px solid #000000'>Diagnosis Requiring Treatment :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:70%; border:1px solid #000000'>" + pdf.ncd_1 +"</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:30%; border:1px solid #000000'>Presenting Complaint/s :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:70%; border:1px solid #000000'>" + pdf.ncd_1 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:30%; border:1px solid #000000'>History :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:70%; border:1px solid #000000'>" + pdf.ncd_1 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:30%; border:1px solid #000000'>Clinical Details :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:70%; border:1px solid #000000'>" + pdf.ncd_1 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:30%; border:1px solid #000000'>Treatment Plan :</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:70%; border:1px solid #000000'>" + pdf.ncd_1 + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<p style='font-weight-semibold'>Section C - Dental Treatment Details</p>");

            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:20%; border:1px solid #000000'>DENTAL PROCEDURE</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>TOOTH #(UNIVERSAL NUMBERING)</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>SURFACE</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>PROCEDURE CODE</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>COST AS PER AGREED TARIFF</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:20%; border:1px solid #000000'rowspan='8'><img src=\"http://localhost:55640/images/Insurance_Forms/Neuron/dental_chart.gif\" style=\"width:60%\" /></td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:20%; border:1px solid #000000'>CONSULTATION</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>"+ pdf.ncd_3 +"</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>"+ pdf.ncd_4 +"</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>"+ pdf.ncd_5 +"</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>"+ pdf.ncd_6 +"</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:20%; border:1px solid #000000'>X-RAY</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_7 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_8 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_9 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_10 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:20%; border:1px solid #000000'>AMALGAM/COMPOSITE/TEMPORARY FILLING</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_11 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_12 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_13 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_14 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:20%; border:1px solid #000000'>EXTRACTION</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_15 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_16 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_17 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_18 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:20%; border:1px solid #000000'>SCALING/PROPHYLAXIS</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_19 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_20 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_21 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_22 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:20%; border:1px solid #000000'>OTHERS(PLS SPCIFY)</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_23 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_24 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_25 + "</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_26 + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("    <td style='text-align: left;padding: 10px; width:20%; border:1px solid #000000'colspan='4'>TOTAL COST(AS PER AGREED TARIFF)</td>");
            sb.Append("    <td style='text-align: center;padding: 10px; width:15%; border:1px solid #000000'>" + pdf.ncd_27 + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<p>PLEASE MARK INVOLVED TOOTH CLEARLY IN THE CHART (CLAIM WILL DENIED IN CASE DISCREPANCY)</p>");
            sb.Append("<p style='font-weight-semibold'>Section - D Treating Dentist</p>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr style='border-bottom:1px solid #000000'>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-left:1px; width:50%'>I declare that I am the patient's treating Dentist, and that the particulars given are to the best of my knowledge true and correct</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-left:1px; width:50%'>Tel Number : "+ emr.set_tel + " <br/><br/>Fax Numbrer : "+ emr.set_fax + " <br/><br/>Treating Dentist Stamp : <img src='" + emr.doc_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px; width: 100px;'/> </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
            sb.Append("<table style='width:100%; font-size: 12px; border:1px solid #000000;border-collapse: collapse;'>");
            sb.Append("    <tr style=''>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-left:1px; width:50%' colspan='2'>Patient's Declaration and Consent</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style=''>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-left:1px; width:50%'>I confirm that I am the patient/ patient's parent or guardian and wish to claim benefits, and declare that all the particulars given above are to the best of my knowledge true and correct. I hereby consent to and authorize the medical practitioner involved in the patient's care to discuss treatment details and discharge arrangements with and to DubaiCare. I agree that a copy of this consent shall have the validity of the original.</td>");
            sb.Append("    <td style='text-align: left;padding: 10px; border-left:1px; width:50%'>Signature : <img src='" + psign.psb_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px; width: 100px;'/></td>");
            sb.Append("    </tr>");
            sb.Append("</table>");
           
            sb.Append("</div>");
            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }

        //Nas Prescripton Claim Form
        public static string HtmlNasPrescriptionClaim(int appId, EMRInfo emr, int setId)
        {

            BusinessEntities.InsuranceForms.NasPrescriptionClaim pdf = BusinessLogicLayer.InsuranceForms.NasPrescriptionClaim.GetNasPrescriptionClaimData(appId).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "NasPrescriptionClaim").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", hf.footer.ToString());

            StringBuilder sb = new StringBuilder();
            BusinessEntities.EMR.PatientDiagnosis Diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(appId, 0).FirstOrDefault();

            BusinessEntities.EMRForms.Adnic sign_bp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_pulse = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_temp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_notes = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();

            BusinessEntities.EMR.PatientTreatments treatments = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(appId, 0, "").FirstOrDefault();

            string ChkHtml1 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='1' id='npc_chk1'>";
            string ChkHtml2 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='2' id='npc_chk2'>";
            string ChkHtml3 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='3' id='npc_chk3'>";
            string ChkHtml4 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='4' id='npc_chk4'>";
           

            if (pdf.npc_chk.Contains("1"))
            {
                ChkHtml1 = ChkHtml1.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            }
            if (pdf.npc_chk.Contains("2"))
            {
                ChkHtml2 = ChkHtml2.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            }
            if (pdf.npc_chk.Contains("3"))
            {
                ChkHtml3 = ChkHtml3.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            }
            if (pdf.npc_chk.Contains("4"))
            {
                ChkHtml4 = ChkHtml4.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            }

            sb.Append("<html>");
            sb.Append("    <head><title>PRESCRIPTION /ADVICE FORM</title></head>");
            sb.Append("    <body style='font-family: Verdana, Geneva, Tahoma, sans-serif;'>");

            sb.Append("    <table style='width:100%; border: none;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'>");
            sb.Append("            <img src='" + header + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    </table>");

            sb.Append("    <table style='width:100%; font-size: 12px;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'  colspan='9'>");
            sb.Append("            <h1>PRESCRIPTION /ADVICE FORM</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>Ref No</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>" + pdf.npc_1 + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:40%;'>( IMPORTANT: Please copy from the Consultation Form )</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>PATIENT NAME</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;' colspan='2'>" + emr.pat_name + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%; '>DIAGNOSIS</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%; ' colspan='2'>" + emr.pat_name + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'colspan='3'>NATURE OF TREATMENT : ( Please use separate sheet for each group )</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'colspan='3'>"+ ChkHtml1 + "Pharmacy "+ ChkHtml2 + "Diagnostic "+ ChkHtml3 + "Physiotherapy "+ ChkHtml4 + "Others</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>Doctor’s Signature and Stamp</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;' colspan='2'><img src='" + emr.doc_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["InsuranceFormEndPoint"]) + "' style='height: 100px; width: 100px;'/></td>");
            sb.Append("    </tr>");

            sb.Append("</table>");

            sb.Append("<div style='width:100%; text-align:justify; font-size: 12px; margin-top: 0px;margin-bottom: 0px;'>");
            sb.Append("<p style='font-weight-semibold'>Section B -Medical Section</p>");
            sb.Append("<p>( to be fully completed by treating dentist - involved tooth numbers must be marked on chart also )</p>");

            sb.Append("<p>I hereby authorize the physician, Hospital or pharmacy to file a claim for medical services on my behalf and I confirm that the above-mentioned examination/Investigation/therapy is given to me by the doctor. I hereby authorize any Clinic, Physician, Pharmacy or any other person who has provided medical services to me to furnish any and all information with regard to any medical history, medical condition, or medical services and copies of all medical and Clinic records.</p>");

            sb.Append("<table style='width:100%; font-size: 12px;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;'colspan='2'>");
            sb.Append("            <img src='" + psign.psb_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px; width: 100px;'/>");
            sb.Append("             <br/>Patient's Signature");
            sb.Append("             <br/> " + emr.app_fdate);
            sb.Append("             <br/><br/>Date");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<p>Pharmaceuticals (to be filled by treating doctor only)</p>");
            sb.Append("</div>");


            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }

        //Nas Consultation Form
        public static string HtmlNasConsultationForm(int appId, EMRInfo emr, int setId)
        {

            BusinessEntities.InsuranceForms.NasConsultationForm pdf = BusinessLogicLayer.InsuranceForms.NasConsultationForm.GetNasConsultationFormData(appId).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "NasConsultationForm").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", hf.footer.ToString());

            StringBuilder sb = new StringBuilder();
            BusinessEntities.EMR.PatientDiagnosis Diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(appId, 0).FirstOrDefault();

            BusinessEntities.EMRForms.Adnic sign_bp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_pulse = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_temp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_notes = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();

            BusinessEntities.EMR.PatientTreatments treatments = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(appId, 0, "").FirstOrDefault();

            string ChkHtml1 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='1' id='npc_chk1'>";
            string ChkHtml2 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='2' id='npc_chk2'>";
            string ChkHtml3 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='3' id='npc_chk3'>";
            string ChkHtml4 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='4' id='npc_chk4'>";


            //if (pdf.npc_chk.Contains("1"))
            //{
            //    ChkHtml1 = ChkHtml1.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            //}
            //if (pdf.npc_chk.Contains("2"))
            //{
            //    ChkHtml2 = ChkHtml2.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            //}
            //if (pdf.npc_chk.Contains("3"))
            //{
            //    ChkHtml3 = ChkHtml3.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            //}
            //if (pdf.npc_chk.Contains("4"))
            //{
            //    ChkHtml4 = ChkHtml4.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            //}

            sb.Append("<html>");
            sb.Append("    <head><title>PRESCRIPTION /ADVICE FORM</title></head>");
            sb.Append("    <body style='font-family: Verdana, Geneva, Tahoma, sans-serif;'>");

            sb.Append("    <table style='width:100%; border: none;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'>");
            sb.Append("            <img src='" + header + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    </table>");

            sb.Append("    <table style='width:100%; font-size: 12px;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'  colspan='9'>");
            sb.Append("            <h1>PRESCRIPTION /ADVICE FORM</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>Ref No</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>" + pdf.ncf_1 + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:40%;'>( IMPORTANT: Please copy from the Consultation Form )</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>PATIENT NAME</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;' colspan='2'>" + emr.pat_name + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%; '>DIAGNOSIS</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%; ' colspan='2'>" + emr.pat_name + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'colspan='3'>NATURE OF TREATMENT : ( Please use separate sheet for each group )</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'colspan='3'>" + ChkHtml1 + "Pharmacy " + ChkHtml2 + "Diagnostic " + ChkHtml3 + "Physiotherapy " + ChkHtml4 + "Others</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>Doctor’s Signature and Stamp</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;' colspan='2'><img src='" + emr.doc_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["InsuranceFormEndPoint"]) + "' style='height: 100px; width: 100px;'/></td>");
            sb.Append("    </tr>");

            sb.Append("</table>");

            sb.Append("<div style='width:100%; text-align:justify; font-size: 12px; margin-top: 0px;margin-bottom: 0px;'>");
            sb.Append("<p style='font-weight-semibold'>Section B -Medical Section</p>");
            sb.Append("<p>( to be fully completed by treating dentist - involved tooth numbers must be marked on chart also )</p>");

            sb.Append("<p>I hereby authorize the physician, Hospital or pharmacy to file a claim for medical services on my behalf and I confirm that the above-mentioned examination/Investigation/therapy is given to me by the doctor. I hereby authorize any Clinic, Physician, Pharmacy or any other person who has provided medical services to me to furnish any and all information with regard to any medical history, medical condition, or medical services and copies of all medical and Clinic records.</p>");

            sb.Append("<table style='width:100%; font-size: 12px;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;'colspan='2'>");
            sb.Append("            <img src='" + psign.psb_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px; width: 100px;'/>");
            sb.Append("             <br/>Patient's Signature");
            sb.Append("             <br/> " + emr.app_fdate);
            sb.Append("             <br/><br/>Date");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<p>Pharmaceuticals (to be filled by treating doctor only)</p>");
            sb.Append("</div>");


            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }

        //Nas Advice Form
        public static string HtmlNasAdviceForm(int appId, EMRInfo emr, int setId)
        {

            BusinessEntities.InsuranceForms.NasAdviceForm pdf = BusinessLogicLayer.InsuranceForms.NasAdviceForm.GetNasAdviceFormData(appId).FirstOrDefault();
            BusinessEntities.Common.eSignature psign = BusinessLogicLayer.Common.eSignature.GetSignature(appId, "patient", "NasAdviceForm").FirstOrDefault();
            BusinessEntities.Common.PDFHeaderFooter hf = BusinessLogicLayer.Common.PDF.GetHeaderFooterByBranch(setId);

            string header = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "header_images", hf.header.ToString());
            string footer = Path.Combine(ConfigurationManager.AppSettings["ConsentFormEndPoint"], "images", "footer_images", hf.footer.ToString());

            StringBuilder sb = new StringBuilder();
            BusinessEntities.EMR.PatientDiagnosis Diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(appId, 0).FirstOrDefault();

            BusinessEntities.EMRForms.Adnic sign_bp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_pulse = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_temp = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();
            BusinessEntities.EMRForms.Adnic sign_notes = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId).FirstOrDefault();

            BusinessEntities.EMR.PatientTreatments treatments = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(appId, 0, "").FirstOrDefault();

            string ChkHtml1 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='1' id='npc_chk1'>";
            string ChkHtml2 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='2' id='npc_chk2'>";
            string ChkHtml3 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='3' id='npc_chk3'>";
            string ChkHtml4 = "<input type='checkbox'  class='custom-control-input' name='npc_chk' value='4' id='npc_chk4'>";


            if (pdf.naf_chk.Contains("1"))
            {
                ChkHtml1 = ChkHtml1.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            }
            if (pdf.naf_chk.Contains("2"))
            {
                ChkHtml2 = ChkHtml2.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            }
            if (pdf.naf_chk.Contains("3"))
            {
                ChkHtml3 = ChkHtml3.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            }
            if (pdf.naf_chk.Contains("4"))
            {
                ChkHtml4 = ChkHtml4.Replace("<input type='checkbox'", "<input type='checkbox' checked");
            }

            sb.Append("<html>");
            sb.Append("    <head><title>PRESCRIPTION /ADVICE FORM</title></head>");
            sb.Append("    <body style='font-family: Verdana, Geneva, Tahoma, sans-serif;'>");

            sb.Append("    <table style='width:100%; border: none;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'>");
            sb.Append("            <img src='" + header + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    </table>");

            sb.Append("    <table style='width:100%; font-size: 12px;border-collapse: collapse;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;'  colspan='9'>");
            sb.Append("            <h1>PRESCRIPTION /ADVICE FORM</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>Ref No</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>" + pdf.naf_1 + "</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:40%;'>( IMPORTANT: Please copy from the Consultation Form )</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>PATIENT NAME</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;' colspan='2'>" + emr.pat_name + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%; '>DIAGNOSIS</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%; ' colspan='2'>" + emr.pat_name + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'colspan='3'>NATURE OF TREATMENT : ( Please use separate sheet for each group )</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'colspan='3'>" + ChkHtml1 + "Pharmacy " + ChkHtml2 + "Diagnostic " + ChkHtml3 + "Physiotherapy " + ChkHtml4 + "Others</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;'>Doctor’s Signature and Stamp</td>");
            sb.Append("        <td style='text-align: left;padding: 10px; width:30%;' colspan='2'><img src='" + emr.doc_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["InsuranceFormEndPoint"]) + "' style='height: 100px; width: 100px;'/></td>");
            sb.Append("    </tr>");

            sb.Append("</table>");

            sb.Append("<div style='width:100%; text-align:justify; font-size: 12px; margin-top: 0px;margin-bottom: 0px;'>");
            sb.Append("<p style='font-weight-semibold'>Section B -Medical Section</p>");
            sb.Append("<p>( to be fully completed by treating dentist - involved tooth numbers must be marked on chart also )</p>");

            sb.Append("<p>I hereby authorize the physician, Hospital or pharmacy to file a claim for medical services on my behalf and I confirm that the above-mentioned examination/Investigation/therapy is given to me by the doctor. I hereby authorize any Clinic, Physician, Pharmacy or any other person who has provided medical services to me to furnish any and all information with regard to any medical history, medical condition, or medical services and copies of all medical and Clinic records.</p>");

            sb.Append("<table style='width:100%; font-size: 12px;'>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;padding: 10px;'colspan='2'>");
            sb.Append("            <img src='" + psign.psb_sign.Replace(ConfigurationManager.AppSettings["ConsentFormEndPoint"], ConfigurationManager.AppSettings["ConsentFormEndPoint"]) + "' style='height: 100px; width: 100px;'/>");
            sb.Append("             <br/>Patient's Signature");
            sb.Append("             <br/> " + emr.app_fdate);
            sb.Append("             <br/><br/>Date");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<p>Pharmaceuticals (to be filled by treating doctor only)</p>");
            sb.Append("</div>");


            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }
    }
}
