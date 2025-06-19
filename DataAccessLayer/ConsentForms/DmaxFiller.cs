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
    public class DmaxFiller
    {
        public static DataTable GetDmaxFillerData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Filler_Select");

                db.AddInParameter(dbCommand, "cdf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxFiller(BusinessEntities.ConsentForms.DmaxFiller derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Filler_Insert");

                db.AddInParameter(dbCommand, "cdf_appId", DbType.Int32, derma.cdf_appId);
                db.AddInParameter(dbCommand, "cdf_1", DbType.String, string.IsNullOrEmpty(derma.cdf_1) ? "" : derma.cdf_1);
                db.AddInParameter(dbCommand, "cdf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cdfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cdfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdfId"));
                return _cdfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxFiller(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Filler_Delete");

                db.AddInParameter(dbCommand, "cdf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cdf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cdf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cdf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdf_output"));

                return _cdf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxFillerPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Filler_PreviousHistory");

                db.AddInParameter(dbCommand, "cdf_appId", DbType.Int32, appId);
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
