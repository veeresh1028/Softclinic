using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Invoice
{
    public class AdvanceLoyaltyRefund
    {
        public static List<BusinessEntities.Invoice.AdvanceLoyaltyRefund> GetAdvanceLoyaltyRefund(ReceiptSearch rec)
        {
            DataTable dt = DataAccessLayer.Invoice.AdvanceLoyaltyRefund.GetAdvanceLoyaltyRefund(rec);
            List<BusinessEntities.Invoice.AdvanceLoyaltyRefund> list = new List<BusinessEntities.Invoice.AdvanceLoyaltyRefund>();

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Invoice.AdvanceLoyaltyRefund d = new BusinessEntities.Invoice.AdvanceLoyaltyRefund();
                d.recId = int.Parse(dr["recId"].ToString());
                d.rec_branch = int.Parse(dr["rec_branch"].ToString());
                d.rec_status2 = dr["rec_status2"].ToString();
                d.rec_code = dr["rec_code"].ToString();
                d.rec_type = dr["rec_type"].ToString();
                d.rec_notes = dr["rec_notes"].ToString();
                d.rec_loy_value = decimal.Parse(dr["rec_loy_value"].ToString());
                d.rec_patient = int.Parse(dr["rec_patient"].ToString());
                d.rec_date = DateTime.Parse(dr["rec_date"].ToString());
                d.rec_cash = decimal.Parse(dr["rec_cash"].ToString());
                d.rec_tabby = decimal.Parse(dr["rec_tabby"].ToString());
                d.rec_self = decimal.Parse(dr["rec_self"].ToString());
                d.rec_spoti = decimal.Parse(dr["rec_spoti"].ToString());
                d.rec_group = decimal.Parse(dr["rec_group"].ToString());
                d.rec_cob = decimal.Parse(dr["rec_cob"].ToString());
                d.rec_stripe = decimal.Parse(dr["rec_stripe"].ToString());
                d.rec_tamara = decimal.Parse(dr["rec_tamara"].ToString());
                d.rec_extra_pay1 = decimal.Parse(dr["rec_extra_pay1"].ToString());
                d.rec_extra_pay2 = decimal.Parse(dr["rec_extra_pay2"].ToString());
                d.rec_extra_pay3 = decimal.Parse(dr["rec_extra_pay3"].ToString());
                d.rec_cc = decimal.Parse(dr["rec_cc"].ToString());
                d.rec_chq = decimal.Parse(dr["rec_chq"].ToString());
                d.rec_chq_date = DateTime.Parse(dr["rec_chq_date"].ToString());
                d.rec_chq_no = dr["rec_chq_no"].ToString();
                d.rec_chq_bank = dr["rec_chq_bank"].ToString();
                d.rec_bt = decimal.Parse(dr["rec_bt"].ToString());
                d.rec_debit = decimal.Parse(dr["rec_debit"].ToString());
                d.rec_total = decimal.Parse(dr["rec_total"].ToString());
                d.rec_advance = decimal.Parse(dr["rec_advance"].ToString());
                d.rec_status = dr["rec_status"].ToString();
                d.rec_branch_name = dr["rec_branch_name"].ToString();
                d.rec_madeby_name = dr["rec_madeby_name"].ToString();
                d.patId = int.Parse(dr["patId"].ToString());
                d.pat_code = dr["pat_code"].ToString();
                d.pat_name = dr["pat_name"].ToString();
                d.pat_dob = DateTime.Parse(dr["pat_dob"].ToString());
                d.pat_class = dr["pat_class"].ToString();
                d.pat_mob = dr["pat_mob"].ToString();
                d.pat_email = dr["pat_email"].ToString();
                d.pat_gender = dr["pat_gender"].ToString();
                d.pat_emirateid = dr["pat_emirateid"].ToString();
                d.id_card_edate = DateTime.Parse(dr["id_card_edate"].ToString());
                d.rec_cc2 = decimal.Parse(dr["rec_cc2"].ToString());
                d.rec_cc_charges2 = decimal.Parse(dr["rec_cc_charges2"].ToString());
                d.rec_total_allocated = decimal.Parse(dr["rec_total_allocated"].ToString());
                d.rec_balance = decimal.Parse(dr["rec_balance"].ToString());
                d.rec_payment_status = dr["rec_payment_status"].ToString();
                d.rec_refund_ag_adv_code = dr["rec_refund_ag_adv_code"].ToString();
                d.rec_doctor_name = dr["rec_doctor_name"].ToString();
                d.emp_name = dr["rec_doctor_name"].ToString();
                d.emp_dept_name = dr["emp_dept_name"].ToString();
                d.emp_color = dr["emp_color"].ToString();
                d.emp_license = dr["emp_license"].ToString();


                list.Add(d);
            }

            return list;
        }

        public static List<CommonDDL> SearchPatients(string query, int search_type)
        {
            DataTable dt = DataAccessLayer.Invoice.AdvanceLoyaltyRefund.SearchPatients(query, search_type);
            List<CommonDDL> items = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    items.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["patId"]),
                        text = "<span class='text-primary me-2'>" + dr["pat_code"].ToString() + " - </span> " +
                                "<span class='text-info me-2'>" + dr["pat_name"].ToString() + " - </span> " +
                                "<span class='text-danger me-2'>" + dr["pat_mob"].ToString() + "</span>"
                    });
                }
            }

            return items;
        }

        public static List<BusinessEntities.Invoice.ReceiptAdvance> RefundInvoiceByPatId(int patId)
        {
            List<BusinessEntities.Invoice.ReceiptAdvance> list = new List<BusinessEntities.Invoice.ReceiptAdvance>();
            DataTable ret = DataAccessLayer.Invoice.AdvanceLoyaltyRefund.RefundInvoiceByPatId(patId);

            foreach (DataRow item in ret.Rows)
            {
                BusinessEntities.Invoice.ReceiptAdvance ra = new BusinessEntities.Invoice.ReceiptAdvance();
                ra.recId = int.Parse(item["recId"].ToString());
                ra.rec_code = item["inv_no"].ToString() + " - " + item["rec_code"].ToString() + " [" + item["invId"].ToString() + "]";
                ra.rec_date = DateTime.Parse(item["rec_date"].ToString()).ToString("dd-MMM-yyyy");
                ra.rec_advance = decimal.Parse(item["rec_refundable"].ToString());

                if (ra.rec_advance > 0)
                {
                    list.Add(ra);
                }
            }

            return list;
        }

        public static int PostToAccountReceipt(ReceiptsBulkStatus data, int madeby)
        {
            return DataAccessLayer.Invoice.AdvanceLoyaltyRefund.PostToAccountReceipt(data, madeby);
        }
    }
}
