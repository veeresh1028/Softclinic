using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Patient.Treatments
{
    public class PatientTreatment
    {
        public static int CreatePatientTreatments(BusinessEntities.Patient.Treatments.PatientTreatment treatment, int madeby,int? invId=0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_TREATMENTS_insert");
                db.AddInParameter(dbCommand, "pt_appId", DbType.Int32, treatment.pt_appId);
                db.AddInParameter(dbCommand, "pt_treatment", DbType.Int32, treatment.pt_treatment);
                db.AddInParameter(dbCommand, "pt_qty", DbType.Int32, treatment.pt_qty);
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
                db.AddInParameter(dbCommand, "pt_ded", DbType.Decimal, treatment.pt_ded);
                db.AddInParameter(dbCommand, "pt_copay", DbType.Decimal, treatment.pt_copay);
                db.AddInParameter(dbCommand, "pt_net", DbType.Decimal, treatment.pt_net);
                db.AddInParameter(dbCommand, "pt_vat", DbType.Decimal, treatment.pt_vat);
                db.AddInParameter(dbCommand, "pt_dcopay", DbType.Decimal, treatment.pt_dcopay);
                db.AddInParameter(dbCommand, "pt_barcode", DbType.Int32, treatment.pt_barcode);
                db.AddInParameter(dbCommand, "pt_auth_edate", DbType.DateTime, treatment.pt_auth_edate);
                db.AddInParameter(dbCommand, "pt_auth_adate", DbType.DateTime, treatment.pt_auth_adate);
                db.AddInParameter(dbCommand, "pt_share", DbType.Decimal, treatment.pt_share);
                db.AddInParameter(dbCommand, "pt_insurance", DbType.Int32, treatment.pt_insurance);
                db.AddInParameter(dbCommand, "pt_dded", DbType.Decimal, treatment.pt_dded);
                db.AddInParameter(dbCommand, "pt_lded", DbType.Decimal, treatment.pt_lded);
                db.AddInParameter(dbCommand, "pt_rded", DbType.Decimal, treatment.pt_rded);
                db.AddInParameter(dbCommand, "pt_mded", DbType.Decimal, treatment.pt_mded);
                db.AddInParameter(dbCommand, "pt_ceiling", DbType.Decimal, treatment.pt_ceiling);
                db.AddInParameter(dbCommand, "pt_vat_type", DbType.String, treatment.pt_vat_type);
                db.AddInParameter(dbCommand, "pt_pdisc", DbType.Decimal, treatment.pt_pdisc);
                db.AddInParameter(dbCommand, "pt_coupon", DbType.String, treatment.pt_coupon);
                db.AddInParameter(dbCommand, "pt_coupon_disc", DbType.Decimal, treatment.pt_coupon_disc);
                db.AddInParameter(dbCommand, "pt_invId", DbType.Int32, invId);
                db.AddOutParameter(dbCommand, "ptId", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ptId").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeletePatientTreatments(int ptId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_TREATMENTS_delete");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "pt_madeby", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdatePatientTreatments(BusinessEntities.Patient.Treatments.PatientTreatment treatment, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_TREATMENTS_update_CASH");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, treatment.ptId);
                db.AddInParameter(dbCommand, "pt_treatment", DbType.Int32, treatment.pt_treatment);
                db.AddInParameter(dbCommand, "pt_ses", DbType.Int32, treatment.pt_ses);
                db.AddInParameter(dbCommand, "pt_type", DbType.String, treatment.pt_type);
                db.AddInParameter(dbCommand, "pt_qty", DbType.Int32, treatment.pt_qty);
                db.AddInParameter(dbCommand, "pt_uprice", DbType.Decimal, treatment.pt_uprice);
                db.AddInParameter(dbCommand, "pt_total", DbType.Decimal, treatment.pt_total);
                db.AddInParameter(dbCommand, "pt_disc", DbType.Decimal, treatment.pt_disc);
                db.AddInParameter(dbCommand, "pt_ded", DbType.Decimal, treatment.pt_ded);
                db.AddInParameter(dbCommand, "pt_copay", DbType.Decimal, treatment.pt_copay);
                db.AddInParameter(dbCommand, "pt_net", DbType.Decimal, treatment.pt_net);
                db.AddInParameter(dbCommand, "pt_dcopay", DbType.Decimal, treatment.pt_dcopay);
                db.AddInParameter(dbCommand, "pt_share", DbType.Decimal, treatment.pt_share);
                db.AddInParameter(dbCommand, "pt_insurance", DbType.Int32, treatment.pt_insurance);
                db.AddInParameter(dbCommand, "pt_teeth", DbType.String, treatment.pt_teeth);
                db.AddInParameter(dbCommand, "pt_sur", DbType.String, treatment.pt_sur);
                db.AddInParameter(dbCommand, "pt_vat", DbType.Decimal, treatment.pt_vat);
                db.AddOutParameter(dbCommand, "ptId_out", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ptId_out").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int PatientTreatmentGroupInsert(int ptId, int trId, int tgId, int appId, string status, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Treatment_Group_Insert");
                db.AddInParameter(dbCommand, "ptg_ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "ptg_trId", DbType.Int32, trId);
                db.AddInParameter(dbCommand, "ptg_tgId", DbType.Int32, tgId);
                db.AddInParameter(dbCommand, "ptg_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ptg_status", DbType.String, status);
                db.AddInParameter(dbCommand, "ptg_updated_by", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static int packagesMasterInsert(string pkg_code, string pkg_name, decimal pkg_price, DateTime pkg_date, int trId, int pt_qty, int ptId, int appId, string status, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_Package_Services_Insert");
                db.AddInParameter(dbCommand, "pkg_code", DbType.String, pkg_code);
                db.AddInParameter(dbCommand, "pkg_name", DbType.String, pkg_name);
                db.AddInParameter(dbCommand, "pkg_price", DbType.Decimal, pkg_price);
                db.AddInParameter(dbCommand, "pkg_date", DbType.DateTime, pkg_date);
                db.AddInParameter(dbCommand, "pos_services", DbType.Int32, trId);
                db.AddInParameter(dbCommand, "pps_ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "pt_qty", DbType.Int32, pt_qty);
                db.AddInParameter(dbCommand, "pps_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pps_status", DbType.String, status);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int PackageInsert(int ptId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_CustomPackage_Insert");
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
        public static int UpdatePatientTreatmentStatus(int ptId, int appId, string inv_no,int invId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_UPDATE_PT_STATUS");
                db.AddInParameter(dbCommand, "upt_ptIs", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "upt_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "upt_invId", DbType.Int32, invId);
                db.AddInParameter(dbCommand, "upt_type", DbType.String, "Cash");
                db.AddInParameter(dbCommand, "upt_insurance", DbType.Int32, 1);
                db.AddInParameter(dbCommand, "upt_inv_no", DbType.String, inv_no);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UpdatePatientMultiTreatmentStatus(int ptIds, int appId, string inv_no,int invId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_UPDATE_MULTI_PT_STATUS");
                db.AddInParameter(dbCommand, "ptIds", DbType.Int32, ptIds);
                db.AddInParameter(dbCommand, "upt_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "upt_invId", DbType.Int32, invId);
                db.AddInParameter(dbCommand, "upt_type", DbType.String, "Cash");
                db.AddInParameter(dbCommand, "upt_insurance", DbType.Int32, 1);
                db.AddInParameter(dbCommand, "upt_inv_no", DbType.String, inv_no);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int CreatePatientpackageTreatments(BusinessEntities.Patient.Treatments.PatientTreatment treatment, int madeby, int posId, int poId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Packages_patients_Treatments_insert");
                db.AddInParameter(dbCommand, "pt_appId", DbType.Int32, treatment.pt_appId);
                db.AddInParameter(dbCommand, "pt_treatment", DbType.Int32, treatment.pt_treatment);
                db.AddInParameter(dbCommand, "pt_qty", DbType.Int32, treatment.pt_qty);
                db.AddInParameter(dbCommand, "pt_notes", DbType.String, treatment.pt_notes);
                db.AddInParameter(dbCommand, "pt_type", DbType.String, treatment.pt_type);
                db.AddInParameter(dbCommand, "PT_teeth", DbType.String, treatment.pt_teeth);
                db.AddInParameter(dbCommand, "pt_sur", DbType.String, treatment.pt_sur);
                db.AddInParameter(dbCommand, "pt_auth_code", DbType.String, treatment.pt_auth_code);
                db.AddInParameter(dbCommand, "pt_ses", DbType.Int32, treatment.pt_ses);
                db.AddInParameter(dbCommand, "pt_treat_type", DbType.Int32, treatment.pt_treat_type);
                db.AddInParameter(dbCommand, "pt_uprice", DbType.Decimal, treatment.pt_uprice);
                db.AddInParameter(dbCommand, "pt_total", DbType.Decimal, treatment.pt_total);
                db.AddInParameter(dbCommand, "pt_disc", DbType.Decimal, treatment.pt_disc);
                db.AddInParameter(dbCommand, "pt_ded", DbType.Decimal, treatment.pt_ded);
                db.AddInParameter(dbCommand, "pt_copay", DbType.Decimal, treatment.pt_copay);
                db.AddInParameter(dbCommand, "pt_net", DbType.Decimal, treatment.pt_net);
                db.AddInParameter(dbCommand, "pt_vat", DbType.Decimal, treatment.pt_vat);
                db.AddInParameter(dbCommand, "pt_dcopay", DbType.Decimal, treatment.pt_dcopay);
                db.AddInParameter(dbCommand, "pt_barcode", DbType.Int32, treatment.pt_barcode);
                db.AddInParameter(dbCommand, "pt_auth_edate", DbType.DateTime, treatment.pt_auth_edate);
                db.AddInParameter(dbCommand, "pt_auth_adate", DbType.DateTime, treatment.pt_auth_adate);
                db.AddInParameter(dbCommand, "pt_share", DbType.Decimal, treatment.pt_share);
                db.AddInParameter(dbCommand, "pt_insurance", DbType.Int32, treatment.pt_insurance);
                db.AddInParameter(dbCommand, "pt_dded", DbType.Decimal, treatment.pt_dded);
                db.AddInParameter(dbCommand, "pt_lded", DbType.Decimal, treatment.pt_lded);
                db.AddInParameter(dbCommand, "pt_rded", DbType.Decimal, treatment.pt_rded);
                db.AddInParameter(dbCommand, "pt_mded", DbType.Decimal, treatment.pt_mded);
                db.AddInParameter(dbCommand, "pt_ceiling", DbType.Decimal, treatment.pt_ceiling);
                db.AddInParameter(dbCommand, "pt_vat_type", DbType.String, treatment.pt_vat_type);
                db.AddInParameter(dbCommand, "pt_pdisc", DbType.Decimal, treatment.pt_pdisc);
                db.AddInParameter(dbCommand, "pt_coupon", DbType.String, treatment.pt_coupon);
                db.AddInParameter(dbCommand, "pt_coupon_disc", DbType.Decimal, treatment.pt_coupon_disc);
                db.AddInParameter(dbCommand, "pt_madeby", DbType.Int32, madeby);
                db.AddInParameter(dbCommand, "posId", DbType.Int32, posId);
                db.AddInParameter(dbCommand, "poId", DbType.Int32, poId);
                db.AddOutParameter(dbCommand, "ptId", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ptId").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}