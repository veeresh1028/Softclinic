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
    public class OzurdexInjection
    {
        public static DataTable GetOzurdexInjectionData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ozurdex_Injection_Procedure_New_Select");

                db.AddInParameter(dbCommand, "oip_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveOzurdexInjection(BusinessEntities.ConsentForms.OzurdexInjection ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ozurdex_Injection_Procedure_New_Insert");

                db.AddInParameter(dbCommand, "oip_appId", DbType.Int32, ophtha.oip_appId);
                db.AddInParameter(dbCommand, "oip_1", DbType.String, string.IsNullOrEmpty(ophtha.oip_1) ? "" : ophtha.oip_1);
                db.AddInParameter(dbCommand, "oip_2", DbType.String, string.IsNullOrEmpty(ophtha.oip_2) ? "" : ophtha.oip_2);
                db.AddInParameter(dbCommand, "oip_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "oipId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _oipId = Convert.ToInt32(db.GetParameterValue(dbCommand, "oipId"));
                return _oipId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteOzurdexInjection(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ozurdex_Injection_Procedure_New_Delete");

                db.AddInParameter(dbCommand, "oip_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "oip_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "oip_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _oip_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "oip_output"));

                return _oip_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetOzurdexInjectionPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Ozurdex_Injection_Procedure_New_PreviousHistory");

                db.AddInParameter(dbCommand, "oip_appId", DbType.Int32, appId);
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
