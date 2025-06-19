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
    public class DmaxGenius
    {
        public static DataTable GetDmaxGeniusData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Genius_Select");

                db.AddInParameter(dbCommand, "cdg_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxGenius(BusinessEntities.ConsentForms.DmaxGenius derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Genius_Insert");

                db.AddInParameter(dbCommand, "cdg_appId", DbType.Int32, derma.cdg_appId);
                db.AddInParameter(dbCommand, "cdg_1", DbType.String, string.IsNullOrEmpty(derma.cdg_1) ? "" : derma.cdg_1);
                db.AddInParameter(dbCommand, "cdg_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cdgId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cdgId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdgId"));
                return _cdgId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxGenius(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Genius_Delete");

                db.AddInParameter(dbCommand, "cdg_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cdg_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cdg_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cdg_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdg_output"));

                return _cdg_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxGeniusPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Genius_PreviousHistory");

                db.AddInParameter(dbCommand, "cdg_appId", DbType.Int32, appId);
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
