using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web.Mvc;

namespace DataAccessLayer.EMR
{
    public class Prescription
    {
        #region Prescription (Page Load)
        public static DataTable GetAllPrescription(int? appId, int? preId, string pre_med_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PRESCRIPTIONS_select_all_info");

                if (preId > 0)
                {
                    db.AddInParameter(dbCommand, "preId", DbType.Int32, preId);
                }

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }

                if (pre_med_type != "")
                {
                    db.AddInParameter(dbCommand, "pre_med_type", DbType.String, pre_med_type);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAllPrescriptionPrint(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PRESCRIPTIONS_select_all_info_print");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPrePrescription(int appId, int patId, string pre_med_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PRESCRIPTIONS_PREVIOUS_History");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "pre_med_type", DbType.String, pre_med_type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPrescriptionType(string query, int type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPrescriptionType");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "category", DbType.Int32, type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static DataTable GetMedicine(string query, int type, string plan, int pre_doctor)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetMedicine");

                if (type > 0)
                {
                    db.AddInParameter(dbCommand, "type", DbType.Int32, type);
                }

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "item_ins_plan", DbType.String, plan);
                db.AddInParameter(dbCommand, "pref_empId", DbType.Int32, pre_doctor);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static DataTable GetRouteOfAdmin(string query, string flag)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Routeofadmin_Select_All_Info");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "flag", DbType.String, flag);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        #endregion

        #region Prescription CRUD Operations
        public static int InsertPrescription(BusinessEntities.EMR.Prescription data)
        {
            try
            {
                int preId_output = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PRESCRIPTIONS_insert");

                db.AddInParameter(dbCommand, "pre_appId", DbType.Int32, data.pre_appId);
                db.AddInParameter(dbCommand, "pre_medicine", DbType.Int32, data.pre_medicine);
                db.AddInParameter(dbCommand, "pre_instr", DbType.String, data.pre_instr);
                db.AddInParameter(dbCommand, "pre_type", DbType.String, data.pre_type);
                db.AddInParameter(dbCommand, "pre_qty", DbType.Double, data.pre_qty);
                db.AddInParameter(dbCommand, "pre_qtype", DbType.String, data.pre_qtype);
                db.AddInParameter(dbCommand, "pre_duration", DbType.String, data.pre_duration);
                db.AddInParameter(dbCommand, "pre_temp1", DbType.String, data.pre_temp1);
                db.AddInParameter(dbCommand, "pre_temp2", DbType.String, data.pre_temp2);
                db.AddInParameter(dbCommand, "pre_temp3", DbType.String, data.pre_temp3);
                db.AddInParameter(dbCommand, "pre_temp4", DbType.String, data.pre_temp4);
                db.AddInParameter(dbCommand, "pre_temp5", DbType.String, data.pre_temp5);
                db.AddInParameter(dbCommand, "pre_temp6", DbType.String, data.pre_temp6);
                db.AddInParameter(dbCommand, "pre_madeby", DbType.Int32, data.pre_madeby);
                db.AddInParameter(dbCommand, "pre_oc_code", DbType.String, data.pre_oc_code);
                db.AddInParameter(dbCommand, "pre_oc_type", DbType.String, data.pre_oc_type);
                db.AddInParameter(dbCommand, "pre_ra_code", DbType.String, data.pre_ra_code);
                db.AddInParameter(dbCommand, "pre_ra_type", DbType.String, data.pre_ra_type);
                db.AddInParameter(dbCommand, "pre_med_type", DbType.String, data.pre_med_type);
                db.AddInParameter(dbCommand, "chkyes", DbType.String, data.chkyes);
                db.AddOutParameter(dbCommand, "preId", DbType.Int32, 100);

                int result = db.ExecuteNonQuery(dbCommand);
                preId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "preId").ToString());

