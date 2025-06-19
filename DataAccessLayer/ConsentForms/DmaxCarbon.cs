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
    public class DmaxCarbon
    {
        public static DataTable GetDmaxCarbonData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Carbon_Select");

                db.AddInParameter(dbCommand, "cdc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxCarbon(BusinessEntities.ConsentForms.DmaxCarbon derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Carbon_Insert");

                db.AddInParameter(dbCommand, "cdc_appId", DbType.Int32, derma.cdc_appId);
                db.AddInParameter(dbCommand, "cdc_1", DbType.String, string.IsNullOrEmpty(derma.cdc_1) ? "" : derma.cdc_1);
                db.AddInParameter(dbCommand, "cdc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cdcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cdcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdcId"));
                return _cdcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxCarbon(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Carbon_Delete");

                db.AddInParameter(dbCommand, "cdc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cdc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cdc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cdc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdc_output"));

                return _cdc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxCarbonPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Carbon_PreviousHistory");

                db.AddInParameter(dbCommand, "cdc_appId", DbType.Int32, appId);
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
