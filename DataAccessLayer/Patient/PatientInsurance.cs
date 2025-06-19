using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Patient;
using System.Net.NetworkInformation;

namespace DataAccessLayer.Patient
{
    public class PatientInsurance
    {
        public static DataTable GetPatient_InsuranceTPA(int? icId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_InsuranceTPA");

                if (icId > 0)
                {
                    db.AddInParameter(dbCommand, "icId", DbType.Int32, icId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetPatient_InsurancePayers(int? ipId, int? ip_ins)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_InsurancePayers");

                if (ipId > 0)
                {
                    db.AddInParameter(dbCommand, "ipId", DbType.Int32, ipId);
                }

                if (ip_ins > 0)
                {
                    db.AddInParameter(dbCommand, "ip_ins", DbType.Int32, ip_ins);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetPatient_InsuranceNetworks(int? isId, int? is_icId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_InsuranceNetworks");

                if (isId > 0)
                {
                    db.AddInParameter(dbCommand, "isId", DbType.Int32, isId);
                }

                if (is_icId > 0)
                {
                    db.AddInParameter(dbCommand, "is_icId", DbType.Int32, is_icId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetInsuranceDataByPatientID(int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_PatientInsurances_ByPatID");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int InsertPatientInsurance(PatientInsuranceDetails i, int madeby, int patId)
        {
            try
            {
                int piId_output = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_INSURANCES_insert");
                //Main Info 
                db.AddInParameter(dbCommand, "pi_patient", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "pi_insurance", DbType.Int32, i.pi_insurance);
                db.AddInParameter(dbCommand, "pi_insno", DbType.String, i.pi_insno);
                db.AddInParameter(dbCommand, "pi_polocyno", DbType.String, i.pi_polocyno);
                db.AddInParameter(dbCommand, "pi_idate", DbType.DateTime, i.pi_idate);
                db.AddInParameter(dbCommand, "pi_edate", DbType.DateTime, i.pi_edate);
                db.AddInParameter(dbCommand, "pi_cded", DbType.Decimal, i.pi_cded);
                db.AddInParameter(dbCommand, "pi_cded_type", DbType.String, i.pi_cded_type);
                db.AddInParameter(dbCommand, "pi_ided", DbType.Decimal, i.pi_ided);
                db.AddInParameter(dbCommand, "pi_ided_type", DbType.String, i.pi_ided_type);
                db.AddInParameter(dbCommand, "pi_pded", DbType.Decimal, i.pi_pded);
                db.AddInParameter(dbCommand, "pi_pded_type", DbType.String, i.pi_pded_type);
                db.AddInParameter(dbCommand, "pi_copay", DbType.Decimal, i.pi_copay);
                db.AddInParameter(dbCommand, "pi_copay_type", DbType.String, i.pi_copay_type);

                db.AddInParameter(dbCommand, "pi_image", DbType.String, i.pi_image);
                db.AddInParameter(dbCommand, "pi_limit", DbType.Decimal, i.pi_limit);

                db.AddInParameter(dbCommand, "pi_dcopay", DbType.Decimal, i.pi_dcopay);
                db.AddInParameter(dbCommand, "pi_dcopay_type", DbType.String, i.pi_dcopay_type);

                db.AddInParameter(dbCommand, "pi_image2", DbType.String, i.pi_image2);
                db.AddInParameter(dbCommand, "pi_hdcopay", DbType.Decimal, i.pi_hdcopay);
                db.AddInParameter(dbCommand, "pi_hdcopay_type", DbType.String, i.pi_hdcopay_type);
                db.AddInParameter(dbCommand, "pi_ip_dcopay", DbType.Decimal, i.pi_ip_dcopay);
                db.AddInParameter(dbCommand, "pi_ip_dcopay_type", DbType.String, i.pi_ip_dcopay_type);
                db.AddInParameter(dbCommand, "pi_dded", DbType.Decimal, i.pi_dded);
                db.AddInParameter(dbCommand, "pi_dded_type", DbType.String, i.pi_dded_type);
                db.AddInParameter(dbCommand, "pi_rded", DbType.Decimal, i.pi_rded);
                db.AddInParameter(dbCommand, "pi_rded_type", DbType.String, i.pi_rded_type);
                db.AddInParameter(dbCommand, "pi_mded", DbType.Decimal, i.pi_mded);
                db.AddInParameter(dbCommand, "pi_mded_type", DbType.String, i.pi_mded_type);
                db.AddInParameter(dbCommand, "pi_ceiling", DbType.Decimal, i.pi_ceiling);
                db.AddInParameter(dbCommand, "pi_scheme", DbType.Int32, i.pi_scheme);

                db.AddInParameter(dbCommand, "pi_copay_limit", DbType.Decimal, i.pi_copay_limit);
                db.AddInParameter(dbCommand, "pi_dcopay_limit", DbType.Decimal, i.pi_dcopay_limit);
                db.AddInParameter(dbCommand, "pi_hp_dcopay_limit", DbType.Decimal, i.pi_hdcopay_limit);
                db.AddInParameter(dbCommand, "pi_ip_dcopay_limit", DbType.Decimal, i.pi_ip_dcopay_limit);
                db.AddInParameter(dbCommand, "pi_cded_limit", DbType.Decimal, i.pi_cded_limit);
                db.AddInParameter(dbCommand, "pi_dded_limit", DbType.Decimal, i.pi_dded_limit);
                db.AddInParameter(dbCommand, "pi_pded_limit", DbType.Decimal, i.pi_pded_limit);
                db.AddInParameter(dbCommand, "pi_ided_limit", DbType.Decimal, i.pi_ided_limit);
                db.AddInParameter(dbCommand, "pi_rded_limit", DbType.Decimal, i.pi_rded_limit);
                db.AddInParameter(dbCommand, "pi_mded_limit", DbType.Decimal, i.pi_mded_limit);
                db.AddInParameter(dbCommand, "pi_payer", DbType.Int32, i.pi_payer);
                db.AddInParameter(dbCommand, "pi_madeby", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "piId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                piId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "piId").ToString());

                return piId_output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetInsuranceDataByInsuranceID(int piId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPatientInsuranceById");
                db.AddInParameter(dbCommand, "piId", DbType.Int32, piId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdatePatientInsurance(PatientInsuranceDetails i, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_INSURANCES_update");
                //Main Info
                db.AddInParameter(dbCommand, "piId", DbType.Int32, i.piId);
                db.AddInParameter(dbCommand, "pi_patient", DbType.Int32, i.pi_patient);
                db.AddInParameter(dbCommand, "pi_insurance", DbType.Int32, i.pi_insurance);
                db.AddInParameter(dbCommand, "pi_insno", DbType.String, i.pi_insno);
                db.AddInParameter(dbCommand, "pi_polocyno", DbType.String, i.pi_polocyno);
                db.AddInParameter(dbCommand, "pi_idate", DbType.DateTime, i.pi_idate);
                db.AddInParameter(dbCommand, "pi_edate", DbType.DateTime, i.pi_edate);
                db.AddInParameter(dbCommand, "pi_cded", DbType.Decimal, i.pi_cded);
                db.AddInParameter(dbCommand, "pi_cded_type", DbType.String, i.pi_cded_type);
                db.AddInParameter(dbCommand, "pi_ided", DbType.Decimal, i.pi_ided);
                db.AddInParameter(dbCommand, "pi_ided_type", DbType.String, i.pi_ided_type);
                db.AddInParameter(dbCommand, "pi_pded", DbType.Decimal, i.pi_pded);
                db.AddInParameter(dbCommand, "pi_pded_type", DbType.String, i.pi_pded_type);
                db.AddInParameter(dbCommand, "pi_copay", DbType.Decimal, i.pi_copay);
                db.AddInParameter(dbCommand, "pi_copay_type", DbType.String, i.pi_copay_type);

                db.AddInParameter(dbCommand, "pi_image", DbType.String, i.pi_image);
                db.AddInParameter(dbCommand, "pi_limit", DbType.Decimal, i.pi_limit);

                db.AddInParameter(dbCommand, "pi_dcopay", DbType.Decimal, i.pi_dcopay);
                db.AddInParameter(dbCommand, "pi_dcopay_type", DbType.String, i.pi_dcopay_type);

                db.AddInParameter(dbCommand, "pi_image2", DbType.String, i.pi_image2);
                db.AddInParameter(dbCommand, "pi_hdcopay", DbType.Decimal, i.pi_hdcopay);
                db.AddInParameter(dbCommand, "pi_hdcopay_type", DbType.String, i.pi_hdcopay_type);
                db.AddInParameter(dbCommand, "pi_ip_dcopay", DbType.Decimal, i.pi_ip_dcopay);
                db.AddInParameter(dbCommand, "pi_ip_dcopay_type", DbType.String, i.pi_ip_dcopay_type);
                db.AddInParameter(dbCommand, "pi_dded", DbType.Decimal, i.pi_dded);
                db.AddInParameter(dbCommand, "pi_dded_type", DbType.String, i.pi_dded_type);
                db.AddInParameter(dbCommand, "pi_rded", DbType.Decimal, i.pi_rded);
                db.AddInParameter(dbCommand, "pi_rded_type", DbType.String, i.pi_rded_type);
                db.AddInParameter(dbCommand, "pi_mded", DbType.Decimal, i.pi_mded);
                db.AddInParameter(dbCommand, "pi_mded_type", DbType.String, i.pi_mded_type);
                db.AddInParameter(dbCommand, "pi_ceiling", DbType.Decimal, i.pi_ceiling);
                db.AddInParameter(dbCommand, "pi_scheme", DbType.Int32, i.pi_scheme);

                db.AddInParameter(dbCommand, "pi_copay_limit", DbType.Decimal, i.pi_copay_limit);
                db.AddInParameter(dbCommand, "pi_dcopay_limit", DbType.Decimal, i.pi_dcopay_limit);
                db.AddInParameter(dbCommand, "pi_hp_dcopay_limit", DbType.Decimal, i.pi_hdcopay_limit);
                db.AddInParameter(dbCommand, "pi_ip_dcopay_limit", DbType.Decimal, i.pi_ip_dcopay_limit);
                db.AddInParameter(dbCommand, "pi_cded_limit", DbType.Decimal, i.pi_cded_limit);
                db.AddInParameter(dbCommand, "pi_dded_limit", DbType.Decimal, i.pi_dded_limit);
                db.AddInParameter(dbCommand, "pi_pded_limit", DbType.Decimal, i.pi_pded_limit);
                db.AddInParameter(dbCommand, "pi_ided_limit", DbType.Decimal, i.pi_ided_limit);
                db.AddInParameter(dbCommand, "pi_rded_limit", DbType.Decimal, i.pi_rded_limit);
                db.AddInParameter(dbCommand, "pi_mded_limit", DbType.Decimal, i.pi_mded_limit);
                db.AddInParameter(dbCommand, "pi_payer", DbType.Int32, i.pi_payer);
                db.AddInParameter(dbCommand, "pi_madeby", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ChangePatientInsuranceStatus(int piId, string pi_status, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PatientInsurance_ChangeStatus");
                db.AddInParameter(dbCommand, "piId", DbType.Int32, piId);
                db.AddInParameter(dbCommand, "pi_status", DbType.String, pi_status);
                db.AddInParameter(dbCommand, "pi_madeby", DbType.String, madeby);
                db.AddOutParameter(dbCommand, "pi_output", DbType.Int32, 100);

                db.ExecuteScalar(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "pi_output").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
