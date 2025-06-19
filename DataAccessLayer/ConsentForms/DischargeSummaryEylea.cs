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
    public class DischargeSummaryEylea
    {
        public static DataTable GetDischargeSummaryEyleaData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Eylea_Injection_New_Select");

                db.AddInParameter(dbCommand, "dsej_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveDischargeSummaryEylea(BusinessEntities.ConsentForms.DischargeSummaryEylea discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Eylea_Injection_New_Insert");

                db.AddInParameter(dbCommand, "dsej_appId", DbType.Int32, discharge.dsej_appId);
                db.AddInParameter(dbCommand, "dsej_1", DbType.String, string.IsNullOrEmpty(discharge.dsej_1) ? "" : discharge.dsej_1);
                db.AddInParameter(dbCommand, "dsej_2", DbType.String, string.IsNullOrEmpty(discharge.dsej_2) ? "" : discharge.dsej_2);
                db.AddInParameter(dbCommand, "dsej_3", DbType.String, string.IsNullOrEmpty(discharge.dsej_3) ? "" : discharge.dsej_3);
                db.AddInParameter(dbCommand, "dsej_4", DbType.String, string.IsNullOrEmpty(discharge.dsej_4) ? "" : discharge.dsej_4);
                db.AddInParameter(dbCommand, "dsej_5", DbType.String, string.IsNullOrEmpty(discharge.dsej_5) ? "" : discharge.dsej_5);
                db.AddInParameter(dbCommand, "dsej_6", DbType.String, string.IsNullOrEmpty(discharge.dsej_6) ? "" : discharge.dsej_6);
                db.AddInParameter(dbCommand, "dsej_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dsejId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dsejId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dsejId"));
                return _dsejId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteDischargeSummaryEylea(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Eylea_Injection_New_Delete");

                db.AddInParameter(dbCommand, "dsej_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dsej_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dsej_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dsej_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dsej_output"));

                return _dsej_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDischargeSummaryEyleaPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_Eylea_Injection_New_PreviousHistory");

                db.AddInParameter(dbCommand, "dsej_appId", DbType.Int32, appId);
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
