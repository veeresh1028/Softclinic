using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMR
{
    public class OralExamination
    {
        #region  Extra Oral Examination (Page Load)
        public static DataTable GetAllExtraOralExam(int? appId, int? ceoId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EXTRA_ORAL_select_all_info");
                if (ceoId > 0)
                {
                    db.AddInParameter(dbCommand, "ceoId", DbType.Int32, ceoId);
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

        public static DataTable GetAllPreExtraOralExam(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EXTRA_ORAL_PREVIOUS_History");
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
        #endregion  Extra Oral Examination (Page Load)

        #region  Extra Oral Examination CRUD Operations
        public static bool InsertUpdateExtraOralExam(BusinessEntities.EMR.ExtraOralExam data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EXTRA_ORAL_INSERT_UPDATE");
                if (data.ceoId > 0)
                {
                    db.AddInParameter(dbCommand, "ceoId", DbType.Int32, data.ceoId);
                }
                db.AddInParameter(dbCommand, "ceo_appId", DbType.Int32, data.ceo_appId);
                db.AddInParameter(dbCommand, "ceo_1", DbType.String, data.ceo_1);
                db.AddInParameter(dbCommand, "ceo_2", DbType.String, data.ceo_2);
                db.AddInParameter(dbCommand, "ceo_3", DbType.String, data.ceo_3);
                db.AddInParameter(dbCommand, "ceo_4", DbType.String, data.ceo_4);
                db.AddInParameter(dbCommand, "ceo_5", DbType.String, data.ceo_5);
                db.AddInParameter(dbCommand, "ceo_6", DbType.String, data.ceo_6);
                db.AddInParameter(dbCommand, "ceo_7", DbType.String, data.ceo_7);
                db.AddInParameter(dbCommand, "ceo_8", DbType.String, data.ceo_8);
                db.AddInParameter(dbCommand, "ceo_9", DbType.String, data.ceo_9);
                db.AddInParameter(dbCommand, "ceo_10", DbType.String, data.ceo_10);
                db.AddInParameter(dbCommand, "ceo_11", DbType.String, data.ceo_11);
                db.AddInParameter(dbCommand, "ceo_12", DbType.String, data.ceo_12);
                
                db.AddInParameter(dbCommand, "ceo_madeby", DbType.Int32, data.ceo_madeby);

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

        public static int DeleteExtraOralExam(int ceoId, int ceo_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EXTRA_ORAL_delete");

                db.AddInParameter(dbCommand, "ceoId", DbType.Int32, ceoId);
                db.AddInParameter(dbCommand, "ceo_madeby", DbType.String, ceo_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Extra Oral Examination CRUD Operations

        #region  IntraOral SoftTissue (Page Load)
        public static DataTable GetAllIntraOralSoftTissue(int? appId, int? cstId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SOFT_TISSUE_select_all_info");
                if (cstId > 0)
                {
                    db.AddInParameter(dbCommand, "cstId", DbType.Int32, cstId);
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

        public static DataTable GetAllPreIntraOralSoftTissue(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SOFT_TISSUE_PREVIOUS_History");
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
        #endregion  IntraOral SoftTissue (Page Load)

        #region  IntraOral SoftTissue CRUD Operations
        public static bool InsertUpdateIntraOralSoftTissue(BusinessEntities.EMR.IntraOralSoftTissue data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SOFT_TISSUE_INSERT_UPDATE");
                if (data.cstId > 0)
                {
                    db.AddInParameter(dbCommand, "cstId", DbType.Int32, data.cstId);
                }
                db.AddInParameter(dbCommand, "cst_appId", DbType.Int32, data.cst_appId);
                db.AddInParameter(dbCommand, "cst_1", DbType.String, data.cst_1);
                db.AddInParameter(dbCommand, "cst_2", DbType.String, data.cst_2);
                db.AddInParameter(dbCommand, "cst_3", DbType.String, data.cst_3);
                db.AddInParameter(dbCommand, "cst_4", DbType.String, data.cst_4);
                db.AddInParameter(dbCommand, "cst_5", DbType.String, data.cst_5);
                db.AddInParameter(dbCommand, "cst_6", DbType.String, data.cst_6);
                db.AddInParameter(dbCommand, "cst_7", DbType.String, data.cst_7);
                db.AddInParameter(dbCommand, "cst_8", DbType.String, data.cst_8);
                db.AddInParameter(dbCommand, "cst_9", DbType.String, data.cst_9);
                db.AddInParameter(dbCommand, "cst_10", DbType.String, data.cst_10);
                db.AddInParameter(dbCommand, "cst_11", DbType.String, data.cst_11);
                db.AddInParameter(dbCommand, "cst_12", DbType.String, data.cst_12);
                db.AddInParameter(dbCommand, "cst_13", DbType.String, data.cst_13);
                db.AddInParameter(dbCommand, "cst_14", DbType.String, data.cst_14);
                db.AddInParameter(dbCommand, "cst_15", DbType.String, data.cst_15);
                db.AddInParameter(dbCommand, "cst_16", DbType.String, data.cst_16);
                db.AddInParameter(dbCommand, "cst_17", DbType.String, data.cst_17);
                db.AddInParameter(dbCommand, "cst_18", DbType.String, data.cst_18);
                db.AddInParameter(dbCommand, "cst_19", DbType.String, data.cst_19);
                db.AddInParameter(dbCommand, "cst_20", DbType.String, data.cst_20);
                db.AddInParameter(dbCommand, "cst_21", DbType.String, data.cst_21);
                db.AddInParameter(dbCommand, "cst_22", DbType.String, data.cst_22);
                db.AddInParameter(dbCommand, "cst_23", DbType.String, data.cst_23);
                db.AddInParameter(dbCommand, "cst_24", DbType.String, data.cst_24);
                db.AddInParameter(dbCommand, "cst_25", DbType.String, data.cst_25);
                db.AddInParameter(dbCommand, "cst_26", DbType.String, data.cst_26);
                db.AddInParameter(dbCommand, "cst_27", DbType.String, data.cst_27);
                db.AddInParameter(dbCommand, "cst_28", DbType.String, data.cst_28);
                db.AddInParameter(dbCommand, "cst_29", DbType.String, data.cst_29);
                db.AddInParameter(dbCommand, "cst_30", DbType.String, data.cst_30);
                db.AddInParameter(dbCommand, "cst_31", DbType.String, data.cst_31);
                db.AddInParameter(dbCommand, "cst_32", DbType.String, data.cst_32);
                db.AddInParameter(dbCommand, "cst_madeby", DbType.Int32, data.cst_madeby);

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

        public static int DeleteIntraOralSoftTissue(int cstId, int cst_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SOFT_TISSUE_delete");

                db.AddInParameter(dbCommand, "cstId", DbType.Int32, cstId);
                db.AddInParameter(dbCommand, "cst_madeby", DbType.String, cst_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  IntraOral SoftTissue CRUD Operations

        #region  IntraOral HardTissue (Page Load)
        public static DataTable GetAllIntraOralHardTissue(int? appId, int? chtId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HARD_TISSUE_select_all_info");
                if (chtId > 0)
                {
                    db.AddInParameter(dbCommand, "chtId", DbType.Int32, chtId);
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
        public static DataTable GetHardTissueTooth(int? chtd_chtId, int? chtdId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HARD_TISSUETOOTH_select_all_info");
                if (chtdId > 0)
                {
                    db.AddInParameter(dbCommand, "chtdId", DbType.Int32, chtdId);
                }
                if (chtd_chtId > 0)
                {
                    db.AddInParameter(dbCommand, "chtd_chtId", DbType.Int32, chtd_chtId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreIntraOralHardTissue(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HARD_TISSUE_PREVIOUS_History");
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

        public static DataTable GetToothSurface(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetToothSurface");
                
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;

            }

        }
        #endregion  IntraOral HardTissue (Page Load)

        #region  IntraOral HardTissue CRUD Operations
        public static int InsertUpdateIntraOralHardTissues(BusinessEntities.EMR.IntraOralHardTissue data,int cht_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HARD_TISSUE_INSERT_UPDATE");
                if (data.chtId > 0)
                {
                    db.AddInParameter(dbCommand, "chtId", DbType.Int32, data.chtId);
                }
                db.AddInParameter(dbCommand, "cht_appId", DbType.Int32, data.cht_appId);
                db.AddInParameter(dbCommand, "cht_1", DbType.String, data.cht_1);
                db.AddInParameter(dbCommand, "cht_2", DbType.String, data.cht_2);
                db.AddInParameter(dbCommand, "cht_3", DbType.String, data.cht_3);
                db.AddInParameter(dbCommand, "cht_4", DbType.String, data.cht_4);
                db.AddInParameter(dbCommand, "cht_5", DbType.String, data.cht_5);
                db.AddInParameter(dbCommand, "cht_6", DbType.String, data.cht_6);
                db.AddInParameter(dbCommand, "cht_7", DbType.String, data.cht_7);
                db.AddInParameter(dbCommand, "cht_8", DbType.String, data.cht_8);
                db.AddInParameter(dbCommand, "cht_9", DbType.String, data.cht_9);
                db.AddInParameter(dbCommand, "cht_10", DbType.String, data.cht_10);
                db.AddInParameter(dbCommand, "cht_11", DbType.String, data.cht_11);
                db.AddInParameter(dbCommand, "cht_12", DbType.String, data.cht_12);
                db.AddInParameter(dbCommand, "cht_13", DbType.String, data.cht_13);
                db.AddInParameter(dbCommand, "cht_14", DbType.String, data.cht_14);
                db.AddInParameter(dbCommand, "cht_15", DbType.String, data.cht_15);
                db.AddInParameter(dbCommand, "cht_16", DbType.String, data.cht_16);
                db.AddInParameter(dbCommand, "cht_17", DbType.String, data.cht_17);
                db.AddInParameter(dbCommand, "cht_18", DbType.String, data.cht_18);
                db.AddInParameter(dbCommand, "cht_madeby", DbType.Int32, cht_madeby);

                //int result = db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.ExecuteNonQuery(dbCommand));
                //if (result > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static int InsertUpdateHardTissuetooth(BusinessEntities.EMR.HardTissue_tooth data,int chtId, int cht_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HARD_TISSUETOOTH_INSERT_UPDATE");
                if (data.chtdId > 0)
                {
                    db.AddInParameter(dbCommand, "chtdId", DbType.Int32, data.chtdId);
                }
                db.AddInParameter(dbCommand, "chtd_chtId", DbType.Int32, chtId);
                db.AddInParameter(dbCommand, "chtd_appId", DbType.Int32, data.chtd_appId);
                db.AddInParameter(dbCommand, "chtd_1", DbType.String, data.chtd_1);
                db.AddInParameter(dbCommand, "chtd_2", DbType.String, data.chtd_2);
                db.AddInParameter(dbCommand, "chtd_3", DbType.String, data.chtd_3);
                
                db.AddInParameter(dbCommand, "chtd_madeby", DbType.Int32, cht_madeby);

                //int result = db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.ExecuteNonQuery(dbCommand));
                //if (result > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int DeleteIntraOralHardTissue(int chtId, int cht_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HARD_TISSUE_delete");

                db.AddInParameter(dbCommand, "chtId", DbType.Int32, chtId);
                db.AddInParameter(dbCommand, "cht_madeby", DbType.String, cht_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                if (result > 0)
                {
                    DbCommand dbCommand1 = db.GetStoredProcCommand("SP_HARD_TISSUE_delete");

                    db.AddInParameter(dbCommand1, "chtId", DbType.Int32, chtId);
                    db.AddInParameter(dbCommand1, "cht_madeby", DbType.String, cht_madeby);
                    int result1 = db.ExecuteNonQuery(dbCommand1);
                }
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int DeleteHardTissueTooth(int chtdId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_HARD_TISSUETOOTH_delete");
                db.AddInParameter(dbCommand, "chtdId", DbType.Int32, chtdId);
                db.AddInParameter(dbCommand, "chtd_madeby", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion  IntraOral HardTissue CRUD Operations
    }
}
