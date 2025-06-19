using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMR
{
    public class GeneralExamination
    {

        #region GeneralExam
        public static DataTable GetAllGeneralExamination(int? appId,int? geId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GENERAL_EXAMINATION_select_all_info");
                if (geId > 0)
                {
                    db.AddInParameter(dbCommand, "geId", DbType.Int32, geId);
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

        public static DataTable GetAllPreGeneralExamination(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GENERAL_EXAMINATION_PREVIOUS_History");
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

        public static bool InsertUpdateGeneralExamination(BusinessEntities.EMR.GeneralExamination data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GENERAL_EXAMINATION_INSERT_UPDATE");
                if (data.geId > 0)
                {
                    db.AddInParameter(dbCommand, "geId", DbType.Int32, data.geId);
                }
                db.AddInParameter(dbCommand, "ge_appId", DbType.Int32, data.ge_appId);
                db.AddInParameter(dbCommand, "ge_1", DbType.String, data.ge_1);
                db.AddInParameter(dbCommand, "ge_2", DbType.String, data.ge_2);
                db.AddInParameter(dbCommand, "ge_3", DbType.String, data.ge_3);
                db.AddInParameter(dbCommand, "ge_4", DbType.String, data.ge_4);
                db.AddInParameter(dbCommand, "ge_5", DbType.String, data.ge_5);
                db.AddInParameter(dbCommand, "ge_6", DbType.String, data.ge_6);
                db.AddInParameter(dbCommand, "ge_7", DbType.String, data.ge_7);
                db.AddInParameter(dbCommand, "ge_8", DbType.String, data.ge_8);
                db.AddInParameter(dbCommand, "ge_9", DbType.String, data.ge_9);
                db.AddInParameter(dbCommand, "ge_10", DbType.String, data.ge_10);
                db.AddInParameter(dbCommand, "ge_11", DbType.String, data.ge_11);
                db.AddInParameter(dbCommand, "ge_12", DbType.String, data.ge_12);
                db.AddInParameter(dbCommand, "ge_13", DbType.String, data.ge_13);
                db.AddInParameter(dbCommand, "ge_14", DbType.String, data.ge_14);
                db.AddInParameter(dbCommand, "ge_15", DbType.String, data.ge_15);
                db.AddInParameter(dbCommand, "ge_16", DbType.String, data.ge_16);
                db.AddInParameter(dbCommand, "ge_17", DbType.String, data.ge_17);
                db.AddInParameter(dbCommand, "ge_18", DbType.String, data.ge_18);
                db.AddInParameter(dbCommand, "ge_19", DbType.String, data.ge_19);
                db.AddInParameter(dbCommand, "ge_20", DbType.String, data.ge_20);
                db.AddInParameter(dbCommand, "ge_21", DbType.String, data.ge_21);
                db.AddInParameter(dbCommand, "ge_22", DbType.String, data.ge_22);
                db.AddInParameter(dbCommand, "ge_23", DbType.String, data.ge_23);
                db.AddInParameter(dbCommand, "ge_24", DbType.String, data.ge_24);
                db.AddInParameter(dbCommand, "ge_25", DbType.String, data.ge_25);
                db.AddInParameter(dbCommand, "ge_1_type", DbType.String, data.ge_1_type);
                db.AddInParameter(dbCommand, "ge_2_type", DbType.String, data.ge_2_type);
                db.AddInParameter(dbCommand, "ge_3_type", DbType.String, data.ge_3_type);
                db.AddInParameter(dbCommand, "ge_4_type", DbType.String, data.ge_4_type);
                db.AddInParameter(dbCommand, "ge_5_type", DbType.String, data.ge_5_type);
                db.AddInParameter(dbCommand, "ge_6_type", DbType.String, data.ge_6_type);
                db.AddInParameter(dbCommand, "ge_7_type", DbType.String, data.ge_7_type);
                db.AddInParameter(dbCommand, "ge_8_type", DbType.String, data.ge_8_type);
                db.AddInParameter(dbCommand, "ge_9_type", DbType.String, data.ge_9_type);
                db.AddInParameter(dbCommand, "ge_10_type", DbType.String, data.ge_10_type);
                db.AddInParameter(dbCommand, "ge_11_type", DbType.String, data.ge_11_type);
                db.AddInParameter(dbCommand, "ge_12_type", DbType.String, data.ge_12_type);
                db.AddInParameter(dbCommand, "ge_13_type", DbType.String, data.ge_13_type);
                db.AddInParameter(dbCommand, "ge_14_type", DbType.String, data.ge_14_type);
                db.AddInParameter(dbCommand, "ge_15_type", DbType.String, data.ge_15_type);
                db.AddInParameter(dbCommand, "ge_16_type", DbType.String, data.ge_16_type);
                db.AddInParameter(dbCommand, "ge_17_type", DbType.String, data.ge_17_type);
                db.AddInParameter(dbCommand, "ge_18_type", DbType.String, data.ge_18_type);
                db.AddInParameter(dbCommand, "ge_19_type", DbType.String, data.ge_19_type);
                db.AddInParameter(dbCommand, "ge_20_type", DbType.String, data.ge_20_type);
                db.AddInParameter(dbCommand, "ge_21_type", DbType.String, data.ge_21_type);
                db.AddInParameter(dbCommand, "ge_22_type", DbType.String, data.ge_22_type);
                db.AddInParameter(dbCommand, "ge_23_type", DbType.String, data.ge_23_type);
                db.AddInParameter(dbCommand, "ge_24_type", DbType.String, data.ge_24_type);
                db.AddInParameter(dbCommand, "ge_25_type", DbType.String, data.ge_25_type);
                db.AddInParameter(dbCommand, "ge_madeby", DbType.Int32, data.ge_madeby);

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

        public static int DeleteGeneralExamination(int geId, int ge_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GENERAL_EXAMINATION_delete");

                db.AddInParameter(dbCommand, "geId", DbType.Int32, geId);
                db.AddInParameter(dbCommand, "ge_madeby", DbType.String, ge_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion GeneralExam
    }
}
