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
    public class MedicalHistoryNew
    {
        public static DataTable GetMedicalHistoryNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_History_New_Select");

                db.AddInParameter(dbCommand, "mhn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveMedicalHistoryNew(BusinessEntities.ConsentForms.MedicalHistoryNew derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_History_New_Insert");

                db.AddInParameter(dbCommand, "mhn_appId", DbType.Int32, derma.mhn_appId);
                db.AddInParameter(dbCommand, "mhn_1", DbType.String, string.IsNullOrEmpty(derma.mhn_1) ? "" : derma.mhn_1);
                db.AddInParameter(dbCommand, "mhn_2", DbType.String, string.IsNullOrEmpty(derma.mhn_2) ? "" : derma.mhn_2);
                db.AddInParameter(dbCommand, "mhn_3", DbType.String, string.IsNullOrEmpty(derma.mhn_3) ? "" : derma.mhn_3);
                db.AddInParameter(dbCommand, "mhn_4", DbType.String, string.IsNullOrEmpty(derma.mhn_4) ? "" : derma.mhn_4);
                db.AddInParameter(dbCommand, "mhn_5", DbType.String, string.IsNullOrEmpty(derma.mhn_5) ? "" : derma.mhn_5);
                db.AddInParameter(dbCommand, "mhn_6", DbType.String, string.IsNullOrEmpty(derma.mhn_6) ? "" : derma.mhn_6);
                db.AddInParameter(dbCommand, "mhn_7", DbType.String, string.IsNullOrEmpty(derma.mhn_7) ? "" : derma.mhn_7);
                db.AddInParameter(dbCommand, "mhn_8", DbType.String, string.IsNullOrEmpty(derma.mhn_8) ? "" : derma.mhn_8);
                db.AddInParameter(dbCommand, "mhn_9", DbType.String, string.IsNullOrEmpty(derma.mhn_9) ? "" : derma.mhn_9);
                db.AddInParameter(dbCommand, "mhn_10", DbType.String, string.IsNullOrEmpty(derma.mhn_10) ? "" : derma.mhn_10);
                db.AddInParameter(dbCommand, "mhn_11", DbType.String, string.IsNullOrEmpty(derma.mhn_11) ? "" : derma.mhn_11);
                db.AddInParameter(dbCommand, "mhn_12", DbType.String, string.IsNullOrEmpty(derma.mhn_12) ? "" : derma.mhn_12);
                db.AddInParameter(dbCommand, "mhn_13", DbType.String, string.IsNullOrEmpty(derma.mhn_13) ? "" : derma.mhn_13);
               
                db.AddInParameter(dbCommand, "mhn_radio1", DbType.String, string.IsNullOrEmpty(derma.mhn_radio1) ? "" : derma.mhn_radio1);
                db.AddInParameter(dbCommand, "mhn_radio2", DbType.String, string.IsNullOrEmpty(derma.mhn_radio2) ? "" : derma.mhn_radio2);
                db.AddInParameter(dbCommand, "mhn_radio3", DbType.String, string.IsNullOrEmpty(derma.mhn_radio3) ? "" : derma.mhn_radio3);
                db.AddInParameter(dbCommand, "mhn_radio4", DbType.String, string.IsNullOrEmpty(derma.mhn_radio4) ? "" : derma.mhn_radio4);
                db.AddInParameter(dbCommand, "mhn_radio5", DbType.String, string.IsNullOrEmpty(derma.mhn_radio5) ? "" : derma.mhn_radio5);
                db.AddInParameter(dbCommand, "mhn_radio6", DbType.String, string.IsNullOrEmpty(derma.mhn_radio6) ? "" : derma.mhn_radio6);
                db.AddInParameter(dbCommand, "mhn_radio7", DbType.String, string.IsNullOrEmpty(derma.mhn_radio7) ? "" : derma.mhn_radio7);
                db.AddInParameter(dbCommand, "mhn_radio8", DbType.String, string.IsNullOrEmpty(derma.mhn_radio8) ? "" : derma.mhn_radio8);
                db.AddInParameter(dbCommand, "mhn_radio9", DbType.String, string.IsNullOrEmpty(derma.mhn_radio9) ? "" : derma.mhn_radio9);
                db.AddInParameter(dbCommand, "mhn_radio10", DbType.String, string.IsNullOrEmpty(derma.mhn_radio10) ? "" : derma.mhn_radio10);
                db.AddInParameter(dbCommand, "mhn_radio11", DbType.String, string.IsNullOrEmpty(derma.mhn_radio11) ? "" : derma.mhn_radio11);
                db.AddInParameter(dbCommand, "mhn_radio12", DbType.String, string.IsNullOrEmpty(derma.mhn_radio12) ? "" : derma.mhn_radio12);
              
                db.AddInParameter(dbCommand, "mhn_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "mhnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _mhnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "mhnId"));
                return _mhnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteMedicalHistoryNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_History_New_Delete");

                db.AddInParameter(dbCommand, "mhn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mhn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "mhn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _mhn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "mhn_output"));

                return _mhn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetMedicalHistoryNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medical_History_New_PreviousHistory");

                db.AddInParameter(dbCommand, "mhn_appId", DbType.Int32, appId);
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
