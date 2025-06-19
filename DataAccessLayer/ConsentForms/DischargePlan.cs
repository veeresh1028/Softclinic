using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConsentForms
{
    public class DischargePlan
    {
        public static DataTable GetDischargePlanData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Plan_New_Select");

                db.AddInParameter(dbCommand, "dpn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDischargePlan(BusinessEntities.ConsentForms.DischargePlan ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Plan_New_Insert");

                db.AddInParameter(dbCommand, "dpn_appId", DbType.Int32, ophtha.dpn_appId);
                db.AddInParameter(dbCommand, "dpn_1", DbType.String, string.IsNullOrEmpty(ophtha.dpn_1) ? "" : ophtha.dpn_1);
                db.AddInParameter(dbCommand, "dpn_2", DbType.String, string.IsNullOrEmpty(ophtha.dpn_2) ? "" : ophtha.dpn_2);
                db.AddInParameter(dbCommand, "dpn_3", DbType.String, string.IsNullOrEmpty(ophtha.dpn_3) ? "" : ophtha.dpn_3);
                db.AddInParameter(dbCommand, "dpn_4", DbType.String, string.IsNullOrEmpty(ophtha.dpn_4) ? "" : ophtha.dpn_4);
                db.AddInParameter(dbCommand, "dpn_5", DbType.String, string.IsNullOrEmpty(ophtha.dpn_5) ? "" : ophtha.dpn_5);
                db.AddInParameter(dbCommand, "dpn_6", DbType.String, string.IsNullOrEmpty(ophtha.dpn_6) ? "" : ophtha.dpn_6);
               

                db.AddInParameter(dbCommand, "dpn_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dpnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dpnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dpnId"));
                return _dpnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDischargePlan(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Plan_New_Delete");

                db.AddInParameter(dbCommand, "dpn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dpn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dpn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dpn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dpn_output"));

                return _dpn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDischargePlanPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Plan_New_PreviousHistory");

                db.AddInParameter(dbCommand, "dpn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
