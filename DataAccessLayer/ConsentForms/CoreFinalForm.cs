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
    public class CoreFinalForm
    {
        public static DataTable GetCoreFinalFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Core_Final_Select");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveCoreFinalForm(BusinessEntities.ConsentForms.CoreFinalForm maple, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Core_Final_Insert");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, maple.ccf_appId);
                db.AddInParameter(dbCommand, "ccf_chk1", DbType.String, string.IsNullOrEmpty(maple.ccf_chk1) ? "" : maple.ccf_chk1);
                db.AddInParameter(dbCommand, "ccf_chk2", DbType.String, string.IsNullOrEmpty(maple.ccf_chk2) ? "" : maple.ccf_chk2);
                db.AddInParameter(dbCommand, "ccf_chk3", DbType.String, string.IsNullOrEmpty(maple.ccf_chk3) ? "" : maple.ccf_chk3);
                db.AddInParameter(dbCommand, "ccf_chk4", DbType.String, string.IsNullOrEmpty(maple.ccf_chk4) ? "" : maple.ccf_chk4);
                db.AddInParameter(dbCommand, "ccf_chk5", DbType.String, string.IsNullOrEmpty(maple.ccf_chk5) ? "" : maple.ccf_chk5);
                db.AddInParameter(dbCommand, "ccf_chk6", DbType.String, string.IsNullOrEmpty(maple.ccf_chk6) ? "" : maple.ccf_chk6);
                db.AddInParameter(dbCommand, "ccf_chk7", DbType.String, string.IsNullOrEmpty(maple.ccf_chk7) ? "" : maple.ccf_chk7);
                db.AddInParameter(dbCommand, "ccf_chk8", DbType.String, string.IsNullOrEmpty(maple.ccf_chk8) ? "" : maple.ccf_chk8);
                db.AddInParameter(dbCommand, "ccf_chk9", DbType.String, string.IsNullOrEmpty(maple.ccf_chk9) ? "" : maple.ccf_chk9);
                db.AddInParameter(dbCommand, "ccf_chk10", DbType.String, string.IsNullOrEmpty(maple.ccf_chk10) ? "" : maple.ccf_chk10);
                db.AddInParameter(dbCommand, "ccf_total", DbType.Double, maple.ccf_total);
                db.AddInParameter(dbCommand, "ccf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ccfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ccfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ccfId"));
                return _ccfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteCoreFinalForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Core_Final_Delete");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ccf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ccf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ccf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ccf_output"));

                return _ccf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetCoreFinalFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Core_Final_PreviousHistory");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, appId);
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
