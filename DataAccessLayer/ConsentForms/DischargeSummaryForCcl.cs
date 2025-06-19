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
    public class DischargeSummaryForCcl
    {
        public static DataTable GetDischargeSummaryForCclData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_For_Ccl_Fcat_New_Select");

                db.AddInParameter(dbCommand, "dsfcf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveDischargeSummaryForCcl(BusinessEntities.ConsentForms.DischargeSummaryForCcl discharge, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_For_Ccl_Fcat_New_Insert");

                db.AddInParameter(dbCommand, "dsfcf_appId", DbType.Int32, discharge.dsfcf_appId);
                db.AddInParameter(dbCommand, "dsfcf_1", DbType.String, string.IsNullOrEmpty(discharge.dsfcf_1) ? "" : discharge.dsfcf_1);
                db.AddInParameter(dbCommand, "dsfcf_2", DbType.String, string.IsNullOrEmpty(discharge.dsfcf_2) ? "" : discharge.dsfcf_2);
                db.AddInParameter(dbCommand, "dsfcf_3", DbType.String, string.IsNullOrEmpty(discharge.dsfcf_3) ? "" : discharge.dsfcf_3);
                db.AddInParameter(dbCommand, "dsfcf_4", DbType.String, string.IsNullOrEmpty(discharge.dsfcf_4) ? "" : discharge.dsfcf_4);
                db.AddInParameter(dbCommand, "dsfcf_5", DbType.String, string.IsNullOrEmpty(discharge.dsfcf_5) ? "" : discharge.dsfcf_5);
                db.AddInParameter(dbCommand, "dsfcf_6", DbType.String, string.IsNullOrEmpty(discharge.dsfcf_6) ? "" : discharge.dsfcf_6);
                db.AddInParameter(dbCommand, "dsfcf_7", DbType.String, string.IsNullOrEmpty(discharge.dsfcf_7) ? "" : discharge.dsfcf_7);
                db.AddInParameter(dbCommand, "dsfcf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "dsfcfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _dsfcfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "dsfcfId"));
                return _dsfcfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int DeleteDischargeSummaryForCcl(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_For_Ccl_Fcat_New_Delete");

                db.AddInParameter(dbCommand, "dsfcf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "dsfcf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "dsfcf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _dsfcf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "dsfcf_output"));

                return _dsfcf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable GetDischargeSummaryForCclPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Discharge_Summary_For_Ccl_Fcat_New_PreviousHistory");

                db.AddInParameter(dbCommand, "dsfcf_appId", DbType.Int32, appId);
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
