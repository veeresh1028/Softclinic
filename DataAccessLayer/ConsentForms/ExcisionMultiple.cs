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
    public class ExcisionMultiple
    {
        public static DataTable GetExcisionMultipleData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Excision_Multiple_New_Select");

                db.AddInParameter(dbCommand, "emn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveExcisionMultiple(BusinessEntities.ConsentForms.ExcisionMultiple ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Excision_Multiple_New_Insert");

                db.AddInParameter(dbCommand, "emn_appId", DbType.Int32, ophtha.emn_appId);
                db.AddInParameter(dbCommand, "emn_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "emnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _emnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "emnId"));
                return _emnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteExcisionMultiple(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Excision_Multiple_New_Delete");

                db.AddInParameter(dbCommand, "emn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "emn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "emn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _emn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "emn_output"));

                return _emn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetExcisionMultiplePreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Excision_Multiple_New_PreviousHistory");

                db.AddInParameter(dbCommand, "emn_appId", DbType.Int32, appId);
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
