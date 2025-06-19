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
    public class LaserTherapySheet
    {
        #region  Monthly Evaluation (Page Load)
        public static DataTable GetAllLaserTherapySheet(int? appId, int? ltsId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Therapy_Sheet_select_all_info");
                if (ltsId > 0)
                {
                    db.AddInParameter(dbCommand, "ltsId", DbType.Int32, ltsId);
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
                throw ex;
            }
        }

        public static DataTable GetAllPreLaserTherapySheet(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Therapy_Sheet_Previous");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion  Monthly Evaluation (Page Load)

        #region  Monthly Evaluation CRUD Operations
        public static bool InsertUpdateLaserTherapySheet(BusinessEntities.EMR.LaserTherapySheet data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Therapy_Sheet_Insert_Update");
                if (data.ltsId > 0)
                {
                    db.AddInParameter(dbCommand, "ltsId", DbType.Int32, data.ltsId);
                }
                db.AddInParameter(dbCommand, "lts_appId", DbType.Int32, data.lts_appId);
                db.AddInParameter(dbCommand, "lts_session", DbType.String, data.lts_session);
                db.AddInParameter(dbCommand, "lts_bodypart", DbType.String, data.lts_bodypart);
                db.AddInParameter(dbCommand, "lts_skintype", DbType.String, data.lts_skintype);
                db.AddInParameter(dbCommand, "lts_flu_alex", DbType.String, data.lts_flu_alex);
                db.AddInParameter(dbCommand, "lts_flu_nd", DbType.String, data.lts_flu_nd);
                db.AddInParameter(dbCommand, "lts_remarks", DbType.String, data.lts_remarks);
                db.AddInParameter(dbCommand, "lts_offer", DbType.String, data.lts_offer);
                db.AddInParameter(dbCommand, "lts_date", DbType.DateTime, data.lts_date);
                db.AddInParameter(dbCommand, "lts_madeby", DbType.Int32, data.lts_madeby);

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
                throw ex;
            }
        }

        public static int DeleteLaserTherapySheet(int ltsId, int lts_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Laser_Therapy_Sheet_delete");

                db.AddInParameter(dbCommand, "ltsId", DbType.Int32, ltsId);
                db.AddInParameter(dbCommand, "lts_madeby", DbType.String, lts_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion  Monthly Evaluation CRUD Operations
    }
}
