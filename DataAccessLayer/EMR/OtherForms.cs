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
    public class OtherForms
    {
        #region  Monthly Evaluation (Page Load)
        public static DataTable GetAllReferal(int? appId, int? rId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Referals_select_all_info");
                if (rId > 0)
                {
                    db.AddInParameter(dbCommand, "rId", DbType.Int32, rId);
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

        public static DataTable GetAllPreReferal(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Referals_Previous");
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
        public static bool InsertUpdateReferal(BusinessEntities.EMR.Referal data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Referals_Insert_Update");
                if (data.rId > 0)
                {
                    db.AddInParameter(dbCommand, "rId", DbType.Int32, data.rId);
                }
                db.AddInParameter(dbCommand, "r_appId", DbType.Int32, data.r_appId);
                db.AddInParameter(dbCommand, "r_to", DbType.String, data.r_to);
                db.AddInParameter(dbCommand, "r_mrno", DbType.String, data.r_mrno);
                db.AddInParameter(dbCommand, "r_type", DbType.String, data.r_type);
                db.AddInParameter(dbCommand, "r_reason", DbType.String, data.r_reason);
                db.AddInParameter(dbCommand, "r_history", DbType.String, data.r_history);
                db.AddInParameter(dbCommand, "r_phy", DbType.String, data.r_phy);
                db.AddInParameter(dbCommand, "r_inv", DbType.String, data.r_inv);
                db.AddInParameter(dbCommand, "r_pro", DbType.String, data.r_pro);
                db.AddInParameter(dbCommand, "r_rec", DbType.String, data.r_rec);
                db.AddInParameter(dbCommand, "r_med", DbType.String, data.r_med);
                db.AddInParameter(dbCommand, "r_date", DbType.DateTime, data.r_date);
                db.AddInParameter(dbCommand, "r_madeby", DbType.Int32, data.r_madeby);

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

        public static int DeleteReferal(int rId, int r_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Referals_delete");

                db.AddInParameter(dbCommand, "rId", DbType.Int32, rId);
                db.AddInParameter(dbCommand, "r_madeby", DbType.String, r_madeby);
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
