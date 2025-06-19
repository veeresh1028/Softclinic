using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BusinessLogicLayer.Invoice
{
    public class QuickCash
    {
        public static BusinessEntities.Invoice.QuickCash GetQC_InvoiceInfo(int appId)
        {
            DataTable dt = DataAccessLayer.Invoice.QuickCash.GetQC_InvoiceInfo(appId);

            BusinessEntities.Invoice.QuickCash qc = new BusinessEntities.Invoice.QuickCash();
            QC_InvoiceInfo info = new QC_InvoiceInfo();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                DateTime _dt = DateTime.Parse("1900-01-01");
                DateTime.TryParse(dr["id_card_edate"].ToString(), out _dt);

                info.appId = appId;
                info.invId = int.Parse(dr["invId"].ToString());
                info.inv_type = dr["inv_type"].ToString();
                info.inv_no = dr["inv_no"].ToString();
                info.inv_date = DateTime.Parse(dr["inv_date"].ToString());
                info.app_fdate = DateTime.Parse(dr["app_fdate"].ToString());
                info.patId = int.Parse(dr["patId"].ToString());
                info.pat_code = dr["pat_code"].ToString();
                info.pat_name = dr["pat_name"].ToString();
                info.pat_emirateid = dr["pat_emirateid"].ToString();
                info.id_card_edate = _dt;
                info.emp_name = dr["emp_name"].ToString();
                info.emp_license = dr["emp_license"].ToString();
                info.emp_dept_name = dr["emp_dept_name"].ToString();
                info.rec_no = dr["rec_no"].ToString();
                info.branch = int.Parse(dr["app_branch"].ToString());
                info.multi_bill = int.Parse(dr["multi_bill"].ToString()); 
                info.set_sync = dr["set_sync"].ToString(); 
                info.set_mnr = dr["set_mnr"].ToString(); 
                info.pat_class = dr["pat_class"].ToString();
                info.app_fdate_time = dt.Rows[0]["app_fdate_time"].ToString();
            }

            qc.qc_invoice_info = info;

            return qc;
        }

        public static BusinessEntities.Invoice.QuickCash GetQCM_InvoiceInfo(int appId, int invId)
        {
            DataTable dt = DataAccessLayer.Invoice.QuickCash.GetQCM_InvoiceInfo(appId, invId);

            BusinessEntities.Invoice.QuickCash qc = new BusinessEntities.Invoice.QuickCash();
            QC_InvoiceInfo info = new QC_InvoiceInfo();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                DateTime _dt = DateTime.Parse("1900-01-01");
                DateTime.TryParse(dr["id_card_edate"].ToString(), out _dt);

                info.appId = appId;
                info.invId = int.Parse(dr["invId"].ToString());
                info.inv_no = dr["inv_no"].ToString();
                info.inv_date = DateTime.Parse(dr["inv_date"].ToString());
                info.app_fdate = DateTime.Parse(dr["app_fdate"].ToString());
                info.patId = int.Parse(dr["patId"].ToString());
                info.pat_code = dr["pat_code"].ToString();
                info.pat_name = dr["pat_name"].ToString();
                info.pat_emirateid = dr["pat_emirateid"].ToString();
                info.id_card_edate = _dt;
                info.emp_name = dr["emp_name"].ToString();
                info.emp_license = dr["emp_license"].ToString();
                info.emp_dept_name = dr["emp_dept_name"].ToString();
                info.rec_no = dr["rec_no"].ToString();
                info.branch = int.Parse(dr["app_branch"].ToString());
            }

            qc.qc_invoice_info = info;

            return qc;
        }

        public static BusinessEntities.Invoice.QuickCash GetQC_InvoiceInfoByInvId(int invId)
        {
            DataTable dt = DataAccessLayer.Invoice.QuickCash.GetQC_InvoiceInfoByInvId(invId);

            BusinessEntities.Invoice.QuickCash qc = new BusinessEntities.Invoice.QuickCash();

            List<BusinessEntities.Invoice.QC_InvoiceItems> list = new List<BusinessEntities.Invoice.QC_InvoiceItems>();
            QC_InvoiceInfo info = new QC_InvoiceInfo();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                DateTime _dt = DateTime.Parse("1900-01-01");
                DateTime.TryParse(dr["id_card_edate"].ToString(), out _dt);

                info.invId = invId;
                info.appId = int.Parse(dr["appId"].ToString());
                info.app_fdate = DateTime.Parse(dr["app_fdate"].ToString());
                info.inv_no = dr["inv_no"].ToString();
                info.inv_notes = dr["inv_notes"].ToString();
                info.inv_date = DateTime.Parse(dr["inv_date"].ToString());
                info.patId = int.Parse(dr["patId"].ToString());
                info.pat_code = dr["pat_code"].ToString();
                info.pat_name = dr["pat_name"].ToString();
                info.pat_emirateid = dr["pat_emirateid"].ToString();
                info.id_card_edate = _dt;
                info.emp_name = dr["emp_name"].ToString();
                info.emp_license = dr["emp_license"].ToString();
                info.emp_dept_name = dr["emp_dept_name"].ToString();
                info.multi_bill = int.Parse(dr["multi_bill"].ToString());
                info.set_sync = dr["set_sync"].ToString();
                info.set_mnr = dr["set_mnr"].ToString();
                info.pat_class = dr["pat_class"].ToString();
                info.app_fdate_time = dt.Rows[0]["app_fdate_time"].ToString();
                if (info.appId > 0)
                {
                    DataTable dt_list = DataAccessLayer.Invoice.Invoice.GetServicesByInvoices(info.appId, invId, 1);

                    foreach (DataRow r in dt_list.Rows)
                    {
                        if (r["pt_status"].ToString() != "Deleted")
                        {
                            BusinessEntities.Invoice.QC_InvoiceItems i = new BusinessEntities.Invoice.QC_InvoiceItems();
                            i.ptId = int.Parse(r["ptId"].ToString());
                            i.pt_treatment = int.Parse(r["pt_treatment"].ToString());
                            i.pt_mode = "edit";
                            i.pt_tr_code = r["pt_tr_code"].ToString();
                            i.pt_tr_name = r["pt_tr_name"].ToString();
                            i.pt_vat_type = r["pt_tr_type"].ToString();
                            i.pt_qty = decimal.Parse(r["pt_qty"].ToString());
                            i.pt_ses = decimal.Parse(r["pt_ses"].ToString());
                            i.pt_teeth = r["PT_TEETH"].ToString();
                            i.pt_sur = r["PT_SUR"].ToString();
                            i.pt_uprice = decimal.Parse(r["pt_uprice"].ToString());
                            i.pt_total = decimal.Parse(r["pt_total"].ToString());
                            i.pt_disc_type = string.IsNullOrEmpty(r["pt_barcode"].ToString()) ? "%" : (r["pt_barcode"].ToString() == "1" ? "Fixed" : "%");
                            i.pt_disc_value = decimal.Parse(r["pt_disc"].ToString());

                            if (i.pt_disc_value == 0)
                            {
                                i.pt_disc = (i.pt_disc_type == "Fixed") ? i.pt_disc_value : ((i.pt_total > 0) ? ((i.pt_total * 100)) : 0);
                            }
                            else
                            {
                                i.pt_disc = (i.pt_disc_type == "Fixed") ? i.pt_disc_value : ((i.pt_total > 0) ? ((i.pt_total * 100) / i.pt_disc_value) : 0);
                            }

                            i.pt_coupon = r["pt_coupon"].ToString();
                            i.pt_coupon_value = r["pt_coupon"].ToString();
                            i.pt_coupon_disc = decimal.Parse(r["pt_coupon_disc"].ToString());
                            i.pt_net = decimal.Parse(r["pt_net"].ToString());
                            i.pt_vat = decimal.Parse(r["pt_vat"].ToString());
                            i.pt_netvat = i.pt_net + i.pt_vat;
                            i.pt_coupon_value = r["pt_coupon"].ToString();
                            i.pt_package = int.Parse(r["pt_package"].ToString());
                            list.Add(i);
                        }
                    }
                }
            }

            qc.qc_invoice_info = info;
            qc.qc_invoice_items = list;

            return qc;
        }

        public static List<CommonDDL> GetQC_Treatments(string query, string appId)
        {
            DataTable dt = DataAccessLayer.Invoice.QuickCash.GetQC_Treatments(query, appId);

            List<CommonDDL> list = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL info = new CommonDDL();
                    info.id = int.Parse(dr["trId"].ToString());

                    //if (dr["type"].ToString().ToLower() == "package")
                    //{
                    //    info.text = "<span class='text-primary me-2'>" + dr["tr_code"].ToString() + " - </span> " +
                    //                "<span class='text-info me-2'>" + dr["tr_name"].ToString() + " - </span> " +
                    //                "<span class='text-danger me-2'> AED " + decimal.Parse(dr["tr_price"].ToString()).ToString("N2") + "</span>" +
                    //                "<span class='badge bg-danger'> (**PACKAGE**) </span>";
                    //}
                    //else
                    //{
                    info.text = "<span class='text-primary me-2'>" + dr["tr_code"].ToString() + " - </span> " +
                                "<span class='text-info me-2'>" + dr["tr_name"].ToString() + " - </span> " +
                                "<span class='text-danger'> AED " + decimal.Parse(dr["tr_price"].ToString()).ToString("N2") + "</span>";
                    //}


                    list.Add(info);
                }
            }
            return list;
        }

        public static List<CommonDDL> GetQC_TreatmentsEdit(int trId, string appId)
        {
            DataTable dt = DataAccessLayer.Invoice.QuickCash.GetQC_TreatmentsEdit(trId, appId);

            List<CommonDDL> list = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL info = new CommonDDL();
                    info.id = int.Parse(dr["trId"].ToString());

                    if (dr["type"].ToString().ToLower() == "package")
                    {
                        info.text = "<span class='text-primary me-2'>" + dr["tr_code"].ToString() + " - </span> " +
                                    "<span class='text-info me-2'>" + dr["tr_name"].ToString() + " - </span> " +
                                    "<span class='text-danger me-2'> AED " + decimal.Parse(dr["tr_price"].ToString()).ToString("N2") + "</span>" +
                                    "<span class='badge bg-danger'> PACKAGE </span>";
                    }
                    else
                    {
                        info.text = "<span class='text-primary me-2'>" + dr["tr_code"].ToString() + " - </span> " +
                                    "<span class='text-info me-2'>" + dr["tr_name"].ToString() + " - </span> " +
                                    "<span class='text-danger'> AED " + decimal.Parse(dr["tr_price"].ToString()).ToString("N2") + "</span>";
                    }


                    list.Add(info);
                }
            }
            return list;
        }

        public static QC_TreatmentSelection GetQC_TreatmentValues(int trId, int appId, int isPackage)
        {
            QC_TreatmentSelection qc = new QC_TreatmentSelection();
            DataSet ds = DataAccessLayer.Invoice.QuickCash.GetQC_TreatmentValues(trId, appId, isPackage);

            QC_TreatmentValues values = new QC_TreatmentValues();
            List<QC_Coupon> coupons = new List<QC_Coupon>();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    values.trId = int.Parse(dr["trId"].ToString());
                    values.tr_code = dr["tr_code"].ToString();
                    values.tr_name = dr["tr_name"].ToString();
                    values.tr_price = decimal.Parse(dr["tr_price"].ToString());
                    values.tr_disc = decimal.Parse(dr["tr_disc"].ToString());
                    values.tr_disc_type = dr["tr_disc_type"].ToString();
                    values.tr_vat = decimal.Parse(dr["tr_vat"].ToString());
                    values.tr_vat2 = decimal.Parse(dr["tr_vat2"].ToString());
                    values.tr_category = dr["tr_category"].ToString();
                    values.tr_tooth = dr["tr_tooth"].ToString();
                    values.tr_notes = dr["tr_notes"].ToString();
                }

                if (isPackage == 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            QC_Coupon coupon = new QC_Coupon();
                            coupon.discId = int.Parse(dr["discId"].ToString());
                            coupon.disc_name = dr["disc_name"].ToString();
                            coupon.disc_float = decimal.Parse(dr["disc_float"].ToString());
                            coupons.Add(coupon);
                        }
                    }
                }
            }

            qc.tr_values = values;
            qc.tr_coupons = coupons;

            return qc;
        }

        public static int Generate_QCInvoice(BusinessEntities.Invoice.QC_Invoice inv, int madeby, int multi_bill, out string inv_no)
        {
            return DataAccessLayer.Invoice.QuickCash.Generate_QCInvoice(inv, madeby, multi_bill, out inv_no);
        }

        public static int Generate_QCInvoiceWithPackage(BusinessEntities.Invoice.QC_Invoice inv, int madeby, out string inv_no)
        {
            return DataAccessLayer.Invoice.QuickCash.Generate_QCInvoiceWithPackage(inv, madeby, out inv_no);

        }

        public static int Update_QCInvoice(BusinessEntities.Invoice.QC_Invoice inv, int madeby, out string inv_no)
        {
            return DataAccessLayer.Invoice.QuickCash.Update_QCInvoice(inv, madeby, out inv_no);

        }

        public static List<BusinessEntities.Invoice.InvoiceServices> GetInvoicesTreatments(int ptId, int appId)
        {

            List<BusinessEntities.Invoice.InvoiceServices> sclist = new List<BusinessEntities.Invoice.InvoiceServices>();
            DataTable dt = DataAccessLayer.Invoice.QuickCash.GetInvoicesTreatments(ptId, appId);
             
            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.Invoice.InvoiceServices
                {
                    ptId = int.Parse(dr["ptId"].ToString()),
                    pt_treatment = int.Parse(dr["pt_treatment"].ToString()),
                    pt_tr_code = dr["pt_tr_code"].ToString(),
                    pt_tr_name = dr["pt_tr_name"].ToString(),
                    pt_tr_type = dr["pt_tr_type"].ToString(),
                    pt_barcode = int.Parse(dr["pt_barcode"].ToString()),
                    pt_uprice = decimal.Parse(dr["pt_uprice"].ToString()),
                    pt_qty = decimal.Parse(dr["pt_qty"].ToString()),
                    pt_ses = decimal.Parse(dr["pt_ses"].ToString()),
                    pt_total = decimal.Parse(dr["pt_total"].ToString()),
                    pt_net = decimal.Parse(dr["pt_net"].ToString()),
                    pt_disc = decimal.Parse(dr["pt_disc"].ToString()),
                    pt_pdisc = decimal.Parse(dr["pt_pdisc"].ToString()),
                    pt_vat = decimal.Parse(dr["pt_vat"].ToString()),
                    pt_vat2 = decimal.Parse(dr["pt_vat2"].ToString()),
                    pt_status = dr["pt_status"].ToString(),
                    pt_lab_status = dr["pt_lab_status"].ToString(),
                    pt_comments = dr["pt_comments"].ToString(),
                    pt_notes = dr["pt_notes"].ToString(),


                });
            }
            return sclist;
        }


        public static BusinessEntities.Invoice.QuickCash GetQCM_InvoiceInfoByappId(int appId)
        {
            DataTable dt = DataAccessLayer.Invoice.QuickCash.GetQCM_InvoiceInfoByappId(appId);

            BusinessEntities.Invoice.QuickCash qc = new BusinessEntities.Invoice.QuickCash();

            List<BusinessEntities.Invoice.QC_InvoiceItems> list = new List<BusinessEntities.Invoice.QC_InvoiceItems>();
            List<BusinessEntities.Invoice.QC_InvoiceInfo> info = new List<BusinessEntities.Invoice.QC_InvoiceInfo>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BusinessEntities.Invoice.QC_InvoiceInfo j = new BusinessEntities.Invoice.QC_InvoiceInfo();
                    DateTime _dt = DateTime.Parse("1900-01-01");
                    DateTime.TryParse(dr["id_card_edate"].ToString(), out _dt);

                    j.invId = int.Parse(dr["invId"].ToString()); ;
                    j.appId = int.Parse(dr["appId"].ToString());
                    j.app_fdate = DateTime.Parse(dr["app_fdate"].ToString());
                    j.inv_no = dr["inv_no"].ToString();
                    j.inv_notes = dr["inv_notes"].ToString();
                    j.inv_date = DateTime.Parse(dr["inv_date"].ToString());
                    j.patId = int.Parse(dr["patId"].ToString());
                    j.pat_code = dr["pat_code"].ToString();
                    j.pat_name = dr["pat_name"].ToString();
                    j.pat_emirateid = dr["pat_emirateid"].ToString();
                    j.id_card_edate = _dt;
                    j.emp_name = dr["emp_name"].ToString();
                    j.emp_license = dr["emp_license"].ToString();
                    j.emp_dept_name = dr["emp_dept_name"].ToString();
                    info.Add(j);
                }

                if (appId > 0)
                {
                    DataTable dt_list = DataAccessLayer.Invoice.Invoice.GetServicesByInvoicesappId(appId, 1);

                    foreach (DataRow r in dt_list.Rows)
                    {
                        if (r["pt_status"].ToString() != "Deleted")
                        {
                            BusinessEntities.Invoice.QC_InvoiceItems i = new BusinessEntities.Invoice.QC_InvoiceItems();
                            i.ptId = int.Parse(r["ptId"].ToString());
                            i.pt_treatment = int.Parse(r["pt_treatment"].ToString());
                            i.pt_mode = "edit";
                            i.pt_tr_code = r["pt_tr_code"].ToString();
                            i.pt_tr_name = r["pt_tr_name"].ToString();
                            i.pt_vat_type = r["pt_tr_type"].ToString();
                            i.pt_qty = decimal.Parse(r["pt_qty"].ToString());
                            i.pt_ses = decimal.Parse(r["pt_ses"].ToString());
                            i.pt_teeth = r["PT_TEETH"].ToString();
                            i.pt_sur = r["PT_SUR"].ToString();
                            i.pt_uprice = decimal.Parse(r["pt_uprice"].ToString());
                            i.pt_total = decimal.Parse(r["pt_total"].ToString());
                            i.pt_disc_type = string.IsNullOrEmpty(r["pt_barcode"].ToString()) ? "%" : (r["pt_barcode"].ToString() == "1" ? "Fixed" : "%");
                            i.pt_disc_value = decimal.Parse(r["pt_disc"].ToString());

                            if (i.pt_disc_value == 0)
                            {
                                i.pt_disc = (i.pt_disc_type == "Fixed") ? i.pt_disc_value : ((i.pt_total > 0) ? ((i.pt_total * 100)) : 0);
                            }
                            else
                            {
                                i.pt_disc = (i.pt_disc_type == "Fixed") ? i.pt_disc_value : ((i.pt_total > 0) ? ((i.pt_total * 100) / i.pt_disc_value) : 0);
                            }

                            i.pt_coupon = r["pt_coupon"].ToString();
                            i.pt_coupon_value = r["pt_coupon"].ToString();
                            i.pt_coupon_disc = decimal.Parse(r["pt_coupon_disc"].ToString());
                            i.pt_net = decimal.Parse(r["pt_net"].ToString());
                            i.pt_vat = decimal.Parse(r["pt_vat"].ToString());
                            i.pt_netvat = i.pt_net + i.pt_vat;
                            i.pt_coupon_value = r["pt_coupon"].ToString();
                            i.pt_package = int.Parse(r["pt_package"].ToString());
                            list.Add(i);
                        }
                    }
                }
            }

            qc.qc_invoices = info;
            qc.qc_invoice_items = list;

            return qc;
        }
    }
}