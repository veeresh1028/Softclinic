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
    public class PunctalPlugs
    {
        public static DataTable GetPunctalPlugsData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Punctal_Plugs_New_Select");

                db.AddInParameter(dbCommand, "ppn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SavePunctalPlugs(BusinessEntities.ConsentForms.PunctalPlugs ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Punctal_Plugs_New_Insert");

                db.AddInParameter(dbCommand, "ppn_appId", DbType.Int32, ophtha.ppn_appId);
                db.AddInParameter(dbCommand, "ppn_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ppnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ppnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ppnId"));
                return _ppnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeletePunctalPlugs(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Punctal_Plugs_New_Delete");

                db.AddInParameter(dbCommand, "ppn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ppn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ppn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ppn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ppn_output"));

                return _ppn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPunctalPlugsPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Punctal_Plugs_New_PreviousHistory");

                db.AddInParameter(dbCommand, "ppn_appId", DbType.Int32, appId);
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
