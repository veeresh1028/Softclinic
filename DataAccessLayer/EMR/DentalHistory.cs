using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataAccessLayer.EMR
{
    public class DentalHistory
    {
        #region  Dental History (Page Load)
        public static DataTable GetAllDentalHistory(int? appId, int? pdId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_DENT_HISTORY_select_all_info");
                if (pdId > 0)
                {
                    db.AddInParameter(dbCommand, "pdId", DbType.Int32, pdId);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreDentalHistory(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_DENT_HISTORY_PREVIOUS");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Dental History (Page Load)

        #region  Dental History CRUD Operations
        public static bool InsertUpdateDentalHistory(BusinessEntities.EMR.DentalHistory data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_DENT_HISTORY_INSERT_UPDATE");
                if (data.pdId > 0)
                {
                    db.AddInParameter(dbCommand, "pdId", DbType.Int32, data.pdId);
                }
                db.AddInParameter(dbCommand, "pd_appId", DbType.Int32, data.pd_appId);
                db.AddInParameter(dbCommand, "pd_medicaltreat", DbType.String, data.pd_medicaltreat);
                db.AddInParameter(dbCommand, "pd_hospitalized", DbType.String, data.pd_hospitalized);
                db.AddInParameter(dbCommand, "pd_medications", DbType.String, data.pd_medications);
                db.AddInParameter(dbCommand, "pd_medicationsyes", DbType.String, data.pd_medicationsyes);
                db.AddInParameter(dbCommand, "pd_tobacco", DbType.String, data.pd_tobacco);
                db.AddInParameter(dbCommand, "pd_gums", DbType.String, data.pd_gums);
                db.AddInParameter(dbCommand, "pd_hotcold", DbType.String, data.pd_hotcold);
                db.AddInParameter(dbCommand, "pd_sweetsour", DbType.String, data.pd_sweetsour);
                db.AddInParameter(dbCommand, "pd_teethpain", DbType.String, data.pd_teethpain);
                db.AddInParameter(dbCommand, "pd_soresjumps", DbType.String, data.pd_soresjumps);
                db.AddInParameter(dbCommand, "pd_headinjuries", DbType.String, data.pd_headinjuries);
                db.AddInParameter(dbCommand, "pd_clicking", DbType.String, data.pd_clicking);
                db.AddInParameter(dbCommand, "pd_pain", DbType.String, data.pd_pain);
                db.AddInParameter(dbCommand, "pd_openingclosing", DbType.String, data.pd_openingclosing);
                db.AddInParameter(dbCommand, "pd_chewing", DbType.String, data.pd_chewing);
                db.AddInParameter(dbCommand, "pd_clench", DbType.String, data.pd_clench);
                db.AddInParameter(dbCommand, "pd_bitelips", DbType.String, data.pd_bitelips);
                db.AddInParameter(dbCommand, "pd_difficultextract", DbType.String, data.pd_difficultextract);
                db.AddInParameter(dbCommand, "pd_prolonged", DbType.String, data.pd_prolonged);
                db.AddInParameter(dbCommand, "pd_gems", DbType.String, data.pd_gems);
                db.AddInParameter(dbCommand, "pd_filling", DbType.String, data.pd_filling);
                db.AddInParameter(dbCommand, "pd_w_medicaltreat", DbType.String, data.pd_w_medicaltreat);
                db.AddInParameter(dbCommand, "pd_w_hospitalized", DbType.String, data.pd_w_hospitalized);
                db.AddInParameter(dbCommand, "pd_w_medications", DbType.String, data.pd_w_medications);
                db.AddInParameter(dbCommand, "pd_w_amenorrhoea", DbType.String, data.pd_w_amenorrhoea);
                db.AddInParameter(dbCommand, "pd_last_dental_exam", DbType.String, data.pd_last_dental_exam);
                db.AddInParameter(dbCommand, "pd_madeby", DbType.Int32, data.pd_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int DeleteDentalHistory(int pdId, int pd_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_DENT_HISTORY_delete");

                db.AddInParameter(dbCommand, "pdId", DbType.Int32, pdId);
                db.AddInParameter(dbCommand, "pd_madeby", DbType.String, pd_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Dental History CRUD Operations

        #region  Medical History (Page Load)
        public static DataTable GetAllMedicalHistory(int? appId, int? oeId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_ORAL_EXAM_select_all_info");
                if (oeId > 0)
                {
                    db.AddInParameter(dbCommand, "oeId", DbType.Int32, oeId);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreMedicalHistory(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_ORAL_EXAM_PREVIOUS_History");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Medical History (Page Load)

        #region  Medical History CRUD Operations
        public static bool InsertUpdateMedicalHistory(BusinessEntities.EMR.MedicalHistory data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_ORAL_EXAM_INSERT_UPDATE");
                if (data.oeId > 0)
                {
                    db.AddInParameter(dbCommand, "oeId", DbType.Int32, data.oeId);
                }
                db.AddInParameter(dbCommand, "oe_appId", DbType.Int32, data.oe_appId);
                db.AddInParameter(dbCommand, "oe_present_ill", DbType.String, data.oe_present_ill);
                db.AddInParameter(dbCommand, "oe_pain", DbType.String, data.oe_pain);
                db.AddInParameter(dbCommand, "oe_duration", DbType.String, data.oe_duration);
                db.AddInParameter(dbCommand, "oe_infecious", DbType.String, data.oe_infecious);
                db.AddInParameter(dbCommand, "oe_infecious_other", DbType.String, data.oe_infecious_other);
                db.AddInParameter(dbCommand, "oe_systemic", DbType.String, data.oe_systemic);
                db.AddInParameter(dbCommand, "oe_systemic_other", DbType.String, data.oe_systemic_other);
                db.AddInParameter(dbCommand, "oe_past_med", DbType.String, data.oe_past_med);
                db.AddInParameter(dbCommand, "oe_past_med_other", DbType.String, data.oe_past_med_other);
                db.AddInParameter(dbCommand, "oe_fall_risk", DbType.String, data.oe_fall_risk);
                db.AddInParameter(dbCommand, "oe_fall_risk_other", DbType.String, data.oe_fall_risk_other);
                db.AddInParameter(dbCommand, "oe_fall_risk_type", DbType.String, data.oe_fall_risk_type);
                db.AddInParameter(dbCommand, "oe_notes", DbType.String, data.oe_notes);
                db.AddInParameter(dbCommand, "oe_extra_oral", DbType.String, data.oe_extra_oral);
                db.AddInParameter(dbCommand, "oe_intra_oral", DbType.String, data.oe_intra_oral);
                db.AddInParameter(dbCommand, "oe_oral_notes", DbType.String, data.oe_oral_notes);
                db.AddInParameter(dbCommand, "oe_madeby", DbType.Int32, data.oe_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int DeleteMedicalHistory(int oeId, int oe_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENT_ORAL_EXAM_delete");

                db.AddInParameter(dbCommand, "oeId", DbType.Int32, oeId);
                db.AddInParameter(dbCommand, "oe_madeby", DbType.String, oe_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Medical History CRUD Operations

        #region  DMF Index (Page Load)
        public static DataTable GetAllDMFIndex(int? appId, int? dmfId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DMF_select_all_info");
                if (dmfId > 0)
                {
                    db.AddInParameter(dbCommand, "dmfId", DbType.Int32, dmfId);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreDMFIndex(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DMF_PREVIOUS");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  DMF Index (Page Load)

        #region  DMF Index CRUD Operations
        public static bool InsertUpdateDMFIndex(BusinessEntities.EMR.DMFIndex data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DMF_INSERT_UPDATE");
                if (data.dmfId > 0)
                {
                    db.AddInParameter(dbCommand, "dmfId", DbType.Int32, data.dmfId);
                }
                db.AddInParameter(dbCommand, "dmf_appId", DbType.Int32, data.dmf_appId);
                db.AddInParameter(dbCommand, "dmf_index", DbType.String, data.dmf_index);
                db.AddInParameter(dbCommand, "dmf_other", DbType.String, data.dmf_other);
                db.AddInParameter(dbCommand, "dmf_madeby", DbType.Int32, data.dmf_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int DeleteDMFIndex(int dmfId, int dmf_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DMF_delete");

                db.AddInParameter(dbCommand, "dmfId", DbType.Int32, dmfId);
                db.AddInParameter(dbCommand, "dmf_madeby", DbType.String, dmf_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  DMF Index CRUD Operations

        public static int GenerateCrownOrderNo()
        {
            try
            {
                int scode_output = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GenerateCrownOrderNo");

                db.AddOutParameter(dbCommand, "scode_output", DbType.Int32, 100);

                db.ExecuteScalar(dbCommand);

                scode_output = (int)db.GetParameterValue(dbCommand, "scode_output");

                return scode_output;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
