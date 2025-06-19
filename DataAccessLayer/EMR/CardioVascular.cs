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
    public class CardioVascular
    {
        #region CardioSystem
        public static DataTable GetAllCardioVascular(int? appId, int? cvId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CARDIO_VASCULAR_select_all_info");
                if (cvId > 0)
                {
                    db.AddInParameter(dbCommand, "cvId", DbType.Int32, cvId);
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

        public static DataTable GetAllPreCardioVascular(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CARDIO_VASCULAR_PREVIOUS_History");
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

        public static bool InsertUpdateCardioVascular(BusinessEntities.EMR.CardioVascular data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CARDIO_VASCULAR_INSERT_UPDATE");
                if (data.cvId > 0)
                {
                    db.AddInParameter(dbCommand, "cvId", DbType.Int32, data.cvId);
                }
                db.AddInParameter(dbCommand, "cv_appId", DbType.Int32, data.cv_appId);
                db.AddInParameter(dbCommand, "cv_1", DbType.String, data.cv_1);
                db.AddInParameter(dbCommand, "cv_2", DbType.String, data.cv_2);
                db.AddInParameter(dbCommand, "cv_3", DbType.String, data.cv_3);
                db.AddInParameter(dbCommand, "cv_4", DbType.String, data.cv_4);
                db.AddInParameter(dbCommand, "cv_5", DbType.String, data.cv_5);
                db.AddInParameter(dbCommand, "cv_6", DbType.String, data.cv_6);
                db.AddInParameter(dbCommand, "cv_1_type", DbType.String, data.cv_1_type);
                db.AddInParameter(dbCommand, "cv_2_type", DbType.String, data.cv_2_type);
                db.AddInParameter(dbCommand, "cv_3_type", DbType.String, data.cv_3_type);
                db.AddInParameter(dbCommand, "cv_4_type", DbType.String, data.cv_4_type);
                db.AddInParameter(dbCommand, "cv_5_type", DbType.String, data.cv_5_type);
                db.AddInParameter(dbCommand, "cv_6_type", DbType.String, data.cv_6_type);
                db.AddInParameter(dbCommand, "cv_madeby", DbType.Int32, data.cv_madeby);

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

        public static int DeleteCardioVascular(int cvId, int cv_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CARDIO_VASCULAR_delete");

                db.AddInParameter(dbCommand, "cvId", DbType.Int32, cvId);
                db.AddInParameter(dbCommand, "cv_madeby", DbType.String, cv_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion CardioSystem
    }
}
