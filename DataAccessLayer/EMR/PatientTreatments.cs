using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Invoice;
using BusinessEntities.EMR;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;
using BusinessEntities.Accounts.MaterialManagement;
using System.Data.SqlClient;

namespace DataAccessLayer.EMR
{
    public class PatientTreatments
    {
        #region Patient Treatments 
        public static DataTable GetAllPatientTreatments(int? appId, int? ptId, string pt_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Treatments_Select_All_Info");

                if (ptId > 0)
                {
                    db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }

                db.AddInParameter(dbCommand, "pt_type", DbType.String, pt_type);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPatientTreatments(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Treatments_Select_All_Info2");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAllPrePatientTreatments(int appId, int patId, string pt_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Treatments_Previous");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pt_type", DbType.String, pt_type);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Get_InvoiceInfo(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInvoiceInfo");

                db.AddInParameter(dbCommand, "appId", DbType.String, appId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable Get_InvoiceInfoByInvId(int invId,int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetEditSubInvoiceInfoByInvId");

                db.AddInParameter(dbCommand, "invId", DbType.String, invId);
                db.AddInParameter(dbCommand, "appId", DbType.String, appId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet PrintTreatments(string ptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_TreatmentQuotation_Print");

                db.AddInParameter(dbCommand, "ptId", DbType.String, ptId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertPatientTreatments(BusinessEntities.EMR.Cash_Treatments data, int madeby, out int ptId)
        {
            int count = 0;
            ptId = 0;
            int val = 0;
            bool is_allowed = false;

            List<Cash_PatientTreat> list = data.treatment_items;

            // Patient Treatments
            foreach (Cash_PatientTreat i in list)
            {
                if (i.isPackage == 1)
                {
                    DataTable dt = DataAccessLayer.Masters.TreatmentGroups.GetPackages(i.ptId);
                    int index = 0;

                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();

                        treatment.pt_appId = int.Parse(i.pt_appId.ToString());
                        treatment.pt_treatment = int.Parse(dr["trId"].ToString());
                        treatment.pt_qty = decimal.Parse(i.pt_qty.ToString());
                        treatment.pt_notes = string.Empty;
                        treatment.pt_type = i.pt_type;
                        treatment.pt_comments = i.pt_comments;
                        treatment.pt_teeth = "";
                        treatment.pt_sur = "";
                        treatment.pt_auth_code = "";
                        treatment.pt_ses = int.Parse(i.pt_ses.ToString());
                        treatment.pt_treat_type = 3;
                        treatment.pt_uprice = (index == 0) ? i.pt_uprice : 0;
                        treatment.pt_total = (index == 0) ? i.pt_total : 0;
                        treatment.pt_disc = (index == 0) ? i.pt_disc_value : 0;
                        treatment.pt_ded = 0;
                        treatment.pt_copay = 0;
                        treatment.pt_net = (index == 0) ? i.pt_net : 0;
                        treatment.pt_vat = (index == 0) ? i.pt_vat : 0;
                        treatment.pt_dcopay = 0;
                        treatment.pt_barcode = string.IsNullOrEmpty(i.pt_disc_type.ToString()) ? "0" : (i.pt_disc_type.ToString() == "Fixed" ? "1" : "0");
                        treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                        treatment.pt_auth_edate = DateTime.Parse("01/01/2100");
                        treatment.pt_share = 0;
                        treatment.pt_insurance = 1;
                        treatment.pt_dded = treatment.pt_dded;
                        treatment.pt_lded = 0;
                        treatment.pt_rded = 0;
                        treatment.pt_mded = 0;
                        treatment.pt_pded = 0;
                        treatment.pt_sded = 0;
                        treatment.pt_ceiling = 0;
                        treatment.pt_vat_type = i.pt_vat_type;
                        treatment.pt_pdisc = (index == 0) ? i.pt_disc : 0;
                        treatment.pt_coupon = (index == 0) ? (string.IsNullOrEmpty(i.pt_coupon_value) ? "" : i.pt_coupon_value.ToString()) : "";
                        treatment.pt_coupon_disc = (index == 0) ? i.pt_coupon_disc : 0;

                        val = DataAccessLayer.Patient.Treatments.PatientTreatment.CreatePatientTreatments(treatment, madeby);

                        if (val > 0)
                        {
                            DataAccessLayer.Patient.Treatments.PatientTreatment.PatientTreatmentGroupInsert(val, treatment.pt_treatment, i.ptId, treatment.pt_appId, "Active", madeby);
                            count++;
                        }

                        index++;
                    }
                }
                else
                {
                    BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();
                    int appId = int.Parse(i.pt_appId.ToString());
                    int pt_appId = int.Parse(i.pt_appId.ToString());

                    if (i.pt_type == "Insurance")
                    {
                        DataTable dti = DataAccessLayer.EMR.PatientTreatments.GetInsuranceDeduction(pt_appId);
                        float PT__NET = 0;
                        float Totalvalue = GET_TOTAL(appId);
                        PT__NET = Totalvalue + float.Parse(i.pt_net.ToString());
                        if (PT__NET <= float.Parse(dti.Rows[0]["is_allowed_limit"].ToString()))
                        {
                            is_allowed = true;
                        }
                        else
                        {
                            is_allowed = false;
                            val = -5;
                        }
                        float ic_discount = float.Parse((dti.Rows[0]["ic_discount"]).ToString());
                        float ic_credit = float.Parse((dti.Rows[0]["ic_credit"]).ToString());
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

                        tr__disc = float.Parse(i.pt_disc.ToString());//TREAT_DISC(pt_treatment);
                        string tr__type = DataAccessLayer.EMR.PatientTreatments.Treat_Type(i.ptId);
                        if (tr__type.Contains("Consultation") == true)
                        {
                            pt__uprice = float.Parse(i.pt_uprice.ToString()) * ic_discount;
                        }
                        else
                        {
                            pt__uprice = float.Parse(i.pt_uprice.ToString()) * ic_credit;
                        }
                        pt__total = int.Parse(i.pt_qty.ToString()) * pt__uprice;
                        pt__disc = 0;


                        pt__disc = tr__disc;

                        if ((tr__type == "General Consultation") && (pt__uprice > 0))
                        {
                            if (dti.Rows[0]["pi_cded"].ToString() != "0")
                            {
                                if (dti.Rows[0]["pi_cded_type"].ToString() == "Fixed")
                                {
                                    pt__ded = float.Parse(dti.Rows[0]["pi_cded"].ToString());
                                }
                                else
                                {
                                    pt__ded = ((pt__total - pt__disc) * float.Parse(dti.Rows[0]["pi_cded"].ToString())) / 100;

                                }
                            }
                        }



                        if ((tr__type == "Specialist Consultation") && (pt__uprice > 0))
                        {
                            if (dti.Rows[0]["pi_ip_dcopay"].ToString() != "0")
                            {
                                if (dti.Rows[0]["pi_ip_dcopay_type"].ToString() == "Fixed")
                                {
                                    pt__ded = float.Parse((dti.Rows[0]["pi_ip_dcopay"]).ToString());
                                }
                                else
                                {
                                    pt__ded = ((pt__total - pt__disc) * float.Parse(dti.Rows[0]["pi_ip_dcopay"].ToString())) / 100;

                                }
                            }
                        }

                        if ((pt__total - pt__disc) <= pt__ded)
                        {
                            pt__ded = (pt__total - pt__disc);
                        }



                        if ((float.Parse(dti.Rows[0]["pi_cded_limit"].ToString()) > 0) && (float.Parse(dti.Rows[0]["pi_cded_limit"].ToString()) < pt__ded))
                        {
                            pt__ded = float.Parse(dti.Rows[0]["pi_cded_limit"].ToString());
                        }



                        if ((tr__type == "Dental Consultation") && (pt__uprice > 0))
                        {
                            if (dti.Rows[0]["pi_dded"].ToString() != "0")
                            {
                                if (dti.Rows[0]["pi_dded_type"].ToString() == "Fixed")
                                {
                                    pt__dded = float.Parse(dti.Rows[0]["pi_dded"].ToString());
                                }
                                else
                                {
                                    pt__dded = (pt__total - pt__disc) * float.Parse(dti.Rows[0]["pi_dded"].ToString()) / 100;
                                }
                            }
                        }

                        if ((pt__total - pt__disc) <= pt__dded)
                        {
                            pt__dded = (pt__total - pt__disc);
                        }



                        if ((float.Parse(dti.Rows[0]["pi_dded_limit"].ToString()) > 0) && (float.Parse(dti.Rows[0]["pi_dded_limit"].ToString()) < pt__dded))
                        {
                            pt__dded = float.Parse(dti.Rows[0]["pi_dded_limit"].ToString());
                        }


                        float pi_ided_limit_bal = calc_bal(appId);
                        if ((tr__type == "Lab") && (pt__uprice > 0))
                        {
                            if (float.Parse(dti.Rows[0]["pi_ided"].ToString()) > 0)
                            {

                                if (dti.Rows[0]["pi_ided_type"].ToString() == "Fixed")
                                {
                                    pt__lded = float.Parse(dti.Rows[0]["pi_ided"].ToString());
                                }
                                else
                                {
                                    pt__lded = ((pt__total - pt__disc) * float.Parse(dti.Rows[0]["pi_ided"].ToString())) / 100;

                                    if (pi_ided_limit_bal > 0 && pi_ided_limit_bal < pt__lded)
                                    {
                                        pt__lded = pi_ided_limit_bal;
                                    }
                                    else if (pi_ided_limit_bal < 0)
                                    {
                                        pt__lded = 0;
                                    }

                                }

                            }
                        }

                        if ((pt__total - pt__disc) <= pt__lded)
                        {
                            pt__lded = (pt__total - pt__disc);
                        }

                        if ((float.Parse(dti.Rows[0]["pi_ided_limit"].ToString()) > 0) && (float.Parse(dti.Rows[0]["pi_ided_limit"].ToString()) < pt__lded))
                        {
                            pt__lded = (float.Parse(dti.Rows[0]["pi_ided_limit"].ToString()));
                        }



                        if ((tr__type == "Radiology") && (pt__uprice > 0))
                        {
                            if (float.Parse(dti.Rows[0]["pi_rded"].ToString()) > 0)
                            {

                                if (dti.Rows[0]["pi_rded_type"].ToString() == "Fixed")
                                {
                                    pt__rded = float.Parse(dti.Rows[0]["pi_rded"].ToString());
                                }
                                else
                                {
                                    pt__rded = ((pt__total - pt__disc) * float.Parse(dti.Rows[0]["pi_rded"].ToString())) / 100;
                                }
                            }
                        }

                        if ((pt__total - pt__disc) <= pt__rded)
                        {
                            pt__rded = (pt__total - pt__disc);
                        }

                        if ((float.Parse(dti.Rows[0]["pi_rded_limit"].ToString()) > 0) && (float.Parse(dti.Rows[0]["pi_rded_limit"].ToString()) < pt__rded))
                        {
                            pt__rded = float.Parse(dti.Rows[0]["pi_rded_limit"].ToString());
                        }

                        if ((tr__type == "Maternity") && (pt__uprice > 0))
                        {
                            if (float.Parse(dti.Rows[0]["pi_mded"].ToString()) > 0)
                            {
                                if (dti.Rows[0]["pi_mded_type"].ToString() == "Fixed")
                                {

                                    pt__mded = float.Parse(dti.Rows[0]["pi_mded"].ToString());

                                }
                                else
                                {
                                    pt__mded = ((pt__total - pt__disc) * float.Parse(dti.Rows[0]["pi_mded"].ToString())) / 100;
                                }
                            }
                        }

                        if ((pt__total - pt__disc) <= pt__mded)
                        {
                            pt__mded = (pt__total - pt__disc);
                        }

                        if ((float.Parse(dti.Rows[0]["pi_mded_limit"].ToString()) > 0) && (float.Parse(dti.Rows[0]["pi_mded_limit"].ToString()) < pt__mded))
                        {
                            pt__mded = float.Parse(dti.Rows[0]["pi_mded_limit"].ToString());
                        }

                        if ((tr__type == "Pharmacy") && (pt__uprice > 0))
                        {
                            if (float.Parse(dti.Rows[0]["pi_pded"].ToString()) > 0)
                            {
                                if (dti.Rows[0]["pi_pded_type"].ToString() == "Fixed")
                                {
                                    pt__copay = float.Parse(dti.Rows[0]["pi_pded"].ToString());
                                }
                                else
                                {
                                    pt__copay = ((pt__total - pt__disc) * float.Parse(dti.Rows[0]["pi_pded"].ToString())) / 100;
                                }
                            }
                        }

                        if ((pt__total - pt__disc) <= pt__copay)
                        {
                            pt__copay = (pt__total - pt__disc);
                        }

                        if ((float.Parse(dti.Rows[0]["pi_pded_limit"].ToString()) > 0) && (float.Parse(dti.Rows[0]["pi_pded_limit"].ToString()) < pt__copay))
                        {
                            pt__copay = float.Parse(dti.Rows[0]["pi_pded_limit"].ToString());
                        }



                        float pi_copay_limit_bal = calc_bal2(appId);

                        if ((tr__type == "Co.Pay") && (pt__uprice > 0))
                        {
                            if (float.Parse(dti.Rows[0]["pi_copay"].ToString()) > 0)
                            {

                                if (dti.Rows[0]["pi_copay_type"].ToString() == "Fixed")
                                {
                                    pt__copay = float.Parse(dti.Rows[0]["pi_copay"].ToString());
                                }
                                else
                                {

                                    pt__copay = ((pt__total - pt__disc) * float.Parse(dti.Rows[0]["pi_copay"].ToString())) / 100;

                                    if (pi_copay_limit_bal > 0 && pi_copay_limit_bal < pt__copay)
                                    {
                                        pt__copay = pi_copay_limit_bal;
                                    }
                                    else if (pi_copay_limit_bal < 0)
                                    {
                                        pt__copay = 0;
                                    }
                                }

                            }
                        }

                        if ((pt__total - pt__disc) <= pt__copay)
                        {
                            pt__copay = (pt__total - pt__disc);
                        }

                        if ((float.Parse(dti.Rows[0]["pi_copay_limit"].ToString()) > 0) && (float.Parse(dti.Rows[0]["pi_copay_limit"].ToString()) < pt__copay))
                        {
                            pt__copay = float.Parse(dti.Rows[0]["pi_copay_limit"].ToString());
                        }

                        if ((tr__type == "Dental Co.Pay") && (pt__uprice > 0))
                        {
                            if (dti.Rows[0]["pi_dcopay"].ToString() != "0")
                            {
                                if (dti.Rows[0]["pi_dcopay_type"].ToString() == "Fixed")
                                {
                                    pt__dcopay = float.Parse(dti.Rows[0]["pi_dcopay"].ToString());
                                }
                                else
                                {
                                    pt__dcopay = ((pt__total - pt__disc) * float.Parse(dti.Rows[0]["pi_dcopay"].ToString())) / 100;
                                }
                            }
                            else if (dti.Rows[0]["pi_hdcopay"].ToString() != "0")
                            {
                                if (dti.Rows[0]["pi_hdcopay_type"].ToString() == "Fixed")
                                {
                                    pt__dcopay = float.Parse(dti.Rows[0]["pi_hdcopay"].ToString());
                                }
                                else
                                {
                                    pt__dcopay = ((pt__total - pt__disc) * float.Parse(dti.Rows[0]["pi_hdcopay"].ToString())) / 100;
                                }
                            }
                        }

                        if ((pt__total - pt__disc) <= pt__dcopay)
                        {
                            pt__dcopay = (pt__total - pt__disc);
                        }

                        if ((float.Parse(dti.Rows[0]["pi_dcopay_limit"].ToString()) > 0) && (float.Parse(dti.Rows[0]["pi_dcopay_limit"].ToString()) < pt__dcopay))
                        {
                            pt__dcopay = float.Parse(dti.Rows[0]["pi_dcopay_limit"].ToString());
                        }


                        pt__net = pt__total - pt__disc - pt__ded - pt__dded - pt__lded - pt__rded - pt__mded - pt__copay - pt__dcopay;

                        if (is_allowed)
                        {
                            treatment.pt_appId = int.Parse(i.pt_appId.ToString());
                            treatment.pt_treatment = i.ptId;
                            treatment.pt_qty = decimal.Parse(i.pt_qty.ToString());
                            treatment.pt_notes = i.pt_notes;
                            treatment.pt_comments = string.IsNullOrEmpty(i.pt_comments) ? string.Empty : i.pt_comments;
                            treatment.pt_type = i.pt_type;
                            treatment.pt_teeth = i.pt_teeth;
                            treatment.pt_sur = i.pt_sur;
                            treatment.pt_auth_code = "";
                            treatment.pt_ses = int.Parse(i.pt_ses.ToString());
                            treatment.pt_treat_type = 0;
                            treatment.pt_uprice = decimal.Parse(pt__uprice.ToString());
                            treatment.pt_total = decimal.Parse(pt__total.ToString());
                            treatment.pt_disc = i.pt_disc_value;
                            treatment.pt_ded = decimal.Parse(pt__ded.ToString());
                            treatment.pt_copay = decimal.Parse(pt__copay.ToString());
                            treatment.pt_net = decimal.Parse(pt__net.ToString());
                            treatment.pt_vat = i.pt_vat;
                            treatment.pt_dcopay = decimal.Parse(pt__dcopay.ToString());
                            treatment.pt_barcode = string.IsNullOrEmpty(i.pt_disc_type.ToString()) ? "0" : (i.pt_disc_type.ToString() == "Fixed" ? "1" : "0");
                            treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                            treatment.pt_auth_edate = DateTime.Parse("01/01/2100");
                            treatment.pt_share = 0;
                            treatment.pt_insurance = 0;
                            treatment.pt_insurance = int.Parse(dti.Rows[0]["icId"].ToString());
                            treatment.pt_dded = decimal.Parse(pt__ded.ToString());
                            treatment.pt_lded = decimal.Parse(pt__lded.ToString());
                            treatment.pt_rded = decimal.Parse(pt__rded.ToString());
                            treatment.pt_mded = decimal.Parse(pt__mded.ToString());
                            treatment.pt_ceiling = 0;
                            treatment.pt_vat_type = i.pt_vat_type;
                            treatment.pt_pdisc = decimal.Parse(pt__disc.ToString());
                            treatment.pt_coupon = string.IsNullOrEmpty(i.pt_coupon_value) ? "" : i.pt_coupon_value.ToString();
                            treatment.pt_coupon_disc = i.pt_coupon_disc;

                            val = DataAccessLayer.Patient.Treatments.PatientTreatment.CreatePatientTreatments(treatment, madeby);

                            if (val > 0)
                            {
                                count++;
                            }
                        }
                    }
                    else
                    {
                        treatment.pt_dded = 0;
                        treatment.pt_appId = int.Parse(i.pt_appId.ToString());
                        treatment.pt_treatment = i.ptId;
                        treatment.pt_qty = decimal.Parse(i.pt_qty.ToString());
                        treatment.pt_notes = string.IsNullOrEmpty(i.pt_notes) ? string.Empty : i.pt_notes;
                        treatment.pt_comments = string.IsNullOrEmpty(i.pt_comments) ? string.Empty : i.pt_comments;
                        treatment.pt_type = i.pt_type;
                        treatment.pt_teeth = string.IsNullOrEmpty(i.pt_teeth) ? string.Empty : i.pt_teeth;
                        treatment.pt_sur = string.IsNullOrEmpty(i.pt_sur) ? string.Empty : i.pt_sur;
                        treatment.pt_auth_code = string.Empty;
                        treatment.pt_ses = int.Parse(i.pt_ses.ToString());
                        treatment.pt_treat_type = 3;
                        treatment.pt_uprice = i.pt_uprice;
                        treatment.pt_total = i.pt_total;
                        treatment.pt_disc = i.pt_disc_value;
                        treatment.pt_ded = 0;
                        treatment.pt_copay = 0;
                        treatment.pt_net = i.pt_net;
                        treatment.pt_vat = i.pt_vat;
                        treatment.pt_dcopay = 0;
                        treatment.pt_barcode = string.IsNullOrEmpty(i.pt_disc_type.ToString()) ? "0" : (i.pt_disc_type.ToString() == "Fixed" ? "1" : "0");
                        treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                        treatment.pt_auth_edate = DateTime.Parse("01/01/2100");
                        treatment.pt_share = 0;
                        treatment.pt_insurance = 1;
                        treatment.pt_dded = 0;
                        treatment.pt_lded = 0;
                        treatment.pt_rded = 0;
                        treatment.pt_mded = 0;
                        treatment.pt_pded = 0;
                        treatment.pt_sded = 0;
                        treatment.pt_ceiling = 0;
                        treatment.pt_vat_type = i.pt_vat_type;
                        treatment.pt_pdisc = i.pt_disc;
                        treatment.pt_coupon = string.IsNullOrEmpty(i.pt_coupon_value) ? "" : i.pt_coupon_value.ToString();
                        treatment.pt_coupon_disc = i.pt_coupon_disc;

                        val = DataAccessLayer.Patient.Treatments.PatientTreatment.CreatePatientTreatments(treatment, madeby);

                        if (val > 0)
                        {
                            count++;
                        }
                    }
                }
            }

            return val;
        }

        public static int UpdatePatientTreatments(BusinessEntities.EMR.Cash_PatientTreat data, int madeby, out int ptId)
        {
            int count = 0;
            ptId = 0;

            BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();
            treatment.ptId = data.ptId;
            treatment.pt_treatment = data.pt_treatment;

            treatment.pt_type = data.pt_type;
            treatment.pt_ses = int.Parse(data.pt_ses.ToString());
            treatment.pt_qty = int.Parse(data.pt_qty.ToString());
            treatment.pt_uprice = data.pt_uprice;
            treatment.pt_total = data.pt_total;
            treatment.pt_disc = data.pt_disc_value;
            treatment.pt_ded = 0;
            treatment.pt_copay = 0;
            treatment.pt_net = data.pt_net;
            treatment.pt_dcopay = 0;
            treatment.pt_share = 0;
            treatment.pt_vat = data.pt_vat;
            treatment.pt_insurance = 1;
            treatment.pt_sur = string.IsNullOrEmpty(data.pt_sur) ? string.Empty : data.pt_sur;
            treatment.pt_teeth = string.IsNullOrEmpty(data.pt_teeth) ? string.Empty : data.pt_teeth;

            int val = DataAccessLayer.Patient.Treatments.PatientTreatment.UpdatePatientTreatments(treatment, madeby);

            if (val > 0)
            {
                count++;
            }

            return val;
        }

        public static float calc_bal(int appId)
        {
            float pi_ided_limit_bal = 0;
            DataTable dt3 = DataAccessLayer.EMR.PatientTreatments.calc_bal_edit(appId, 0, "Lab");

            if (dt3.Rows.Count > 0)
            {
                pi_ided_limit_bal = float.Parse(dt3.Rows[0]["pi_ided_limit"].ToString()) - float.Parse(dt3.Rows[0]["pt_lded"].ToString());

                if (float.Parse(dt3.Rows[0]["pi_ided_limit"].ToString()) > 0 && pi_ided_limit_bal > 0)
                {
                    return pi_ided_limit_bal;
                }
                else if (float.Parse(dt3.Rows[0]["pi_ided_limit"].ToString()) > 0 && pi_ided_limit_bal == 0)
                {
                    return -1;
                }
                else if (float.Parse(dt3.Rows[0]["pi_ided_limit"].ToString()) == 0)
                {
                    return 0;
                }
                else if (float.Parse(dt3.Rows[0]["pi_ided_limit"].ToString()) > 0 && pi_ided_limit_bal < 0)
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
                pi_ided_limit_bal = -2;
                return pi_ided_limit_bal;
            }

        }

        public static float calc_bal2(int appId)
        {
            float pi_copay_limit_bal = 0;
            DataTable dt3 = calc_bal_edit(appId, 0, "Co.Pay");

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

        public static float GET_TOTAL(int appId)
        {
            DataTable dt3 = GET_PTTOTAL(appId);

            if (dt3.Rows.Count > 0)
            {

                return float.Parse(dt3.Rows[0]["TOTAL"].ToString());

            }
            else
            {
                return 0;
            }

        }

        public static int GenerateInvoice(BusinessEntities.Invoice.InvoiceNew inv, out string inv_no, int? multi_bill=0)
        {
            // Invoice
            int invId = DataAccessLayer.Invoice.Invoice.GenerateInvoice(inv,out inv_no, multi_bill);

            // Invoice Patient Treatments
            if (invId > 0)
            {
                //foreach (var ptId in ptIds)
                //{
                //    val += DataAccessLayer.EMR.PatientTreatments.UpdateInsurancePatientTreatmentStatus(ptId, inv.inv_appId, inv_no, inv.inv_insurance);
                //}
                int ptId = DataAccessLayer.Patient.Treatments.PatientTreatment.UpdatePatientTreatmentStatus(inv.ptId, inv.inv_appId, inv_no, invId);
            }

            return invId;
        }

        public static int CreatePackage(int ptId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_RUNNING_PACKAGE_insert");
                db.AddInParameter(dbCommand, "ccdt_ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "ccdt_madeby", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdatePatientTreatmentStatus(int ptId, string pt_status, string pt_notes)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_TREATMENTS_update_status2");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "pt_status", DbType.String, pt_status);
                db.AddInParameter(dbCommand, "pt_notes", DbType.String, pt_notes);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Patient Treatments Plan
        public static DataTable GetAllPatientTreatmentsPlan(int? appId, int? ptId, string pt_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Treatments_plan_Select_All_Info");
                if (ptId > 0)
                {
                    db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                db.AddInParameter(dbCommand, "pt_type", DbType.String, pt_type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insurance Treatments CRUD Operations
        public static DataTable GetInsuranceTreatments(string query, string appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTreatmentForInsurance");

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "appId", DbType.String, int.Parse(appId));

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int CreateInsurancePatientTreatments(BusinessEntities.Patient.Treatments.PatientTreatment treatment, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Treatments_Insurance_Insert");
                db.AddInParameter(dbCommand, "pt_appId", DbType.Int32, treatment.pt_appId);
                db.AddInParameter(dbCommand, "pt_treatment", DbType.Int32, treatment.pt_treatment);
                db.AddInParameter(dbCommand, "pt_qty", DbType.Decimal, treatment.pt_qty);
                db.AddInParameter(dbCommand, "pt_notes", DbType.String, treatment.pt_notes);
                db.AddInParameter(dbCommand, "pt_comments", DbType.String, treatment.pt_comments);
                db.AddInParameter(dbCommand, "pt_type", DbType.String, treatment.pt_type);
                db.AddInParameter(dbCommand, "PT_teeth", DbType.String, treatment.pt_teeth);
                db.AddInParameter(dbCommand, "pt_sur", DbType.String, treatment.pt_sur);
                db.AddInParameter(dbCommand, "pt_auth_code", DbType.String, treatment.pt_auth_code);
                db.AddInParameter(dbCommand, "pt_ses", DbType.Int32, treatment.pt_ses);
                db.AddInParameter(dbCommand, "pt_treat_type", DbType.Int32, treatment.pt_treat_type);
                db.AddInParameter(dbCommand, "pt_uprice", DbType.Decimal, treatment.pt_uprice);
                db.AddInParameter(dbCommand, "pt_total", DbType.Decimal, treatment.pt_total);
                db.AddInParameter(dbCommand, "pt_disc", DbType.Decimal, treatment.pt_disc);
                db.AddInParameter(dbCommand, "pt_net", DbType.Decimal, treatment.pt_net);
                db.AddInParameter(dbCommand, "pt_vat", DbType.Decimal, treatment.pt_vat);
                db.AddInParameter(dbCommand, "pt_barcode", DbType.Int32, treatment.pt_barcode);
                db.AddInParameter(dbCommand, "pt_auth_edate", DbType.DateTime, treatment.pt_auth_edate);
                db.AddInParameter(dbCommand, "pt_auth_adate", DbType.DateTime, treatment.pt_auth_adate);
                db.AddInParameter(dbCommand, "pt_share", DbType.Decimal, treatment.pt_share);
                db.AddInParameter(dbCommand, "pt_ceiling", DbType.Decimal, treatment.pt_ceiling);
                db.AddInParameter(dbCommand, "pt_vat_type", DbType.String, treatment.pt_vat_type);
                db.AddInParameter(dbCommand, "pt_pdisc", DbType.Decimal, treatment.pt_pdisc);
                db.AddInParameter(dbCommand, "pt_coupon", DbType.String, treatment.pt_coupon);
                db.AddInParameter(dbCommand, "pt_coupon_disc", DbType.Decimal, treatment.pt_coupon_disc);
                db.AddOutParameter(dbCommand, "ptId", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ptId").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateInsuranceTreatments(BusinessEntities.Patient.Treatments.PatientTreatment treatment, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Treatment_Insurance_Update");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, treatment.ptId);
                db.AddInParameter(dbCommand, "pt_treatment", DbType.Int32, treatment.pt_treatment);
                db.AddInParameter(dbCommand, "pt_qty", DbType.Int32, treatment.pt_qty);
                db.AddInParameter(dbCommand, "pt_notes", DbType.String, treatment.pt_notes);
                db.AddInParameter(dbCommand, "pt_type", DbType.String, treatment.pt_type);
                db.AddInParameter(dbCommand, "pt_teeth", DbType.String, treatment.pt_teeth);
                db.AddInParameter(dbCommand, "pt_sur", DbType.String, treatment.pt_sur);
                db.AddInParameter(dbCommand, "pt_ses", DbType.Int32, treatment.pt_ses);
                db.AddInParameter(dbCommand, "pt_uprice", DbType.Decimal, treatment.pt_uprice);
                db.AddInParameter(dbCommand, "pt_total", DbType.Decimal, treatment.pt_total);
                db.AddInParameter(dbCommand, "pt_disc", DbType.Decimal, treatment.pt_disc);
                db.AddInParameter(dbCommand, "pt_net", DbType.Decimal, treatment.pt_net);
                db.AddInParameter(dbCommand, "pt_vat", DbType.Decimal, treatment.pt_vat);
                db.AddInParameter(dbCommand, "pt_vat_type", DbType.String, treatment.pt_vat_type);
                db.AddInParameter(dbCommand, "pt_pdisc", DbType.Decimal, treatment.pt_pdisc);
                db.AddInParameter(dbCommand, "pt_coupon", DbType.Decimal, treatment.pt_coupon);
                db.AddInParameter(dbCommand, "pt_share_new", DbType.Decimal, treatment.pt_share);
                db.AddInParameter(dbCommand, "pt_coupon_disc", DbType.Decimal, treatment.pt_coupon_disc);
                db.AddInParameter(dbCommand, "pt_auth_code", DbType.String, treatment.pt_auth_code);
                db.AddInParameter(dbCommand, "pt_auth_edate", DbType.DateTime, treatment.pt_auth_edate);

                db.AddOutParameter(dbCommand, "ptId_out", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ptId_out").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Dental Insurance Treatments (CRUD Operations)
        public static decimal GetPatientShare(int appId, int ptId, decimal qty, decimal uprice, decimal disc, out decimal pt_net, out int allowed_limit)
        {
            try
            {
                pt_net = 0;
                allowed_limit = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_PatientShare");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "qty", DbType.Double, qty);
                db.AddInParameter(dbCommand, "uprice", DbType.Double, uprice);
                db.AddInParameter(dbCommand, "disc", DbType.Double, disc);
                db.AddOutParameter(dbCommand, "pt_share", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt_net", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "icId", DbType.Int32, 100);
                db.AddOutParameter(dbCommand, "allowed_limit", DbType.Int32, 100);

                db.AddOutParameter(dbCommand, "pt__dded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__dcopay", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__ded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__sded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__lded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__rded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__mded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__copay", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__pded", DbType.Double, 100);

                db.ExecuteNonQuery(dbCommand);

                pt_net = Convert.ToDecimal(db.GetParameterValue(dbCommand, "pt_net").ToString());
                allowed_limit = Convert.ToInt32(db.GetParameterValue(dbCommand, "allowed_limit").ToString());

                return Convert.ToDecimal(db.GetParameterValue(dbCommand, "pt_share").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateDentalInsurancePatientTreatments(BusinessEntities.Patient.Treatments.PatientTreatment treatment, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Treatments_Insurance_Insert");
                db.AddInParameter(dbCommand, "pt_appId", DbType.Int32, treatment.pt_appId);
                db.AddInParameter(dbCommand, "pt_treatment", DbType.Int32, treatment.pt_treatment);
                db.AddInParameter(dbCommand, "pt_qty", DbType.Decimal, treatment.pt_qty);
                db.AddInParameter(dbCommand, "pt_notes", DbType.String, treatment.pt_notes);
                db.AddInParameter(dbCommand, "pt_comments", DbType.String, treatment.pt_comments);
                db.AddInParameter(dbCommand, "pt_type", DbType.String, treatment.pt_type);
                db.AddInParameter(dbCommand, "PT_teeth", DbType.String, treatment.pt_teeth);
                db.AddInParameter(dbCommand, "pt_sur", DbType.String, treatment.pt_sur);
                db.AddInParameter(dbCommand, "pt_auth_code", DbType.String, treatment.pt_auth_code);
                db.AddInParameter(dbCommand, "pt_ses", DbType.Int32, treatment.pt_ses);
                db.AddInParameter(dbCommand, "pt_treat_type", DbType.Int32, treatment.pt_treat_type);
                db.AddInParameter(dbCommand, "pt_uprice", DbType.Decimal, treatment.pt_uprice);
                db.AddInParameter(dbCommand, "pt_total", DbType.Decimal, treatment.pt_total);
                db.AddInParameter(dbCommand, "pt_disc", DbType.Decimal, treatment.pt_disc);
                db.AddInParameter(dbCommand, "pt_net", DbType.Decimal, treatment.pt_net);
                db.AddInParameter(dbCommand, "pt_vat", DbType.Decimal, treatment.pt_vat);
                db.AddInParameter(dbCommand, "pt_barcode", DbType.Int32, treatment.pt_barcode);
                db.AddInParameter(dbCommand, "pt_auth_edate", DbType.DateTime, treatment.pt_auth_edate);
                db.AddInParameter(dbCommand, "pt_auth_adate", DbType.DateTime, treatment.pt_auth_adate);
                db.AddInParameter(dbCommand, "pt_share", DbType.Decimal, treatment.pt_share);
                db.AddInParameter(dbCommand, "pt_ceiling", DbType.Decimal, treatment.pt_ceiling);
                db.AddInParameter(dbCommand, "pt_vat_type", DbType.String, treatment.pt_vat_type);
                db.AddInParameter(dbCommand, "pt_pdisc", DbType.Decimal, treatment.pt_pdisc);
                db.AddInParameter(dbCommand, "pt_coupon", DbType.String, treatment.pt_coupon);
                db.AddInParameter(dbCommand, "pt_coupon_disc", DbType.Decimal, treatment.pt_coupon_disc);
                db.AddOutParameter(dbCommand, "ptId", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ptId").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static decimal GetPatientShareEdit(int appId, int ptId, decimal qty, decimal uprice, decimal disc, int id, decimal new_share, out decimal pt_net, out int allowed_limit)
        {
            try
            {
                pt_net = 0;
                allowed_limit = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_PatientShareEdit");

                db.AddInParameter(dbCommand, "id", DbType.Int32, id);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "qty", DbType.Double, qty);
                db.AddInParameter(dbCommand, "uprice", DbType.Double, uprice);
                db.AddInParameter(dbCommand, "disc", DbType.Double, disc);
                db.AddInParameter(dbCommand, "pt_share_new", DbType.Double, new_share);
                db.AddOutParameter(dbCommand, "pt_share", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt_net", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "icId", DbType.Int32, 100);
                db.AddOutParameter(dbCommand, "allowed_limit", DbType.Int32, 100);

                db.AddOutParameter(dbCommand, "pt__dded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__dcopay", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__ded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__sded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__lded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__rded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__mded", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__copay", DbType.Double, 100);
                db.AddOutParameter(dbCommand, "pt__pded", DbType.Double, 100);

                db.ExecuteNonQuery(dbCommand);

                pt_net = Convert.ToDecimal(db.GetParameterValue(dbCommand, "pt_net").ToString());
                allowed_limit = Convert.ToInt32(db.GetParameterValue(dbCommand, "allowed_limit").ToString());

                return Convert.ToDecimal(db.GetParameterValue(dbCommand, "pt_share").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateDentInsPatientTreatment(BusinessEntities.Patient.Treatments.PatientTreatment treatment, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Treatment_Insurance_Update");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, treatment.ptId);
                db.AddInParameter(dbCommand, "pt_treatment", DbType.Int32, treatment.pt_treatment);
                db.AddInParameter(dbCommand, "pt_qty", DbType.Int32, treatment.pt_qty);
                db.AddInParameter(dbCommand, "pt_notes", DbType.String, treatment.pt_notes);
                db.AddInParameter(dbCommand, "pt_type", DbType.String, treatment.pt_type);
                db.AddInParameter(dbCommand, "pt_teeth", DbType.String, treatment.pt_teeth);
                db.AddInParameter(dbCommand, "pt_sur", DbType.String, treatment.pt_sur);
                db.AddInParameter(dbCommand, "pt_ses", DbType.Int32, treatment.pt_ses);
                db.AddInParameter(dbCommand, "pt_uprice", DbType.Decimal, treatment.pt_uprice);
                db.AddInParameter(dbCommand, "pt_total", DbType.Decimal, treatment.pt_total);
                db.AddInParameter(dbCommand, "pt_disc", DbType.Decimal, treatment.pt_disc);
                db.AddInParameter(dbCommand, "pt_net", DbType.Decimal, treatment.pt_net);
                db.AddInParameter(dbCommand, "pt_vat", DbType.Decimal, treatment.pt_vat);
                db.AddInParameter(dbCommand, "pt_vat_type", DbType.String, treatment.pt_vat_type);
                db.AddInParameter(dbCommand, "pt_pdisc", DbType.Decimal, treatment.pt_pdisc);
                db.AddInParameter(dbCommand, "pt_coupon", DbType.Decimal, treatment.pt_coupon);
                db.AddInParameter(dbCommand, "pt_coupon_disc", DbType.Decimal, treatment.pt_coupon_disc);
                db.AddInParameter(dbCommand, "pt_share_new", DbType.Decimal, treatment.pt_share);
                db.AddInParameter(dbCommand, "pt_auth_code", DbType.String, treatment.pt_auth_code);
                db.AddInParameter(dbCommand, "pt_auth_edate", DbType.DateTime, treatment.pt_auth_edate);

                db.AddOutParameter(dbCommand, "ptId_out", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ptId_out").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Miscellaneous Functions 
        public static int CopyInsuranceTreatment(int pt_appId, int ptId, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Copy_Insurance_Treatment");

                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "pt_appId", DbType.Int32, pt_appId);
                db.AddInParameter(dbCommand, "type", DbType.String, type);
                db.AddOutParameter(dbCommand, "pt_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "pt_output").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int MoveInsuranceTreatment(int pt_appId, int ptId, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Move_Insurance_Treatment");

                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "pt_appId", DbType.Int32, pt_appId);
                db.AddInParameter(dbCommand, "type", DbType.String, type);
                db.AddOutParameter(dbCommand, "pt_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "pt_output").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string Treat_Type(int pt_treatment)
        {
            try
            {
                string tr_type_ = "";
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTreatType");

                db.AddInParameter(dbCommand, "pt_treatment", DbType.Int32, pt_treatment);
                object result = db.ExecuteScalar(dbCommand);
                if (result != null)
                {
                    tr_type_ = result.ToString();
                }

                return tr_type_;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdateStatusToPriorRequest(int ptId, int inv_appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Update_Status_To_Prior_Request");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "inv_appId", DbType.Int32, inv_appId);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetInsuranceDeduction(int? pt_appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_InsuranceDeduction");

                if (pt_appId > 0)
                {
                    db.AddInParameter(dbCommand, "pt_appId", DbType.Int32, pt_appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable calc_bal_edit(int? appId, int? ptId, string tr_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_calc_bal_edit");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "pt_appId", DbType.Int32, appId);

                }
                if (ptId > 0)
                {
                    db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                }
                db.AddInParameter(dbCommand, "tr_type", DbType.String, tr_type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GET_PTTOTAL(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Pttotal");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);

                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetTeeth(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTeeth");

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static DataSet PrintInsuranceQuotation(string ptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_InsuranceTreatmentsQuotation_Print");

                db.AddInParameter(dbCommand, "ptId", DbType.String, ptId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetInsuranceInvoiceDetails(BusinessEntities.EMR.TreatmentBulkInvoice inv)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInsurance_DetailsForInvoice");
                db.AddInParameter(dbCommand, "inv_appId", DbType.Int32, inv.inv_appId);
                db.AddInParameter(dbCommand, "ptIds", DbType.String, string.Join(",", inv.ptIds));

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int GenerateInsuranceInvoice(InvoiceNew inv, out string inv_no, List<int> ptIds, int? multi_bill = 0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand;
                if (multi_bill == 0)
                {
                    dbCommand = db.GetStoredProcCommand("SP_INVOICES_insert");
                }
                else
                {
                    dbCommand = db.GetStoredProcCommand("SP_INVOICES_Multi_insert");
                    db.AddInParameter(dbCommand, "prev_invId", DbType.Int32, inv.invId);
                }
                db.AddInParameter(dbCommand, "inv_appId", DbType.Int32, inv.inv_appId);
                db.AddInParameter(dbCommand, "inv_no", DbType.String, inv.inv_no);
                db.AddInParameter(dbCommand, "inv_date", DbType.DateTime, inv.inv_date);
                db.AddInParameter(dbCommand, "inv_total", DbType.Decimal, inv.inv_total);
                db.AddInParameter(dbCommand, "inv_tdisc", DbType.Decimal, inv.inv_tdisc);
                db.AddInParameter(dbCommand, "inv_tdisc_type", DbType.String, inv.inv_tdisc_type);
                db.AddInParameter(dbCommand, "inv_disc", DbType.Decimal, inv.inv_disc);
                db.AddInParameter(dbCommand, "inv_tded", DbType.Decimal, inv.inv_tded);
                db.AddInParameter(dbCommand, "inv_copay", DbType.Decimal, inv.inv_copay);
                db.AddInParameter(dbCommand, "inv_net", DbType.Decimal, inv.inv_net);
                db.AddInParameter(dbCommand, "inv_notes", DbType.String, inv.inv_notes);
                db.AddInParameter(dbCommand, "inv_ic_name", DbType.String, inv.inv_ic_name);
                db.AddInParameter(dbCommand, "inv_type", DbType.String, inv.inv_type);
                db.AddInParameter(dbCommand, "pat_name", DbType.String, inv.pat_name);
                db.AddInParameter(dbCommand, "pat_code", DbType.String, inv.pat_code);
                db.AddInParameter(dbCommand, "inv_dcopay", DbType.Decimal, inv.inv_dcopay);
                db.AddInParameter(dbCommand, "inv_share", DbType.Decimal, inv.inv_share);
                db.AddInParameter(dbCommand, "inv_insurance", DbType.Int32, inv.inv_insurance);
                db.AddInParameter(dbCommand, "inv_dded", DbType.Decimal, inv.inv_dded);
                db.AddInParameter(dbCommand, "inv_lded", DbType.Decimal, inv.inv_lded);
                db.AddInParameter(dbCommand, "inv_rded", DbType.Decimal, inv.inv_rded);
                db.AddInParameter(dbCommand, "inv_mded", DbType.Decimal, inv.inv_mded);
                db.AddInParameter(dbCommand, "inv_sded", DbType.Decimal, inv.inv_sded);
                db.AddInParameter(dbCommand, "inv_pded", DbType.Decimal, inv.inv_pded);
                db.AddInParameter(dbCommand, "inv_madeby", DbType.Int32, inv.inv_madeby);

                db.AddOutParameter(dbCommand, "invId", DbType.Int32, 100);
                db.AddOutParameter(dbCommand, "inv_no_output", DbType.String, 100);

                db.ExecuteNonQuery(dbCommand);

                inv_no = db.GetParameterValue(dbCommand, "inv_no_output").ToString();

                int invId = Convert.ToInt32(db.GetParameterValue(dbCommand, "invId").ToString());

                int val = 0;

                if (invId > 0)
                {
                    foreach (var ptId in ptIds)
                    {
                        val += DataAccessLayer.EMR.PatientTreatments.UpdateInsurancePatientTreatmentStatus(ptId, invId, inv.inv_appId, inv_no, inv.inv_insurance);
                    }
                }

                return invId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateInsurancePatientTreatmentStatus(int ptId, int invId, int appId, string inv_no, int ins)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Update_Insurance_PTStatus");
                db.AddInParameter(dbCommand, "upt_ptIs", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "pt_invId", DbType.Int32, invId);
                db.AddInParameter(dbCommand, "upt_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "upt_type", DbType.String, "Insurance");
                db.AddInParameter(dbCommand, "upt_insurance", DbType.Int32, ins);
                db.AddInParameter(dbCommand, "upt_inv_no", DbType.String, inv_no);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool InsertDentalTreatBulk(DataTable dt, Cash_Treatments data, int madeby)
        {
            int inserts = 0;
            int pr_slno_out = 0;
            bool return_value = false;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                if (dt.Rows.Count > 0)
                {
                    SqlConnection con = new SqlConnection(db.ConnectionString);
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertDentalTreatBulk"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@tblBulk", dt);
                            cmd.Parameters.AddWithValue("@pt_madeby", madeby);
                            //cmd.Parameters.AddWithValue("@pir_branch", data.grn.pr_branch);
                            //cmd.Parameters.AddWithValue("@pir_piId", pr_Id);
                            //cmd.Parameters.AddWithValue("@pir_slno", pr_slno_out);
                            //cmd.Parameters.AddWithValue("@pir_supplier_inv", data.grn.pr_supplier_inv);
                            cmd.Parameters.Add("@id_out", SqlDbType.VarChar, 1000);
                            cmd.Parameters["@id_out"].Direction = ParameterDirection.Output;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            inserts = int.Parse((cmd.Parameters["@id_out"].Value).ToString());
                        }
                    }
                }


                if (inserts > 0)
                {
                    return_value = true;
                }
                else
                {
                    return_value = false;
                }
                return return_value;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            ;
        }

        public static DataTable GetLOINCForDropdown(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetLoinCodes");
                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region EAUTH Prior Requests
        public static int EAUTH_Prior_Requests_insert(DateTime epr_date, string epr_ID, string epr_sender, string epr_receiver, string epr_filename, string epr_file, string epr_ErrorMessage, int epr_appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EAUTH_PRIOR_REQUESTS_insert");

                db.AddInParameter(dbCommand, "epr_date", DbType.DateTime, epr_date);
                db.AddInParameter(dbCommand, "epr_ID", DbType.String, epr_ID);
                db.AddInParameter(dbCommand, "epr_sender", DbType.String, epr_sender);
                db.AddInParameter(dbCommand, "epr_receiver", DbType.String, epr_receiver);
                db.AddInParameter(dbCommand, "epr_filename", DbType.String, epr_filename);
                db.AddInParameter(dbCommand, "epr_file", DbType.String, epr_file);
                db.AddInParameter(dbCommand, "epr_ErrorMessage", DbType.String, epr_ErrorMessage);
                db.AddInParameter(dbCommand, "epr_appId", DbType.Int32, epr_appId);
                db.AddInParameter(dbCommand, "epr_madeby", DbType.Int32, madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateApproval(int ptId, string pt_auth_code, DateTime pt_auth_adate, DateTime pt_auth_edate)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_TREATMENTS_update_status3");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "pt_auth_code", DbType.String, pt_auth_code);
                db.AddInParameter(dbCommand, "pt_auth_adate", DbType.DateTime, pt_auth_adate);
                db.AddInParameter(dbCommand, "pt_auth_edate", DbType.DateTime, pt_auth_edate);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertActivityDetails(int ptId, int appId, string pt_resub_type, string act_no, int madeby, float pt_net, string act_xml_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prior_Requests_Activity_Details_insert");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "act_madeby", DbType.Int32, madeby);
                db.AddInParameter(dbCommand, "pt_resub_type", DbType.String, pt_resub_type);
                db.AddInParameter(dbCommand, "act_no", DbType.String, act_no);
                db.AddInParameter(dbCommand, "pt_net", DbType.Decimal, pt_net);
                db.AddInParameter(dbCommand, "act_xml_type", DbType.String, act_xml_type);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdatePatientTreatmentPRStatus(int ptId, string pt_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PRIOR_REQUEST_update_status2");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "pt_status", DbType.String, pt_status);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateBatch(int ptId, int pt_appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_UPDATE_PT_BATCHES");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "pt_appId", DbType.Int32, pt_appId);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ClearBatch(int ptId, int pt_appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_CLEAR_PT_BATCHES");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "pt_appId", DbType.Int32, pt_appId);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateResubTypeComments(string ptIds, string pt_resub_type, string pt_resub_notes)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_TREATMENTS_Resub_Type");
                db.AddInParameter(dbCommand, "ptIds", DbType.String, ptIds);
                db.AddInParameter(dbCommand, "pt_resub_type", DbType.String, pt_resub_type);
                db.AddInParameter(dbCommand, "pt_resub_notes", DbType.String, pt_resub_notes);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet GetPatientTreatmentsPriorRequestDirect(int appId, string ptIds)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_TREATMENTS_FOR_PRIOR_REQUEST_DIRECT");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "pt_appId", DbType.String, appId);
                    db.AddInParameter(dbCommand, "ptIds", DbType.String, ptIds);
                }

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataSet GetPatientTreatmentsPriorRequestCancel(int appId, string ptIds)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_TREATMENTS_FOR_PRIOR_REQUEST_CANCEL");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "pt_appId", DbType.String, appId);
                    db.AddInParameter(dbCommand, "ptIds", DbType.String, ptIds);
                }
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Packages
        public static DataTable GetPatientPackageOrders(int patId = 0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PackageOrderInfoBypatId");
                db.AddInParameter(dbCommand, "po_patient", DbType.Int32, patId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable PatientPackageOrder(int poId, int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPatientPackageOrderInfo");

                db.AddInParameter(dbCommand, "poId", DbType.String, poId);
                db.AddInParameter(dbCommand, "appId", DbType.String, appId);
                db.AddInParameter(dbCommand, "patId", DbType.String, patId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable PatientPackageServices(int poId, int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPatientPackageOrderInfo");

                db.AddInParameter(dbCommand, "poId", DbType.String, poId);
                db.AddInParameter(dbCommand, "appId", DbType.String, appId);
                db.AddInParameter(dbCommand, "patId", DbType.String, patId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPatientPackageServices(int poId, int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPatientPackageServicesInfo");
                db.AddInParameter(dbCommand, "poId", DbType.String, poId);
                db.AddInParameter(dbCommand, "appId", DbType.String, appId);
                db.AddInParameter(dbCommand, "patId", DbType.String, patId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int GenerateTreatmentsandInvoice(BusinessEntities.EMR.PT_treatments treat, int madeby, out string inv_no)
        {
            int count = 0;
            int invId = 0;
            int poId = 0;
            int inv_appId = 0;
            int recId = 0;
            int val = 0;
            inv_no = string.Empty;
            List<Cash_PackService> list = treat.treat_items;
            StringBuilder posServicesBuilder = new StringBuilder();
            foreach (Cash_PackService i in list)
            {
                if (i.pos_status == "Selected")
                {
                    val = 1;
                }
                else
                {
                    BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();
                    var total = (i.pos_sess * i.pos_ps_unitPrice);
                    treatment.pt_appId = i.appId;
                    treatment.pt_treatment = i.pos_services;
                    treatment.pt_qty = i.pos_sess;
                    treatment.pt_notes = "";
                    treatment.pt_type = "Cash";
                    treatment.pt_teeth = "";
                    treatment.pt_sur = "";
                    treatment.pt_auth_code = "";
                    treatment.pt_ses = 1;
                    treatment.pt_treat_type = 3;
                    treatment.pt_uprice = i.pos_ps_unitPrice;
                    treatment.pt_total = total;
                    treatment.pt_disc = 0;
                    treatment.pt_ded = 0;
                    treatment.pt_copay = 0;
                    treatment.pt_net = total;
                    treatment.pt_vat = 0;
                    treatment.pt_dcopay = 0;
                    treatment.pt_barcode = "0";
                    treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                    treatment.pt_auth_edate = DateTime.Parse("01/01/1900");
                    treatment.pt_share = 0;
                    treatment.pt_insurance = 1;
                    treatment.pt_dded = 0;
                    treatment.pt_lded = 0;
                    treatment.pt_rded = 0;
                    treatment.pt_mded = 0;
                    treatment.pt_ceiling = 0;
                    treatment.pt_vat_type = "0";
                    treatment.pt_pdisc = 0;
                    treatment.pt_coupon = "";
                    treatment.pt_coupon_disc = 0;

                    val = DataAccessLayer.Patient.Treatments.PatientTreatment.CreatePatientpackageTreatments(treatment, madeby, i.posId, i.poId);
                }
                if (val > 0)
                {
                    posServicesBuilder.Append(i.pos_services);
                    posServicesBuilder.Append(",");
                    count++;
                    inv_appId = i.appId;
                    poId = i.poId;
                }
            }
            if (count > 0)
            {
                BusinessEntities.Invoice.InvoiceNew _inv = new BusinessEntities.Invoice.InvoiceNew();
                _inv.invId = 0;
                _inv.inv_appId = inv_appId;
                _inv.inv_no = "0";
                _inv.inv_total = list.Sum(e => (e.pos_ps_unitPrice * e.pos_sess));
                _inv.inv_tdisc = 0;
                _inv.inv_tdisc_type = "Fixed";
                _inv.inv_net = list.Sum(e => (e.pos_ps_unitPrice * e.pos_sess));
                _inv.inv_disc = 0;
                _inv.inv_tded = 0;
                _inv.inv_lded = 0;
                _inv.inv_rded = 0;
                _inv.inv_mded = 0;
                _inv.inv_copay = 0;
                _inv.inv_dcopay = 0;
                _inv.inv_share = 0;
                _inv.inv_notes = "Session used from packages";
                _inv.inv_madeby = madeby;
                _inv.inv_ic_name = "Cash";
                _inv.inv_type = "Cash";
                _inv.inv_insurance = 1;
                _inv.poId = poId;
                if (posServicesBuilder.Length > 0)
                {
                    posServicesBuilder.Length--; // Remove the last comma
                }
                string ptIds = posServicesBuilder.ToString();
                invId = DataAccessLayer.Invoice.Invoice.GenerateInvoiceforPackage(_inv, ptIds, out inv_no);
            }
            if (invId > 0)
            {
                BusinessEntities.Invoice.Receipts rec = treat.invoice_receipt;
                if ((rec.rec_cash + rec.rec_cc + rec.rec_cc_per + rec.rec_chq + rec.rec_bt + rec.rec_allocated + rec.rec_debit + rec.rec_vamount +
                     rec.rec_lamount + rec.rec_tabby + rec.rec_self + rec.rec_spoti + rec.rec_group + rec.rec_cob + rec.rec_stripe +
                     rec.rec_tamara + rec.rec_extra_pay1 + rec.rec_extra_pay2 + rec.rec_extra_pay3) > 0)
                {
                    rec.rec_code = string.IsNullOrEmpty(rec.rec_code) ? string.Empty : rec.rec_code;
                    rec.rec_invoice = invId;
                    rec.rec_chq_no = string.IsNullOrEmpty(rec.rec_chq_no) ? string.Empty : rec.rec_chq_no;
                    rec.rec_chq_bank = string.IsNullOrEmpty(rec.rec_chq_bank) ? string.Empty : rec.rec_chq_bank;
                    rec.rec_bt_bank = string.IsNullOrEmpty(rec.rec_bt_bank) ? string.Empty : rec.rec_bt_bank;
                    rec.rec_notes = string.IsNullOrEmpty(rec.rec_notes) ? string.Empty : rec.rec_notes;
                    rec.rec_madeby = madeby;

                    decimal total = (rec.rec_cash + rec.rec_cc + rec.rec_cc_per + rec.rec_chq + rec.rec_bt + rec.rec_allocated + rec.rec_debit +
                            rec.rec_tabby + rec.rec_self + rec.rec_spoti + rec.rec_group + rec.rec_cob + rec.rec_stripe +
                            rec.rec_tamara + rec.rec_extra_pay1 + rec.rec_extra_pay2 + rec.rec_extra_pay3);

                    if (total > 0)
                    {
                        if (string.IsNullOrEmpty(rec.rec_type))
                        {
                            if (rec.rec_invoice == 0)
                            {
                                if (rec.rec_advance == 0)
                                {
                                    rec.rec_type = "Advance";
                                    rec.rec_prefix = "ADV-" + rec.rec_branch;
                                }
                                if (rec.rec_advance > 0)
                                {
                                    rec.rec_type = "Refund";
                                    rec.rec_prefix = "REF-" + rec.rec_branch;
                                }
                                if (rec.rec_loy_value > 0)
                                {
                                    rec.rec_type = "Loyalty";
                                    rec.rec_prefix = "LYP-" + rec.rec_branch;
                                }
                            }
                            else
                            {
                                if (total > 0 && rec.rec_allocated == 0 && rec.rec_lamount == 0 && rec.rec_advance == 0)
                                {
                                    rec.rec_type = "Invoice";
                                    rec.rec_prefix = "REC-" + rec.rec_branch;
                                }

                                if (rec.rec_advance > 0 && rec.rec_allocated == 0)
                                {
                                    rec.rec_type = "Inv Refund";
                                    rec.rec_prefix = "I-REF-" + rec.rec_branch;
                                }

                                if (total == 0 && rec.rec_allocated > 0)
                                {
                                    rec.rec_type = "Allocation";
                                    rec.rec_prefix = "ALC-" + rec.rec_branch;
                                }

                                if (total > 0 && rec.rec_allocated > 0)
                                {
                                    rec.rec_type = "Invoice & Allocation";
                                    rec.rec_prefix = "I-ALC-" + rec.rec_branch;
                                }

                                if (total == 0 && rec.rec_lamount > 0)
                                {
                                    rec.rec_type = "Invoice & Loyalty";
                                    rec.rec_prefix = "I-LYP-" + rec.rec_branch;
                                }

                                if (total > 0 && rec.rec_lamount > 0)
                                {
                                    rec.rec_type = "Loy/Allocation";
                                    rec.rec_prefix = "LYP-ALC-" + rec.rec_branch;
                                }
                            }
                        }

                        recId = DataAccessLayer.Invoice.Receipts.CreateReceipts(rec);
                    }
                    else
                    {
                        if (rec.rec_type.ToLower().Contains("refund"))
                        {
                            recId = DataAccessLayer.Invoice.Receipts.CreateReceipts(rec);
                        }
                        else
                        {
                            recId = -1;
                        }
                    }
                }
            }

            return invId;
        }
        public static int GenerateTreatments(BusinessEntities.EMR.PT_treatments treat, int madeby)
        {
            int count = 0;
            List<Cash_PackService> list = treat.treat_items;
            foreach (Cash_PackService i in list)
            {
                BusinessEntities.Patient.Treatments.PatientTreatment treatment = new BusinessEntities.Patient.Treatments.PatientTreatment();
                var total = (i.pos_sess * i.pos_ps_unitPrice);
                treatment.pt_appId = i.appId;
                treatment.pt_treatment = i.pos_services;
                treatment.pt_qty = i.pos_sess;
                treatment.pt_notes = "";
                treatment.pt_type = "Cash";
                treatment.pt_teeth = "";
                treatment.pt_sur = "";
                treatment.pt_auth_code = "";
                treatment.pt_ses = 1;
                treatment.pt_treat_type = 3;
                treatment.pt_uprice = i.pos_ps_unitPrice;
                treatment.pt_total = total;
                treatment.pt_disc = 0;
                treatment.pt_ded = 0;
                treatment.pt_copay = 0;
                treatment.pt_net = total;
                treatment.pt_vat = 0;
                treatment.pt_dcopay = 0;
                treatment.pt_barcode = "0";
                treatment.pt_auth_adate = DateTime.Parse("01/01/1900");
                treatment.pt_auth_edate = DateTime.Parse("01/01/1900");
                treatment.pt_share = 0;
                treatment.pt_insurance = 1;
                treatment.pt_dded = 0;
                treatment.pt_lded = 0;
                treatment.pt_rded = 0;
                treatment.pt_mded = 0;
                treatment.pt_ceiling = 0;
                treatment.pt_vat_type = "0";
                treatment.pt_pdisc = 0;
                treatment.pt_coupon = "";
                treatment.pt_coupon_disc = 0;

                int val = DataAccessLayer.Patient.Treatments.PatientTreatment.CreatePatientpackageTreatments(treatment, madeby, i.posId, i.poId);

                if (val > 0)
                {
                    count++;
                }
            }
            return count;
        }
        #endregion

        public static int GetInvoiceId(int inv_appId)
        {
            try
            {
                int type_output = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Invoice_GetInvId");

                db.AddInParameter(dbCommand, "inv_appId", DbType.Int32, inv_appId);

                db.AddOutParameter(dbCommand, "invId", DbType.Int32, 100);

                db.ExecuteScalar(dbCommand);

                type_output = int.Parse(db.GetParameterValue(dbCommand, "invId").ToString());

                return type_output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetRadiologyTreatments(int? appId, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Rad_Patient_Treatments_Select_All_Info");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                db.AddInParameter(dbCommand, "type", DbType.String, type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetInvNosList(int appId, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInvNos");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                db.AddInParameter(dbCommand, "type", DbType.String, type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}