                return preId_output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdatePrescription(BusinessEntities.EMR.Prescription data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PRESCRIPTIONS_update");

                db.AddInParameter(dbCommand, "preId", DbType.Int32, data.preId);
                db.AddInParameter(dbCommand, "pre_appId", DbType.Int32, data.pre_appId);
                db.AddInParameter(dbCommand, "pre_medicine", DbType.Int32, data.pre_medicine);
                db.AddInParameter(dbCommand, "pre_instr", DbType.String, data.pre_instr);
                db.AddInParameter(dbCommand, "pre_type", DbType.String, data.pre_type);
                db.AddInParameter(dbCommand, "pre_qty", DbType.Double, data.pre_qty);
                db.AddInParameter(dbCommand, "pre_qtype", DbType.String, data.pre_qtype);
                db.AddInParameter(dbCommand, "pre_duration", DbType.String, data.pre_duration);
                db.AddInParameter(dbCommand, "pre_temp1", DbType.String, data.pre_temp1);
                db.AddInParameter(dbCommand, "pre_temp2", DbType.String, data.pre_temp2);
                db.AddInParameter(dbCommand, "pre_temp3", DbType.String, data.pre_temp3);
                db.AddInParameter(dbCommand, "pre_temp4", DbType.String, data.pre_temp4);
                db.AddInParameter(dbCommand, "pre_temp5", DbType.String, data.pre_temp5);
                db.AddInParameter(dbCommand, "pre_temp6", DbType.String, data.pre_temp6);
                db.AddInParameter(dbCommand, "pre_med_type", DbType.String, data.pre_med_type);
                db.AddInParameter(dbCommand, "pre_modifiedby", DbType.Int32, data.pre_madeby);
                db.AddInParameter(dbCommand, "pre_oc_code", DbType.String, data.pre_oc_code);
                db.AddInParameter(dbCommand, "pre_oc_type", DbType.String, data.pre_oc_type);
                db.AddInParameter(dbCommand, "pre_ra_code", DbType.String, data.pre_ra_code);
                db.AddInParameter(dbCommand, "pre_ra_type", DbType.String, data.pre_ra_type);

                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeletePrescription(int preId, int pre_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PRESCRIPTIONS_delete");
                db.AddInParameter(dbCommand, "preId", DbType.Int32, preId);
                db.AddInParameter(dbCommand, "pre_madeby", DbType.Int32, pre_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataSet PrintPrescription(string preId, int pre_appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prescription_Print");

                if (!string.IsNullOrEmpty(preId))
                {
                    string preIds = string.Join(",", preId.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "preIds", DbType.String, preIds);
                }

                db.AddInParameter(dbCommand, "pre_appId", DbType.Int32, pre_appId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet PrintPrescriptionPD(int pre_appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PatientDiagnosisPrescription");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, pre_appId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Prescription Favourites (Page Load)
        public static DataTable GetAllPrescriptionFavourites(int? empId, int? prefId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Prescription_Favourites");

                if (prefId > 0)
                {
                    db.AddInParameter(dbCommand, "prefId", DbType.Int32, prefId);
                }

                if (empId > 0)
                {
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Prescription Favourites CRUD Operations
        public static int InsertUpdatePrescriptionFavourites(BusinessEntities.EMR.PrescriptionFavourites data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PRESC_FAVOURITES_insert_update");

                if (data.prefId > 0)
                {
                    db.AddInParameter(dbCommand, "prefId", DbType.Int32, data.prefId);
                }

                db.AddInParameter(dbCommand, "pref_medicine", DbType.Int32, data.pref_medicine);
                db.AddInParameter(dbCommand, "pref_instr", DbType.String, data.pref_instr);
                db.AddInParameter(dbCommand, "pref_type", DbType.String, data.pref_type);
                db.AddInParameter(dbCommand, "pref_qty", DbType.Double, data.pref_qty);
                db.AddInParameter(dbCommand, "pref_qtype", DbType.String, data.pref_qtype);
                db.AddInParameter(dbCommand, "pref_duration", DbType.String, data.pref_duration);
                db.AddInParameter(dbCommand, "pref_temp1", DbType.String, data.pref_temp1);
                db.AddInParameter(dbCommand, "pref_temp2", DbType.String, data.pref_temp2);
                db.AddInParameter(dbCommand, "pref_temp3", DbType.String, data.pref_temp3);
                db.AddInParameter(dbCommand, "pref_temp4", DbType.String, data.pref_temp4);
                db.AddInParameter(dbCommand, "pref_temp5", DbType.String, data.pref_temp5);
                db.AddInParameter(dbCommand, "pref_temp6", DbType.String, data.pref_temp6);
                db.AddInParameter(dbCommand, "pref_madeby", DbType.Int32, data.pref_madeby);
                db.AddInParameter(dbCommand, "pref_oc_code", DbType.String, data.pref_oc_code);
                db.AddInParameter(dbCommand, "pref_oc_type", DbType.String, data.pref_oc_type);
                db.AddInParameter(dbCommand, "pref_ra_code", DbType.String, data.pref_ra_code);
                db.AddInParameter(dbCommand, "pref_ra_type", DbType.String, data.pref_ra_type);
                db.AddInParameter(dbCommand, "pref_empId", DbType.Int32, data.pref_empId);

                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeletePrescriptionFavourites(int prefId, int pref_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PRESC_FAVOURITES_delete");

                db.AddInParameter(dbCommand, "prefId", DbType.Int32, prefId);
                db.AddInParameter(dbCommand, "pref_madeby", DbType.Int32, pref_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion 

        #region Prescription Controlled (Page Load)
        public static DataTable GetDrugMedicine(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetDrugMedicine");

                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;

            }

        }

        public static string GetDrugCode(int prec_medicine)
        {
            try
            {
                string item_code = "";
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetDrugCode");

                db.AddInParameter(dbCommand, "prec_medicine", DbType.Int32, prec_medicine);
                object result = db.ExecuteScalar(dbCommand);
                if (result != null)
                {
                    item_code = result.ToString();
                }

                return item_code;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetControlledDrugPrescription(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ControlledDrugs_Prescription");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertControlledDrugs(BusinessEntities.EMR.ControlledDrug data)
        {
            try
            {
                int precId_output = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ControlledDrugs_Prescription_insert");

                db.AddInParameter(dbCommand, "prec_appId", DbType.Int32, data.prec_appId);
                db.AddInParameter(dbCommand, "prec_medicine", DbType.Int32, data.prec_medicine);
                db.AddInParameter(dbCommand, "prec_instr", DbType.String, data.prec_instr);
                db.AddInParameter(dbCommand, "prec_type", DbType.String, data.prec_type);
                db.AddInParameter(dbCommand, "prec_qty", DbType.Double, data.prec_qty);
                db.AddInParameter(dbCommand, "prec_qtype", DbType.String, data.prec_qtype);
                db.AddInParameter(dbCommand, "prec_duration", DbType.String, data.prec_duration);
                db.AddInParameter(dbCommand, "prec_temp1", DbType.String, data.prec_temp1);
                db.AddInParameter(dbCommand, "prec_temp2", DbType.String, data.prec_temp2);
                db.AddInParameter(dbCommand, "prec_temp3", DbType.String, data.prec_temp3);
                db.AddInParameter(dbCommand, "prec_temp4", DbType.String, data.prec_temp4);
                db.AddInParameter(dbCommand, "prec_temp5", DbType.String, data.prec_temp5);
                db.AddInParameter(dbCommand, "prec_temp6", DbType.String, data.prec_temp6);
                db.AddInParameter(dbCommand, "prec_empId", DbType.Int32, data.prec_madeby);
                db.AddInParameter(dbCommand, "prec_oj_code", DbType.String, data.prec_oj_code);
                db.AddInParameter(dbCommand, "prec_oj_type", DbType.String, data.prec_oj_type);
                db.AddInParameter(dbCommand, "prec_status", DbType.String, data.prec_status);
                db.AddOutParameter(dbCommand, "precId", DbType.Int32, 100);

                int result = db.ExecuteNonQuery(dbCommand);
                precId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "precId").ToString());

                return precId_output;


            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region General Prescription (Page Load)
        public static DataTable GetAllGeneralPrescription(int? appId, int? gpreId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_General_Prescriptions");

                if (gpreId > 0)
                {
                    db.AddInParameter(dbCommand, "gpreId", DbType.Int32, gpreId);
                }

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPrevGeneralPrescription(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Previous_General_Prescriptions_History");

                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region General Prescription CRUD Operations
        public static int InsertGeneralPrescription(BusinessEntities.EMR.GeneralPrescription data)
        {
            try
            {
                int gpreId_output = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_General_Prescription_Insert");

                db.AddInParameter(dbCommand, "gpre_appId", DbType.Int32, data.gpre_appId);
                db.AddInParameter(dbCommand, "gpre_desc", DbType.String, data.gpre_desc);
                db.AddInParameter(dbCommand, "gpre_madeby", DbType.Int32, data.gpre_madeby);

                db.AddOutParameter(dbCommand, "gpreId", DbType.Int32, 100);

                int result = db.ExecuteNonQuery(dbCommand);

                gpreId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "gpreId").ToString());

                return gpreId_output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateGeneralPrescription(BusinessEntities.EMR.GeneralPrescription data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_General_Prescription_Update");

                db.AddInParameter(dbCommand, "gpreId", DbType.Int32, data.gpreId);
                db.AddInParameter(dbCommand, "gpre_appId", DbType.Int32, data.gpre_appId);
                db.AddInParameter(dbCommand, "gpre_desc", DbType.String, data.gpre_desc);
                db.AddInParameter(dbCommand, "gpre_modifiedby", DbType.Int32, data.gpre_modifiedby);

                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteGeneralPrescription(int gpreId, int gpre_modifiedby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_General_Prescriptions_Delete");

                db.AddInParameter(dbCommand, "gpreId", DbType.Int32, gpreId);
                db.AddInParameter(dbCommand, "gpre_modifiedby", DbType.Int32, gpre_modifiedby);

                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Prescription Insurance  (Page Load)
        public static int Generate_eRX(int erx_appId, string file_name, string eRx_ReferenceNo, string eRx_ErrorMessage, string preIds, int madeby, string Tr__date2)
        {
            try
            {
                int appId = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ERX_insert");

                db.AddInParameter(dbCommand, "erx_appId", DbType.Int32, erx_appId);
                db.AddInParameter(dbCommand, "erx_date", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "erx_filename", DbType.String, file_name);
                db.AddInParameter(dbCommand, "erx_ReferenceNo", DbType.String, eRx_ReferenceNo);
                db.AddInParameter(dbCommand, "erx_ErrorMessage", DbType.String, eRx_ErrorMessage);
                db.AddInParameter(dbCommand, "erx_ErrorReport", DbType.String, "");
                db.AddInParameter(dbCommand, "erx_madeby", DbType.Int32, madeby);
                db.AddInParameter(dbCommand, "preIds", DbType.String, preIds);
                db.AddInParameter(dbCommand, "pre_qtype", DbType.String, Tr__date2);

                int result = db.ExecuteNonQuery(dbCommand);

                appId = Convert.ToInt32(db.GetParameterValue(dbCommand, "erx_appId").ToString());

                return appId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Cancel erX Prescription
        public static int Generate_Cancel_eRX(int erx_appId, string file_name, string eRx_ReferenceNo, string eRx_ErrorMessage, string preIds, int madeby, string Tr__date2)
        {
            try
            {
                int appId = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Cancel_ERX_insert");

                db.AddInParameter(dbCommand, "erx_appId", DbType.Int32, erx_appId);
                db.AddInParameter(dbCommand, "erx_date", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "erx_filename", DbType.String, file_name);
                db.AddInParameter(dbCommand, "erx_ReferenceNo", DbType.String, eRx_ReferenceNo);
                db.AddInParameter(dbCommand, "erx_ErrorMessage", DbType.String, eRx_ErrorMessage);
                db.AddInParameter(dbCommand, "erx_ErrorReport", DbType.String, "Cancellation");
                db.AddInParameter(dbCommand, "erx_madeby", DbType.Int32, madeby);
                db.AddInParameter(dbCommand, "preIds", DbType.String, preIds);
                db.AddInParameter(dbCommand, "pre_qtype", DbType.String, Tr__date2);

                int result = db.ExecuteNonQuery(dbCommand);

                appId = Convert.ToInt32(db.GetParameterValue(dbCommand, "erx_appId").ToString());

                return appId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region eRX Submissions
        public static DataTable Geterx_Prescription(string preIds)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Geterx_Prescription");

                db.AddInParameter(dbCommand, "preIds", DbType.String, preIds);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GeterxSubmissions(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Geterx_Submissions");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public static DataSet GetPatientEMRInfoPresc(int? appId, string preIds)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPatAppInfoEMRPresc");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                db.AddInParameter(dbCommand, "preIds", DbType.String, preIds);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}