using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.NurseStation
{
    public class ReviewofSystems
    {
        #region ROS
        public static DataTable GetAllReviewofSystems(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_REVIEW_SYSTEMS_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreReviewofSystems(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_REVIEW_SYSTEMS_PREVIOUS_History");
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

        public static bool InsertUpdateReviewofSystems(BusinessEntities.NurseStation.ReviewofSystems data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_REVIEW_SYSTEMS_INSERT_UPDATE");
                if (data.rsId > 0)
                {
                    db.AddInParameter(dbCommand, "rsId", DbType.Int32, data.rsId);
                }
                db.AddInParameter(dbCommand, "rs_appId", DbType.Int32, data.rs_appId);
                db.AddInParameter(dbCommand, "rs_1", DbType.String, data.rs_1);
                db.AddInParameter(dbCommand, "rs_2", DbType.String, data.rs_2);
                db.AddInParameter(dbCommand, "rs_3", DbType.String, data.rs_3);
                db.AddInParameter(dbCommand, "rs_4", DbType.String, data.rs_4);
                db.AddInParameter(dbCommand, "rs_5", DbType.String, data.rs_5);
                db.AddInParameter(dbCommand, "rs_6", DbType.String, data.rs_6);
                db.AddInParameter(dbCommand, "rs_7", DbType.String, data.rs_7);
                db.AddInParameter(dbCommand, "rs_8", DbType.String, data.rs_8);
                db.AddInParameter(dbCommand, "rs_9", DbType.String, data.rs_9);
                db.AddInParameter(dbCommand, "rs_10", DbType.String, data.rs_10);
                db.AddInParameter(dbCommand, "rs_11", DbType.String, data.rs_11);
                db.AddInParameter(dbCommand, "rs_12", DbType.String, data.rs_12);
                db.AddInParameter(dbCommand, "rs_13", DbType.String, data.rs_13);
                db.AddInParameter(dbCommand, "rs_14", DbType.String, data.rs_14);
                db.AddInParameter(dbCommand, "rs_15", DbType.String, data.rs_15);
                db.AddInParameter(dbCommand, "rs_16", DbType.String, data.rs_16);
                db.AddInParameter(dbCommand, "rs_1_type", DbType.String, data.rs_1_type);
                db.AddInParameter(dbCommand, "rs_2_type", DbType.String, data.rs_2_type);
                db.AddInParameter(dbCommand, "rs_3_type", DbType.String, data.rs_3_type);
                db.AddInParameter(dbCommand, "rs_4_type", DbType.String, data.rs_4_type);
                db.AddInParameter(dbCommand, "rs_5_type", DbType.String, data.rs_5_type);
                db.AddInParameter(dbCommand, "rs_6_type", DbType.String, data.rs_6_type);
                db.AddInParameter(dbCommand, "rs_7_type", DbType.String, data.rs_7_type);
                db.AddInParameter(dbCommand, "rs_8_type", DbType.String, data.rs_8_type);
                db.AddInParameter(dbCommand, "rs_9_type", DbType.String, data.rs_9_type);
                db.AddInParameter(dbCommand, "rs_10_type", DbType.String, data.rs_10_type);
                db.AddInParameter(dbCommand, "rs_11_type", DbType.String, data.rs_11_type);
                db.AddInParameter(dbCommand, "rs_12_type", DbType.String, data.rs_12_type);
                db.AddInParameter(dbCommand, "rs_13_type", DbType.String, data.rs_13_type);
                db.AddInParameter(dbCommand, "rs_14_type", DbType.String, data.rs_14_type);
                db.AddInParameter(dbCommand, "rs_15_type", DbType.String, data.rs_15_type);
                db.AddInParameter(dbCommand, "rs_16_type", DbType.String, data.rs_16_type);
                db.AddInParameter(dbCommand, "rs_comments", DbType.String, data.rs_comments);
                db.AddInParameter(dbCommand, "rs_madeby", DbType.Int32, data.rs_madeby);
                db.AddInParameter(dbCommand, "rs_modifyby", DbType.Int32, data.rs_madeby);

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


        public static int DeleteReviewofSystems(int rsId,  int rs_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_REVIEW_SYSTEMS_delete");

                db.AddInParameter(dbCommand, "rsId", DbType.Int32, rsId);
                db.AddInParameter(dbCommand, "rs_modifyby", DbType.String, rs_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion ROS
    }
}
