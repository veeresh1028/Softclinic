using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Invoice
{
    public class CreditNote
    {
        public static List<BusinessEntities.Invoice.CreditNote> GetCreditNotes(CreditNoteSearch search)
        {
            List<BusinessEntities.Invoice.CreditNote> creditNotes = new List<BusinessEntities.Invoice.CreditNote>();
            DataTable dt = DataAccessLayer.Invoice.CreditNote.GetCreditNotes(search);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Invoice.CreditNote cn = new BusinessEntities.Invoice.CreditNote();
                cn.invcId = int.Parse(dr["invcId"].ToString());
                cn.invId = int.Parse(dr["invId"].ToString());
                cn.invc_no = dr["invc_no"].ToString();
                cn.inv_no = dr["inv_no"].ToString();
                cn.invc_date = DateTime.Parse(dr["invc_date"].ToString());
                cn.invc_total = DataValidation.isDecimalValid(dr["invc_total"].ToString());
                cn.invc_disc = DataValidation.isDecimalValid(dr["invc_disc"].ToString());
                cn.invc_tded = DataValidation.isDecimalValid(dr["invc_tded"].ToString());
                cn.invc_dded = DataValidation.isDecimalValid(dr["invc_dded"].ToString());
                cn.invc_lded = DataValidation.isDecimalValid(dr["invc_lded"].ToString());
                cn.invc_rded = DataValidation.isDecimalValid(dr["invc_rded"].ToString());
                cn.invc_mded = DataValidation.isDecimalValid(dr["invc_mded"].ToString());
                cn.invc_copay = DataValidation.isDecimalValid(dr["invc_copay"].ToString());
                cn.invc_dcopay = DataValidation.isDecimalValid(dr["invc_dcopay"].ToString());
                cn.invc_deductions = (cn.invc_tded + cn.invc_dded + cn.invc_lded + cn.invc_rded + cn.invc_mded + cn.invc_copay + cn.invc_dcopay);
                cn.invc_net = DataValidation.isDecimalValid(dr["invc_net"].ToString());
                cn.invc_vat = DataValidation.isDecimalValid(dr["invc_vat"].ToString());
                cn.invc_status = dr["invc_status"].ToString();
                cn.invc_status2 = dr["invc_status2"].ToString();
                cn.invc_madeby = int.Parse(dr["invc_madeby"].ToString());
                cn.invc_notes = dr["invc_notes"].ToString();
                cn.patId = int.Parse(dr["patId"].ToString());
                cn.pat_code = dr["pat_code"].ToString();
                cn.pat_name = dr["pat_name"].ToString();
                cn.pat_dob = DateTime.Parse(dr["pat_dob"].ToString());
                cn.pat_class = dr["pat_class"].ToString();
                cn.pat_mob = dr["pat_mob"].ToString();
                cn.pat_email = dr["pat_email"].ToString();
                cn.pat_gender = dr["pat_gender"].ToString();
                cn.pat_emirateid = dr["pat_emirateid"].ToString();
                cn.id_card_edate = DateTime.Parse(dr["id_card_edate"].ToString());
                cn.doctor_name = dr["doctor_name"].ToString();
                cn.emp_dept_name = dr["emp_dept_name"].ToString();
                cn.emp_license = dr["emp_license"].ToString();

                creditNotes.Add(cn);
            }

            return creditNotes;

        }

        public static List<CommonDDL> SearchInvoicedPatients(string query)
        {
            DataTable dt = DataAccessLayer.Invoice.CreditNote.SearchInvoicedPatients(query);

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
                                "<span class='text-danger me-2'>" + dr["pat_mob"].ToString() + "</span>" +
                                "<span class='badge bg-danger'> " + dr["inv_count"].ToString() + " Invoice(s)</span>"
                    });
                }
            }

            return items;
        }

        public static List<BusinessEntities.Invoice.Invoice> GetInvoiceByPatId(int patId)
        {
            DataTable dt = DataAccessLayer.Invoice.Invoice.GetInvoiceByPatId(patId);
            DataRow[] rows = dt.Select("inv_status <> 'Unpaid'");

            List<BusinessEntities.Invoice.Invoice> list = new List<BusinessEntities.Invoice.Invoice>();

            foreach (DataRow dr in rows)
            {
                string _d = DateTime.Parse(dr["inv_date"].ToString()).ToString("yyyy-MM-dd");
                string _t = DateTime.Parse(dr["inv_date_created"].ToString()).ToString("HH:mm:ss");
                DateTime _dt = DateTime.ParseExact(_d + " " + _t, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                BusinessEntities.Invoice.Invoice i = new BusinessEntities.Invoice.Invoice();
                i.invId = int.Parse(dr["invId"].ToString());
                i.inv_no = dr["inv_no"].ToString();
                i.inv_date = _dt;
                i.inv_net = DataValidation.isDecimalValid(dr["inv_net"].ToString());
                i.inv_status = dr["inv_status"].ToString();
                i.inv_status2 = dr["inv_status2"].ToString();
                i.inv_type = dr["inv_type"].ToString();
                i.rec_count = int.Parse(dr["rec_count"].ToString());
                i.paid_amount = DataValidation.isDecimalValid(dr["total"].ToString());
                i.patient_balance = DataValidation.isDecimalValid(dr["outstanding"].ToString());
                list.Add(i);
            }

            return list;
        }

        public static BusinessEntities.Invoice.CreditNote AutoCreateCreditNoteCode()
        {
            BusinessEntities.Invoice.CreditNote cn = new BusinessEntities.Invoice.CreditNote();
            cn.invcId = 0;
            cn.invc_no = DataAccessLayer.Invoice.CreditNote.AutoCreateCreditNoteCode();

            return cn;
        }

        public static CreditNoteViewModel GetCreditNoteByInvoice(int invId)
        {
            CreditNoteViewModel model = new CreditNoteViewModel();

            DataSet ds = DataAccessLayer.Invoice.CreditNote.GetCreditNoteByInvoice(invId);
            CreditNoteInfo info = new CreditNoteInfo();
            List<CreditNoteDetails> details = new List<CreditNoteDetails>();
            List<CreditNoteItems> items = new List<CreditNoteItems>();


            if (ds != null)
            {
                if (ds.Tables.Count >= 0)
                {
                    info.invId = int.Parse(ds.Tables[0].Rows[0]["invId"].ToString());
                    info.inv_no = ds.Tables[0].Rows[0]["inv_no"].ToString();
                    info.inv_date = DateTime.Parse(ds.Tables[0].Rows[0]["inv_date"].ToString());
                    info.inv_net = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["inv_net"].ToString());
                    info.inv_vat = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["inv_vat"].ToString());
                    info.inv_status = ds.Tables[0].Rows[0]["inv_status"].ToString();
                    info.rec_total = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["total"].ToString());
                    info.invc_net = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["invc_net"].ToString());
                    info.invc_vat = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["invc_vat"].ToString());
                    info.paid = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["paid"].ToString());
                    info.balance = DataValidation.isDecimalValid(ds.Tables[0].Rows[0]["balance"].ToString());
                }

                if (ds.Tables.Count >= 1)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        CreditNoteDetails d = new CreditNoteDetails
                        {
                            invcId = int.Parse(dr["invcId"].ToString()),
                            invc_no = dr["invc_no"].ToString(),
                            invc_status = dr["invc_status"].ToString(),
                            invc_net = DataValidation.isDecimalValid(dr["invc_net"].ToString()),
                            invc_vat = DataValidation.isDecimalValid(dr["invc_vat"].ToString())
                        };
                        details.Add(d);
                    }
                }

                if (ds.Tables.Count >= 2)
                {
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        if (int.Parse(dr["isCreditNote"].ToString()) == 0)
                        {
                            CreditNoteItems d = new CreditNoteItems
                            {
                                ptId = int.Parse(dr["ptId"].ToString()),
                                pt_tr_code = dr["pt_tr_code"].ToString(),
                                pt_tr_name = dr["pt_tr_name"].ToString(),
                                pt_net = DataValidation.isDecimalValid(dr["pt_net"].ToString()),
                                pt_vat = DataValidation.isDecimalValid(dr["pt_vat"].ToString()),
                                pt_qty = DataValidation.isDecimalValid(dr["pt_qty"].ToString())
                            };

                            items.Add(d);
                        }

                    }
                }
            }


            model.info = info;
            model.details = details;
            model.items = items;

            return model;
        }

        public static string CreateNewCreditNote(CreditNoteInvoiceWithArrayItems data, int madeby)
        {
            int val = 0;
            string cn_no = string.Empty;

            if (data.items.Count > 0)
            {
                val = DataAccessLayer.Invoice.CreditNote.CreateNewCreditNote(data.invId, data.net, data.vat, madeby, out cn_no);

                if (val > 0 && !string.IsNullOrEmpty(cn_no))
                {
                    foreach (CreditNoteArrayItem i in data.items)
                    {
                        val += DataAccessLayer.Invoice.CreditNote.AddCreditNoteItems(cn_no, i.id, 0, i.value, madeby);
                    }
                }
            }

            return cn_no;
        }

        public static int DeleteCreditNote(int invcId, int madeby)
        {
            return DataAccessLayer.Invoice.CreditNote.DeleteCreditNote(invcId, madeby);
        }

        public static List<BusinessEntities.Invoice.CreditNoteAudit> GetCreditNoteLog(int invcId)
        {
            DataTable dt = DataAccessLayer.Invoice.CreditNote.GetCreditNoteLog(invcId);
            List<BusinessEntities.Invoice.CreditNoteAudit> list = new List<BusinessEntities.Invoice.CreditNoteAudit>();

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Invoice.CreditNoteAudit i = new BusinessEntities.Invoice.CreditNoteAudit();
                i.invcaId = int.Parse(dr["invcaId"].ToString());
                i.invca_no = dr["invca_no"].ToString();
                i.invca_date = DateTime.Parse(dr["invca_date"].ToString());
                i.invca_net = decimal.Parse(dr["invca_net"].ToString());
                i.invca_vat = decimal.Parse(dr["invca_vat"].ToString());
                i.invca_status = dr["invca_status"].ToString();
                i.invca_operation = dr["invca_operation"].ToString();
                i.invca_date_modified = DateTime.Parse(dr["invca_date_modified"].ToString());
                i.madeby = dr["madeby"].ToString();
                list.Add(i);
            }

            return list;
        }

        public static CreditNotePrint PrintCreditNote(int invcId)
        {
            DataSet ds = DataAccessLayer.Invoice.CreditNote.PrintCreditNote(invcId);

            CreditNoteHeader header = new CreditNoteHeader();
            List<CreditNoteBody> body = new List<CreditNoteBody>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    header.set_vat_regno = dr["set_vat_regno"].ToString();
                    header.set_company = dr["set_company"].ToString();
                    header.set_address = dr["set_address"].ToString();
                    header.set_email = dr["set_email"].ToString();
                    header.set_tel = dr["set_tel"].ToString();
                    header.set_mob = dr["set_mob"].ToString();
                    header.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", dr["set_header_image"].ToString());
                    header.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", dr["set_footer_image"].ToString());

                    header.inv_no = dr["inv_no"].ToString();
                    header.inv_date = DateTime.Parse(dr["inv_date"].ToString()).ToString("dd-MMM-yyyy");
                    header.invc_no = dr["invc_no"].ToString();
                    header.invc_date = DateTime.Parse(dr["invc_date"].ToString()).ToString("dd-MMM-yyyy") + " " + DateTime.Parse(dr["invc_date_created"].ToString()).ToString("HH:mm:ss");
                    header.emp_name = dr["emp_name"].ToString();
                    header.emp_license = dr["emp_license"].ToString();
                    header.emp_dept_name = dr["emp_dept_name"].ToString();
                    header.pat_name = dr["pat_name"].ToString();
                    header.pat_code = dr["pat_code"].ToString();
                    header.invc_type = dr["invc_type"].ToString();
                    header.pat_gender = dr["pat_gender"].ToString();
                    header.invc_date_created = dr["invc_date_created"].ToString();
                    header.madeby_name = dr["madeby_name"].ToString();

                    header.invc_vat = decimal.Parse(dr["invc_vat"].ToString()).ToString("N2");
                    header.invc_net = decimal.Parse(dr["invc_net"].ToString()).ToString("N2");
                    header.invc_netvat = (decimal.Parse(header.invc_net) + decimal.Parse(header.invc_vat)).ToString("N2");

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
                        CreditNoteBody i = new CreditNoteBody();
                        i.tr_code = dr["tr_code"].ToString();
                        i.tr_name = dr["tr_name"].ToString();
                        i.ptc_uprice = decimal.Parse(dr["ptc_uprice"].ToString()).ToString("N2");
                        i.ptc_qty = decimal.Parse(dr["ptc_qty"].ToString()).ToString("N2");
                        i.ptc_total = decimal.Parse(dr["ptc_total"].ToString()).ToString("N2");
                        i.ptc_disc = decimal.Parse(dr["ptc_disc"].ToString()).ToString("N2");
                        i.ptc_vat = decimal.Parse(dr["ptc_vat"].ToString()).ToString("N2");
                        i.ptc_net = decimal.Parse(dr["ptc_net"].ToString()).ToString("N2");
                        i.ptc_netvat = (decimal.Parse(i.ptc_net) + decimal.Parse(i.ptc_vat)).ToString("N2");
                        body.Add(i);
                    }
                }
            }

            CreditNotePrint print = new CreditNotePrint();
            print.cn_header = header;
            print.cn_body = body;

            return print;
        }

        public static int PostCreditNoteToAccount(string data, int empId)
        {
            return DataAccessLayer.Invoice.CreditNote.PostCreditNoteToAccount(data, empId);

        }
    }
}