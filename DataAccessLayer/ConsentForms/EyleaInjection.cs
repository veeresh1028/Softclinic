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
    public class EyleaInjection
    {
        public static DataTable GetEyleaInjectionData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intravitreal_Eylea_Injection_New_Select");

                db.AddInParameter(dbCommand, "iei_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveEyleaInjection(BusinessEntities.ConsentForms.EyleaInjection ophtha, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intravitreal_Eylea_Injection_New_Insert");

                db.AddInParameter(dbCommand, "iei_appId", DbType.Int32, ophtha.iei_appId);
                db.AddInParameter(dbCommand, "iei_1", DbType.String, string.IsNullOrEmpty(ophtha.iei_1) ? "" : ophtha.iei_1);
                db.AddInParameter(dbCommand, "iei_2", DbType.String, string.IsNullOrEmpty(ophtha.iei_2) ? "" : ophtha.iei_2);
                db.AddInParameter(dbCommand, "iei_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ieiId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ieiId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ieiId"));
                return _ieiId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteEyleaInjection(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intravitreal_Eylea_Injection_New_Delete");

                db.AddInParameter(dbCommand, "iei_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "iei_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "iei_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _iei_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "iei_output"));

                return _iei_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetEyleaInjectionPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Intravitreal_Eylea_Injection_New_PreviousHistory");

                db.AddInParameter(dbCommand, "iei_appId", DbType.Int32, appId);
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
