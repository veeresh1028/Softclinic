using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace BusinessLogicLayer.Invoice
{
    public class PDFExport
    {
        public static string HtmlInvoice(int invId)
        {

            BusinessEntities.Invoice.InvoicePrint print = BusinessLogicLayer.Invoice.Invoice.PrintCashInvoice(invId);


            StringBuilder sb = new StringBuilder();

            sb.Append("<html>");
            sb.Append("    <head><title>Invoice</title></head>");
            sb.Append("    <body style='font-family: Verdana, Geneva, Tahoma, sans-serif;'>");

            sb.Append("    <table style='width:100%; font-size: 12px; '>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: center;' colspan='6'>");
            sb.Append("            <img src='"+ print.inv_header.set_header_image + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'  colspan='6'>");
            sb.Append("            <h1>TAX INVOICE</h1>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Reg TRN No</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;' colspan='4'>"+ print.inv_header.set_vat_regno + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Facility Name </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'  colspan='4'>"+ print.inv_header.set_company + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Address </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'  colspan='4'>"+ print.inv_header.set_address + " <br/> "+ print.inv_header.set_tel + "/" + print.inv_header.set_mob + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;' colspan='6'>");
            sb.Append("            <hr/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Invoice No</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>"+ print.inv_header.inv_no + "</td>");
            sb.Append("        <td style='text-align: left;'>Invoice Date </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>"+ print.inv_header.inv_date + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Doctor</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>"+ print.inv_header.emp_name  + "(DHA # -" + print.inv_header.emp_license + ") </td>");
            sb.Append("        <td style='text-align: left;'>Department </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>"+ print.inv_header.emp_dept_name  + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Patient Name</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>"+ print.inv_header.pat_name  + "</td>");
            sb.Append("        <td style='text-align: left;'>MRN/File No. </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>"+ print.inv_header.pat_code  + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Age / Gender</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>"+ print.inv_header.pat_age +"/"+ print.inv_header.pat_gender + "</td>");
            sb.Append("        <td style='text-align: left;'>Type</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>"+ print.inv_header.inv_type + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr>");
            sb.Append("        <td style='text-align: left;'>Visit Date </td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>"+ print.inv_header.app_fdate + "</td>");
            sb.Append("        <td style='text-align: left;'>Made By</td>");
            sb.Append("        <td style='text-align: center;'>:</td>");
            sb.Append("        <td style='text-align: left;'>"+ print.inv_header.madeby_name + "</td>");
            sb.Append("    </tr>");
            sb.Append("</table>");

            sb.Append("<table style='width:100%; font-size: 12px; border-collapse: collapse; margin-top:10px;'>");
            sb.Append("    <thead>");
            sb.Append("        <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("            <th style='width:5%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'></th>");
            sb.Append("            <th style='width:40%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Treatment/Procedure</th>");
            sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Qty</th>");
            sb.Append("            <th style='width:10%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Unit Price </th>");
            sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Gross </th>");
            sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Discount</th>");
            sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Net</th>");
            sb.Append("            <th style='width:7%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>VAT</th>");
            sb.Append("            <th style='width:10%; text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>Net + VAT</th>");
            sb.Append("        </tr>");
            sb.Append("    </thead>");
            sb.Append("    <tbody>");

            int count = 0;
            foreach (BusinessEntities.Invoice.InvoiceBody i in print.inv_body)
            {
                count++;

                sb.Append("        <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("            <td style='text-align: center; border: 1px solid #cdcdcd; padding: 10px;'>"+ count.ToString("D2") + "</td>");
                sb.Append("            <td style='border: 1px solid #cdcdcd; padding: 10px;'>");
                sb.Append("                <strong>"+ i.pt_tr_code + "</strong>");
                sb.Append("                <br/>");
                sb.Append("                <p>"+ i.pt_tr_name + "</p>");
                sb.Append("            </td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ i.pt_qty + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ i.pt_uprice + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ i.pt_total + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ i.pt_disc + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ i.pt_net + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ i.pt_vat + "</td>");
                sb.Append("            <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ i.pt_netvat + "</td>");
                sb.Append("        </tr>");

            }

            sb.Append("    </tbody>");

            sb.Append("    <tfoot>");
            sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Gross Amount (in AED)</td>");
            sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ print.inv_footer.inv_total + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Discount (in AED) </td>");
            sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ print.inv_footer.inv_disc + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Net Amount (in AED) </td>");
            sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ print.inv_footer.inv_net + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Tax on 5% (in AED) </td>");
            sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ print.inv_footer.inv_vat + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Credit Note (in AED)</td>");
            sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ print.inv_footer.inv_incv_net + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Credit Note VAT (in AED) </td>");
            sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ print.inv_footer.inv_incv_vat + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Total Amount(in AED) </td>");
            sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ (print.inv_footer.inv_net + print.inv_footer.inv_vat) + "</td>");
            sb.Append("    </tr>");


            if (decimal.Parse(print.inv_footer.rec_cash) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Paid by Cash (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>"+ print.inv_footer.rec_cash + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_cc) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Paid by Credit Card (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_cc + "</td>");
                sb.Append("    </tr>");

                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Credit Card Charges (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_cc_charges2 + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_chq) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Paid by Cheque (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_chq + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_bt) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Paid by Bank Transfer (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_bt + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_debit) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Bad Debit (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_debit + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_allocated) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Redeemed from Advance Allocation (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_allocated + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_vamount) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Redeemed from Voucher (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_vamount + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_lamount) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Redeemed from Loyalty Values (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_lamount + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_tabby) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Paid by Tabby (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_tabby + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_self) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Paid by Selfologi (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_self + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_spoti) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Paid by Spotii (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_spoti + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_cob) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Paid by Cobone (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_cob + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_group) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Paid by Groupon (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_group + "</td>");
                sb.Append("    </tr>");
            }

            if (decimal.Parse(print.inv_footer.rec_stripe) > 0)
            {
                sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
                sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Paid by Stripe (in AED) </td>");
                sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.rec_stripe + "</td>");
                sb.Append("    </tr>");
            }

     
            sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Balance (in AED) </td>");
            sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.balance + "</td>");
            sb.Append("    </tr>");
            sb.Append("    <tr style='border: 1px solid #cdcdcd; '>");
            sb.Append("        <td colspan='8' style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>Advance Balance (in AED) </td>");
            sb.Append("        <td style='text-align: right;border: 1px solid #cdcdcd; padding: 10px;'>" + print.inv_footer.advance_balance + "</td>");
            sb.Append("    </tr>");
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
            sb.Append("            <img src='"+ print.inv_header.set_footer_image + "'/>");
            sb.Append("        </td>");
            sb.Append("    </tr>");
            sb.Append("</table>");


            sb.Append("    </body>");
            sb.Append("</html>");

            String htmlString = sb.ToString();

            return htmlString;
        }
    }
}
