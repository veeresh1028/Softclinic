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
    public class DischargeCrossLinkingNew
    {
        public static DataTable GetDischargeCrossLinkingNewData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Cross_Linking_New_Select");

                db.AddInParameter(dbCommand, "dcl_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveDischargeCrossLinkingNew(BusinessEntities.ConsentForms.DischargeCrossLinkingNew discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Cross_Linking_New_Insert");

                db.AddInParameter(dbCommand, "dcl_appId", DbType.Int32, discharge.dcl_appId);
                db.AddInParameter(dbCommand, "dcl_1", DbType.String, string.IsNullOrEmpty(discharge.dcl_1) ? "" : discharge.dcl_1);
                db.AddInParameter(dbCommand, "dcl_2", DbType.String, string.IsNullOrEmpty(discharge.dcl_2) ? "" : discharge.dcl_2);
                db.AddInParameter(dbCommand, "dcl_3", DbType.String, string.IsNullOrEmpty(discharge.dcl_3) ? "" : discharge.dcl_3);
                db.AddInParameter(dbCommand, "dcl_4", DbType.String, string.IsNullOrEmpty(discharge.dcl_4) ? "" : discharge.dcl_4);
                db.AddInParameter(dbCommand, "dcl_5", DbType.String, string.IsNullOrEmpty(discharge.dcl_5) ? "" : discharge.dcl_5);
                db.AddInParameter(dbCommand, "dcl_6", DbType.String, string.IsNullOrEmpty(discharge.dcl_6) ? "" : discharge.dcl_6);
                db.AddInParameter(dbCommand, "dcl_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dclId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dclId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dclId"));
                return _dclId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteDischargeCrossLinkingNew(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Cross_Linking_New_Delete");

                db.AddInParameter(dbCommand, "dcl_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dcl_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dcl_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dcl_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dcl_output"));

                return _dcl_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetDischargeCrossLinkingNewPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Cross_Linking_New_PreviousHistory");

                db.AddInParameter(dbCommand, "dcl_appId", DbType.Int32, appId);
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
