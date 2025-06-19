using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConcentForms
{
    public class RootCanal
    {
        public static DataTable GetRootCanalData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Root_Canal_Treatment_Eng_Select");

                db.AddInParameter(dbCommand, "crct_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveRootCanal(BusinessEntities.ConcentForms.RootCanal root, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Root_Canal_Treatment_Eng_Insert");

                db.AddInParameter(dbCommand, "crct_appId", DbType.Int32, root.crct_appId);
                db.AddInParameter(dbCommand, "crct_1", DbType.String, root.crct_1);
                db.AddInParameter(dbCommand, "crct_2", DbType.String, root.crct_2);
                db.AddInParameter(dbCommand, "crct_3", DbType.String, root.crct_3);
                db.AddInParameter(dbCommand, "crct_4", DbType.String, root.crct_4);
                db.AddInParameter(dbCommand, "crct_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "crctId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _crctId = Convert.ToInt32(db.GetParameterValue(dbCommand, "crctId"));
                return _crctId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteRootCanal(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Root_Canal_Treatment_Eng_Delete");

                db.AddInParameter(dbCommand, "crct_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "crct_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "crct_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _crct_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "crct_output"));

                return _crct_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetRootCanalPreviousHistroy(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Root_Canal_Treatment_Eng_PreviousHistroy");

                db.AddInParameter(dbCommand, "crct_appId", DbType.Int32, appId);
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
